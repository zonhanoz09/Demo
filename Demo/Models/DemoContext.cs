using System;
using System.Collections.Generic;
using System.Data.Entity;
using Demo.Models.Classes;
using System.Linq;
using System.Threading;
using System.Web;

namespace Demo.Models
{
    public class DemoContext : DbContext
    {
        public DemoContext() : base("Demo")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<DemoTable> DemoTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //set schema
            modelBuilder.HasDefaultSchema("dbo");


            //call base function
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            SetModifiedInformation();
            return base.SaveChanges();
        }
        private void SetModifiedInformation()
        {
            var identityName = Thread.CurrentPrincipal.Identity.Name;

            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IEntity
                            && x.State != EntityState.Unchanged);

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is IEntity entity)
                {
                    var currentDateTime = DateTime.Now;

                    //if (entry.State == EntityState.Added)
                    //{
                    //    entity.InsertedBy = identityName;
                    //    entity.InsertedAt = currentDateTime;
                    //}
                    //else
                    //{
                    //    Entry(entity).Property(x => x.InsertedBy).IsModified = false;
                    //    Entry(entity).Property(x => x.InsertedAt).IsModified = false;
                    //}

                    entity.LastUpdated = currentDateTime;
                    //entity.LastUpdatedBy = 1;
                }
            }
        }
    }
}