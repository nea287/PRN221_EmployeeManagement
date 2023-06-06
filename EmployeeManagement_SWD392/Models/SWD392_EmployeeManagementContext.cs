using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeManagement_SWD392.Models
{
    public partial class SWD392_EmployeeManagementContext : DbContext
    {
        public SWD392_EmployeeManagementContext()
        {
        }

        public SWD392_EmployeeManagementContext(DbContextOptions<SWD392_EmployeeManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Achievement> Achievements { get; set; } = null!;
        public virtual DbSet<Allowance> Allowances { get; set; } = null!;
        public virtual DbSet<AllowanceType> AllowanceTypes { get; set; } = null!;
        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Benefit> Benefits { get; set; } = null!;
        public virtual DbSet<BenefitType> BenefitTypes { get; set; } = null!;
        public virtual DbSet<DateReport> DateReports { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Director> Directors { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Leave> Leaves { get; set; } = null!;
        public virtual DbSet<LeaveType> LeaveTypes { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<MonthReport> MonthReports { get; set; } = null!;
        public virtual DbSet<Performance> Performances { get; set; } = null!;
        public virtual DbSet<Plan> Plans { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RuleAward> RuleAwards { get; set; } = null!;
        public virtual DbSet<RuleDisciplinary> RuleDisciplinaries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS01;uid=sa;pwd=1234;database=SWD392_EmployeeManagement");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RoleCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.Username)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Account_Employee");

                entity.HasOne(d => d.RoleCodeNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleCode)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.HasKey(e => e.AchievementCode);

                entity.ToTable("Achievement");

                entity.Property(e => e.AchievementCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AchievementName).HasMaxLength(100);

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Achievements)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Achievement_Employee");
            });

            modelBuilder.Entity<Allowance>(entity =>
            {
                entity.ToTable("Allowance");

                entity.Property(e => e.AllowanceId).HasColumnName("AllowanceID");

                entity.Property(e => e.AllowanceDate).HasColumnType("date");

                entity.Property(e => e.AllowanceTypeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AllowanceTypeID");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Remarks).HasMaxLength(250);

                entity.HasOne(d => d.AllowanceType)
                    .WithMany(p => p.Allowances)
                    .HasForeignKey(d => d.AllowanceTypeId)
                    .HasConstraintName("FK_Allowance_AllowanceType");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Allowances)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Allowance_Employee");
            });

            modelBuilder.Entity<AllowanceType>(entity =>
            {
                entity.ToTable("AllowanceType");

                entity.Property(e => e.AllowanceTypeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AllowanceTypeID");

                entity.Property(e => e.AllowanceAmount).HasColumnType("money");

                entity.Property(e => e.AllowanceTypeDescription).HasMaxLength(250);

                entity.Property(e => e.AllowanceTypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasKey(e => new { e.Date, e.EmployeeId });

                entity.ToTable("Attendance");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Remarks).HasMaxLength(250);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attendance_Employee");

                entity.HasOne(d => d.LeaveTypeNavigation)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.LeaveType)
                    .HasConstraintName("FK_Attendance_LeaveType");
            });

            modelBuilder.Entity<Benefit>(entity =>
            {
                entity.ToTable("Benefit");

                entity.Property(e => e.BenefitId).HasColumnName("BenefitID");

                entity.Property(e => e.BenefitTypeId).HasColumnName("BenefitTypeID");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.ReceivedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.BenefitType)
                    .WithMany(p => p.Benefits)
                    .HasForeignKey(d => d.BenefitTypeId)
                    .HasConstraintName("FK_Benefit_BenefitType");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Benefits)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Benefit_Employee");
            });

            modelBuilder.Entity<BenefitType>(entity =>
            {
                entity.ToTable("BenefitType");

                entity.Property(e => e.BenefitTypeId).HasColumnName("BenefitTypeID");

                entity.Property(e => e.BenefitAmount).HasColumnType("money");

                entity.Property(e => e.BenefitTypeName).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(250);
            });

            modelBuilder.Entity<DateReport>(entity =>
            {
                entity.HasKey(e => e.Date);

                entity.ToTable("DateReport");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.RuleAwardId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RuleAwardID");

                entity.Property(e => e.RuleDisciplinaryId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RuleDisciplinaryID");

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.DateReports)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_DateReport_Employee");

                entity.HasOne(d => d.RuleAward)
                    .WithMany(p => p.DateReports)
                    .HasForeignKey(d => d.RuleAwardId)
                    .HasConstraintName("FK_DateReport_RuleAward");

                entity.HasOne(d => d.RuleDisciplinary)
                    .WithMany(p => p.DateReports)
                    .HasForeignKey(d => d.RuleDisciplinaryId)
                    .HasConstraintName("FK_DateReport_RuleDisciplinary");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName).HasMaxLength(150);

                entity.Property(e => e.DirectorId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DirectorID");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("FK_Department_Director");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("Director");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.Director)
                    .HasForeignKey<Director>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Director_Employee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.BankAccount)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Birthdate).HasColumnType("datetime");

                entity.Property(e => e.Coach).HasMaxLength(200);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.DateOfHide).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DepartmentID");

                entity.Property(e => e.EmployeeAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName).HasMaxLength(150);

                entity.Property(e => e.Mail)
                    .HasMaxLength(320)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Employee_Department");
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.ToTable("Leave");

                entity.Property(e => e.LeaveId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LeaveID");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Leave_Employee");

                entity.HasOne(d => d.LeaveTypeNavigation)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.LeaveType)
                    .HasConstraintName("FK_Leave_LeaveType");
            });

            modelBuilder.Entity<LeaveType>(entity =>
            {
                entity.HasKey(e => e.LeaveType1);

                entity.ToTable("LeaveType");

                entity.Property(e => e.LeaveType1).HasColumnName("LeaveType");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.LeaveTypeName).HasMaxLength(150);

                entity.Property(e => e.Penalty).HasColumnType("money");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("Manager");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.DepartmentId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DepartmentID");

                entity.Property(e => e.DirectorId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DirectorID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Manager_Department");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("FK_Manager_Director");
            });

            modelBuilder.Entity<MonthReport>(entity =>
            {
                entity.HasKey(e => e.Month);

                entity.ToTable("MonthReport");

                entity.Property(e => e.Month)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.FinalSalary).HasColumnType("money");

                entity.Property(e => e.Fine).HasColumnType("money");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.MonthReports)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_MonthReport_Employee");
            });

            modelBuilder.Entity<Performance>(entity =>
            {
                entity.ToTable("Performance");

                entity.Property(e => e.PerformanceId)
                    .HasMaxLength(50)
                    .HasColumnName("PerformanceID");

                entity.Property(e => e.DatePerf).HasColumnType("date");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Performances)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Performance_Employee");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.PlanCode);

                entity.ToTable("Plan");

                entity.Property(e => e.PlanCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Deadline).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.StartedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Plan_Employee");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleCode);

                entity.ToTable("Role");

                entity.Property(e => e.RoleCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName).HasMaxLength(150);
            });

            modelBuilder.Entity<RuleAward>(entity =>
            {
                entity.ToTable("RuleAward");

                entity.Property(e => e.RuleAwardId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RuleAwardID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RuleAwardName).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RuleDisciplinary>(entity =>
            {
                entity.ToTable("RuleDisciplinary");

                entity.Property(e => e.RuleDisciplinaryId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RuleDisciplinaryID");

                entity.Property(e => e.RuleDisciplinaryName).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
