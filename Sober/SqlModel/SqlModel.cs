namespace SqlModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SqlModel : DbContext
    {
        public SqlModel()
            : base("name=SqlModel")
        {
        }

        public virtual DbSet<everydaynews> everydaynews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<everydaynews>()
                .Property(e => e.state)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<everydaynews>()
                .Property(e => e.isvalid)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
