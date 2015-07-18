using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BizTier;
using OfficeOpenXml;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationTier.Views
{
    public class ExcelExport
    {

        #region properties
        Proj projectInfo;

        public class Proj
        {
            public int projID;
            public string projName;
            public string projGoal;
            public DateTime startDate;
            public DateTime endDate;

            public Project_Settings projSettings = new Project_Settings();
            public List<Income> incomeList = new List<Income>();
            public List<obj> objList = new List<obj>();
            public class obj
            {
                public int ID;
                public string objName;
                public List<act> ActivitysList = new List<act>();

                public class act
                {
                    public int ID;
                    public string actName;
                    public DateTime startDate;
                    public DateTime endDate;
                    public List<exp> ExpenseList = new List<exp>();

                    public class exp
                    {
                        public int ID;
                        public List<UPStaffMember> upstaffList = new List<UPStaffMember>();
                        public List<Equipment> equipList = new List<Equipment>();
                        public List<Contractor> contrList = new List<Contractor>();
                        public List<Operational> OperatList = new List<Operational>();
                        public List<Car> carList = new List<Car>();
                        public List<Travel> travList = new List<Travel>();
                    }
                }
            }
        }
        

        #endregion

        public ExcelPackage PrintProject(int ProjectID)
        {
            //get project info here
            //var fileName = ProjectName + " " + DateTime.Today.ToString()+".xlsx";
            //var file = new FileInfo(fileName);
            //begin writing document
            using (ExcelPackage pck = new ExcelPackage())
            {
                //get data
                getProjectData(ProjectID);

                //start with excel
                int col = 1;
                int row = 2;
                int AmountColumns = 1;

                //Create the worksheet
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(projectInfo.projName);

                //write Project details
                ws.Cells[row++, col].Value = projectInfo.projName;
                ws.Cells[row++, col].Value = projectInfo.projGoal;

                //write column headings
                ws.Cells[row, col++].Value = "Objectives".ToUpper();
                ws.Cells[row, col++].Value = "Activities".ToUpper();
                ws.Cells[row, col++].Value = "Start Date".ToUpper();
                ws.Cells[row, col++].Value = "End Date".ToUpper();
                ws.Cells[row, col++].Value = "Description of expenses".ToUpper();
                ws.Cells[row, col++].Value = "Note";

                var start = projectInfo.startDate;
                var end = projectInfo.endDate;
                while (start < end)
                {
                    ws.Cells[row, col++].Value = start.ToString("MMMM yyyy");
                    start = start.AddMonths(1);
                }

                //Write the months / years

                //write total columna
                ws.Cells[row, col].Value = "Total".ToUpper();
                FormatHeadings(ws, 1, col, row);

                //reset for next row
                col = 1;
                row++;

                //start writing in data for main part

                //Write each objective
                foreach(Proj.obj objective in projectInfo.objList)
                {
                    ws.Cells[row, col++].Value = objective.objName;
                    //Write each activity
                    foreach(Proj.obj.act activity in objective.ActivitysList)
                    {
                        ws.Cells[row, col++].Value = activity.actName;
                        ws.Cells[row, col++].Value = activity.startDate;
                        ws.Cells[row, col++].Value = activity.endDate;

                        foreach (Proj.obj.act.exp expenses  in activity.ExpenseList)
                        {
                            AmountColumns = col;
                            //UP staff
                            if(expenses.upstaffList.Count != 0)
                            {
                                ws.Cells[row, col++].Value = "UP Personnel Costs";
                                double total = 0;
                                foreach(UPStaffMember temp in expenses.upstaffList)
                                {
                                    total += temp.Expens.Amount;
                                }

                                //Add Note value
                                col++;

                                //Write amounts
                                while (start < end)
                                {
                                    if(start.Year < start.AddMonths(1).Year)
                                    {
                                        total = total * (1 + (projectInfo.projSettings.EscalationRate/100));
                                    }
                                    ws.Cells[row, col++].Value = total;
                                    start = start.AddMonths(1);
                                }
                            }

                            //Cars
                            col = AmountColumns;
                            if (expenses.carList.Count != 0)
                            {
                                ws.Cells[row, col++].Value = "Car/Vehicle Expenses";
                                double total = 0;
                                foreach (Car temp in expenses.carList)
                                {
                                    total += temp.Expen.Amount;
                                }

                                //Add Note value
                                col++;

                                //Write amounts
                                while (start < end)
                                {
                                    if (start.Year < start.AddMonths(1).Year)
                                    {
                                        total = total * (1 + (projectInfo.projSettings.EscalationRate / 100));
                                    }
                                    ws.Cells[row, col++].Value = total;
                                    start = start.AddMonths(1);
                                }
                            }
                        }
                    }
                }

                #region Notes
                //Write main heading
                ws.Cells[row++, col].Value = "Budget Notes";

                #endregion

                //Write it back to the client

                //HttpResponse Response;

                return pck;
                //this.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //Response.AddHeader("content-disposition", "attachment;  filename=" + ProjectName + " " + DateTime.Now.ToString() + "");
                //Response.BinaryWrite(pck.GetAsByteArray());
            }
        }


        #region DataCollection
        public void getProjectData(int ProjectID)
        {
            projectInfo = new Proj();
            projectInfo.projID = ProjectID;

            using (var dbContext = new dboEntities())
            { 
                //get project details
                var queryProject = from project
                            in dbContext.Projects
                            where project.Id == ProjectID
                            select project;

                projectInfo.projName = queryProject.First().Title.ToString();
                projectInfo.projGoal = queryProject.First().Goal.ToString();
                projectInfo.startDate = (DateTime)queryProject.First().StartDate;
                projectInfo.endDate = (DateTime)queryProject.First().EndDate;
                projectInfo.projSettings = queryProject.First().Project_Settings;

                //get Project Incomes
                var queryIncomes = from income
                            in dbContext.Incomes
                                   where income.ProjectId == ProjectID
                                   select income;

                projectInfo.incomeList = queryIncomes.ToList<Income>();

                //get Objective
                var queryObjective = from objective
                            in dbContext.Objectives
                                     where objective.ProjectId == ProjectID
                                     select objective;

                //get activities
                foreach (Objective obj in queryObjective)
                {
                    Proj.obj tempObjective = new Proj.obj();
                    tempObjective.ID = obj.Id;
                    tempObjective.objName = obj.ObjectiveName;

                    //get Activity Data
                    var queryActivity = from activity
                            in dbContext.Activities
                                        where activity.ObjectiveId == tempObjective.ID
                                        select activity;

                    foreach(Activity act in queryActivity)
                    {
                        Proj.obj.act tempActivity = new Proj.obj.act();
                        tempActivity.actName = act.ActivityName;
                        tempActivity.startDate = act.StartDate;
                        tempActivity.endDate = act.EndDate;
                        tempActivity.ID = act.Id;

                        //get Expense Data
                        var queryExpense = from expense
                                in dbContext.Expenses
                                           where expense.ActivityId == tempActivity.ID
                                           select expense;

                        foreach (Expens exp in queryExpense)
                        {
                            Proj.obj.act.exp tempExpense = new Proj.obj.act.exp();
                            tempExpense.ID = exp.Id;

                            //Add Each type of expense
                            //get UPStaff Data
                            var queryUPStaff = from upstaff
                                    in dbContext.UPStaffMembers
                                               where upstaff.Expense_Id == tempExpense.ID
                                               select upstaff;

                            foreach (UPStaffMember upStaffMember in queryUPStaff)
                            {
                                tempExpense.upstaffList.Add(upStaffMember);
                            }

                            //get equipment Data
                            var queryEquip = from equipment
                                    in dbContext.Equipments
                                             where equipment.Expense_Id == tempExpense.ID
                                             select equipment;

                            foreach (Equipment equip in queryEquip)
                            {
                                tempExpense.equipList.Add(equip);
                            }


                            //get Contractor Data
                            var queryContractor = from contractor
                                    in dbContext.Contractors
                                        where contractor.Expense_Id == tempExpense.ID
                                        select contractor;

                            foreach (Contractor contractor in queryContractor)
                            {
                                tempExpense.contrList.Add(contractor);
                            }

                            //get Operational Data
                            var queryOperational = from operational
                                    in dbContext.Operationals
                                                   where operational.Expense_Id == tempExpense.ID
                                                   select operational;

                            foreach (Operational operation in queryOperational)
                            {
                                tempExpense.OperatList.Add(operation);
                            }

                            //get Car Data
                            var queryCar = from car
                                    in dbContext.Cars
                                           where car.ExpensId == tempExpense.ID
                                           select car;

                            foreach (Car operation in queryCar)
                            {
                                tempExpense.carList.Add(operation);
                            }

                            //get Travel Data
                            var queryTravel = from travel
                                    in dbContext.Travels
                                              where travel.Expense_Id == tempExpense.ID
                                              select travel;

                            foreach (Travel operation in queryTravel)
                            {
                                tempExpense.travList.Add(operation);
                            }

                            //add Expense to list
                            tempActivity.ExpenseList.Add(tempExpense);
                        } 

                        //add Activity to list
                        tempObjective.ActivitysList.Add(tempActivity);
                    }                    

                    //add Objective to list
                    projectInfo.objList.Add(tempObjective);
                }
            }

            //Get Project incomes


            //using (var dbContext = new dboEntities())
            //{ 
            //    //get project details
            //    var queryProject = from project
            //                in dbContext.Projects
            //                where project.Id == ProjectID
            //                select project;

            //    ProjectName = queryProject.First().Title.ToString();
            //    ProjectGoal = queryProject.First().Goal.ToString();

            //    //get all objectives in project
            //    var queryObjectives = from objectives
            //                in dbContext.Objectives
            //                where objectives.ProjectId == ProjectID
            //                select objectives;

            //    objectivesList = queryObjectives.ToList<Objective>();

            //    //get all project incomes
            //    var queryIncomes = from income
            //                in dbContext.Incomes
            //                       where income.ProjectId == ProjectID
            //                       select income;

            //    foreach (Income a in queryIncomes)
            //    {
            //        IncomeList.Add(a);
            //    }

            //    //get all activities in objective
            //    foreach (Objective p in queryObjectives)
            //    {
            //        var queryActivities = from acts
            //                in dbContext.Activities
            //                where acts.ObjectiveId == p.Id
            //                select acts;

            //        foreach(Activity a in queryActivities)
            //        {
            //            ActivityList.Add(a);
            //        }

            //        //get all Expenses in objective
            //        foreach (Activity a in queryActivities)
            //        {
            //            var queryExpense = from expense
            //                    in dbContext.Expenses
            //                    where expense.ActivityId == a.Id
            //                    select expense;

            //            foreach (Expens e in queryExpense)
            //            {
            //                ExpenseList.Add(e);
            //            }

            //            //get all travel from expenses
            //            foreach (Expens exp in queryExpense)
            //            {
            //                var queryTravel = from trav
            //                        in dbContext.Travels
            //                        where trav.Expense_Id == exp.Id
            //                        select trav;

            //                foreach (Travel t in queryTravel)
            //                {
            //                    TravelList.Add(t);
            //                }
            //            }

            //            //get all travel from expenses
            //            foreach (Expens exp in queryExpense)
            //            {
            //                var queryContractor = from trav
            //                        in dbContext.Contractors
            //                        where trav.Expense_Id == exp.Id
            //                        select trav;

            //                foreach (Contractor t in queryContractor)
            //                {
            //                    ContractorList.Add(t);
            //                }
            //            }

            //            //get all travel from expenses
            //            foreach (Expens exp in queryExpense)
            //            {
            //                var queryTravel = from trav
            //                        in dbContext.Travels
            //                                  where trav.Expense_Id == exp.Id
            //                                  select trav;

            //                foreach (Travel t in queryTravel)
            //                {
            //                    TravelList.Add(t);
            //                }
            //            }
            //        }
            //    }

                
            
            //}
            
        }
            
        
        #endregion

        #region Document Creation
        public void FormatColumnHeadings(ExcelWorksheet worksheet, int startCol, int endCol, int row)
        {
            using (var range = worksheet.Cells[row, startCol, row, endCol])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gray);
                //range.Style.Font.VerticalAlign = VerticalAlign.Middle;
                range.Style.ShrinkToFit = false;
            }
        }

        public void FormatHeadings(ExcelWorksheet worksheet, int startCol, int endCol, int row)
        {
            using (var range = worksheet.Cells[row, startCol, row, endCol])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                range.Style.Font.Size = 20;
                range.Style.ShrinkToFit = false;
            }
        }
        #endregion
        
    }
}