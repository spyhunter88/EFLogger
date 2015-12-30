using Logger.Example.Models;
using Logger.Example.Models.Mapping;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Example
{
    public partial class ExampleContext : DataContext
    {
        static ExampleContext()
        {
            Database.SetInitializer<ExampleContext>(null);
        }

        public ExampleContext()
            : base("Name=ExampleContext")
        {
            // Logger = new FrameLogModule<ChangeSet, User>(new ChangeSetFactory(), FrameLogContext, filterProvider);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Claim> Claims { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Allocation> Allocations { get; set; }
        public DbSet<ClaimStatus> ClaimStatuses { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new ClaimMap());
            modelBuilder.Configurations.Add(new RequestMap());
            modelBuilder.Configurations.Add(new RequirementMap());
            modelBuilder.Configurations.Add(new DocumentMap());
            modelBuilder.Configurations.Add(new PaymentMap());
            modelBuilder.Configurations.Add(new AllocationMap());
            modelBuilder.Configurations.Add(new ClaimStatusMap());

            modelBuilder.Entity<Requirement>().HasRequired<Claim>(s => s.Claim)
                .WithMany(s => s.Requirements).HasForeignKey(s => s.ClaimID);

            modelBuilder.Entity<Payment>().HasRequired<Claim>(s => s.Claim)
                .WithMany(s => s.Payments).HasForeignKey(s => s.ClaimID);

            modelBuilder.Entity<Allocation>().HasRequired<Claim>(s => s.Claim)
                .WithMany(s => s.Allocations).HasForeignKey(s => s.ClaimID);

            modelBuilder.Entity<ClaimDocument>().HasRequired<Claim>(s => s.Claim)
                .WithMany(s => s.ClaimDocuments).HasForeignKey(s => s.ClaimID);
        }
    }
}
