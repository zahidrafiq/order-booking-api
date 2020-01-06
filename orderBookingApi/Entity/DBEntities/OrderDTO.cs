using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace orderBookingApi.Entity.DBEntities
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public string OrderCode { get; set; }
        public string IMEI { get; set; }
        public string PIN { get; set; }
        public string DeviceColor { get; set; }
        public string ProblemDescription { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public Nullable<int> PaymentTypeID { get; set; }
        public Nullable<int> OrderKindID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}