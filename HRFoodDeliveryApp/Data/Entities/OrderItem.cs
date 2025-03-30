﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class OrderItem
    {
        public  int OrderItemId  { get; set; }  
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal UnitPrice { get; set; }
        public  decimal TotalPrice => Quantity * UnitPrice;
    }
}
