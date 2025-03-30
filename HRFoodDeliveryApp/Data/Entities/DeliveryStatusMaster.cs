﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class DeliveryStatusMaster
    {
        public int DeliveryStatusMasterId { get; set; }
        public string StatusName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        // navigation
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
