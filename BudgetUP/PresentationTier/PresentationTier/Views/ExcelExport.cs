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
            public List<Bursary> bursaryList = new List<Bursary>();
            public List<UPStaffMember> staffIncome = new List<UPStaffMember>();

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
                        public List<travExp> travBools = new List<travExp>();

                    public class travExp
                    {
                        public bool allowance = false;
                        public bool accomodation = false;
                        public bool airline = false;
                        public bool gautrain = false;
                        public bool visa = false;
                    }
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
                int firstAmountRow = 1;
                int lastAmountRow = 1;
                int descriptionColumn = 1;

                //Create the worksheet
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(projectInfo.projName);
                

                //write Project details
                ws.Cells[row, col].Value = projectInfo.projName;
                FormatColumnHeadings(ws, col, 20, row++);
                row++;
                ws.Cells[row, col].Value = projectInfo.projGoal;
                FormatColumnHeadings(ws, col, 20, row++);
                row++;

                firstAmountRow = row+1;
                #region Column Headings
                //write column headings
                ws.Cells[row, col++].Value = "Objectives".ToUpper();
                ws.Cells[row, col++].Value = "Activities".ToUpper();
                ws.Cells[row, col++].Value = "Start Date".ToUpper();
                ws.Cells[row, col++].Value = "End Date".ToUpper();
                ws.Cells[row, col].Value = "Description of expenses".ToUpper();
                descriptionColumn = col++;
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

                //write total columns
                ws.Cells[row, col].Value = "Total".ToUpper();
                FormatHeadings(ws, 1, col, row);
                LastAmountColumn = col  -1;
                #endregion

                //reset for next row
                col = 1;
                row++;
                int MonthInc = 12;
                objectiveColumn = col;
                firstAmountRow = row;
                int objCount = 0;
                //start writing in data for main part
                #region Write objective (Expense portion)
                //Write each objective
                foreach(Proj.obj objective in projectInfo.objList)
                {
                    if (objCount != 0)
                    {
                        FormatSpacers(ws, 1, LastAmountColumn + 1, row++);
                    }
                    objCount++;
                    //firstAmountRow = row;
                    col = objectiveColumn;
                    ws.Cells[row, col++].Value = objective.objName;
                    int activityColumn = col;

                    #region Write each activity
                    //Write each activity
                    foreach (Proj.obj.act activity in objective.ActivitysList)
                    {
                        expenseNote = 1;
                        col = activityColumn;
                        ws.Cells[row, col++].Value = activity.actName.ToString();
                        ws.Cells[row, col++].Value = activity.startDate.Date.ToString("dd MMMM yyyy");
                        ws.Cells[row, col++].Value = activity.endDate.Date.ToString("dd MMMM yyyy");

                        ExpenseColumns = col;
                        double total = 0;
                        int monthCount = 1;
                        DateTime tempStartDate = projectInfo.startDate;

                        #region Write each expense

                        #region UP staff
                        //====================UP staff====================    
                        if (activity.upstaffList.Count() != 0)
                        {
                            ws.Cells[row, col++].Value = "UP Personnel Costs";

                            //Write note value
                            ws.Cells[row, col++].Value = "1." + objective.noteID + "." + activity.noteID;
                            int colSub = 1;
                            tempStartDate = projectInfo.startDate;
                            monthCount = 1;

                            while (tempStartDate < projectInfo.endDate)
                            {
                                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                ws.Cells[row, col].Value = 0;

                                foreach (UPStaffMember upstaff in activity.upstaffList)
                                {
                                    if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                    {
                                        if (monthCount > MonthInc)
                                        {
                                            total += upstaff.Expens.Amount;
                                            int years = monthCount / 12;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row);
                                            colSub++;
                                        }
                                        else
                                        {
                                            total += upstaff.Expens.Amount;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row);
                                        }
                                    }
                                }
                                monthCount++;
                                tempStartDate = tempStartDate.AddMonths(1);
                                col++;
                                total = 0;
                            }
                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col].Formula = SumRange(FirstAmountColumn, row, LastAmountColumn, row);
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
                            ws.Cells[row, col++].Value = "2." + objective.noteID + "." + activity.noteID;
                            int colSub = 1;
                            tempStartDate = projectInfo.startDate;
                            monthCount = 1;

                            while (tempStartDate < projectInfo.endDate)
                            {
                                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                ws.Cells[row, col].Value = 0;

                                foreach (Contractor listRowValue in activity.contrList)
                                {
                                    if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                    {
                                        if (monthCount > MonthInc)
                                        {
                                            total += listRowValue.Expens.Amount;
                                            int years = monthCount / 12;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row);
                                            colSub++;
                                        }
                                        else
                                        {
                                            total += listRowValue.Expens.Amount;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row);
                                        }
                                    }
                                }
                                monthCount++;
                                tempStartDate = tempStartDate.AddMonths(1);
                                col++;
                                total = 0;
                            }
                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col].Formula = SumRange(FirstAmountColumn, row, LastAmountColumn, row);
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
                            ws.Cells[row, col++].Value = "3." + objective.noteID + "." + activity.noteID;
                            int colSub = 1;
                            tempStartDate = projectInfo.startDate;
                            monthCount = 1;

                            while (tempStartDate < projectInfo.endDate)
                            {
                                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                ws.Cells[row, col].Value = 0;

                                foreach (Operational listRowValue in activity.OperatList)
                                {
                                    if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                    {
                                        if (monthCount > MonthInc)
                                        {
                                            total += listRowValue.Expens.Amount;
                                            int years = monthCount / 12;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row);
                                            colSub++;
                                        }
                                        else
                                        {
                                            total += listRowValue.Expens.Amount;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row);
                                        }
                                    }
                                }
                                monthCount++;
                                tempStartDate = tempStartDate.AddMonths(1);
                                col++;
                                total = 0;
                            }
                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col].Formula = SumRange(FirstAmountColumn, row, LastAmountColumn, row);
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
                            ws.Cells[row, col++].Value = "4." + objective.noteID + "." + activity.noteID;
                            int colSub = 1;
                            tempStartDate = projectInfo.startDate;
                            monthCount = 1;

                            while (tempStartDate < projectInfo.endDate)
                            {
                                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                ws.Cells[row, col].Value = 0;

                                foreach (Car listRowValue in activity.carList)
                                {
                                    if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                    {
                                        if (monthCount > MonthInc)
                                        {
                                            total += listRowValue.Expen.Amount;
                                            int years = monthCount / 12;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row);
                                            colSub++;
                                        }
                                        else
                                        {
                                            total += listRowValue.Expen.Amount;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row);
                                        }
                                    }
                                }
                                monthCount++;
                                tempStartDate = tempStartDate.AddMonths(1);
                                col++;
                                total = 0;
                            }
                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col].Formula = SumRange(FirstAmountColumn, row, LastAmountColumn, row);
                            col = ExpenseColumns;
                            row++;
                        }
                        #endregion

                        #region Travel
                        //====================Other Travels====================    
                        if (activity.travList.Count() != 0)
                        {
                            bool bAccom = false;
                            bool bAllow = false;
                            bool bVisa = false;
                            bool bGautrain = false;
                            bool bAirline = false;

                            for (int i = 0; i < activity.travList.Count(); i++)
                            {
                                if (activity.travBools.ElementAt(i).accomodation)
                                {
                                    bAccom = true;
                                }
                                if (activity.travBools.ElementAt(i).allowance)
                                {
                                    bAllow = true;
                                }
                                if (activity.travBools.ElementAt(i).airline)
                                {
                                    bAirline = true;
                                }
                                if (activity.travBools.ElementAt(i).visa)
                                {
                                    bVisa = true;
                                }
                                if (activity.travBools.ElementAt(i).gautrain)
                                {
                                    bGautrain = true;
                                }
                            }

                            #region Write Acomodation
                            if (bAccom)
                            {
                                ws.Cells[row, col++].Value = "Accomodation";

                                //Write note value
                                ws.Cells[row, col++].Value = "5." + objective.noteID + "." + activity.noteID;
                                int colSub = 1;
                                tempStartDate = projectInfo.startDate;
                                monthCount = 1;
                                while (tempStartDate < projectInfo.endDate)
                                {
                                    ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                    ws.Cells[row, col].Value = 0;

                                    if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                    {
                                        if (monthCount > MonthInc)
                                        {
                                            total += 0;
                                            int years = monthCount / 12;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row);
                                            colSub++;
                                        }
                                        else
                                        {
                                            total += 0;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row);
                                        }

                                    }
                                    monthCount++;
                                    tempStartDate = tempStartDate.AddMonths(1);
                                    col++;
                                    total = 0;
                                }
                                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                ws.Cells[row, col].Formula = SumRange(FirstAmountColumn, row, LastAmountColumn, row);
                                col = ExpenseColumns;
                                row++;
                            }
                            #endregion

                            #region Write Allowance
                            if (bAllow)
                            {
                                ws.Cells[row, col++].Value = "Per Diem";

                                //Write note value
                                ws.Cells[row, col++].Value = "5." + objective.noteID + "." + activity.noteID;
                                int colSub = 1;
                                tempStartDate = projectInfo.startDate;
                                monthCount = 1;
                                while (tempStartDate < projectInfo.endDate)
                                {
                                    ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                    ws.Cells[row, col].Value = 0;

                                    if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                    {
                                        if (monthCount > MonthInc)
                                        {
                                            total += 0;
                                            int years = monthCount / 12;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row);
                                            colSub++;
                                        }
                                        else
                                        {
                                            total += 0;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row);
                                        }

                                    }
                                    monthCount++;
                                    tempStartDate = tempStartDate.AddMonths(1);
                                    col++;
                                    total = 0;
                                }
                                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                ws.Cells[row, col].Formula = SumRange(FirstAmountColumn, row, LastAmountColumn, row);
                                col = ExpenseColumns;
                                row++;
                            }
                            #endregion

                            #region Write Airline
                            if (bAirline)
                            {
                                ws.Cells[row, col++].Value = "Airline";

                                //Write note value
                                ws.Cells[row, col++].Value = "5." + objective.noteID + "." + activity.noteID;
                                int colSub = 1;
                                tempStartDate = projectInfo.startDate;
                                monthCount = 1;
                                while (tempStartDate < projectInfo.endDate)
                                {
                                    ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                    ws.Cells[row, col].Value = 0;

                                    if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                    {
                                        if (monthCount > MonthInc)
                                        {
                                            total += 0;
                                            int years = monthCount / 12;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row);
                                            colSub++;
                                        }
                                        else
                                        {
                                            total += 0;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row);
                                        }

                                    }
                                    monthCount++;
                                    tempStartDate = tempStartDate.AddMonths(1);
                                    col++;
                                    total = 0;
                                }
                                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                ws.Cells[row, col].Formula = SumRange(FirstAmountColumn, row, LastAmountColumn, row);
                                col = ExpenseColumns;
                                row++;
                            }
                            #endregion

                            #region Write Gautrain
                            if (bGautrain)
                            {
                                ws.Cells[row, col++].Value = "Gautrain";

                                //Write note value
                                ws.Cells[row, col++].Value = "5." + objective.noteID + "." + activity.noteID;
                                int colSub = 1;
                                tempStartDate = projectInfo.startDate;
                                monthCount = 1;
                                while (tempStartDate < projectInfo.endDate)
                                {
                                    ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                    ws.Cells[row, col].Value = 0;

                                    if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                    {
                                        if (monthCount > MonthInc)
                                        {
                                            total += 0;
                                            int years = monthCount / 12;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row);
                                            colSub++;
                                        }
                                        else
                                        {
                                            total += 0;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row);
                                        }

                                    }
                                    monthCount++;
                                    tempStartDate = tempStartDate.AddMonths(1);
                                    col++;
                                    total = 0;
                                }
                                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                ws.Cells[row, col].Formula = SumRange(FirstAmountColumn, row, LastAmountColumn, row);
                                col = ExpenseColumns;
                                row++;
                            }
                            #endregion

                            #region Write Visa
                            if (bVisa)
                            {
                                ws.Cells[row, col++].Value = "Visa";

                                //Write note value
                                ws.Cells[row, col++].Value = "5." + objective.noteID + "." + activity.noteID;
                                int colSub = 1;
                                tempStartDate = projectInfo.startDate;
                                monthCount = 1;
                                while (tempStartDate < projectInfo.endDate)
                                {
                                    ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                    ws.Cells[row, col].Value = 0;

                                    if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                    {
                                        if (monthCount > MonthInc)
                                        {
                                            total += 0;
                                            int years = monthCount / 12;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row);
                                            colSub++;
                                        }
                                        else
                                        {
                                            total += 0;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row);
                                        }

                                    }
                                    monthCount++;
                                    tempStartDate = tempStartDate.AddMonths(1);
                                    col++;
                                    total = 0;
                                }
                                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                ws.Cells[row, col].Formula = SumRange(FirstAmountColumn, row, LastAmountColumn, row);
                                col = ExpenseColumns;
                                row++;
                            }
                            #endregion
                        }
                        #endregion

                        #region Equipment
                        //====================Equipment====================    
                        if (activity.equipList.Count() != 0)
                        {
                            ws.Cells[row, col++].Value = "Equipment";

                            //Write note value
                            ws.Cells[row, col++].Value = "6." + objective.noteID + "." + activity.noteID;
                            int colSub = 1;
                            tempStartDate = projectInfo.startDate;
                            monthCount = 1;

                            while (tempStartDate < projectInfo.endDate)
                            {
                                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                ws.Cells[row, col].Value = 0;

                                foreach (Equipment listRowValue in activity.equipList)
                                {
                                    if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                    {
                                        if (monthCount > MonthInc)
                                        {
                                            total += listRowValue.Expens.Amount;
                                            int years = monthCount / 12;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row);
                                            colSub++;
                                        }
                                        else
                                        {
                                            total += listRowValue.Expens.Amount;
                                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                            ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row);
                                        }
                                    }
                                }
                                monthCount++;
                                tempStartDate = tempStartDate.AddMonths(1);
                                col++;
                                total = 0;
                            }
                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col].Formula = SumRange(FirstAmountColumn, row, LastAmountColumn, row);
                            col = ExpenseColumns;
                            row++;
                        }
                        #endregion
                        #endregion
                    }
                    #endregion
                    //row++;
                    
                }
                lastAmountRow = row;
                
                FormatAmountCells(ws,FirstAmountColumn,firstAmountRow,LastAmountColumn,lastAmountRow);
                
                //Total Columns
                ws.Cells[row, 1].Value = "Total Expenses";
                FormatColumnTotal(ws, 1, row + 1, row);
                for (int i = FirstAmountColumn; i <= LastAmountColumn + 1; i++)
                {
                    ws.Cells[row, i].Style.Numberformat.Format = "R #,##0.00";
                    ws.Cells[row, i].Formula = SumRange(i, firstAmountRow, i, lastAmountRow-1);
                }
                #endregion

                int ExpenseTotalRow = row;
                row += 2;

                #region Write Incomes

                ws.Cells[row, 1].Value = "Incomes and Donations";
                FormatAmountCells(ws, 1, row, LastAmountColumn, row);
                row++;
                col = descriptionColumn;

                if (projectInfo.incomeList.Count() != 0)
                {
                    double total = 0;
                    int colSub = 1;
                    DateTime tempStartDate = projectInfo.startDate;
                    int monthCount = 1;
                    int noteID = 1;
                    foreach(Income income in projectInfo.incomeList)
                    {

                        ws.Cells[row, col++].Value = income.DonorName;
                        //Write note value
                        ws.Cells[row, col++].Value = "7." + noteID++;

                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                        ws.Cells[row, col].Value = 0;                   

                        while (tempStartDate < projectInfo.endDate)
                        {
                            if (projectInfo.startDate <= tempStartDate && projectInfo.endDate >= tempStartDate)
                            {
                                if (monthCount > MonthInc)
                                {
                                    total += income.Amount;
                                    int years = monthCount / 12;
                                    ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                    ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row);
                                    colSub++;
                                }
                                else
                                {
                                    total += income.Amount;
                                    ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                    ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row);
                                }
                            }
                            monthCount++;
                            tempStartDate = tempStartDate.AddMonths(1);
                            col++;
                            total = 0;
                        }
                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                        ws.Cells[row, LastAmountColumn + 1].Formula = SumRange(FirstAmountColumn, row, LastAmountColumn, row);
                        col = ExpenseColumns;
                        tempStartDate = projectInfo.startDate;
                        row++;
                    }
                    //while (tempStartDate < projectInfo.endDate)
                    //{
                    //    ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                    //    ws.Cells[row, col].Value = 0;
                    //    col = descriptionColumn;
                    //    foreach (Income income in projectInfo.incomeList)
                    //    {
                            
                    //        ws.Cells[row, col++].Value = income.DonorName;
                    //        //Write note value
                    //        ws.Cells[row, col++].Value = "7." + noteID++;

                    //        if (projectInfo.startDate <= tempStartDate && projectInfo.endDate >= tempStartDate)
                    //        {
                    //            if (monthCount > MonthInc)
                    //            {
                    //                total += income.Amount;
                    //                int years = monthCount / 12;
                    //                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                    //                ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row);
                    //                colSub++;
                    //            }
                    //            else
                    //            {
                    //                total += income.Amount;
                    //                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                    //                ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row);
                    //            }
                    //        }
                    //        monthCount++;
                    //        tempStartDate = tempStartDate.AddMonths(1);
                    //        col++;
                    //        total = 0;
                    //    }                        
                    //}
                    //ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                    //ws.Cells[row, LastAmountColumn+1].Formula = SumRange(FirstAmountColumn, row, LastAmountColumn, row);
                    //col = ExpenseColumns;
                    //row++;
                }

                #endregion


                #region Notes
                //Write main notes heading
                col = 1; 
                //ws.Cells[row, col].Value = "Budget Notes";
                //FormatColumnHeadings(ws, 1, LastAmountColumn, row++);

                #endregion

                //FInal Worksheet formatting
                FormatDocumentCells(ws, 1, 1, 999, 999);

                //Create and return file
                pck.SaveAs(stream);
                stream.Position = 0;
                return stream;
            }
        }

        #region Math
        public string SumRange(int col1, int row1, int col2, int row2)
        {
            //double body = 1 + (interestRate / timesPerYear);
            //double exponent = timesPerYear * years;
            //amount = amount * Math.Pow(body, exponent);
            string sum = "=SUM(" + GetExcelColumnName(col1) + row1 + ":" + GetExcelColumnName(col2) + row2 +")";//"POWER("++",1+"+(interestRate / timesPerYear)+")"
            return sum;
        }

        public string compoundInterest(double amount, double interestRate, int timesPerYear, int years, int col, int row)
        {
            //double body = 1 + (interestRate / timesPerYear);
            //double exponent = timesPerYear * years;
            //amount = amount * Math.Pow(body, exponent);
            string sum = "=" + amount + "* POWER(1+" + (interestRate / timesPerYear) + "," + timesPerYear * years + ")";
            return sum;
        }

        public double compoundInterest(double amount, double interestRate, int timesPerYear, int years)
        {
            double body = 1 + (interestRate / timesPerYear);
            double exponent = timesPerYear * years;
            return amount * Math.Pow(body, exponent);
            //string sum = GetExcelColumnName(col) + row.ToString() + "* POWER(1+" + (interestRate / timesPerYear) + "," + timesPerYear * years + ")";//"POWER("++",1+"+(interestRate / timesPerYear)+")"
            //return sum;
        }

        public string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
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

                //get Project Bursaries
                var queryBursary = from bursary
                            in dbContext.Bursaries
                                   where bursary.ProjectId == ProjectID
                                   select bursary;

                projectInfo.bursaryList = queryBursary.ToList<Bursary>();               


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
                                if(upStaffMember.SubventionLevy == false)
                                {
                                    projectInfo.staffIncome.Add(upStaffMember);
                                }
                                else
                                {
                                    tempActivity.upstaffList.Add(upStaffMember);
                                }                                
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

                                Proj.obj.act.travExp subTravs = new Proj.obj.act.travExp();

                                var querySubTravs = from allowance
                                            in dbContext.Allowances
                                                    where allowance.Travel_Id == operation.Id
                                                    select allowance;
                                if(querySubTravs.Count() != 0)
                                {
                                    subTravs.allowance = true;
                                }

                                var querySubAccom = from accomodation
                                            in dbContext.Accommodations
                                                    where accomodation.Travel_Id == operation.Id
                                                    select accomodation;
                                if (querySubAccom.Count() != 0)
                                {
                                    subTravs.accomodation = true;
                                }

                                var querySubAirline = from airline
                                            in dbContext.AirlineExpenses
                                                      where airline.Travel_Id == operation.Id
                                                      select airline;
                                if (querySubAirline.Count() != 0)
                                {
                                    subTravs.airline = true;
                                }

                                var querySubVisa = from visa
                                            in dbContext.Visas
                                                   where visa.Travel_Id == operation.Id
                                                   select visa;
                                if (querySubVisa.Count() != 0)
                                {
                                    subTravs.visa = true;
                                }

                                var querySubGautrain = from gautrain
                                                       in dbContext.Gautrains
                                                       where gautrain.Travel_Id == operation.Id
                                                       select gautrain;
                                if (querySubGautrain.Count() != 0)
                                {
                                    subTravs.visa = true;
                                }

                                tempActivity.travBools.Add(subTravs);
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
        public void FormatAmountCells(ExcelWorksheet worksheet, int startCol, int endCol, int startRow, int endRow)
        {
            using (var range = worksheet.Cells[startRow, startCol, endRow, endCol])
            {
                //range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.White);
                range.Style.Numberformat.Format = "R #,##0.00";
            }
        }

        public void FormatDocumentCells(ExcelWorksheet worksheet, int startCol, int endCol, int startRow, int endRow)
        {
            using (var range = worksheet.Cells[startRow, startCol, endRow, endCol])
            {
                range.AutoFitColumns();
            }
        }

        public void FormatColumnTotal(ExcelWorksheet worksheet, int startCol, int endCol, int row)
        {
            using (var range = worksheet.Cells[ row, startCol, row, endCol])
            {
                range.Style.Font.Bold = true;
                //range.Style.Border.Top = BorderStyle.Solid;
                //Excel.Borders borders = range.Borders;
                //borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                //range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }
        }

        public void FormatColumnHeadings(ExcelWorksheet worksheet, int startCol, int endCol, int row)
        {
            using (var range = worksheet.Cells[row, startCol, row, endCol])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
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
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                range.Style.Font.Size = 10;
                range.Style.ShrinkToFit = false;
            }
        }

        public void FormatSpacers(ExcelWorksheet worksheet, int startCol, int endCol, int row)
        {
            using (var range = worksheet.Cells[row, startCol, row, endCol])
            {
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
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