using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP_5.Models
{
    public class Product_in_Order
    {

        [Key] public int Product_in_OrderID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Count { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}