namespace ValidLogin
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuestionContext : DbContext
    {
        public QuestionContext()
            : base("name=ResultContext")
        {
        }

        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Questions> Question { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Result> Result { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answers>()
                .HasMany(e => e.Result)
                .WithRequired(e => e.Answers)
                .HasForeignKey(e => e.AnsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Questions>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Questions)
                .HasForeignKey(e => e.QId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Questions>()
                .HasMany(e => e.Result)
                .WithRequired(e => e.Questions)
                .HasForeignKey(e => e.QuestId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Result)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
