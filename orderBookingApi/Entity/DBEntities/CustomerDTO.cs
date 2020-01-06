using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace orderBookingApi.Entity.DBEntities
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Road { get; set; }
        public string PostalCode { get; set; }
        public string Place { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}