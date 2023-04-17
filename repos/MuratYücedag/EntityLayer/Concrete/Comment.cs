using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [StringLength(30)]
        public string UserName { get; set; }
        [StringLength(30)]
        public string Mail { get; set; }
       
        public string CommentText { get; set; }
        
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
