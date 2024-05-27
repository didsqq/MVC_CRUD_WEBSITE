using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP_5.Models
{
    public class Component_Type
    {
        [Key] public int Component_TypeID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}