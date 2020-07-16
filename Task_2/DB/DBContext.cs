namespace Task_2.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBConnection")
        {
        }

        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>()
                .HasMany(e => e.Book)
                .WithRequired(e => e.Autor)
                .WillCascadeOnDelete(false);
        }
    }
}
