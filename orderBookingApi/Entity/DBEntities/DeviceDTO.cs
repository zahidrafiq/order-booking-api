using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace orderBookingApi.Entity.DBEntities
{
    public class DeviceDTO
    {
        public int DeviceID { get; set; }
        public string DeviceName { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}