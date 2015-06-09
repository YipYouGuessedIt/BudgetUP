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
        /// <param name="project"></param>
        public void UpdateUserProject(Project project)
        {
            using(var dbContext = new dboEntities())
            {
                var entry = dbContext.Projects
                        .Where(ad => ad.Id == project.Id)
                        .FirstOrDefault();

                entry.UserId = project.UserId;
                entry.Title = project.Title;
                entry.Goal = project.Goal;
                entry.Length = project.Length;
                entry.DurationTypeId = project.DurationTypeId;
                entry.Project_Settings_Id = project.Project_Settings_Id;
                dbContext.SaveChanges();
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
        /// <param name="description"></param>
        public void UpdateDurationType(DurationType durationType)
        {
                        using (var dbContext = new dboEntities())
            {
                var entry = dbContext.DurationTypes
                        .Where(ad => ad.Id == durationType.Id)
                        .FirstOrDefault();

                entry.Description = durationType.Description;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        public void UpdateDurationType(DurationType durationType)
        {
                        using (var dbContext = new dboEntities())
            {
                var entry = dbContext.DurationTypes
                        .Where(ad => ad.Id == durationType.Id)
                        .FirstOrDefault();

                entry.Description = durationType.Description;
                dbContext.SaveChanges();
            }  
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        public void UpdateProjectSettings(Project_Settings projectSettings)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Project_Settings
                        .Where(ad => ad.Id == projectSettings.Id)
                        .FirstOrDefault();

                entry.InstitutionalCost = projectSettings.InstitutionalCost;
                entry.SubventionRate = projectSettings.SubventionRate;
                entry.EscalationRate = projectSettings.EscalationRate;
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
        /// <param name="bursary"></param>
        public void UpdateBursary(Bursary bursary)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Bursaries
                        .Where(ad => ad.Id == bursary.Id)
                        .FirstOrDefault();

                entry.ProjectId = bursary.ProjectId;
                entry.Note = bursary.Note;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bursary"></param>
        public void UpdateBursaryType(BursaryType bursary)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.BursaryTypes
                        .Where(ad => ad.Id == bursary.Id)
                        .FirstOrDefault();

                entry.Description = bursary.Description;
                entry.AnnualCost = bursary.AnnualCost;
                entry.DurationYears = bursary.DurationYears;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="note"></param>
        public void UpdateNotes(Note note)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Notes
                        .Where(ad => ad.Id == note.Id)
                        .FirstOrDefault();

                entry.UserNote = note.UserNote;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="titleID"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="roleID"></param>
        /// <param name="faculty"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(User user)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Users
                        .Where(ad => ad.Id == user.Id)
                        .FirstOrDefault();

                entry.TitleId = user.TitleId;
                entry.Name = user.Name;
                entry.Surname = user.Surname;
                entry.RoleId = user.RoleId;
                entry.FacultyId = user.FacultyId;
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="userID"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUserCredentials(UserCredential user)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.UserCredentials
                        .Where(ad => ad.Id == user.Id)
                        .FirstOrDefault();

                entry.Email = user.Email;
                entry.Password = user.Password;
                dbContext.SaveChanges();
            }
        }

        #endregion

        #region Faculty
        /// <summary>
        /// 
        /// </summary>
        /// <param name="facultyName"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="faculty"></param>
        public void UpdateFaculty(Faculty faculty)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Faculties
                        .Where(ad => ad.Id == faculty.Id)
                        .FirstOrDefault();

                entry.FacultyName = faculty.FacultyName;
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Role
        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        public void UpdateRole(Role role)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Roles
                        .Where(ad => ad.Id == role.Id)
                        .FirstOrDefault();

                entry.Description = role.Description;
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Title
        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        public void AddTitles(string description)
        {
            Title title = new Title();

            title.Description = description;

            using (var dbContext = new dboEntities())
            {
                dbContext.Titles.Add(title);
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        public void UpdateTitle(Title title)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Titles
                        .Where(ad => ad.Id == title.Id)
                        .FirstOrDefault();

                entry.Description = title.Description;
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Objectives
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="objectiveName"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objective"></param>
        public void UpdateObjectives(Objective objective)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Objectives
                        .Where(ad => ad.Id == objective.Id)
                        .FirstOrDefault();

                entry.ObjectiveName = objective.ObjectiveName;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activity"></param>
        public void UpdateActivity(Activity activity)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Activities
                        .Where(ad => ad.Id == activity.Id)
                        .FirstOrDefault();

                entry.ActivityName = activity.ActivityName;
                entry.StartDate = activity.StartDate;
                entry.EndDate = activity.EndDate;
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Incomes
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="donorName"></param>
        /// <param name="amount"></param>
        /// <param name="noteID"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="income"></param>
        public void UpdateIncome(Income income)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Incomes
                        .Where(ad => ad.Id == income.Id)
                        .FirstOrDefault();

                entry.DonorName = income.DonorName;
                entry.Amount = income.Amount;
                entry.Note.UserNote = income.Note.UserNote;
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Expenses
        /// <summary>
        /// 
        /// </summary>
        /// <param name="activityID"></param>
        /// <param name="amount"></param>
        /// <param name="noteID"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expense"></param>
        public void UpdateExpense(Expens expense)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Expenses
                        .Where(ad => ad.Id == expense.Id)
                        .FirstOrDefault();

                entry.Amount = expense.Amount;
                entry.Note.UserNote = expense.Note.UserNote;
                dbContext.SaveChanges();
            }
        }

        #region Contractor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contractorName"></param>
        /// <param name="expenseID"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contractor"></param>
        public void UpdateContractor(Contractor contractor)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Contractors
                        .Where(ad => ad.Id == contractor.Id)
                        .FirstOrDefault();

                entry.ContractorName = contractor.ContractorName;
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Equipment
        /// <summary>
        /// 
        /// </summary>
        /// <param name="equipmentName"></param>
        /// <param name="expenseID"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="equipment"></param>
        public void UpdateEquipment(Equipment equipment)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Equipments
                        .Where(ad => ad.Id == equipment.Id)
                        .FirstOrDefault();

                entry.EquipmentName = equipment.EquipmentName;
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Operational
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expenseID"></param>
        /// <param name="operationTypeID"></param>
        /// <param name="quantity"></param>
        /// <param name="pricePerUnit"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void UpdateOperation(Operational operation)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Operationals
                        .Where(ad => ad.Id == operation.Id)
                        .FirstOrDefault();

                entry.Operation_TypeId = operation.Operation_TypeId;
                entry.Quantity = operation.Quantity;
                entry.PricePerUnit = operation.PricePerUnit;
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        public void AddOperationType(string description)
        {
            Operation_Type operation = new Operation_Type();

            operation.Description = description;

            using (var dbContext = new dboEntities())
            {
                dbContext.Operation_Type.Add(operation);
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        public void UpdateOperationalType(Operation_Type operation)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Operation_Type
                        .Where(ad => ad.Id == operation.Id)
                        .FirstOrDefault();

                entry.Description = operation.Description;
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region UP Staff Member
        /// <summary>
        /// 
        /// </summary>
        /// <param name="postLevelID"></param>
        /// <param name="daysInvolved"></param>
        /// <param name="subventionLevy"></param>
        /// <param name="expenseID"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="upStaffMember"></param>
        public void UpdateUPStaffMember(UPStaffMember upStaffMember)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.UPStaffMembers
                        .Where(ad => ad.Id == upStaffMember.Id)
                        .FirstOrDefault();

                entry.PostLevelId = upStaffMember.PostLevelId;
                entry.DaysInvolved = upStaffMember.DaysInvolved;
                entry.SubventionLevy = upStaffMember.SubventionLevy;
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Travel
        /// <summary>
        /// 
        /// </summary>
        /// <param name="travellerNumber"></param>
        /// <param name="durationDays"></param>
        /// <param name="departureDate"></param>
        /// <param name="destination"></param>
        /// <param name="expenseID"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="travels"></param>
        public void UpdateTravel(Travel travels)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Travels
                        .Where(ad => ad.Id == travels.Id)
                        .FirstOrDefault();

                entry.DurationDays = travels.DurationDays;
                entry.Destination = travels.Destination;
                entry.DepartureDate = travels.DepartureDate;
                dbContext.SaveChanges();
            }
        }
       
        #region Accommodation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="travelID"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accommodation"></param>
        public void UpdateAccomodation(Accommodation accommodation)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Accommodations
                        .Where(ad => ad.Id == accommodation.Id)
                        .FirstOrDefault();

                entry.Amount = accommodation.Amount;
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Airline Expense
        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnTicket"></param>
        /// <param name="amount"></param>
        /// <param name="travelID"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="airline"></param>
        public void UpdateAirline(AirlineExpens airline)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.AirlineExpenses
                        .Where(ad => ad.Id == airline.Id)
                        .FirstOrDefault();

                entry.Amount = airline.Amount;
                entry.ReturnTicket = airline.ReturnTicket;
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Allowance
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="travelID"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="allowance"></param>
        public void UpdateAllowance(Allowance allowance)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Allowances
                        .Where(ad => ad.Id == allowance.Id)
                        .FirstOrDefault();

                entry.Amount = allowance.Amount;
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Car Expense
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UPFleet"></param>
        /// <param name="amount"></param>
        /// <param name="travelID"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="car"></param>
        public void UpdateCarExpense(CarExpens car)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.CarExpenses
                        .Where(ad => ad.Id == car.Id)
                        .FirstOrDefault();

                entry.Amount = car.Amount;
                entry.UP_Fleet = car.UP_Fleet;
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Gautrain
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="travelID"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gautrain"></param>
        public void UpdateGautrainExpense(Gautrain gautrain)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Gautrains
                        .Where(ad => ad.Id == gautrain.Id)
                        .FirstOrDefault();

                entry.Amount = gautrain.Amount;
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Visa
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="travelID"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="visa"></param>
        public void UpdateVisaExpense(Visa visa)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.Visas
                        .Where(ad => ad.Id == visa.Id)
                        .FirstOrDefault();

                entry.Amount = visa.Amount;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        public void UpdatePostLevel(PostLevel post)
        {
            using (var dbContext = new dboEntities())
            {
                var entry = dbContext.PostLevels
                        .Where(ad => ad.Id == post.Id)
                        .FirstOrDefault();

                entry.Description = post.Description;
                entry.AnnualSalary = post.AnnualSalary;
                dbContext.SaveChanges();
            }
        }
        #endregion

    }
}