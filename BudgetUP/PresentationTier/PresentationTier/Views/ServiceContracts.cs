using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BizTier;

namespace PresentationTier.Views
{
    /// <summary>
    /// This contains all methods that retrieve data from and add/edit data to that databas
    /// </summary>
    public class ServiceContracts
    {
        #region Project
        /// <summary>
        /// Used to add project to the users project
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="title"></param>
        /// <param name="goal"></param>
        /// <param name="length"></param>
        /// <param name="durationTypeID"></param>
        /// <param name="projectSettingsID"></param>
        public void AddUserProject(int userID, string title, string goal, int length, int durationTypeID, int projectSettingsID)
        {
            try
            {                
                Project project = new Project();
                project.UserId = userID;
                project.Title = title;
                project.Goal = goal;
                project.Length = length;

                //these can be an object sent to another function if done on same page
                project.DurationTypeId = durationTypeID;
                project.Project_Settings_Id = projectSettingsID;
                using(var dbContext = new dboEntities())
                {
                    dbContext.Projects.Add(project);
                    dbContext.SaveChanges();
                }
            }
            catch(Exception f)
            {
                EventLogger EL = new EventLogger();                
                EL.LogFile("AddUserProject","Creation of project:"+ title  +" by user: "+ userID.ToString(),f.ToString(),f.Source.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        public void AddDurationType(string description)
        {
            DurationType dt = new DurationType();
            dt.Description = description;
            using (var dbContext = new dboEntities())
            {
                dbContext.DurationTypes.Add(dt);
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="escalationRate"></param>
        /// <param name="subventionRate"></param>
        /// <param name="institutionalCost"></param>
        public void AddProjectSettings(double escalationRate, double subventionRate, double institutionalCost)
        {
            Project_Settings ps = new Project_Settings();
            ps.EscalationRate = escalationRate;
            ps.SubventionRate = subventionRate;
            ps.InstitutionalCost = institutionalCost;

            using (var dbContext = new dboEntities())
            {
                dbContext.Project_Settings.Add(ps);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Bursaries
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bursaryTypeID"></param>
        /// <param name="projectID"></param>
        /// <param name="noteID"></param>
        public void AddBursary(int bursaryTypeID, int projectID, int noteID)
        {
            Bursary bursary = new Bursary();
            
            //these can be determined by other functions below
            bursary.BursaryTypeId = bursaryTypeID;
            bursary.ProjectId = projectID;
            bursary.Note_Id = noteID;

            using (var dbContext = new dboEntities())
            {
                dbContext.Bursaries.Add(bursary);
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        /// <param name="annualCost"></param>
        /// <param name="durationYears"></param>
        public void AddBursaryType(string description, double annualCost, int durationYears)
        {
            BursaryType bursary = new BursaryType();

            //these can be determined by other functions below
            bursary.Description = description;
            bursary.AnnualCost = annualCost;
            bursary.DurationYears = durationYears;

            using (var dbContext = new dboEntities())
            {
                dbContext.BursaryTypes.Add(bursary);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Notes
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userNote"></param>
        public void AddNotes(string userNote)
        {
            Note note = new Note();

            //these can be determined by other functions below
            note.UserNote = userNote;

            using (var dbContext = new dboEntities())
            {
                dbContext.Notes.Add(note);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Admin
        public void AddAdminSysSettings(double institutionalCost, double subventionRate, double escalationRate, int maximumProjectSpan) 
        {
            Admin_SysSettings admin = new Admin_SysSettings();

            admin.InstitutionalCost = institutionalCost;
            admin.SubventionRate = subventionRate;
            admin.EscalationRate = escalationRate;
            admin.MaximumProjectSpan = maximumProjectSpan;

            using (var dbContext = new dboEntities())
            {
                dbContext.Admin_SysSettings.Add(admin);
                dbContext.SaveChanges();
            }
        }

        public void UpdateAdminSysSettings(Admin_SysSettings admin)
        {
            using(var dbContext = new dboEntities())
            {
                var entry = dbContext.Admin_SysSettings
                        .Where(ad => ad.Id == admin.Id)
                        .FirstOrDefault();
                entry.InstitutionalCost = admin.InstitutionalCost;
                entry.SubventionRate = admin.SubventionRate;
                entry.EscalationRate = admin.EscalationRate;
                entry.MaximumProjectSpan = admin.MaximumProjectSpan;
                dbContext.SaveChanges();
            }
        }

        public void AddEmailDomain(string domain)
        {
            EmailDomain admin = new EmailDomain();

            admin.Domain = domain;

            using (var dbContext = new dboEntities())
            {
                dbContext.EmailDomains.Add(admin);
                dbContext.SaveChanges();
            }
        }

        public void UpdateEmailDomain(EmailDomain emailDomain)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.EmailDomains
                        .Where(ad => ad.Id == emailDomain.Id)
                        .FirstOrDefault();
                entry.Domain = emailDomain.Domain;
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region User / UserCredentials
        public void AddUser(int titleID, string name, string surname, int roleID, string faculty)
        {
            User user = new User();

            //these can be determined by other functions below
            user.TitleId = titleID;
            user.Name = name;
            user.Surname = surname;
            user.RoleId = roleID;
            user.Faculty.FacultyName = faculty;

            using (var dbContext = new dboEntities())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
        }

        public void AddUserCredential(string email, string password, int userID)
        {
            UserCredential user = new UserCredential();

            //these can be determined by other functions below
            user.Email = email;
            user.Password = password;
            user.User_Id = userID;

            using (var dbContext = new dboEntities())
            {
                dbContext.UserCredentials.Add(user);
                dbContext.SaveChanges();
            }
        }

        #endregion

        #region Faculty
        public void AddFaculty(string facultyName)
        {
            Faculty faculty = new Faculty();

            //these can be determined by other functions below
            faculty.FacultyName = facultyName;

            using (var dbContext = new dboEntities())
            {
                dbContext.Faculties.Add(faculty);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Role
        public void AddRole(string description)
        {
            Role role = new Role();

            //these can be determined by other functions below
            role.Description = description;

            using (var dbContext = new dboEntities())
            {
                dbContext.Roles.Add(role);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Title
        public void AddTitles(string description)
        {
            Title title = new Title();

            //these can be determined by other functions below
            title.Description = description;

            using (var dbContext = new dboEntities())
            {
                dbContext.Titles.Add(title);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Objectives
        public void AddObjective(int projectID, string objectiveName)
        {
            Objective objective = new Objective();

            //these can be determined by other functions below
            objective.ProjectId = projectID;
            objective.ObjectiveName = objectiveName;

            using (var dbContext = new dboEntities())
            {
                dbContext.Objectives.Add(objective);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Activities
        public void AddActivity(int objectiveID, string activityName, DateTime startDate, DateTime endDate)
        {
            Activity activity = new Activity();

            //these can be determined by other functions below
            activity.ObjectiveId = objectiveID;
            activity.ActivityName = activityName;
            activity.StartDate = startDate;
            activity.EndDate = endDate;

            using (var dbContext = new dboEntities())
            {
                dbContext.Activities.Add(activity);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Incomes
        public void AddIncome(int projectID, string donorName, double amount, int noteID)
        {
            Income income = new Income();

            //these can be determined by other functions below
            income.ProjectId = projectID;
            income.DonorName = donorName;
            income.Amount = amount;
            income.Note_Id = noteID;

            using (var dbContext = new dboEntities())
            {
                dbContext.Incomes.Add(income);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Expenses
        public void AddExpense(int activityID, double amount, int noteID)
        {
            Expens expense = new Expens();

            //these can be determined by other functions below
            expense.ActivityId = activityID;
            expense.Amount = amount;
            expense.Note_Id = noteID;

            using (var dbContext = new dboEntities())
            {
                dbContext.Expenses.Add(expense);
                dbContext.SaveChanges();
            }
        }

        #region Contractor
        public void AddContractor(string contractorName, int expenseID)
        {
            Contractor contractor = new Contractor();

            //these can be determined by other functions below
            contractor.ContractorName = contractorName;
            contractor.Expense_Id = expenseID;

            using (var dbContext = new dboEntities())
            {
                dbContext.Contractors.Add(contractor);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Equipment
        public void AddEquipment(string equipmentName, int expenseID)
        {
            Equipment equipment = new Equipment();

            //these can be determined by other functions below
            equipment.EquipmentName = equipmentName;
            equipment.Expense_Id = expenseID;

            using (var dbContext = new dboEntities())
            {
                dbContext.Equipments.Add(equipment);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Operational
        public void AddOperation(int expenseID, int operationTypeID, int quantity, double pricePerUnit)
        {
            Operational operation = new Operational();

            //these can be determined by other functions below
            operation.ExpenseId = expenseID;
            operation.Expense_Id = expenseID;
            operation.Operation_TypeId = operationTypeID;
            operation.Quantity = quantity;
            operation.PricePerUnit = pricePerUnit;

            using (var dbContext = new dboEntities())
            {
                dbContext.Operationals.Add(operation);
                dbContext.SaveChanges();
            }
        }

        public void AddOperationType(string description)
        {
            Operation_Type operation = new Operation_Type();

            //these can be determined by other functions below
            operation.Description = description;

            using (var dbContext = new dboEntities())
            {
                dbContext.Operation_Type.Add(operation);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region UP Staff Member
        public void AddUPStaffMember(int postLevelID, int daysInvolved, bool subventionLevy, int expenseID)
        {
            UPStaffMember upStaffMember = new UPStaffMember();

            upStaffMember.Expense_Id = expenseID;
            upStaffMember.PostLevelId = postLevelID;
            upStaffMember.DaysInvolved = daysInvolved;
            upStaffMember.SubventionLevy = subventionLevy;

            using (var dbContext = new dboEntities())
            {
                dbContext.UPStaffMembers.Add(upStaffMember);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Travel
        public void AddTravel(int travellerNumber, int durationDays, DateTime departureDate, string destination, int expenseID)
        {
            Travel travels = new Travel();

            travels.TravellerNo = travellerNumber;
            travels.DurationDays = durationDays;
            travels.DepartureDate = departureDate;
            travels.Destination = destination;
            travels.Expense_Id = expenseID;

            using (var dbContext = new dboEntities())
            {
                dbContext.Travels.Add(travels);
                dbContext.SaveChanges();
            }
        }
        
       
        #region Accommodation
        public void AddAccommodation(double amount, int travelID)
        {
            Accommodation accommodation = new Accommodation();

            accommodation.Amount = amount;
            accommodation.Travel_Id = travelID;

            using (var dbContext = new dboEntities())
            {
                dbContext.Accommodations.Add(accommodation);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Airline Expense
        public void AddAirline(bool returnTicket, double amount, int travelID)
        {
            AirlineExpens airline = new AirlineExpens();
            airline.ReturnTicket = returnTicket;
            airline.Amount = amount;
            airline.Travel_Id = travelID;

            using (var dbContext = new dboEntities())
            {
                dbContext.AirlineExpenses.Add(airline);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Allowance
        public void AddAllowance(double amount, int travelID)
        {
            Allowance allowance = new Allowance();
            allowance.Amount = amount;
            allowance.Travel_Id = travelID;

            using (var dbContext = new dboEntities())
            {
                dbContext.Allowances.Add(allowance);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Car Expense
        public void AddCarExpense(bool UPFleet, int amount, int travelID)
        {
            CarExpens car = new CarExpens();
            car.UP_Fleet = UPFleet;
            car.Amount = amount;
            car.Travel_Id = travelID;

            using (var dbContext = new dboEntities())
            {
                dbContext.CarExpenses.Add(car);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Gautrain
        public void AddGautrainExpense( int amount, int travelID)
        {
            Gautrain gautrain = new Gautrain();
            gautrain.Amount = amount;
            gautrain.Travel_Id = travelID;

            using (var dbContext = new dboEntities())
            {
                dbContext.Gautrains.Add(gautrain);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Visa
        public void AddVisaExpense(int amount, int travelID)
        {
            Visa visa = new Visa();
            visa.Amount = amount;
            visa.Travel_Id = travelID;

            using (var dbContext = new dboEntities())
            {
                dbContext.Visas.Add(visa);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #endregion

        #endregion

        #region Posts
        public void AddPostLevel(string description, string annualSalary)
        {
            PostLevel post = new PostLevel();

            //these can be determined by other functions below
            post.Description = description;
            post.AnnualSalary = annualSalary;

            using (var dbContext = new dboEntities())
            {
                dbContext.PostLevels.Add(post);
                dbContext.SaveChanges();
            }
        }
        #endregion

        

    }
}