using orderBookingApi.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Booking_order.Controllers
{
    public class BaseDataController : ApiController
    {
        protected DBEntitiesModel db = new DBEntitiesModel();
        
        public BaseDataController() : base()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
    }
}
