namespace Task_2.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Autor")]
    public partial class Autor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Autor()
        {
            Book = new HashSet<Book>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Autor { get; set; }

        [StringLength(50)]
        public string NameAutor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Book { get; set; }

        public Autor(string nameAutor,Autor autor, ICollection<Book> book):this(nameAutor,autor)
        {
            Id_Autor = autor.Id_Autor+1;
            Book = book ?? throw new ArgumentNullException(nameof(book),"Список книг написанных автором не может быть null.");
        }
        public Autor(string nameAutor, Autor autor) : this(nameAutor)
        {
            if (autor != null)
                Id_Autor = autor.Id_Autor + 1;
            else
                throw new ArgumentNullException(nameof(autor), "Предыдущий автор не може быть null.");
        }
        private Autor(string nameAutor)
        {
            try
            {
                Id_Autor = 0;
                NameAutor = nameAutor ?? throw new ArgumentNullException(nameof(nameAutor), "Имя автора не может быть null.");
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
         }
        public static Autor BaseAutor()
        {
            return new Autor("Base");
        }
    }
}
