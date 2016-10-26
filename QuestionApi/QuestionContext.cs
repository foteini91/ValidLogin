namespace QuestionApi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuestionContext : DbContext
    {
        public QuestionContext()
            : base("name=QuestionContext")
        {
        }

        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
