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
    /*Notes
     * 1. CHeck yes/no for travels stuffs
     * 
     */
    public class ExcelExport
    {
        public string ProjectName;

        //Add Email Settings
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
                public int noteID;
                public string objName;
                public List<act> ActivitysList = new List<act>();

                public class act
                {
                    public int ID;
                    public int noteID;
                    public string actName;
                    public DateTime startDate;
                    public DateTime endDate;
                    public List<Expens> ExpenseList = new List<Expens>();

                    //public class exp
                    //{
                    //    public int ID;
                        public List<UPStaffMember> upstaffList = new List<UPStaffMember>();
                        public List<Equipment> equipList = new List<Equipment>();
                        public List<Contractor> contrList = new List<Contractor>();
                        public List<Operational> OperatList = new List<Operational>();
                        public List<Car> carList = new List<Car>();
                        public List<Travel> travList = new List<Travel>();
                    //}
                }
            }
        }
        

        #endregion

        public Stream PrintProject(int ProjectID)
        {
            //get data
            getProjectData(ProjectID);
            ProjectName = projectInfo.projName;

            //begin writing document
            MemoryStream stream = new MemoryStream();
            using (ExcelPackage pck = new ExcelPackage())
            {               
                //start with excel
                int col = 1;
                int row = 2;
                int expenseNote = 1;

                //column indexes
                int FirstAmountColumn = 1;
                int LastAmountColumn = 1;
                int ExpenseColumns = 1;
                int objectiveColumn = 1;

                //Create the worksheet
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(projectInfo.projName);
                

                //write Project details
                ws.Cells[row, col].Value = projectInfo.projName;
                FormatColumnHeadings(ws, col, 20, row++);
                row++;
                ws.Cells[row, col].Value = projectInfo.projGoal;
                FormatColumnHeadings(ws, col, 20, row++);
                row++;

                #region Column Headings
                //write column headings
                ws.Cells[row, col++].Value = "Objectives".ToUpper();
                ws.Cells[row, col++].Value = "Activities".ToUpper();
                ws.Cells[row, col++].Value = "Start Date".ToUpper();
                ws.Cells[row, col++].Value = "End Date".ToUpper();
                ws.Cells[row, col++].Value = "Description of expenses".ToUpper();
                ws.Cells[row, col++].Value = "Note";

                //Write the months / years
                FirstAmountColumn = col;
                var start = projectInfo.startDate;
                var end = projectInfo.endDate;
                while (start < end)
                {
                    ws.Cells[row, col++].Value = start.ToString("MMMM yyyy");
                    start = start.AddMonths(1);
                }
                LastAmountColumn = col - 1;

                //write total columns
                ws.Cells[row, col].Value = "Total".ToUpper();
                FormatHeadings(ws, 1, col, row);

                #endregion

                //reset for next row
                col = 1;
                row++;

                //start writing in data for main part

                //Write each objective
                objectiveColumn = col;
                foreach(Proj.obj objective in projectInfo.objList)
                {
                    col = objectiveColumn;
                    ws.Cells[row, col++].Value = objective.objName;                    
                    int activityColumn = col;

                    #region Write each activity
                    //Write each activity
                    foreach(Proj.obj.act activity in objective.ActivitysList)
                    {
                        expenseNote = 1;
                        col = activityColumn;
                        ws.Cells[row, col++].Value = activity.actName.ToString();
                        ws.Cells[row, col++].Value = activity.startDate.Date.ToString("dd MMMM yyyy");
                        ws.Cells[row, col++].Value = activity.endDate.Date.ToString("dd MMMM yyyy");

                        ExpenseColumns = col;
                        double total = 0;
                        int monthCount = 1;
                        double summedColumn = 0;
                        DateTime tempStartDate = projectInfo.startDate;

                        #region Write each expense

                        #region UP staff
                        //====================UP staff====================    
                        if (activity.upstaffList.Count() != 0)
                        {
                            ws.Cells[row, col++].Value = "UP Personnel Costs";

                            //Write note value
                            ws.Cells[row, col++].Value = objective.noteID + "." + activity.noteID + "." + expenseNote++;

                            tempStartDate = projectInfo.startDate;
                            monthCount = 1;
                            while (tempStartDate < projectInfo.endDate)
                            {
                                double escalationRate = (1 + projectInfo.projSettings.EscalationRate / 100);

                                foreach (UPStaffMember upstaff in activity.upstaffList)
                                {
                                    if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                    {
                                        if (monthCount > 12)
                                        {
                                            total += upstaff.Expens.Amount;
                                            int years = monthCount / 12;
                                            total = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years);
                                        }
                                        else
                                        {
                                            total += upstaff.Expens.Amount;
                                        }
                                    }

                                    ws.Cells[row, col].Value = total.ToString("#,#0.00");//(Convert.ToDouble(ws.Cells[row, col].Value) + total).ToString("#,#0.00");                                
                                    monthCount++;

                                }
                                tempStartDate = tempStartDate.AddMonths(1);
                                col++;
                                summedColumn += total;
                                total = 0;
                            }
                            ws.Cells[row, col].Value = summedColumn.ToString("#,#0.00");
                            col = ExpenseColumns;
                            row++;
                        }
                        #endregion

                        #region Contractors
                        //=================Contractors===================
                        if (activity.contrList.Count() != 0)
                        {
                            ws.Cells[row, col++].Value = "External consultant costs ";

                            //Write note value
                            ws.Cells[row, col++].Value = objective.noteID + "." + activity.noteID + "." + expenseNote++;
                            summedColumn = 0;
                            tempStartDate = projectInfo.startDate;
                            monthCount = 1;
                            while (tempStartDate < projectInfo.endDate)
                            {
                                double escalationRate = (1 + projectInfo.projSettings.EscalationRate / 100);

                                foreach (Contractor contractors in activity.contrList)
                                {
                                    if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                    {
                                        if (monthCount > 12)
                                        {
                                            total += contractors.Expens.Amount;
                                            int years = monthCount / 12;
                                            total = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years);
                                        }
                                        else
                                        {
                                            total += contractors.Expens.Amount;
                                        }
                                    }
                                    ws.Cells[row, col].Value = total.ToString("#,#0.00");//(Convert.ToDouble(ws.Cells[row, col].Value) + total).ToString("#,#0.00");                                
                                    monthCount++;

                                }
                                tempStartDate = tempStartDate.AddMonths(1);
                                col++;
                                summedColumn += total;
                                total = 0;
                            }
                            ws.Cells[row, col].Value = summedColumn.ToString("#,#0.00");
                            col = ExpenseColumns;
                            row++;
                        }
                        #endregion

                        #region Operational Costs
                        //=================Operational===================
                        if (activity.OperatList.Count() != 0)
                        {
                            ws.Cells[row, col++].Value = "Operational expenses";

                            //Write note value
                            ws.Cells[row, col++].Value = objective.noteID + "." + activity.noteID + "." + expenseNote++;
                            summedColumn = 0;
                            tempStartDate = projectInfo.startDate;
                            monthCount = 1;
                            while (tempStartDate < projectInfo.endDate)
                            {
                                double escalationRate = (1 + projectInfo.projSettings.EscalationRate / 100);

                                foreach (Operational operations in activity.OperatList)
                                {
                                    if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                    {
                                        if (monthCount > 12)
                                        {
                                            total += operations.Expens.Amount;
                                            int years = monthCount / 12;
                                            total = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years);
                                        }
                                        else
                                        {
                                            total += operations.Expens.Amount;
                                        }
                                    }
                                    ws.Cells[row, col].Value = total.ToString("#,#0.00");//(Convert.ToDouble(ws.Cells[row, col].Value) + total).ToString("#,#0.00");                                
                                    monthCount++;

                                }
                                tempStartDate = tempStartDate.AddMonths(1);
                                col++;
                                summedColumn += total;
                                total = 0;
                            }
                            ws.Cells[row, col].Value = summedColumn.ToString("#,#0.00");
                            col = ExpenseColumns;
                            row++;
                        }
                        #endregion

                        #region Cars
                        //====================Car Travels====================    
                        if (activity.carList.Count() != 0)
                        {
                            ws.Cells[row, col++].Value = "Car Expenses";

                            //Write note value
                            ws.Cells[row, col++].Value = objective.noteID + "." + activity.noteID + "." + expenseNote++;

                            tempStartDate = projectInfo.startDate;
                            monthCount = 1;
                            while (tempStartDate < projectInfo.endDate)
                            {
                                double escalationRate = (1 + projectInfo.projSettings.EscalationRate / 100);

                                foreach (Car car in activity.carList)
                                {
                                    if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                    {
                                        if (monthCount > 12)
                                        {
                                            total += car.Expen.Amount;
                                            int years = monthCount / 12;
                                            total = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years);
                                        }
                                        else
                                        {
                                            total += car.Expen.Amount;
                                        }
                                    }

                                    ws.Cells[row, col].Value = total.ToString("#,#0.00");//(Convert.ToDouble(ws.Cells[row, col].Value) + total).ToString("#,#0.00");                                
                                    monthCount++;

                                }
                                tempStartDate = tempStartDate.AddMonths(1);
                                col++;
                                summedColumn += total;
                                total = 0;
                            }
                            ws.Cells[row, col].Value = summedColumn.ToString("#,#0.00");
                            col = ExpenseColumns;
                            row++;
                        }
                        #endregion

                        #region Travel
                        //====================Other Travels====================    
                        if (activity.travList.Count() != 0)
                        {
                            ws.Cells[row, col++].Value = "Travel Expenses";

                            //Write note value
                            ws.Cells[row, col++].Value = objective.noteID + "." + activity.noteID + "." + expenseNote++;

                            tempStartDate = projectInfo.startDate;
                            monthCount = 1;
                            while (tempStartDate < projectInfo.endDate)
                            {
                                double escalationRate = (1 + projectInfo.projSettings.EscalationRate / 100);

                                foreach (Travel travel in activity.travList)
                                {
                                    if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                    {
                                        if (monthCount > 12)
                                        {
                                            total += travel.Expens.Amount;
                                            int years = monthCount / 12;
                                            total = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years);
                                        }
                                        else
                                        {
                                            total += travel.Expens.Amount;
                                        }
                                    }

                                    ws.Cells[row, col].Value = total.ToString("#,#0.00");//(Convert.ToDouble(ws.Cells[row, col].Value) + total).ToString("#,#0.00");                                
                                    monthCount++;

                                }
                                tempStartDate = tempStartDate.AddMonths(1);
                                col++;
                                summedColumn += total;
                                total = 0;
                            }
                            ws.Cells[row, col].Value = summedColumn.ToString("#,#0.00");
                            col = ExpenseColumns;
                            row++;
                        }
                        #endregion

                        #region Equipment
                        //====================Equipment====================    
                        if (activity.equipList.Count() != 0)
                        {
                            ws.Cells[row, col++].Value = "Equipment";

                            //Write note value
                            ws.Cells[row, col++].Value = objective.noteID + "." + activity.noteID + "." + expenseNote++;

                            tempStartDate = projectInfo.startDate;
                            monthCount = 1;
                            while (tempStartDate < projectInfo.endDate)
                            {
                                double escalationRate = (1 + projectInfo.projSettings.EscalationRate / 100);

                                foreach (Equipment equipment in activity.equipList)
                                {
                                    if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                    {
                                        if (monthCount > 12)
                                        {
                                            total += equipment.Expens.Amount;
                                            int years = monthCount / 12;
                                            total = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years);
                                        }
                                        else
                                        {
                                            total += equipment.Expens.Amount;
                                        }
                                    }

                                    ws.Cells[row, col].Value = total.ToString("#,#0.00");//(Convert.ToDouble(ws.Cells[row, col].Value) + total).ToString("#,#0.00");                                
                                    monthCount++;

                                }
                                tempStartDate = tempStartDate.AddMonths(1);
                                col++;
                                summedColumn += total;
                                total = 0;
                            }
                            ws.Cells[row, col].Value = summedColumn.ToString("#,#0.00");
                            col = ExpenseColumns;
                            row++;
                        }
                        #endregion

                        #endregion

                        //row++;
                        FormatSpacers(ws, 1, LastAmountColumn + 1, row++);
                    }
                    #endregion
                }

                #region Notes
                //Write main notes heading
                col = 1; 
                ws.Cells[row, col].Value = "Budget Notes";
                FormatColumnHeadings(ws, 1, LastAmountColumn, row++);

                #endregion

                //Create and return file
                pck.SaveAs(stream);
                stream.Position = 0;
                return stream;
            }
        }

        #region Math
        public double compoundInterest(double amount, double interestRate, int timesPerYear,int years)
        {
            double body = 1 + (interestRate / timesPerYear);
            double exponent = timesPerYear * years;
            return amount * Math.Pow(body, exponent);
        }
        #endregion

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

                int noteIDobj = 1;
                //get activities
                foreach (Objective obj in queryObjective)
                {
                    Proj.obj tempObjective = new Proj.obj();
                    tempObjective.noteID = noteIDobj++;
                    tempObjective.ID = obj.Id;
                    tempObjective.objName = obj.ObjectiveName;

                    //get Activity Data
                    var queryActivity = from activity
                            in dbContext.Activities
                                        where activity.ObjectiveId == tempObjective.ID
                                        select activity;
                    int noteIDact = 1;
                    foreach(Activity act in queryActivity)
                    {
                        Proj.obj.act tempActivity = new Proj.obj.act();
                        tempActivity.noteID = noteIDact++;          
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
                            //Proj.obj.act tempExpense = new Proj.obj.act();
                            //tempExpense.ID = exp.Id;
                            int tempExpense = exp.Id;

                            //Add Each type of expense
                            //get UPStaff Data
                            var queryUPStaff = from upstaff
                                    in dbContext.UPStaffMembers
                                               where upstaff.Expense_Id == tempExpense
                                               select upstaff;

                            foreach (UPStaffMember upStaffMember in queryUPStaff)
                            {
                                tempActivity.upstaffList.Add(upStaffMember);
                            }

                            //get equipment Data
                            var queryEquip = from equipment
                                    in dbContext.Equipments
                                             where equipment.Expense_Id == tempExpense
                                             select equipment;

                            foreach (Equipment equip in queryEquip)
                            {
                                tempActivity.equipList.Add(equip);
                            }


                            //get Contractor Data
                            var queryContractor = from contractor
                                    in dbContext.Contractors
                                        where contractor.Expense_Id == tempExpense
                                        select contractor;

                            foreach (Contractor contractor in queryContractor)
                            {
                                tempActivity.contrList.Add(contractor);
                            }

                            //get Operational Data
                            var queryOperational = from operational
                                    in dbContext.Operationals
                                                   where operational.Expense_Id == tempExpense
                                                   select operational;

                            foreach (Operational operation in queryOperational)
                            {
                                tempActivity.OperatList.Add(operation);
                            }

                            //get Car Data
                            var queryCar = from car
                                    in dbContext.Cars
                                           where car.ExpensId == tempExpense
                                           select car;

                            foreach (Car operation in queryCar)
                            {
                                tempActivity.carList.Add(operation);
                            }

                            //get Travel Data
                            var queryTravel = from travel
                                    in dbContext.Travels
                                              where travel.Expense_Id == tempExpense
                                              select travel;

                            foreach (Travel operation in queryTravel)
                            {
                                tempActivity.travList.Add(operation);
                            }

                            //add Expense to list
                            tempActivity.ExpenseList.Add(exp);
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
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.LightGray;
                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gray);
                //range.Style.Font.VerticalAlign = VerticalAlign.Middle;
                range.Style.Font.Size = 20;
                range.Style.ShrinkToFit = false;
            }
        }

        public void FormatHeadings(ExcelWorksheet worksheet, int startCol, int endCol, int row)
        {
            using (var range = worksheet.Cells[row, startCol, row, endCol])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.LightGray;
                range.Style.Font.Size = 10;
                range.Style.ShrinkToFit = false;
            }
        }

        public void FormatSpacers(ExcelWorksheet worksheet, int startCol, int endCol, int row)
        {
            using (var range = worksheet.Cells[row, startCol, row, endCol])
            {
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.LightGray;
            }
        }
        #endregion
        
    }
}

//ExcelExport temp = new ExcelExport();
//var ProjectFile = temp.PrintProject(1);

//var memoryStream = new MemoryStream();
//ProjectFile.CopyTo(memoryStream);

//Response.Clear();
//Response.ContentType = "application/force-download";
//Response.AddHeader("content-disposition", "attachment; filename=" + /*temp.ProjectName +*/" " + DateTime.Now.ToString(@"yyyy-MM-dd") + ".xlsx");
//Response.BinaryWrite(memoryStream.ToArray());
//Response.End();