using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BizTier;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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

            #region column indexes
            #region Travel
            public int Travel_rowStart;
            public int Travel_rowEnd;
            public int Travel_ID_col;
            public int Travel_StartDate_col;
            public int Travel_EndDate_col;
            public int Travel_Amount_col;
            #endregion
            #region Incomes
            public int incomes_rowStart;
            public int incomes_rowEnd;
            public int incomes_ID_col;
            public int incomes_StartDate_col;
            public int incomes_EndDate_col;
            public int incomes_Amount_col;
            #endregion
            #region bursary
            public int bursary_rowStart;
            public int bursary_rowEnd;
            public int bursary_ID_col;
            public int bursary_StartDate_col;
            public int bursary_EndDate_col;
            public int bursary_Amount_col;
            #endregion
            #region UP Staff Income
            public int upStaffInc_rowStart;
            public int upStaffInc_rowEnd;
            public int upStaffInc_ID_col;
            public int upStaffInc_StartDate_col;
            public int upStaffInc_EndDate_col;
            public int upStaffInc_Amount_col;
            #endregion
            #region UP Staff Expense
            public int upStaff_rowStart;
            public int upStaff_rowEnd;
            public int upStaff_ID_col;
            public int upStaff_StartDate_col;
            public int upStaff_EndDate_col;
            public int upStaff_Amount_col;
            #endregion
            #region equipment
            public int equipment_rowStart;
            public int equipment_rowEnd;
            public int equipment_ID_col;
            public int equipment_StartDate_col;
            public int equipment_EndDate_col;
            public int equipment_Amount_col;
            #endregion
            #region Contractors
            public int Contractors_rowStart;
            public int Contractors_rowEnd;
            public int Contractors_ID_col;
            public int Contractors_StartDate_col;
            public int Contractors_EndDate_col;
            public int Contractors_Amount_col;
            #endregion
            #region Operational
            public int Operational_rowStart;
            public int Operational_rowEnd;
            public int Operational_ID_col;
            public int Operational_StartDate_col;
            public int Operational_EndDate_col;
            public int Operational_Amount_col;
            #endregion
            #region Car
            public int Car_rowStart;
            public int Car_rowEnd;
            public int Car_ID_col;
            public int Car_StartDate_col;
            public int Car_EndDate_col;
            public int Car_Amount_col;
            #endregion
            #endregion

            public Project_Settings projSettings = new Project_Settings();
            public List<Income> incomeList = new List<Income>();
            public List<BursaryType> bursaryList = new List<BursaryType>();
            public List<Bursary> bursary2List = new List<Bursary>();
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
                //call notes
                createNotes(pck);
                //call monthly
                createMonthlySheet(pck);
                //call quarterly
                createQuarterlySheet(pck);
                //call yearly
                createYearlySheet(pck);

                pck.SaveAs(stream);
                stream.Position = 0;
                return stream;
            }
        }

        ExcelPackage createMonthlySheet(ExcelPackage pck)
        {
            //start with excel
            int col = 1;
            int row = 1;

            //column indexes
            int FirstAmountColumn = 1;
            int LastAmountColumn = 1;
            int ExpenseColumns = 1;
            int objectiveColumn = 1;
            int firstAmountRow = 1;
            int lastAmountRow = 1;
            int descriptionColumn = 1;
            int expenseNote = 0;

            //Create the worksheet
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Budget - Monthly");
                

            //write Project details
            ws.Cells[row, col].Value = projectInfo.projName;
            row++;
            row++;
            ws.Cells[row, col].Value = projectInfo.projGoal;
            row++;
            row++;

            firstAmountRow = row+1;

            #region Write Amount Table
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


            FormatHeadings(ws, 1, col, 1);
            FormatHeadings(ws, 1, col, 3);
            FormatColumnHeadings(ws, 1, col, row);


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
                    int AmountOfMonths = ((activity.endDate.Year - activity.startDate.Year) * 12) + activity.endDate.Month - activity.startDate.Month;
                    if(AmountOfMonths == 0)
                    {
                        AmountOfMonths = 1;
                    }
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
                                        total += upstaff.Expens.Amount/AmountOfMonths;
                                        int years = monthCount / 12;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row, projectInfo.upStaff_rowStart, projectInfo.upStaff_rowEnd, projectInfo.upStaff_Amount_col,projectInfo.upStaff_StartDate_col, projectInfo.upStaff_EndDate_col, projectInfo.upStaff_ID_col, "1." + objective.noteID + "." + activity.noteID, tempStartDate,tempStartDate);
                                        colSub++;
                                    }
                                    else
                                    {
                                        total += upstaff.Expens.Amount/AmountOfMonths;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row, projectInfo.upStaff_rowStart, projectInfo.upStaff_rowEnd, projectInfo.upStaff_Amount_col, projectInfo.upStaff_StartDate_col, projectInfo.upStaff_EndDate_col, projectInfo.upStaff_ID_col, "1." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
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
                                        total += listRowValue.Expens.Amount / AmountOfMonths;
                                        int years = monthCount / 12;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row, projectInfo.Contractors_rowStart, projectInfo.Contractors_rowEnd, projectInfo.Contractors_Amount_col, projectInfo.Contractors_StartDate_col, projectInfo.Contractors_EndDate_col, projectInfo.Contractors_ID_col, "2." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
                                        colSub++;
                                    }
                                    else
                                    {
                                        total += listRowValue.Expens.Amount / AmountOfMonths;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row, projectInfo.Contractors_rowStart, projectInfo.Contractors_rowEnd, projectInfo.Contractors_Amount_col, projectInfo.Contractors_StartDate_col, projectInfo.Contractors_EndDate_col, projectInfo.Contractors_ID_col, "2." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
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
                                        total += listRowValue.Expens.Amount / AmountOfMonths;
                                        int years = monthCount / 12;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row, projectInfo.Operational_rowStart, projectInfo.Operational_rowEnd, projectInfo.Operational_Amount_col, projectInfo.Operational_StartDate_col, projectInfo.Operational_EndDate_col, projectInfo.Operational_ID_col, "3." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
                                        colSub++;
                                    }
                                    else
                                    {
                                        total += listRowValue.Expens.Amount / AmountOfMonths;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row, projectInfo.Operational_rowStart, projectInfo.Operational_rowEnd, projectInfo.Operational_Amount_col, projectInfo.Operational_StartDate_col, projectInfo.Operational_EndDate_col, projectInfo.Operational_ID_col, "3." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
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
                                        total += listRowValue.Expen.Amount / AmountOfMonths;
                                        int years = monthCount / 12;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row, projectInfo.Car_rowStart, projectInfo.Car_rowEnd, projectInfo.Car_Amount_col, projectInfo.Car_StartDate_col, projectInfo.Car_EndDate_col, projectInfo.Car_ID_col, "4." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
                                        colSub++;
                                    }
                                    else
                                    {
                                        total += listRowValue.Expen.Amount / AmountOfMonths;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row, projectInfo.Car_rowStart, projectInfo.Car_rowEnd, projectInfo.Car_Amount_col, projectInfo.Car_StartDate_col, projectInfo.Car_EndDate_col, projectInfo.Car_ID_col, "4." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
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
                                ws.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);

                                if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                {
                                    if (monthCount > MonthInc)
                                    {
                                        total += 0;
                                        int years = monthCount / 12;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row, projectInfo.Travel_rowStart, projectInfo.Travel_rowEnd, projectInfo.Travel_Amount_col, projectInfo.Travel_StartDate_col, projectInfo.Travel_EndDate_col, projectInfo.Travel_ID_col, "5." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
                                        colSub++;
                                    }
                                    else
                                    {
                                        total += 0;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row, projectInfo.Travel_rowStart, projectInfo.Travel_rowEnd, projectInfo.Travel_Amount_col, projectInfo.Travel_StartDate_col, projectInfo.Travel_EndDate_col, projectInfo.Travel_ID_col, "5." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
                                    }

                                }
                                monthCount++;
                                tempStartDate = tempStartDate.AddMonths(1);
                                col++;
                                total = 0;
                            }
                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col].Formula = SumRange(FirstAmountColumn, row, LastAmountColumn, row);
                            ws.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);
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
                                ws.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);

                                if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                {
                                    if (monthCount > MonthInc)
                                    {
                                        total += 0;
                                        int years = monthCount / 12;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row, projectInfo.Travel_rowStart, projectInfo.Travel_rowEnd, projectInfo.Travel_Amount_col, projectInfo.Travel_StartDate_col, projectInfo.Travel_EndDate_col, projectInfo.Travel_ID_col, "5." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
                                        colSub++;
                                    }
                                    else
                                    {
                                        total += 0;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row, projectInfo.Travel_rowStart, projectInfo.Travel_rowEnd, projectInfo.Travel_Amount_col, projectInfo.Travel_StartDate_col, projectInfo.Travel_EndDate_col, projectInfo.Travel_ID_col, "5." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
                                    }

                                }
                                monthCount++;
                                tempStartDate = tempStartDate.AddMonths(1);
                                col++;
                                total = 0;
                            }
                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col].Formula = SumRange(FirstAmountColumn, row, LastAmountColumn, row);
                            ws.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);
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
                                ws.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);

                                if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                {
                                    if (monthCount > MonthInc)
                                    {
                                        total += 0;
                                        int years = monthCount / 12;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row, projectInfo.Travel_rowStart, projectInfo.Travel_rowEnd, projectInfo.Travel_Amount_col, projectInfo.Travel_StartDate_col, projectInfo.Travel_EndDate_col, projectInfo.Travel_ID_col, "5." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
                                        colSub++;
                                    }
                                    else
                                    {
                                        total += 0;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row, projectInfo.Travel_rowStart, projectInfo.Travel_rowEnd, projectInfo.Travel_Amount_col, projectInfo.Travel_StartDate_col, projectInfo.Travel_EndDate_col, projectInfo.Travel_ID_col, "5." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
                                    }

                                }
                                monthCount++;
                                tempStartDate = tempStartDate.AddMonths(1);
                                col++;
                                total = 0;
                            }
                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col].Formula = SumRange(FirstAmountColumn, row, LastAmountColumn, row);
                            ws.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);
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
                                ws.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);

                                if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                {
                                    if (monthCount > MonthInc)
                                    {
                                        total += 0;
                                        int years = monthCount / 12;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row, projectInfo.Travel_rowStart, projectInfo.Travel_rowEnd, projectInfo.Travel_Amount_col, projectInfo.Travel_StartDate_col, projectInfo.Travel_EndDate_col, projectInfo.Travel_ID_col, "5." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
                                        colSub++;
                                    }
                                    else
                                    {
                                        total += 0;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row, projectInfo.Travel_rowStart, projectInfo.Travel_rowEnd, projectInfo.Travel_Amount_col, projectInfo.Travel_StartDate_col, projectInfo.Travel_EndDate_col, projectInfo.Travel_ID_col, "5." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
                                    }

                                }
                                monthCount++;
                                tempStartDate = tempStartDate.AddMonths(1);
                                col++;
                                total = 0;
                            }
                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col].Formula = SumRange(FirstAmountColumn, row, LastAmountColumn, row);
                            ws.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);
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
                                ws.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);

                                if (activity.startDate <= tempStartDate && activity.endDate >= tempStartDate)
                                {
                                    if (monthCount > MonthInc)
                                    {
                                        total += 0;
                                        int years = monthCount / 12;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row, projectInfo.Travel_rowStart, projectInfo.Travel_rowEnd, projectInfo.Travel_Amount_col, projectInfo.Travel_StartDate_col, projectInfo.Travel_EndDate_col, projectInfo.Travel_ID_col, "5." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
                                        colSub++;
                                    }
                                    else
                                    {
                                        total += 0;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row, projectInfo.Travel_rowStart, projectInfo.Travel_rowEnd, projectInfo.Travel_Amount_col, projectInfo.Travel_StartDate_col, projectInfo.Travel_EndDate_col, projectInfo.Travel_ID_col, "5." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
                                    }

                                }
                                monthCount++;
                                tempStartDate = tempStartDate.AddMonths(1);
                                col++;
                                total = 0;
                            }
                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col].Formula = SumRange(FirstAmountColumn, row, LastAmountColumn, row);
                            ws.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);
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
                                        total += listRowValue.Expens.Amount / AmountOfMonths;
                                        int years = monthCount / 12;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, years, col - colSub, row, projectInfo.equipment_rowStart, projectInfo.equipment_rowEnd, projectInfo.equipment_Amount_col, projectInfo.equipment_StartDate_col, projectInfo.equipment_EndDate_col, projectInfo.equipment_ID_col, "6." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
                                        colSub++;
                                    }
                                    else
                                    {
                                        total += listRowValue.Expens.Amount / AmountOfMonths;
                                        ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                        ws.Cells[row, col].Formula = compoundInterest(total, projectInfo.projSettings.EscalationRate, 1, 0, col - colSub, row, projectInfo.equipment_rowStart, projectInfo.equipment_rowEnd, projectInfo.equipment_Amount_col, projectInfo.equipment_StartDate_col, projectInfo.equipment_EndDate_col, projectInfo.equipment_ID_col, "6." + objective.noteID + "." + activity.noteID, tempStartDate, tempStartDate);
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
                
            //FormatAmountCells(ws,FirstAmountColumn,firstAmountRow,LastAmountColumn,lastAmountRow);
                
            //Total Columns
            ws.Cells[row, 1].Value = "Total Expenses";
            FormatColumnTotal(ws, 1, LastAmountColumn + 1, row);
            for (int i = FirstAmountColumn; i <= LastAmountColumn + 1; i++)
            {
                ws.Cells[row, i].Style.Numberformat.Format = "R #,##0.00";
                ws.Cells[row, i].Formula = SumRange(i, firstAmountRow, i, lastAmountRow-1);
            }
            #endregion
            //FormatAmountCells(ws, 1, LastAmountColumn, row, row);
            int ExpenseTotalRow = row;
            row += 2;

            #region Write Incomes

            ws.Cells[row, 1].Value = "Minus other donations, in-kind support and pledges / Incomes and Donations (Pick one?)";
                
            row++;
            col = descriptionColumn;

            int incomeRowStart = row + 1;
            int incomeRowLast = 1;

            #region Donations
            if (projectInfo.incomeList.Count() != 0)
            {
                int AmountOfMonths = ((projectInfo.endDate.Year - projectInfo.startDate.Year) * 12) + projectInfo.endDate.Month - projectInfo.startDate.Month;
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
                                total += income.Amount / AmountOfMonths;
                                int years = monthCount / 12;
                                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                ws.Cells[row, col].Value = total;
                                colSub++;
                            }
                            else
                            {
                                total += income.Amount / AmountOfMonths;
                                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                ws.Cells[row, col].Value = total;
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
            }
            #endregion

            #region up staff income
            if (projectInfo.staffIncome.Count() != 0)
            {
                double total = 0;
                int colSub = 1;
                DateTime tempStartDate = projectInfo.startDate;
                int AmountOfMonths = ((projectInfo.endDate.Year - projectInfo.startDate.Year) * 12) + projectInfo.endDate.Month - projectInfo.startDate.Month;
                        
                int monthCount = 1;
                int noteID = 1;
                foreach (UPStaffMember income in projectInfo.staffIncome)
                {

                    ws.Cells[row, col++].Value = "UP Staff";
                    //Write note value
                    ws.Cells[row, col++].Value = "8." + noteID++;

                    ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                    ws.Cells[row, col].Value = 0;

                    while (tempStartDate < projectInfo.endDate)
                    {
                        if (projectInfo.startDate <= tempStartDate && projectInfo.endDate >= tempStartDate)
                        {
                            if (monthCount > MonthInc)
                            {
                                total += income.Expens.Amount / AmountOfMonths;
                                int years = monthCount / 12;
                                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                ws.Cells[row, col].Value = total; 
                                colSub++;
                            }
                            else
                            {
                                total += income.Expens.Amount / AmountOfMonths;
                                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                                ws.Cells[row, col].Value = total;
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
                #endregion
            }
            incomeRowLast = row - 1;
            //FormatAmountCells(ws, FirstAmountColumn, firstAmountRow, LastAmountColumn, lastAmountRow);

            //Total Columns
            ws.Cells[row, 1].Value = "Total Incomes";
            FormatColumnTotal(ws, 1, LastAmountColumn + 1, row);
            for (int i = FirstAmountColumn; i <= LastAmountColumn + 1; i++)
            {
                ws.Cells[row, i].Style.Numberformat.Format = "R #,##0.00";
                ws.Cells[row, i].Formula = SumRange(i, incomeRowStart, i, incomeRowLast - 1);
            }
            int incomeTotals = row;
            #endregion

            row = row + 2;
            #region Incomes - Expenses
            ws.Cells[row, 1].Value = "Sub Total";
            ws.Cells[row, FirstAmountColumn -1].Value = "*" ;
            FormatColumnTotal(ws, 1, LastAmountColumn + 1, row);
            for (int i = FirstAmountColumn; i <= LastAmountColumn + 1; i++)
            {
                ws.Cells[row, i].Style.Numberformat.Format = "R #,##0.00";
                ws.Cells[row, i].Formula = MinusStuff(i,ExpenseTotalRow,i,incomeTotals);
            }
            int SubTotalRow = row;
            #endregion

            row = row+1;
            #region INSTITUTIONAL/ INDIRECT COST
            int indirectTotals = 1;
            ws.Cells[row, 1].Value = "INSTITUTIONAL/ INDIRECT COST";
            FormatColumnTotal(ws, 1, LastAmountColumn + 1, row);
            for (int i = FirstAmountColumn; i <= LastAmountColumn + 1; i++)
            {
                ws.Cells[row, i].Style.Numberformat.Format = "R #,##0.00";
                ws.Cells[row, i].Formula = "=(" + GetExcelColumnName(i) + SubTotalRow +"* " +projectInfo.projSettings.InstitutionalCost + ")";
            }
            indirectTotals = row;
            #endregion

                
            row = row + 2;
            #region bursaries/Scholarships
            int bursaryTotals = 1;
            ws.Cells[row, 1].Value = "Bursaries/Scholarships";

            //Write note value
            ws.Cells[row, FirstAmountColumn-1].Value = "9";
            col = FirstAmountColumn;
            if (projectInfo.bursaryList.Count() != 0)
            {
                int AmountOfMonths = ((projectInfo.endDate.Year - projectInfo.startDate.Year) * 12) + projectInfo.endDate.Month - projectInfo.startDate.Month;
                if(AmountOfMonths == 0)
                {
                    AmountOfMonths = 1;
                }
                double total = 0;
                DateTime tempStartDate = projectInfo.startDate;
                int monthCount = 1;
                while(tempStartDate >= projectInfo.startDate && tempStartDate <= projectInfo.endDate)
                {
                    foreach (BursaryType bursary in projectInfo.bursaryList)
                    {
                        total += bursary.AnnualCost / AmountOfMonths;
                    }

                    ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                    ws.Cells[row, col++].Value = total;
                    total = 0;
                    tempStartDate = tempStartDate.AddMonths(1);
                }

                ws.Cells[row, lastAmountRow+1].Style.Numberformat.Format = "R #,##0.00";
                ws.Cells[row, lastAmountRow+1].Formula = SumRange(firstAmountRow, row, lastAmountRow, row - 1);
            }
            bursaryTotals = row++;
            #endregion

            #region FUNDING OPPORTUNITY
            ws.Cells[row, 1].Value = "FUNDING OPPORTUNITY";
            FormatFinalTotal(ws, 1, LastAmountColumn + 1, row);
            for (int i = FirstAmountColumn; i <= LastAmountColumn + 1; i++)
            {
                ws.Cells[row, i].Style.Numberformat.Format = "R #,##0.00";
                ws.Cells[row, i].Formula = "=" + GetExcelColumnName(i) + SubTotalRow + "+" + GetExcelColumnName(i) + indirectTotals + "-" + GetExcelColumnName(i) + bursaryTotals;
            }
            int FinalTotalRow = row;
            #endregion
        #endregion

            //FInal Worksheet formatting
            //for (int i = firstAmountRow; i < FinalTotalRow; i++)
            //{
            //    FormatDocumentCells(ws, 1, LastAmountColumn, firstAmountRow, lastAmountRow);
            //}

            FormatColumnHeadings(ws, col, LastAmountColumn, 1);
            FormatColumnHeadings(ws, col, LastAmountColumn, 3);
            return pck;
        }

        ExcelPackage createQuarterlySheet(ExcelPackage pck)
        {
            return pck;
        }

        ExcelPackage createYearlySheet(ExcelPackage pck)
        {
            return pck;
        }

        ExcelPackage createNotes(ExcelPackage pck)
        {
            #region Notes
            int col = 1;
            int row = 1;
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Notes");
            //Write main notes heading

            ws.Cells[row, col].Value = "*The indirect/institutional cost, charged by the University of Pretoria on all projects, is [current percentage]% of total project expenses";

            row += 2;
            ws.Cells[row, col].Value = "Budget Notes";
            FormatNoteHeading(ws, 1, 5, row++);
            ws.Cells[row, 1, row, 5].Merge = true;

            row++;
            #region Write UP Staff
            col=1;
            ws.Cells[row, col].Value = "1. UP Staff Members";
            FormatNoteHeading(ws, 1, 5, row);
            ws.Cells[row, 1, row, 5].Merge = true;
            row++;
            ws.Cells[row, col++].Value = "ID";
            projectInfo.upStaff_ID_col = col;
            ws.Cells[row, col++].Value = "Note ID";
            ws.Cells[row, col++].Value = "Note";
            projectInfo.upStaff_StartDate_col = col;
            ws.Cells[row, col++].Value = "Start Date";
            projectInfo.upStaff_EndDate_col = col;
            ws.Cells[row, col++].Value = "End Date";
            ws.Cells[row, col++].Value = "Subvention Levy";
            projectInfo.upStaff_Amount_col = col;
            ws.Cells[row, col++].Value = "Amount";
            FormatNoteHeading(ws, 1, 5, row);

            col = 1;
            row++;
            projectInfo.Travel_rowStart = row;
            foreach (Proj.obj objective in projectInfo.objList)
            {
                foreach (Proj.obj.act activity in objective.ActivitysList)
                {
                   
                    #region Write each expense
                    #region UP staff
                    //====================UP staff====================    
                    if (activity.upstaffList.Count() != 0)
                    {
                        //Write note value                                                      

                        foreach (UPStaffMember upstaff in activity.upstaffList)
                        {
                            ws.Cells[row, col++].Value = upstaff.Expens.Note_Id;
                            ws.Cells[row, col++].Value = "1." + objective.noteID + "." + activity.noteID;

                            using (var dbContext = new dboEntities())
                            {
                                //get project details
                                var queryNotes = from note
                                            in dbContext.Notes
                                                where note.Id == upstaff.Expens.Note_Id
                                                select note;

                                foreach (Note qn in queryNotes)
                                {
                                    ws.Cells[row, col++].Value = qn.UserNote + "\n\r\n\r";
                                }
                            }
                            //Start Date
                            ws.Cells[row, col++].Value = activity.startDate.ToString();
                            //End Date
                            ws.Cells[row, col++].Value = activity.endDate.ToString();

                            if (upstaff.SubventionLevy == false)
                            {
                                ws.Cells[row, col++].Value = "No";
                            }
                            else
                            {
                                ws.Cells[row, col++].Value = "Yes";
                            }


                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col++].Value = upstaff.Expens.Amount;
                            col = 1;
                            row++;
                        }
                    }
                    #endregion
                    #endregion
                }                    
            }              
            #endregion
            projectInfo.Travel_rowEnd = row;
            row += 2;

            #region Write Contractors
            col=1;
            ws.Cells[row, col].Value = "2. External Service Provider";
            FormatNoteHeading(ws, 1, 4, row);
            ws.Cells[row, 1, row, 4].Merge = true;
            row++;

            ws.Cells[row, col++].Value = "ID";
            projectInfo.Contractors_ID_col = col;
            ws.Cells[row, col++].Value = "Note ID";
            ws.Cells[row, col++].Value = "Note";
            projectInfo.upStaff_StartDate_col = col;
            ws.Cells[row, col++].Value = "Start Date";
            projectInfo.upStaff_EndDate_col = col;
            ws.Cells[row, col++].Value = "End Date";
            projectInfo.Contractors_Amount_col = col;
            ws.Cells[row, col++].Value = "Amount";
            FormatNoteHeading(ws, 1, 4, row);
            row++;
            col=1;
            projectInfo.Contractors_rowStart = row;
            foreach (Proj.obj objective in projectInfo.objList)
            {
                foreach (Proj.obj.act activity in objective.ActivitysList)
                {
                    #region Write each expense
                    if (activity.contrList.Count() != 0)
                    {
                        //Write note value                                                      

                        foreach (Contractor item in activity.contrList)
                        {
                            ws.Cells[row, col++].Value = item.Expens.Note_Id;
                            ws.Cells[row, col++].Value = "2." + objective.noteID + "." + activity.noteID;

                            using (var dbContext = new dboEntities())
                            {
                                //get project details
                                var queryNotes = from note
                                            in dbContext.Notes
                                                where note.Id == item.Expens.Note_Id
                                                select note;

                                foreach (Note qn in queryNotes)
                                {
                                    ws.Cells[row, col++].Value = qn.UserNote + "\n\r\n\r";
                                }
                            }


                            //Start Date
                            ws.Cells[row, col++].Value = activity.startDate.ToString();
                            //End Date
                            ws.Cells[row, col++].Value = activity.endDate.ToString();

                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col++].Value = item.Expens.Amount;
                            col = 1;
                            row++;
                        }
                    }
                    #endregion
                }
            }
            projectInfo.Contractors_rowEnd = row;
            #endregion

            row += 2;

            #region Write Operational Expense Notes
            col = 1;
            ws.Cells[row, col].Value = "3. Operational Expense Notes";
            FormatNoteHeading(ws, 1, 5, row);
            ws.Cells[row, 1, row, 5].Merge = true;
            row++;

            ws.Cells[row, col++].Value = "ID";
            projectInfo.Operational_ID_col = col;
            ws.Cells[row, col++].Value = "Note ID";
            ws.Cells[row, col++].Value = "Note";
            projectInfo.upStaff_StartDate_col = col;
            ws.Cells[row, col++].Value = "Start Date";
            projectInfo.upStaff_EndDate_col = col;
            ws.Cells[row, col++].Value = "End Date";
            ws.Cells[row, col++].Value = "Type";
            projectInfo.Operational_Amount_col = col;
            ws.Cells[row, col++].Value = "Amount";
            FormatNoteHeading(ws, 1, 5, row);
            row++;
            col = 1;
            projectInfo.Operational_rowStart = row;
            foreach (Proj.obj objective in projectInfo.objList)
            {
                foreach (Proj.obj.act activity in objective.ActivitysList)
                {
                    #region Write each expense
                    if (activity.OperatList.Count() != 0)
                    {
                        //Write note value                                                      

                        foreach (Operational item in activity.OperatList)
                        {
                            ws.Cells[row, col++].Value = item.Expens.Note_Id;
                            ws.Cells[row, col++].Value = "3." + objective.noteID + "." + activity.noteID;

                            using (var dbContext = new dboEntities())
                            {
                                var queryNotes = from note
                                            in dbContext.Notes
                                                where note.Id == item.Expens.Note_Id
                                                select note;
                                foreach(Note qn in queryNotes)
                                {
                                    ws.Cells[row, col++].Value = qn.UserNote + "\n\r\n\r";
                                }


                                //Start Date
                                ws.Cells[row, col++].Value = activity.startDate.ToString();
                                //End Date
                                ws.Cells[row, col++].Value = activity.endDate.ToString();

                                var queryOp = from operation
                                            in dbContext.Operation_Type
                                            where operation.Id == item.Operation_TypeId
                                            select operation;

                                foreach (Operation_Type qn in queryOp)
                                {
                                    ws.Cells[row, col++].Value = qn.Description + "\n\r\n\r";
                                }
                            }


                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col++].Value = item.Expens.Amount;
                            col = 1;
                            row++;
                        }
                    }
                    #endregion
                }
            }
            projectInfo.Operational_rowEnd = row;
            #endregion

            row += 2;

            #region Write Car Notes
            col = 1;
            ws.Cells[row, col].Value = "4. Car Expense Notes";
            FormatNoteHeading(ws, 1, 4, row);
            ws.Cells[row, 1, row, 4].Merge = true;
            row++;

            ws.Cells[row, col++].Value = "ID";
            ws.Cells[row, col++].Value = "Note ID";
            ws.Cells[row, col++].Value = "Note";
            projectInfo.upStaff_StartDate_col = col;
            ws.Cells[row, col++].Value = "Start Date";
            projectInfo.upStaff_EndDate_col = col;
            ws.Cells[row, col++].Value = "End Date";
            ws.Cells[row, col++].Value = "UP Fleet";
            FormatNoteHeading(ws, 1, 4, row);
            row++;
            col = 1;
            foreach (Proj.obj objective in projectInfo.objList)
            {
                foreach (Proj.obj.act activity in objective.ActivitysList)
                {
                    #region Write each expense
                    if (activity.OperatList.Count() != 0)
                    {
                        //Write note value                                                      

                        foreach (Car item in activity.carList)
                        {
                            ws.Cells[row, col++].Value = item.Expen.Note_Id;
                            ws.Cells[row, col++].Value = "4." + objective.noteID + "." + activity.noteID;

                            using (var dbContext = new dboEntities())
                            {
                                var queryNotes = from note
                                            in dbContext.Notes
                                                where note.Id == item.Expen.Note_Id
                                                select note;
                                foreach (Note qn in queryNotes)
                                {
                                    ws.Cells[row, col++].Value = qn.UserNote + "\n\r\n\r";
                                }
                            }


                            //Start Date
                            ws.Cells[row, col++].Value = activity.startDate.ToString();
                            //End Date
                            ws.Cells[row, col++].Value = activity.endDate.ToString();

                            //if (item.UPFleet == false)
                            //{
                            //    ws.Cells[row, col++].Value = "No";
                            //}
                            //else
                            //{
                            //    ws.Cells[row, col++].Value = "Yes";
                            //}

                            col = 1;
                            row++;
                        }
                    }
                    #endregion
                }
            }
            #endregion

            row += 2;

            #region Write Travel Notes
            col = 1;
            ws.Cells[row, col].Value = "5. Travel Expense Notes";
            FormatNoteHeading(ws, 1, 12, row);
            ws.Cells[row, 1, row, 12].Merge = true;
            row++;

            ws.Cells[row, col++].Value = "ID";
            ws.Cells[row, col++].Value = "Note ID";
            ws.Cells[row, col++].Value = "Note";
            projectInfo.upStaff_StartDate_col = col;
            ws.Cells[row, col++].Value = "Start Date";
            projectInfo.upStaff_EndDate_col = col;
            ws.Cells[row, col++].Value = "End Date";
            ws.Cells[row, col++].Value = "Departure Location";
            ws.Cells[row, col++].Value = "Destination";
            ws.Cells[row, col++].Value = "Departure Date";
            ws.Cells[row, col++].Value = "Duration (Days)";
            ws.Cells[row, col++].Value = "Accomodation";
            ws.Cells[row, col++].Value = "Airline";
            ws.Cells[row, col++].Value = "Allowance";
            ws.Cells[row, col++].Value = "Gautrain";
            ws.Cells[row, col++].Value = "Visa";
            FormatNoteHeading(ws, 1, 12, row);
            row++;
            col = 1;
            foreach (Proj.obj objective in projectInfo.objList)
            {
                foreach (Proj.obj.act activity in objective.ActivitysList)
                {
                    #region Write each expense
                    if (activity.travList.Count() != 0)
                    {
                        bool bAccom = false;
                        bool bAllow = false;
                        bool bAirline = false;
                        bool bVisa = false;
                        bool bGautrain = false;

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


                        //Write note value                                                      

                        foreach (Travel item in activity.travList)
                        {
                            ws.Cells[row, col++].Value = item.Expens.Note_Id;
                            ws.Cells[row, col++].Value = "5." + objective.noteID + "." + activity.noteID;

                            using (var dbContext = new dboEntities())
                            {
                                var queryNotes = from note
                                            in dbContext.Notes
                                                where note.Id == item.Expens.Note_Id
                                                select note;
                                foreach (Note qn in queryNotes)
                                {
                                    ws.Cells[row, col++].Value = qn.UserNote + "\n\r\n\r";
                                }
                            }


                            //Start Date
                            ws.Cells[row, col++].Value = activity.startDate.ToString();
                            //End Date
                            ws.Cells[row, col++].Value = activity.endDate.ToString();

                            ws.Cells[row, col++].Value = item.DepatureLocation;
                            ws.Cells[row, col++].Value = item.Destination;
                            ws.Cells[row, col++].Value = item.DepartureDate;
                            ws.Cells[row, col++].Value = item.DurationDays;

                            if(bAccom == false)
                            {
                                ws.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);
                            }
                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col++].Value = 0;

                            if (bAirline == false)
                            {
                                ws.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);
                            }
                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col++].Value = 0;

                            if (bAllow == false)
                            {
                                ws.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);
                            }
                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col++].Value = 0;

                            if (bGautrain == false)
                            {
                                ws.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);
                            }
                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col++].Value = 0;

                            if (bVisa == false)
                            {
                                ws.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);
                            }
                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col++].Value = 0;

                            col = 1;
                            row++;
                        }
                    }
                    #endregion
                }
            }
            #endregion

            row += 2;

            #region Write Car Notes
            col = 1;
            ws.Cells[row, col].Value = "6. Equipment Notes";
            FormatNoteHeading(ws, 1, 4, row);
            ws.Cells[row, 1, row, 4].Merge = true;
            row++;

            ws.Cells[row, col++].Value = "ID";
            ws.Cells[row, col++].Value = "Note ID";
            ws.Cells[row, col++].Value = "Note";
            projectInfo.upStaff_StartDate_col = col;
            ws.Cells[row, col++].Value = "Start Date";
            projectInfo.upStaff_EndDate_col = col;
            ws.Cells[row, col++].Value = "End Date";
            ws.Cells[row, col++].Value = "Item Amount";
            FormatNoteHeading(ws, 1, 4, row);
            row++;

            col = 1;
            foreach (Proj.obj objective in projectInfo.objList)
            {
                foreach (Proj.obj.act activity in objective.ActivitysList)
                {
                    #region Write each expense
                    if (activity.OperatList.Count() != 0)
                    {
                        //Write note value                                                      

                        foreach (Equipment item in activity.equipList)
                        {
                            ws.Cells[row, col++].Value = item.Expens.Note_Id;
                            ws.Cells[row, col++].Value = "6." + objective.noteID + "." + activity.noteID;

                            using (var dbContext = new dboEntities())
                            {
                                var queryNotes = from note
                                            in dbContext.Notes
                                                where note.Id == item.Expens.Note_Id
                                                select note;
                                foreach (Note qn in queryNotes)
                                {
                                    ws.Cells[row, col++].Value = qn.UserNote + "\n\r\n\r";
                                }
                            }


                            //Start Date
                            ws.Cells[row, col++].Value = activity.startDate.ToString();
                            //End Date
                            ws.Cells[row, col++].Value = activity.endDate.ToString();

                            ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                            ws.Cells[row, col++].Value = item.Expens.Amount;

                            col = 1;
                            row++;
                        }
                    }
                    #endregion
                }
            }
            #endregion

            row += 2;

            #region Write Income Notes
            col = 1;
            ws.Cells[row, col].Value = "7. Incomes/Donations/Gifts";
            FormatNoteHeading(ws, 1, 4, row);
            ws.Cells[row, 1, row, 4].Merge = true;
            row++;

            ws.Cells[row, col++].Value = "ID";
            ws.Cells[row, col++].Value = "Note ID";
            ws.Cells[row, col++].Value = "Note";
            ws.Cells[row, col++].Value = "Item Amount";
            FormatNoteHeading(ws, 1, 4, row);
            row++;
            col = 1;
            int itemID = 1;
            foreach (Income item in projectInfo.incomeList)
            {
                ws.Cells[row, col++].Value = item.Note_Id;
                ws.Cells[row, col++].Value = "7." + itemID++;

                using (var dbContext = new dboEntities())
                {
                    var queryNotes = from note
                                in dbContext.Notes
                                    where note.Id == item.Note_Id
                                    select note;
                    foreach (Note qn in queryNotes)
                    {
                        ws.Cells[row, col++].Value = qn.UserNote + "\n\r\n\r";
                    }
                }

                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                ws.Cells[row, col++].Value = item.Amount;

                col = 1;
                row++;
            }
            #endregion

            row += 2;

            #region Write UP Staff income
            col = 1;
            ws.Cells[row++, col].Value = "8. UP Staff Members Income Notes";
            FormatNoteHeading(ws, 1, 5, row);
            ws.Cells[row, 1, row, 5].Merge = true;
            row++;

            ws.Cells[row, col++].Value = "ID";
            ws.Cells[row, col++].Value = "Note ID";
            ws.Cells[row, col++].Value = "Note";
            ws.Cells[row, col++].Value = "Subvention Levy";
            ws.Cells[row, col++].Value = "Amount";
            FormatNoteHeading(ws, 1, 5, row);

            col = 1;
            row++;
            itemID = 1;
            foreach (UPStaffMember item in projectInfo.staffIncome)
            {
                ws.Cells[row, col++].Value = item.Expens.Note_Id;
                ws.Cells[row, col++].Value = "8." + itemID++;

                using (var dbContext = new dboEntities())
                {
                    //get project details
                    var queryNotes = from note
                                in dbContext.Notes
                                    where note.Id == item.Expens.Note_Id
                                        select note;

                    foreach (Note qn in queryNotes)
                    {
                        ws.Cells[row, col++].Value = qn.UserNote + "\n\r\n\r";
                    }
                }

                if (item.SubventionLevy == false)
                {
                    ws.Cells[row, col++].Value = "No";
                }
                else
                {
                    ws.Cells[row, col++].Value = "Yes";
                }


                ws.Cells[row, col].Style.Numberformat.Format = "R #,##0.00";
                ws.Cells[row, col++].Value = item.Expens.Amount;
                col = 1;
                row++;
                     
            }
            #endregion

            row += 2;

            #region WriteDonation
            col = 1;
            ws.Cells[row++, col].Value = "9. Bursaries/Scholarships";
            FormatNoteHeading(ws, 1, 4, row);
            ws.Cells[row, 1, row, 4].Merge = true;
            row++;

            ws.Cells[row, col++].Value = "ID";
            ws.Cells[row, col++].Value = "Note ID";
            ws.Cells[row, col++].Value = "Note";
            ws.Cells[row, col++].Value = "Type";
            FormatNoteHeading(ws, 1, 4, row);
            col = 1;
            row++;
            itemID = 1;
            foreach (Bursary item in projectInfo.bursary2List)
            {
                ws.Cells[row, col++].Value = item.Note_Id;
                ws.Cells[row, col++].Value = "9" ;

                using (var dbContext = new dboEntities())
                {
                    //get project details
                    var queryNotes = from note
                                in dbContext.Notes
                                    where note.Id == item.Note_Id
                                    select note;

                    foreach (Note qn in queryNotes)
                    {
                        ws.Cells[row, col++].Value = qn.UserNote + "\n\r\n\r";
                    }
                }

                ws.Cells[row, col++].Value = item.BursaryType.Description;
                col = 1;
                row++;

            }
            #endregion
            #endregion

            return pck;
        }
        #region Math
        public string MinusStuff(int col1, int row1, int col2, int row2)
        {
            //double body = 1 + (interestRate / timesPerYear);
            //double exponent = timesPerYear * years;
            //amount = amount * Math.Pow(body, exponent);
            string sum = "=(" + GetExcelColumnName(col1) + row1 + "-" + GetExcelColumnName(col2) + row2 + ")";//"POWER("++",1+"+(interestRate / timesPerYear)+")"
            return sum;
        }
        
        
        public string SumRange(int col1, int row1, int col2, int row2)
        {
            //double body = 1 + (interestRate / timesPerYear);
            //double exponent = timesPerYear * years;
            //amount = amount * Math.Pow(body, exponent);
            string sum = "=SUM(" + GetExcelColumnName(col1) + row1 + ":" + GetExcelColumnName(col2) + row2 +")";//"POWER("++",1+"+(interestRate / timesPerYear)+")"
            return sum;
        }

        public string compoundInterest(double amount, double interestRate, int timesPerYear, int years, int col, int row, int NoteStartRow, int NoteEndRow, int AmountCol, int StartDateCol,int endDateCol, int noteIDCol, string noteID, DateTime startDate, DateTime endDate)
        {
            //double body = 1 + (interestRate / timesPerYear);
            //double exponent = timesPerYear * years;
            //amount = amount * Math.Pow(body, exponent);
            /*string sum = "=" + amount + "* POWER(1+" + (interestRate / timesPerYear) + "," + timesPerYear * years + ")";*/
            string sum = "=SUMIFS(Notes!$" + GetExcelColumnName(AmountCol) + "$" + NoteStartRow + ":$" + GetExcelColumnName(AmountCol) + "$" + NoteEndRow + ", ";
            sum += "Notes!$" + GetExcelColumnName(StartDateCol) + "$" + NoteStartRow + ":$" + GetExcelColumnName(StartDateCol) + "$" + NoteEndRow + ", \">=\"  + &DATE(" + startDate.Year + "," + startDate.Month + "," + startDate.Day + "),";
            sum += "Notes!$" + GetExcelColumnName(endDateCol) + "$" + NoteStartRow + ":$" + GetExcelColumnName(endDateCol) + "$" + NoteEndRow + ", \">=\"  + &DATE(" + endDate.Year + "," + endDate.Month + "," + endDate.Day + "),";
            sum += "Notes!$" + GetExcelColumnName(noteIDCol) + "$" + NoteStartRow + ":$" + GetExcelColumnName(noteIDCol) + "$" + NoteEndRow + ", \"=\"" + noteID + " )";
            sum += "* POWER(1+" + (interestRate / timesPerYear) + "," + timesPerYear * years + ")";
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
                projectInfo.bursary2List = queryBursary.ToList<Bursary>();
                foreach(Bursary b in queryBursary)
                {
                    projectInfo.bursaryList.Add(b.BursaryType);
                }
               


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
                //range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            }
        }

        public void FormatDocumentCells(ExcelWorksheet worksheet, int startCol, int endCol, int startRow, int endRow)
        {
            using (var range = worksheet.Cells[startRow, startCol, endRow, endCol])
            {
                //range.AutoFitColumns();
                //range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                //range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                //range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                //range.Style.Border.Right.Style = ExcelBorderStyle.Thin; 
            }
        }

        public void FormatFinalTotal(ExcelWorksheet worksheet, int startCol, int endCol, int row)
        {
            using (var range = worksheet.Cells[row, startCol, row, endCol])
            {
                range.Style.Font.Bold = true;
                range.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                range[row, startCol].Style.Border.Left.Style = ExcelBorderStyle.Medium;
                range[row, endCol].Style.Border.Right.Style = ExcelBorderStyle.Medium;               

                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
            }
        }

        public void FormatColumnTotal(ExcelWorksheet worksheet, int startCol, int endCol, int row)
        {
            using (var range = worksheet.Cells[ row, startCol, row, endCol])
            {
                range.Style.Font.Bold = true;
                range.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                //range.Style.Border.Top = BorderStyle.Solid;
                //Excel.Borders borders = range.Borders;
                //borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                //range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }
        }

        public void FormatNoteHeading(ExcelWorksheet worksheet, int startCol, int endCol, int row)
        {
            using (var range = worksheet.Cells[row, startCol, row, endCol])
            {
                range.Style.Font.Bold = true;
                range.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                range.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                range.Style.Border.Right.Style = ExcelBorderStyle.Medium;  
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
                range.Style.Font.Size = 10;
                range.Style.ShrinkToFit = false;
            }
        }

        public void FormatHeadings(ExcelWorksheet worksheet, int startCol, int endCol, int row)
        {
            using (var range = worksheet.Cells[row, startCol, row, endCol])
            {
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.White);
                range.Style.Font.Bold = true;
                range.Merge = true;
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                range.Style.Font.Size = 20;
                range.Style.ShrinkToFit = false;
            }
        }

        public void FormatSpacers(ExcelWorksheet worksheet, int startCol, int endCol, int row)
        {
            using (var range = worksheet.Cells[row, startCol, row, endCol])
            {
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
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