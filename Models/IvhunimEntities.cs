namespace Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IvhunimEntities : DbContext
    {
        public IvhunimEntities()
            : base("name=IvhunimEntities")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Ivhunim> Ivhunims { get; set; }
        public virtual DbSet<RolesActions> RolesActionss { get; set; }
        public virtual DbSet<RolesInstitues> RolesInstitues { get; set; }
        public virtual DbSet<RolesMainTableColumns> RolesMainTableColumns { get; set; }
        public virtual DbSet<Institue> Institues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
