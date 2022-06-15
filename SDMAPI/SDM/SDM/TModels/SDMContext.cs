using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SDM.TModels
{
    public partial class SDMContext : DbContext
    {
        public SDMContext()
        {
        }

        public SDMContext(DbContextOptions<SDMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankMasterEntry> BankMasterEntry { get; set; }
        public virtual DbSet<CostCenterMaster> CostCenterMaster { get; set; }
        public virtual DbSet<CreditCardMaster> CreditCardMaster { get; set; }
        public virtual DbSet<CurrencyType> CurrencyType { get; set; }
        public virtual DbSet<CustomerMaster> CustomerMaster { get; set; }
        public virtual DbSet<DepartmentMaster> DepartmentMaster { get; set; }
        public virtual DbSet<DesignationMaster> DesignationMaster { get; set; }
        public virtual DbSet<EmployeeMaster> EmployeeMaster { get; set; }
        public virtual DbSet<ExpenseCategory> ExpenseCategory { get; set; }
        public virtual DbSet<GenderMaster> GenderMaster { get; set; }
        public virtual DbSet<InsuranceMaster> InsuranceMaster { get; set; }
        public virtual DbSet<SalaryPaidMaster> SalaryPaidMaster { get; set; }
        public virtual DbSet<SubAccountMaster> SubAccountMaster { get; set; }
        public virtual DbSet<SupplierMaster> SupplierMaster { get; set; }
        public virtual DbSet<TransactionEntry> TransactionEntry { get; set; }
        public virtual DbSet<VehicleMaster> VehicleMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-20Q2S9O;Initial Catalog=SDM;TrustServerCertificate = True; MultipleActiveResultSets=true;Trusted_Connection = True;Connection Timeout=30000;ConnectRetryCount=255;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankMasterEntry>(entity =>
            {
                entity.HasKey(e => e.BnkId)
                    .HasName("PK__Bank_Mas__0868EDDCB7751574");

                entity.ToTable("Bank_Master_Entry");

                entity.Property(e => e.BnkId).HasColumnName("bnk_Id");

                entity.Property(e => e.BnkAccName)
                    .HasColumnName("bnk_Acc_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BnkAccNo)
                    .HasColumnName("bnk_AccNo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BnkAccountCcy).HasColumnName("bnk_Account_Ccy");

                entity.Property(e => e.BnkAddress)
                    .HasColumnName("bnk_Address")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BnkCode)
                    .HasColumnName("bnk_Code")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BnkCreatedBy).HasColumnName("bnk_CreatedBy");

                entity.Property(e => e.BnkCreatedDate)
                    .HasColumnName("bnk_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.BnkCreditOrDebit)
                    .HasColumnName("bnk_Credit_Or_Debit")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BnkCreditOrDebit2)
                    .HasColumnName("bnk_Credit_Or_Debit2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BnkCreditOrDebit3)
                    .HasColumnName("bnk_Credit_Or_Debit3")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BnkCreditOrDebit4)
                    .HasColumnName("bnk_Credit_Or_Debit4")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BnkCreditOrDebit5)
                    .HasColumnName("bnk_Credit_Or_Debit5")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BnkDeletedBy).HasColumnName("bnk_DeletedBy");

                entity.Property(e => e.BnkDeletedDate)
                    .HasColumnName("bnk_DeletedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.BnkIbanNumb)
                    .HasColumnName("bnk_IBAN_Numb")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BnkName)
                    .HasColumnName("bnk_Name")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BnkOthers1)
                    .HasColumnName("bnk_Others1")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BnkSwiftCode)
                    .HasColumnName("bnk_Swift_Code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BnkUpdatedBy).HasColumnName("bnk_UpdatedBy");

                entity.Property(e => e.BnkUpdatedDate)
                    .HasColumnName("bnk_UpdatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rm1Contact)
                    .HasColumnName("rm1_Contact")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rm1Email)
                    .HasColumnName("rm1_Email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rm1Name)
                    .HasColumnName("rm1_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rm2Contact)
                    .HasColumnName("rm2_Contact")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rm2Email)
                    .HasColumnName("rm2_Email")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Rm2Name)
                    .HasColumnName("rm2_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RmContact)
                    .HasColumnName("rm_Contact")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RmEmail)
                    .HasColumnName("rm_Email")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RmName)
                    .HasColumnName("rm_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CostCenterMaster>(entity =>
            {
                entity.HasKey(e => e.CsId)
                    .HasName("PK__Cost_Cen__138D51DC034C0B49");

                entity.ToTable("Cost_Center_Master");

                entity.Property(e => e.CsId).HasColumnName("cs_Id");

                entity.Property(e => e.CsCode)
                    .IsRequired()
                    .HasColumnName("cs_Code")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CsCountry)
                    .HasColumnName("cs_Country")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CsCreatedBy).HasColumnName("cs_CreatedBy");

                entity.Property(e => e.CsCreatedDate)
                    .HasColumnName("cs_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CsDeletedBy).HasColumnName("cs_DeletedBy");

                entity.Property(e => e.CsDeletedDate)
                    .HasColumnName("cs_DeletedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CsLocation)
                    .HasColumnName("cs_Location")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CsName)
                    .IsRequired()
                    .HasColumnName("cs_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CsOthers1)
                    .HasColumnName("cs_Others1")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CsUpdatedBy).HasColumnName("cs_UpdatedBy");

                entity.Property(e => e.CsUpdatedDate)
                    .HasColumnName("cs_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<CreditCardMaster>(entity =>
            {
                entity.HasKey(e => e.CcId)
                    .HasName("PK__Credit_C__9F1D07A318C54EE4");

                entity.ToTable("Credit_Card_Master");

                entity.Property(e => e.CcId).HasColumnName("cc_Id");

                entity.Property(e => e.CcBnkCode)
                    .HasColumnName("cc_Bnk_Code")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CcBnkName)
                    .HasColumnName("cc_Bnk_Name")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CcCreatedBy).HasColumnName("cc_CreatedBy");

                entity.Property(e => e.CcCreatedDate)
                    .HasColumnName("cc_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CcDeletedBy).HasColumnName("cc_DeletedBy");

                entity.Property(e => e.CcDeletedDate)
                    .HasColumnName("cc_DeletedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CcExpDt)
                    .HasColumnName("cc_Exp_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CcNumber)
                    .HasColumnName("cc_Number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CcOwnerName)
                    .HasColumnName("cc_Owner_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CcUpdatedBy).HasColumnName("cc_UpdatedBy");

                entity.Property(e => e.CcUpdatedDate)
                    .HasColumnName("cc_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<CurrencyType>(entity =>
            {
                entity.HasKey(e => e.CtId)
                    .HasName("PK__Currency__33D771110037810E");

                entity.ToTable("Currency_Type");

                entity.Property(e => e.CtId).HasColumnName("ct_Id");

                entity.Property(e => e.CtCreatedBy).HasColumnName("ct_CreatedBy");

                entity.Property(e => e.CtCreatedDate)
                    .HasColumnName("ct_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CtDeletedBy).HasColumnName("ct_DeletedBy");

                entity.Property(e => e.CtDeletedDate)
                    .HasColumnName("ct_DeletedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CtName)
                    .HasColumnName("ct_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CtUpdatedBy).HasColumnName("ct_UpdatedBy");

                entity.Property(e => e.CtUpdatedDate)
                    .HasColumnName("ct_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<CustomerMaster>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK__Customer__A1B623A8BB85EF55");

                entity.ToTable("Customer_Master");

                entity.Property(e => e.CustId).HasColumnName("cust_Id");

                entity.Property(e => e.CustAddress)
                    .HasColumnName("cust_Address")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CustContact)
                    .HasColumnName("cust_Contact")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustContactMobile)
                    .HasColumnName("cust_Contact_Mobile")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustCreatedBy).HasColumnName("cust_CreatedBy");

                entity.Property(e => e.CustCreatedDate)
                    .HasColumnName("cust_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustDeletedBy).HasColumnName("cust_DeletedBy");

                entity.Property(e => e.CustDeletedDate)
                    .HasColumnName("cust_DeletedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustEmail)
                    .HasColumnName("cust_Email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustFax)
                    .HasColumnName("cust_Fax")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustLandLine)
                    .HasColumnName("cust_LandLine")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustName)
                    .IsRequired()
                    .HasColumnName("cust_Name")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CustOthers1)
                    .HasColumnName("cust_Others1")
                    .IsUnicode(false);

                entity.Property(e => e.CustPhone)
                    .HasColumnName("cust_Phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustTrnOrVatNo)
                    .HasColumnName("cust_Trn_Or_Vat_No")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustUpdatedBy).HasColumnName("cust_UpdatedBy");

                entity.Property(e => e.CustUpdatedDate)
                    .HasColumnName("cust_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DepartmentMaster>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("PK__Departme__BB4CBBE0565C6D55");

                entity.ToTable("Department_Master");

                entity.Property(e => e.DepId).HasColumnName("dep_Id");

                entity.Property(e => e.DepCreatedBy).HasColumnName("dep_CreatedBy");

                entity.Property(e => e.DepCreatedDate)
                    .HasColumnName("dep_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepDeletedBy).HasColumnName("dep_DeletedBy");

                entity.Property(e => e.DepDeletedDate)
                    .HasColumnName("dep_DeletedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepName)
                    .IsRequired()
                    .HasColumnName("dep_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DepUpdatedBy).HasColumnName("dep_UpdatedBy");

                entity.Property(e => e.DepUpdatedDate)
                    .HasColumnName("dep_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DesignationMaster>(entity =>
            {
                entity.HasKey(e => e.DesId)
                    .HasName("PK__Designat__92C8691A416A5E08");

                entity.ToTable("Designation_Master");

                entity.Property(e => e.DesId).HasColumnName("des_Id");

                entity.Property(e => e.DesCreatedBy).HasColumnName("des_CreatedBy");

                entity.Property(e => e.DesCreatedDate)
                    .HasColumnName("des_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DesDeletedBy).HasColumnName("des_DeletedBy");

                entity.Property(e => e.DesDeletedDate)
                    .HasColumnName("des_DeletedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DesName)
                    .IsRequired()
                    .HasColumnName("des_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DesUpdatedBy).HasColumnName("des_UpdatedBy");

                entity.Property(e => e.DesUpdatedDate)
                    .HasColumnName("des_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<EmployeeMaster>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__12854529DDAA79FA");

                entity.ToTable("Employee_Master");

                entity.Property(e => e.EmpId).HasColumnName("emp_Id");

                entity.Property(e => e.EmpAirTicket)
                    .HasColumnName("emp_Air_Ticket")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EmpAssetsGiven)
                    .HasColumnName("emp_Assets_Given")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCode)
                    .IsRequired()
                    .HasColumnName("emp_Code")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCostCenter).HasColumnName("emp_Cost_Center");

                entity.Property(e => e.EmpCreatedBy).HasColumnName("emp_CreatedBy");

                entity.Property(e => e.EmpCreatedDate)
                    .HasColumnName("emp_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpDeletedBy).HasColumnName("emp_DeletedBy");

                entity.Property(e => e.EmpDeletedDate)
                    .HasColumnName("emp_DeletedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpDepartment)
                    .HasColumnName("emp_Department")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmpDesignation)
                    .HasColumnName("emp_Designation")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmpDob)
                    .HasColumnName("emp_Dob")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpEidExpDt)
                    .HasColumnName("emp_EID_exp_dt")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmpEidImageAttachment)
                    .HasColumnName("emp_EID_Image_Attachment")
                    .IsUnicode(false);

                entity.Property(e => e.EmpEidNo)
                    .HasColumnName("emp_EID_No")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmpEmailId)
                    .HasColumnName("emp_Email_ID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpEmployer)
                    .HasColumnName("emp_Employer")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EmpEmploymentEndDate)
                    .HasColumnName("emp_Employment_EndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpEmploymentStatus)
                    .HasColumnName("emp_Employment_Status")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EmpGenderId).HasColumnName("emp_GenderId");

                entity.Property(e => e.EmpHousingDetails)
                    .HasColumnName("emp_Housing_Details")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpJobLocation)
                    .HasColumnName("emp_Job_Location")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EmpJoiningDate)
                    .HasColumnName("emp_JoiningDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpLeaveBalance)
                    .HasColumnName("emp_Leave_Balance")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpLoansGiven)
                    .HasColumnName("emp_Loans_Given")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpMobileNumber)
                    .HasColumnName("emp_Mobile_Number")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmpMonthlySalary)
                    .HasColumnName("emp_MonthlySalary")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasColumnName("emp_Name")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmpNationality)
                    .HasColumnName("emp_Nationality")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmpOthers1)
                    .HasColumnName("emp_Others1")
                    .IsUnicode(false);

                entity.Property(e => e.EmpPhoto)
                    .HasColumnName("emp_Photo")
                    .IsUnicode(false);

                entity.Property(e => e.EmpPpExpirationDate)
                    .HasColumnName("emp_Pp_ExpirationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpPpImageAttachment)
                    .HasColumnName("emp_Pp_Image_Attachment")
                    .IsUnicode(false);

                entity.Property(e => e.EmpPpIssuedDate)
                    .HasColumnName("emp_Pp_IssuedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpPpNo)
                    .HasColumnName("emp_Pp_No")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EmpPrevVacationDetails)
                    .HasColumnName("emp_Prev_Vacation_Details")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpProbationPeriod)
                    .HasColumnName("emp_Probation_Period")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpSalaryPaid)
                    .HasColumnName("emp_SalaryPaid")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmpType)
                    .HasColumnName("emp_Type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpUpdatedBy).HasColumnName("emp_UpdatedBy");

                entity.Property(e => e.EmpUpdatedDate)
                    .HasColumnName("emp_UpdatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpVisaExpDt)
                    .HasColumnName("emp_Visa_Exp_Dt")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmpVisaImageAttachment)
                    .HasColumnName("emp_Visa_Image_Attachment")
                    .IsUnicode(false);

                entity.Property(e => e.EmpVisaIssuedFrom)
                    .HasColumnName("emp_Visa_Issued_From")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EmpVisaNo)
                    .HasColumnName("emp_Visa_No")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExpenseCategory>(entity =>
            {
                entity.HasKey(e => e.TrnId)
                    .HasName("PK__Expense___3E30CBC718433C62");

                entity.ToTable("Expense_Category");

                entity.Property(e => e.TrnId).HasColumnName("trn_Id");

                entity.Property(e => e.TrnCategory)
                    .HasColumnName("trn_Category")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TrnCreatedBy).HasColumnName("trn_CreatedBy");

                entity.Property(e => e.TrnCreatedDate)
                    .HasColumnName("trn_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TrnDeletedBy).HasColumnName("trn_DeletedBy");

                entity.Property(e => e.TrnDeletedDate)
                    .HasColumnName("trn_deletedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TrnUpdatedBy).HasColumnName("trn_UpdatedBy");

                entity.Property(e => e.TrnUpdatedDate)
                    .HasColumnName("trn_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<GenderMaster>(entity =>
            {
                entity.HasKey(e => e.GenId)
                    .HasName("PK__Gender_M__7263C303BD4F369B");

                entity.ToTable("Gender_Master");

                entity.Property(e => e.GenId).HasColumnName("gen_Id");

                entity.Property(e => e.GenCreatedBy).HasColumnName("gen_CreatedBy");

                entity.Property(e => e.GenCreatedDate)
                    .HasColumnName("gen_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GenDeletedBy).HasColumnName("gen_DeletedBy");

                entity.Property(e => e.GenDeletedDate)
                    .HasColumnName("gen_DeletedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GenGender)
                    .IsRequired()
                    .HasColumnName("gen_Gender")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GenUpdatedBy).HasColumnName("gen_UpdatedBy");

                entity.Property(e => e.GenUpdatedDate)
                    .HasColumnName("gen_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<InsuranceMaster>(entity =>
            {
                entity.HasKey(e => e.InsId)
                    .HasName("PK__Insuranc__9CB02918B029C0AE");

                entity.ToTable("Insurance_Master");

                entity.Property(e => e.InsId).HasColumnName("ins_Id");

                entity.Property(e => e.InsCompany)
                    .HasColumnName("Ins_Company")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsCostCenter).HasColumnName("ins_Cost_Center");

                entity.Property(e => e.InsCreatedBy).HasColumnName("ins_CreatedBy");

                entity.Property(e => e.InsCreatedDate)
                    .HasColumnName("ins_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.InsDeletedBy).HasColumnName("ins_DeletedBy");

                entity.Property(e => e.InsDeletedDate)
                    .HasColumnName("ins_DeletedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.InsExpDate)
                    .HasColumnName("ins_Exp_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InsOthers1)
                    .HasColumnName("ins_Others1")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.InsPolicyNo)
                    .HasColumnName("ins_Policy_No")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.InsPremiumAmount)
                    .HasColumnName("ins_Premium_Amount")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsPurchaseAmount)
                    .HasColumnName("ins_Purchase_Amount")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsPurchaseDate)
                    .HasColumnName("ins_Purchase_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InsUpdatedBy).HasColumnName("ins_UpdatedBy");

                entity.Property(e => e.InsUpdatedDate)
                    .HasColumnName("ins_UpdatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.InsVehicleCode)
                    .HasColumnName("ins_Vehicle_Code")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.InsVehicleName)
                    .HasColumnName("ins_Vehicle_Name")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SalaryPaidMaster>(entity =>
            {
                entity.HasKey(e => e.SalId)
                    .HasName("PK__Salary_P__FEF21B40EF0B45AC");

                entity.ToTable("Salary_Paid_Master");

                entity.Property(e => e.SalId).HasColumnName("sal_Id");

                entity.Property(e => e.SalCreatedBy).HasColumnName("sal_CreatedBy");

                entity.Property(e => e.SalCreatedDate)
                    .HasColumnName("sal_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SalDeletedBy).HasColumnName("sal_DeletedBy");

                entity.Property(e => e.SalDeletedDate)
                    .HasColumnName("sal_DeletedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SalName)
                    .IsRequired()
                    .HasColumnName("sal_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalUpdatedBy).HasColumnName("sal_UpdatedBy");

                entity.Property(e => e.SalUpdatedDate)
                    .HasColumnName("sal_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<SubAccountMaster>(entity =>
            {
                entity.HasKey(e => e.PrpId)
                    .HasName("PK__Sub_Acco__DB0138390426525D");

                entity.ToTable("Sub_Account_Master");

                entity.Property(e => e.PrpId).HasColumnName("prp_Id");

                entity.Property(e => e.PrpContactPerson)
                    .HasColumnName("prp_Contact_Person")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrpContactPersonNumber)
                    .HasColumnName("prp_Contact_Person_Number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrpCostCentre).HasColumnName("prp_Cost_Centre");

                entity.Property(e => e.PrpCreatedBy).HasColumnName("prp_CreatedBy");

                entity.Property(e => e.PrpCreatedDate)
                    .HasColumnName("prp_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrpDeletedBy).HasColumnName("prp_DeletedBy");

                entity.Property(e => e.PrpDeletedDate)
                    .HasColumnName("prp_DeletedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrpDetails)
                    .HasColumnName("prp_Details")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PrpLocation)
                    .HasColumnName("prp_Location")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PrpName)
                    .HasColumnName("prp_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrpOthers1)
                    .HasColumnName("prp_Others1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrpOthers2)
                    .HasColumnName("prp_Others2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrpOthers3)
                    .HasColumnName("prp_Others3")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PrpShortName)
                    .HasColumnName("prp_Short_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrpUpdatedBy).HasColumnName("prp_UpdatedBy");

                entity.Property(e => e.PrpUpdatedDate)
                    .HasColumnName("prp_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<SupplierMaster>(entity =>
            {
                entity.HasKey(e => e.SupId)
                    .HasName("PK__Supplier__FB7184C7BA712BF8");

                entity.ToTable("Supplier_Master");

                entity.Property(e => e.SupId).HasColumnName("sup_Id");

                entity.Property(e => e.SupAddress)
                    .HasColumnName("sup_Address")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SupCode)
                    .HasColumnName("sup_Code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupCompanyName)
                    .HasColumnName("sup_Company_Name")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SupContactMobile)
                    .HasColumnName("sup_Contact_Mobile")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupContactPerson)
                    .HasColumnName("sup_Contact_Person")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupCreatedBy).HasColumnName("sup_CreatedBy");

                entity.Property(e => e.SupCreatedDate)
                    .HasColumnName("sup_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SupDeletedBy).HasColumnName("sup_DeletedBy");

                entity.Property(e => e.SupDeletedDate)
                    .HasColumnName("sup_DeletedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SupDetails)
                    .HasColumnName("sup_Details")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SupEmail)
                    .HasColumnName("sup_Email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupLandline)
                    .HasColumnName("sup_Landline")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupOthers1)
                    .HasColumnName("sup_Others1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupUpdatedBy).HasColumnName("sup_UpdatedBy");

                entity.Property(e => e.SupUpdatedDate)
                    .HasColumnName("sup_UpdatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SupVatNumb)
                    .HasColumnName("sup_Vat_Numb")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransactionEntry>(entity =>
            {
                entity.HasKey(e => e.TrnId)
                    .HasName("PK__Transact__3E30CBC7B85CF4E2");

                entity.ToTable("Transaction_Entry");

                entity.Property(e => e.TrnId).HasColumnName("trn_Id");

                entity.Property(e => e.TrnAccountnumber)
                    .HasColumnName("trn_Accountnumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrnAmount)
                    .HasColumnName("trn_Amount")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrnBankAccountNo).HasColumnName("trn_Bank_Account_No");

                entity.Property(e => e.TrnCategory).HasColumnName("trn_Category");

                entity.Property(e => e.TrnCostCentre).HasColumnName("trn_Cost_Centre");

                entity.Property(e => e.TrnCreatedBy).HasColumnName("trn_CreatedBy");

                entity.Property(e => e.TrnCreatedDate)
                    .HasColumnName("trn_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TrnCreditDebit).HasColumnName("trn_Credit_debit");

                entity.Property(e => e.TrnCurrency).HasColumnName("trn_Currency");

                entity.Property(e => e.TrnDate)
                    .HasColumnName("trn_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TrnDeletedBy).HasColumnName("trn_DeletedBy");

                entity.Property(e => e.TrnDeletedDate)
                    .HasColumnName("trn_deletedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TrnDetails)
                    .HasColumnName("trn_Details")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TrnEmployee).HasColumnName("trn_Employee");

                entity.Property(e => e.TrnFlag)
                    .HasColumnName("trn_Flag")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrnInstrumentNo)
                    .HasColumnName("trn_Instrument_No")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TrnInstrumentType).HasColumnName("trn_Instrument_Type");

                entity.Property(e => e.TrnInvNo)
                    .HasColumnName("trn_Inv_no")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TrnRemarks)
                    .HasColumnName("trn_Remarks")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TrnRequestBy)
                    .HasColumnName("trn_Request_By")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TrnSubAccount).HasColumnName("trn_Sub_Account");

                entity.Property(e => e.TrnSupplier).HasColumnName("trn_Supplier");

                entity.Property(e => e.TrnType).HasColumnName("trn_Type");

                entity.Property(e => e.TrnUpdatedBy).HasColumnName("trn_UpdatedBy");

                entity.Property(e => e.TrnUpdatedDate)
                    .HasColumnName("trn_UpdatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TrnVechile).HasColumnName("trn_Vechile");
            });

            modelBuilder.Entity<VehicleMaster>(entity =>
            {
                entity.HasKey(e => e.VhId)
                    .HasName("PK__Vehicle___9C5502CBD69F5A53");

                entity.ToTable("Vehicle_Master");

                entity.Property(e => e.VhId).HasColumnName("vh_Id");

                entity.Property(e => e.VhCode)
                    .HasColumnName("vh_Code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VhColour)
                    .HasColumnName("vh_Colour")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VhCostCentre).HasColumnName("vh_Cost_Centre");

                entity.Property(e => e.VhCreatedBy).HasColumnName("vh_CreatedBy");

                entity.Property(e => e.VhCreatedDate)
                    .HasColumnName("vh_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.VhDeletedBy).HasColumnName("vh_DeletedBy");

                entity.Property(e => e.VhDeletedDate)
                    .HasColumnName("vh_deletedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.VhDrivenBy)
                    .HasColumnName("vh_Driven_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VhEngineMake)
                    .HasColumnName("vh_Engine_Make")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VhEnginePower)
                    .HasColumnName("vh_Engine_Power")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VhEngineSerialNumber)
                    .HasColumnName("vh_Engine_Serial_Number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VhHullChassisNo)
                    .HasColumnName("vh_Hull_Chassis_No")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.VhImage)
                    .HasColumnName("vh_Image")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VhLocation)
                    .HasColumnName("vh_Location")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VhMakeBrand)
                    .HasColumnName("vh_Make_Brand")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VhModelYear)
                    .HasColumnName("vh_Model_Year")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VhName)
                    .HasColumnName("vh_Name")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VhNoOfCrew)
                    .HasColumnName("vh_No_Of_Crew")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VhNoOfEngines)
                    .HasColumnName("vh_No_Of_Engines")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VhNoOfPassengers)
                    .HasColumnName("vh_No_Of_Passengers")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VhOriginPlace)
                    .HasColumnName("vh_Origin_Place")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VhOthers1)
                    .HasColumnName("vh_Others1")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VhOthers2)
                    .HasColumnName("vh_Others2")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VhOthers3)
                    .HasColumnName("vh_Others3")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VhOthers4)
                    .HasColumnName("vh_OThers4")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VhPurchaseDt)
                    .HasColumnName("vh_Purchase_Dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.VhPurchaseValue)
                    .HasColumnName("vh_Purchase_Value")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VhPurchasedColor)
                    .HasColumnName("vh_Purchased_Color")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VhPurchasedFrom)
                    .HasColumnName("vh_Purchased_From")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VhRadioDeviceName)
                    .HasColumnName("vh_Radio_Device_Name")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VhRadioDeviceSno)
                    .HasColumnName("vh_Radio_Device_SNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VhRadioDeviceType)
                    .HasColumnName("vh_Radio_Device_Type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VhRegNo)
                    .HasColumnName("vh_Reg_No")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VhRegistrationExp)
                    .HasColumnName("vh_Registration_Exp")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VhSizeCapacity)
                    .HasColumnName("vh_Size_Capacity")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VhStatus)
                    .HasColumnName("vh_Status")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VhType)
                    .HasColumnName("vh_Type")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.VhTypeOfHull)
                    .HasColumnName("vh_Type_Of_Hull")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VhTypeOfPurchase)
                    .HasColumnName("vh_Type_Of_Purchase")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VhUpdatedBy).HasColumnName("vh_UpdatedBy");

                entity.Property(e => e.VhUpdatedDate)
                    .HasColumnName("vh_UpdatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.VhVehicleOn)
                    .HasColumnName("vh_Vehicle_On")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VhWeight)
                    .HasColumnName("vh_Weight")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
