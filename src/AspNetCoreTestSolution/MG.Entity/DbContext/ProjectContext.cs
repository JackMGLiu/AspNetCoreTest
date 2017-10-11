using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MG.Entity.DbContext
{
    public class ProjectContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<SysRole> SysRoles { get; set; }
        public DbSet<SysOrganize> SysOrganizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Account>().Property(p => p.EmailChecked).HasDefaultValue(false);
            modelBuilder.Entity<Account>().Property(p => p.PhoneChecked).HasDefaultValue(false);
            modelBuilder.Entity<Account>().Property(p => p.Sex).HasDefaultValue(0);
            modelBuilder.Entity<Account>().Property(p => p.Type).HasDefaultValue(0);
            modelBuilder.Entity<Account>().Property(p => p.Wallet).HasDefaultValue(0);
            modelBuilder.Entity<Account>().Property(p => p.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Account>().Property(p => p.CreateTime).HasDefaultValueSql("GETDATE()"); ;

            modelBuilder.Entity<SysRole>().ToTable("SysRole");
            modelBuilder.Entity<SysRole>().Property(p => p.AllowEdit).HasDefaultValue(true);
            modelBuilder.Entity<SysRole>().Property(p => p.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<SysRole>().Property(p => p.SortCode).HasDefaultValue(0);
            modelBuilder.Entity<SysRole>().Property(p => p.CreateTime).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<SysOrganize>().ToTable("SysOrganize");
            modelBuilder.Entity<SysOrganize>().Property(p => p.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<SysOrganize>().Property(p => p.SortCode).HasDefaultValue(0);
            modelBuilder.Entity<SysOrganize>().Property(p => p.CreateTime).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<UserRole>().Property(p => p.CreateTime).HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(modelBuilder);
        }
    }
}
