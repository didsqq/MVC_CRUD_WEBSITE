using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace PP_5.Models
{
    public class Order
    {
        [Key] public int OrderID { get; set; }
        public DateTime Date { get; set; }
        public SqlMoney Total_Amount { get; set; }
        public string Status { get; set; }
        public int Product_Count { get; set; }
        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Product_in_Order> Product_in_Order { get; set; }
    }
}