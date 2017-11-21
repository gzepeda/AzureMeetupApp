using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;

namespace WebApiCore.Model.Data
{
    public partial class EmployeesContext : DbContext
    {
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<DeptEmp> DeptEmp { get; set; }
        public virtual DbSet<DeptManager> DeptManager { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Salaries> Salaries { get; set; }
        public virtual DbSet<Titles> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=127.0.0.1;User Id=root;Password=okidoki;Database=Employees");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DeptNo);

                entity.ToTable("departments");

                entity.HasIndex(e => e.DeptName)
                    .HasName("dept_name")
                    .IsUnique();

                entity.Property(e => e.DeptNo)
                    .HasColumnName("dept_no")
                    .HasColumnType("char(4)")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasColumnName("dept_name")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<DeptEmp>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.DeptNo });

                entity.ToTable("dept_emp");

                entity.HasIndex(e => e.DeptNo)
                    .HasName("dept_no");

                entity.Property(e => e.EmpNo)
                    .HasColumnName("emp_no")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeptNo)
                    .HasColumnName("dept_no")
                    .HasColumnType("char(4)");

                entity.Property(e => e.FromDate)
                    .HasColumnName("from_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ToDate)
                    .HasColumnName("to_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.DeptEmp)
                    .HasForeignKey(d => d.DeptNo)
                    .HasConstraintName("dept_emp_ibfk_2");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.DeptEmp)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("dept_emp_ibfk_1");
            });

            modelBuilder.Entity<DeptManager>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.DeptNo });

                entity.ToTable("dept_manager");

                entity.HasIndex(e => e.DeptNo)
                    .HasName("dept_no");

                entity.Property(e => e.EmpNo)
                    .HasColumnName("emp_no")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeptNo)
                    .HasColumnName("dept_no")
                    .HasColumnType("char(4)");

                entity.Property(e => e.FromDate)
                    .HasColumnName("from_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ToDate)
                    .HasColumnName("to_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.DeptManager)
                    .HasForeignKey(d => d.DeptNo)
                    .HasConstraintName("dept_manager_ibfk_2");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.DeptManager)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("dept_manager_ibfk_1");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpNo);

                entity.ToTable("employees");

                entity.Property(e => e.EmpNo)
                    .HasColumnName("emp_no")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(14);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender");
                //.HasColumnType("smallint(6)");
                EnumConventions(entity.Metadata, entity.Property(e => e.Gender).Metadata);

                entity.Property(e => e.HireDate)
                    .HasColumnName("hire_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<Salaries>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.FromDate });

                entity.ToTable("salaries");

                entity.Property(e => e.EmpNo)
                    .HasColumnName("emp_no")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FromDate)
                    .HasColumnName("from_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ToDate)
                    .HasColumnName("to_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("salaries_ibfk_1");
            });

            modelBuilder.Entity<Titles>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.Title, e.FromDate });

                entity.ToTable("titles");

                entity.Property(e => e.EmpNo)
                    .HasColumnName("emp_no")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.Property(e => e.FromDate)
                    .HasColumnName("from_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ToDate)
                    .HasColumnName("to_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.Titles)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("titles_ibfk_1");
            });
        }

        /// <summary>
        ///     Leverages MySql's enum type
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        public static void EnumConventions(IMutableEntityType entity, IMutableProperty property)
        {
            var typeInfo = property.ClrType.GetTypeInfo();
            if (typeInfo.IsEnum && typeInfo.GetCustomAttribute<FlagsAttribute>() == null)
            {
                property.Relational().ColumnType = property.ClrType.EnumTypeToMySqlEnum();
            }
        }
    }

    public static class Helper
    {
        public static string EnumTypeToMySqlEnum(this Type value)
        {
            return $"ENUM('{string.Join("','", Enum.GetNames(value))}')";
        }
    }
}
