using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace fyp_project.Models;

public partial class WorkforceManagementDbContext : DbContext
{
    public WorkforceManagementDbContext()
    {
    }

    public WorkforceManagementDbContext(DbContextOptions<WorkforceManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgreementRule> AgreementRules { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<BusinessOwner> BusinessOwners { get; set; }

    public virtual DbSet<CustomerPayment> CustomerPayments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeAllocation> EmployeeAllocations { get; set; }

    public virtual DbSet<ForecastingDatum> ForecastingData { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<OrganizationContract> OrganizationContracts { get; set; }

    public virtual DbSet<OrganizationCustomer> OrganizationCustomers { get; set; }

    public virtual DbSet<OrganizationInvoice> OrganizationInvoices { get; set; }

    public virtual DbSet<OrganizationManager> OrganizationManagers { get; set; }

    public virtual DbSet<OrganizationPayout> OrganizationPayouts { get; set; }

    public virtual DbSet<OrganizationServiceUsage> OrganizationServiceUsages { get; set; }

    public virtual DbSet<PerformanceMetric> PerformanceMetrics { get; set; }

    public virtual DbSet<ResourceRequest> ResourceRequests { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ServiceSession> ServiceSessions { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WorkforceManagementDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgreementRule>(entity =>
        {
            entity.HasKey(e => e.RuleId).HasName("PK__Agreemen__E92A9296663D12E7");

            entity.Property(e => e.RuleId).HasColumnName("rule_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.RuleType)
                .HasMaxLength(100)
                .HasColumnName("rule_type");
            entity.Property(e => e.RuleValue).HasColumnName("rule_value");

            entity.HasOne(d => d.Organization).WithMany(p => p.AgreementRules)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Agreement__organ__7B5B524B");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__20D6A968966AEB1F");

            entity.ToTable("Attendance");

            entity.Property(e => e.AttendanceId).HasColumnName("attendance_id");
            entity.Property(e => e.CheckIn)
                .HasPrecision(0)
                .HasColumnName("check_in");
            entity.Property(e => e.CheckOut)
                .HasPrecision(0)
                .HasColumnName("check_out");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.WorkingHours)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("working_hours");

            entity.HasOne(d => d.Employee).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__emplo__1DB06A4F");

            entity.HasOne(d => d.Organization).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__organ__1EA48E88");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__AuditLog__9E2397E009D2CF95");

            entity.Property(e => e.LogId).HasColumnName("log_id");
            entity.Property(e => e.Action)
                .HasMaxLength(200)
                .HasColumnName("action");
            entity.Property(e => e.EntityId).HasColumnName("entity_id");
            entity.Property(e => e.EntityType)
                .HasMaxLength(100)
                .HasColumnName("entity_type");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(45)
                .HasColumnName("ip_address");
            entity.Property(e => e.Timestamp)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AuditLogs__user___5D95E53A");
        });

        modelBuilder.Entity<BusinessOwner>(entity =>
        {
            entity.HasKey(e => e.OwnerId).HasName("PK__Business__3C4FBEE4F0CEBBC0");

            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Designation)
                .HasMaxLength(100)
                .HasColumnName("designation");
            entity.Property(e => e.OwnershipPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("ownership_percentage");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.BusinessOwners)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BusinessO__user___6B24EA82");
        });

        modelBuilder.Entity<CustomerPayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Customer__ED1FC9EAFBBD65DE");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.ServiceSessionId).HasColumnName("service_session_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TransactionReference)
                .HasMaxLength(200)
                .HasColumnName("transaction_reference");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerPayments)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerP__custo__3B40CD36");

            entity.HasOne(d => d.Organization).WithMany(p => p.CustomerPayments)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerP__organ__3C34F16F");

            entity.HasOne(d => d.ServiceSession).WithMany(p => p.CustomerPayments)
                .HasForeignKey(d => d.ServiceSessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerP__servi__3D2915A8");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__C52E0BA8EF1F2CCF");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.AvailabilityStatus)
                .HasMaxLength(50)
                .HasColumnName("availability_status");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrentOrganizationId).HasColumnName("current_organization_id");
            entity.Property(e => e.EmployeeType)
                .HasMaxLength(50)
                .HasColumnName("employee_type");
            entity.Property(e => e.HourlyRate)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("hourly_rate");
            entity.Property(e => e.IsInSharedPool).HasColumnName("is_in_shared_pool");
            entity.Property(e => e.PersonaType)
                .HasMaxLength(100)
                .HasColumnName("persona_type");
            entity.Property(e => e.Picture).HasColumnName("picture");
            entity.Property(e => e.ProficiencyLevel).HasColumnName("proficiency_level");
            entity.Property(e => e.Rating)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("rating");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.CurrentOrganization).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CurrentOrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__curre__02084FDA");

            entity.HasOne(d => d.User).WithMany(p => p.Employees)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__user___01142BA1");
        });

        modelBuilder.Entity<EmployeeAllocation>(entity =>
        {
            entity.HasKey(e => e.AllocationId).HasName("PK__Employee__5DFAFF30C57FD69F");

            entity.Property(e => e.AllocationId).HasColumnName("allocation_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EndTime)
                .HasPrecision(0)
                .HasColumnName("end_time");
            entity.Property(e => e.FromOrgId).HasColumnName("from_org_id");
            entity.Property(e => e.HourlyWage)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("hourly_wage");
            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.StartTime)
                .HasPrecision(0)
                .HasColumnName("start_time");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.ToOrgId).HasColumnName("to_org_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeAllocations)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeA__emplo__114A936A");

            entity.HasOne(d => d.FromOrg).WithMany(p => p.EmployeeAllocationFromOrgs)
                .HasForeignKey(d => d.FromOrgId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeA__from___1332DBDC");

            entity.HasOne(d => d.Request).WithMany(p => p.EmployeeAllocations)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeA__reque__123EB7A3");

            entity.HasOne(d => d.ToOrg).WithMany(p => p.EmployeeAllocationToOrgs)
                .HasForeignKey(d => d.ToOrgId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeA__to_or__14270015");
        });

        modelBuilder.Entity<ForecastingDatum>(entity =>
        {
            entity.HasKey(e => e.DataId).HasName("PK__Forecast__F5A76B3BA85D973E");

            entity.Property(e => e.DataId).HasColumnName("data_id");
            entity.Property(e => e.ActualStaff).HasColumnName("actual_staff");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Hour).HasColumnName("hour");
            entity.Property(e => e.IncomingDemand).HasColumnName("incoming_demand");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.RequiredStaff).HasColumnName("required_staff");

            entity.HasOne(d => d.Organization).WithMany(p => p.ForecastingData)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Forecasti__organ__489AC854");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__E059842F6515F482");

            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.IsRead).HasColumnName("is_read");
            entity.Property(e => e.Message)
                .HasMaxLength(1000)
                .HasColumnName("message");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__user___59C55456");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.OrganizationId).HasName("PK__Organiza__C0B2F4321C9B8E16");

            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("address");
            entity.Property(e => e.ContractEndDate).HasColumnName("contract_end_date");
            entity.Property(e => e.ContractStartDate).HasColumnName("contract_start_date");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.OrgName)
                .HasMaxLength(200)
                .HasColumnName("org_name");
            entity.Property(e => e.OrgType)
                .HasMaxLength(100)
                .HasColumnName("org_type");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .HasColumnName("phone");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        modelBuilder.Entity<OrganizationContract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PK__Organiza__F8D664233093295C");

            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.AgreedPersonaTypes)
                .HasMaxLength(500)
                .HasColumnName("agreed_persona_types");
            entity.Property(e => e.BillingRatePerHour)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("billing_rate_per_hour");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.MaxSharedEmployees).HasColumnName("max_shared_employees");
            entity.Property(e => e.MinFixedEmployees).HasColumnName("min_fixed_employees");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.ServiceClauses).HasColumnName("service_clauses");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.Organization).WithMany(p => p.OrganizationContracts)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Organizat__organ__74AE54BC");
        });

        modelBuilder.Entity<OrganizationCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Organiza__CD65CB855F9C44FB");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerType)
                .HasMaxLength(50)
                .HasColumnName("customer_type");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(150)
                .HasColumnName("full_name");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .HasColumnName("phone");

            entity.HasOne(d => d.Organization).WithMany(p => p.OrganizationCustomers)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Organizat__organ__29221CFB");
        });

        modelBuilder.Entity<OrganizationInvoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Organiza__F58DFD49E1FA7864");

            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.BillingMonth).HasColumnName("billing_month");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_amount");
            entity.Property(e => e.TotalHours)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_hours");

            entity.HasOne(d => d.Organization).WithMany(p => p.OrganizationInvoices)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Organizat__organ__3587F3E0");
        });

        modelBuilder.Entity<OrganizationManager>(entity =>
        {
            entity.HasKey(e => e.OrgManagerId).HasName("PK__Organiza__41C9D5AE7FF4714C");

            entity.Property(e => e.OrgManagerId).HasColumnName("org_manager_id");
            entity.Property(e => e.ContactNo)
                .HasMaxLength(30)
                .HasColumnName("contact_no");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Designation)
                .HasMaxLength(100)
                .HasColumnName("designation");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Organization).WithMany(p => p.OrganizationManagers)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Organizat__organ__70DDC3D8");

            entity.HasOne(d => d.User).WithMany(p => p.OrganizationManagers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Organizat__user___6FE99F9F");
        });

        modelBuilder.Entity<OrganizationPayout>(entity =>
        {
            entity.HasKey(e => e.PayoutId).HasName("PK__Organiza__3B0771EC517D6C9F");

            entity.Property(e => e.PayoutId).HasColumnName("payout_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.PayoutAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("payout_amount");
            entity.Property(e => e.PayoutDate).HasColumnName("payout_date");
            entity.Property(e => e.PlatformCommission)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("platform_commission");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TotalCollectedAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_collected_amount");

            entity.HasOne(d => d.Organization).WithMany(p => p.OrganizationPayouts)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Organizat__organ__41EDCAC5");
        });

        modelBuilder.Entity<OrganizationServiceUsage>(entity =>
        {
            entity.HasKey(e => e.UsageId).HasName("PK__Organiza__B6B13A02DC0C0773");

            entity.ToTable("OrganizationServiceUsage");

            entity.Property(e => e.UsageId).HasColumnName("usage_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.HoursWorked)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("hours_worked");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.PeriodEnd).HasColumnName("period_end");
            entity.Property(e => e.PeriodStart).HasColumnName("period_start");
            entity.Property(e => e.RatePerHour)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("rate_per_hour");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_amount");

            entity.HasOne(d => d.Employee).WithMany(p => p.OrganizationServiceUsages)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Organizat__emplo__2DE6D218");

            entity.HasOne(d => d.Organization).WithMany(p => p.OrganizationServiceUsages)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Organizat__organ__2CF2ADDF");
        });

        modelBuilder.Entity<PerformanceMetric>(entity =>
        {
            entity.HasKey(e => e.MetricId).HasName("PK__Performa__13D5DCA48FAD586A");

            entity.Property(e => e.MetricId).HasColumnName("metric_id");
            entity.Property(e => e.AttendanceRate)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("attendance_rate");
            entity.Property(e => e.AvgRating)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("avg_rating");
            entity.Property(e => e.CalculatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("calculated_at");
            entity.Property(e => e.EfficiencyScore)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("efficiency_score");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.TasksCompleted).HasColumnName("tasks_completed");

            entity.HasOne(d => d.Employee).WithMany(p => p.PerformanceMetrics)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Performan__emplo__503BEA1C");

            entity.HasOne(d => d.Organization).WithMany(p => p.PerformanceMetrics)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Performan__organ__51300E55");
        });

        modelBuilder.Entity<ResourceRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Resource__18D3B90F4C4920C4");

            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.EndTime)
                .HasPrecision(0)
                .HasColumnName("end_time");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.PersonaType)
                .HasMaxLength(100)
                .HasColumnName("persona_type");
            entity.Property(e => e.RequiredCount).HasColumnName("required_count");
            entity.Property(e => e.StartTime)
                .HasPrecision(0)
                .HasColumnName("start_time");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.Organization).WithMany(p => p.ResourceRequests)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ResourceR__organ__0B91BA14");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__760965CC4BF29E46");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__783254B1D69495C6").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<ServiceSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__ServiceS__69B13FDC51886573");

            entity.Property(e => e.SessionId).HasColumnName("session_id");
            entity.Property(e => e.CustomerType)
                .HasMaxLength(50)
                .HasColumnName("customer_type");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EndTime)
                .HasPrecision(0)
                .HasColumnName("end_time");
            entity.Property(e => e.Notes)
                .HasMaxLength(1000)
                .HasColumnName("notes");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.PerformanceRating)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("performance_rating");
            entity.Property(e => e.PersonaType)
                .HasMaxLength(100)
                .HasColumnName("persona_type");
            entity.Property(e => e.StartTime)
                .HasPrecision(0)
                .HasColumnName("start_time");

            entity.HasOne(d => d.Employee).WithMany(p => p.ServiceSessions)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ServiceSe__emplo__22751F6C");

            entity.HasOne(d => d.Organization).WithMany(p => p.ServiceSessions)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ServiceSe__organ__236943A5");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK__Shifts__7B267220346B9A9F");

            entity.Property(e => e.ShiftId).HasColumnName("shift_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.EndTime)
                .HasPrecision(0)
                .HasColumnName("end_time");
            entity.Property(e => e.OrganizationId).HasColumnName("organization_id");
            entity.Property(e => e.RequiredPersonas)
                .HasMaxLength(500)
                .HasColumnName("required_personas");
            entity.Property(e => e.ShiftName)
                .HasMaxLength(100)
                .HasColumnName("shift_name");
            entity.Property(e => e.StartTime)
                .HasPrecision(0)
                .HasColumnName("start_time");

            entity.HasOne(d => d.Organization).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Shifts__organiza__19DFD96B");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__Skills__FBBA83792F11A13C");

            entity.Property(e => e.SkillId).HasColumnName("skill_id");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .HasColumnName("category");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.SkillName)
                .HasMaxLength(150)
                .HasColumnName("skill_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F164742B7");

            entity.HasIndex(e => e.Cnic, "UQ__Users__35BD76A4F84B776B").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E616440250D61").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Cnic)
                .HasMaxLength(20)
                .HasColumnName("cnic");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(150)
                .HasColumnName("full_name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastLogin)
                .HasPrecision(0)
                .HasColumnName("last_login");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(500)
                .HasColumnName("password_hash");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__role_id__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
