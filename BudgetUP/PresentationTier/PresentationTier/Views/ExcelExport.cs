using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BizTier;
//using OfficeOpenXml;

using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationTier.Views
{
    public class ExcelExport
    {

        //#region properties
        //string ProjectName;
        //string ProjectGoal;
        //List<Objective> objectivesList = new List<Objective>();
        //List<Activity> ActivityList = new List<Activity>();
        //List<Income> IncomeList = new List<Income>();
        //List<Expens> ExpenseList = new List<Expens>();
        //List<Travel> TravelList = new List<Travel>();
        //List<Contractor> ContractorList = new List<Contractor>();
        //List<UPStaffMember> UPStaffList = new List<UPStaffMember>();
        //List<Operational> OperationalList = new List<Operational>();
        //List<Equipment> EquipmentList = new List<Equipment>();
        ////List<Operational> ExpenseList = new List<Expens>();
        ////List<Operational> ExpenseList = new List<Expens>();
        

        //#endregion

        //public void PrintProject(int ProjectID)
        //{
        //    //get project info here

        //    //begin writing document
        //    //using (ExcelPackage pck = new ExcelPackage())
        //    {
        //        int col = 1;
        //        int row = 2;
        //        int columnWidth = 1;

        //        //Create the worksheet
        //        //ExcelWorksheet ws = pck.Workbook.Worksheets.Add(ProjectName);

        //        //write Project details
        //        ws.Cells[row++, col].Value = ProjectName;
        //        ws.Cells[row++, col].Value = ProjectGoal;

        //        //write column headings
        //        ws.Cells[row, col++].Value = "Objectives".ToUpper();
        //        ws.Cells[row, col++].Value = "Activities".ToUpper();
        //        ws.Cells[row, col++].Value = "Start Date".ToUpper();
        //        ws.Cells[row, col++].Value = "End Date".ToUpper();
        //        ws.Cells[row, col++].Value = "Description of expenses".ToUpper();
        //        ws.Cells[row, col++].Value = "Note";
                
        //        //Write the months / years

        //        //write total columna
        //        ws.Cells[row, col].Value = "Total".ToUpper();
        //        FormatHeadings(ws, 1, col, row);

        //        //reset for next row
        //        col = 1;
        //        row++;

        //        //start writing in data for main part

        //        #region Notes
        //        //Write main heading
        //        ws.Cells[row++, col].Value = "Budget Notes";

        //        #endregion

        //        //Write it back to the client
        //        //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //        //Response.AddHeader("content-disposition", "attachment;  filename="+ ProjectName + " " + DateTime.Now.ToString()+"");
        //        //Response.BinaryWrite(pck.GetAsByteArray());
        //    }
        //}


        //#region DataCollection
        //public void getProjectData(int ProjectID)
        //{
        //    using (var dbContext = new dboEntities())
        //    { 
        //        //get project details
        //        var queryProject = from project
        //                    in dbContext.Projects
        //                    where project.Id == ProjectID
        //                    select project;

        //        ProjectName = queryProject.First().Title.ToString();
        //        ProjectGoal = queryProject.First().Goal.ToString();

        //        //get all objectives in project
        //        var queryObjectives = from objectives
        //                    in dbContext.Objectives
        //                    where objectives.ProjectId == ProjectID
        //                    select objectives;

        //        objectivesList = queryObjectives.ToList<Objective>();

        //        //get all project incomes
        //        var queryIncomes = from income
        //                    in dbContext.Incomes
        //                           where income.ProjectId == ProjectID
        //                           select income;

        //        foreach (Income a in queryIncomes)
        //        {
        //            IncomeList.Add(a);
        //        }

        //        //get all activities in objective
        //        foreach (Objective p in queryObjectives)
        //        {
        //            var queryActivities = from acts
        //                    in dbContext.Activities
        //                    where acts.ObjectiveId == p.Id
        //                    select acts;

        //            foreach(Activity a in queryActivities)
        //            {
        //                ActivityList.Add(a);
        //            }

        //            //get all Expenses in objective
        //            foreach (Activity a in queryActivities)
        //            {
        //                var queryExpense = from expense
        //                        in dbContext.Expenses
        //                        where expense.ActivityId == a.Id
        //                        select expense;

        //                foreach (Expens e in queryExpense)
        //                {
        //                    ExpenseList.Add(e);
        //                }

        //                //get all travel from expenses
        //                foreach (Expens exp in queryExpense)
        //                {
        //                    var queryTravel = from trav
        //                            in dbContext.Travels
        //                            where trav.Expense_Id == exp.Id
        //                            select trav;

        //                    foreach (Travel t in queryTravel)
        //                    {
        //                        TravelList.Add(t);
        //                    }
        //                }

        //                //get all travel from expenses
        //                foreach (Expens exp in queryExpense)
        //                {
        //                    var queryContractor = from trav
        //                            in dbContext.Contractors
        //                            where trav.Expense_Id == exp.Id
        //                            select trav;

        //                    foreach (Contractor t in queryContractor)
        //                    {
        //                        ContractorList.Add(t);
        //                    }
        //                }

        //                //get all travel from expenses
        //                foreach (Expens exp in queryExpense)
        //                {
        //                    var queryTravel = from trav
        //                            in dbContext.Travels
        //                                      where trav.Expense_Id == exp.Id
        //                                      select trav;

        //                    foreach (Travel t in queryTravel)
        //                    {
        //                        TravelList.Add(t);
        //                    }
        //                }
        //            }
        //        }

                
            
        //    }
            
        //}
            
        
        //#endregion

        //#region Document Creation
        //public void FormatColumnHeadings(ExcelWorksheet worksheet, int startCol, int endCol, int row)
        //{
        //    using (var range = worksheet.Cells[row, startCol, row, endCol])
        //    {
        //        range.Style.Font.Bold = true;
        //        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        //        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gray);
        //        //range.Style.Font.VerticalAlign = VerticalAlign.Middle;
        //        range.Style.ShrinkToFit = false;
        //    }
        //}

        //public void FormatHeadings(ExcelWorksheet worksheet, int startCol, int endCol, int row)
        //{
        //    using (var range = worksheet.Cells[row, startCol, row, endCol])
        //    {
        //        range.Style.Font.Bold = true;
        //        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        //        range.Style.Font.Size = 20;
        //        range.Style.ShrinkToFit = false;
        //    }
        //}
        //#endregion
        
    }
}