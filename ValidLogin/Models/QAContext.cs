namespace ValidLogin
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QAContext : DbContext
    {
        public QAContext()
            : base("name=QAContext")
        {
        }

        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Questions>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Questions)
                .HasForeignKey(e => e.QId)
                .WillCascadeOnDelete(false);
        }
    }
}
