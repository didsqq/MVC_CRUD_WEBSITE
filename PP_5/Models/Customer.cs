using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP_5.Models
{
    public class Customer
    {
        [Key] public int CustomerID { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}