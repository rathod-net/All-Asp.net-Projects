﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int  DeliveryPartnerProfileId { get; set; }
        public virtual DeliveryPartnerProfile DeliveryPartnerProfile { get; set; }
        public DateTime? PickupTime { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public int DeliveryStatusMasterId { get; set; }
        public virtual DeliveryStatusMaster DeliveryStatusMaster { get; set; }
    }
}
