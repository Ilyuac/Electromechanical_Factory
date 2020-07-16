namespace Task_2.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Autor { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string NameBook { get; set; }

        public virtual Autor Autor { get; set; }

        public Book(string nameBook)
        {
            try
            {
                NameBook = nameBook ?? throw new ArgumentNullException(nameof(nameBook),"Имя книги не может быть null.");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
