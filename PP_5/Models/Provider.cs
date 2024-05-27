using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP_5.Models
{
    public class Provider
    {
        [Key] public int ProviderID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}