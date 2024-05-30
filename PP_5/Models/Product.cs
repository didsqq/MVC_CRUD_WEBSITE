using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;

namespace PP_5.Models
{
    public class Product
    {
        [Key] public int ProductID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public SqlMoney Price { get; set; }
        public int Warranty_Period { get; set; }
        public int ProviderID { get; set; }
        public int TypeID { get; set; }

        public virtual Provider Provider { get; set; }
        public virtual Component_Type Component_Type { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}