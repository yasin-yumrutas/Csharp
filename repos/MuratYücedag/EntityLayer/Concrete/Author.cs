using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EntityLayer.Concrete
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [StringLength(100)]
        public string AuthorImage { get; set; }
        [StringLength(30)]
        public string AuthorName { get; set; }
        [StringLength(500)]
        public string AuthorAbout { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
