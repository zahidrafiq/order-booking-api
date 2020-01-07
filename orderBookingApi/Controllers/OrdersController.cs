using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Booking_order.Controllers;
using Booking_order.Entity;
using orderBookingApi.DB.Model;
using orderBookingApi.Services;

namespace orderBookingApi.Controllers
{
    public class OrdersController : BaseDataController
    {
        // GET: api/Orders
        public List<Order> GetOrders()
        {
            //new DataService().SendEmail("hafizmzahid2@gmail.com");
            var data = db.Orders.ToList();
            return data;
        }

        [HttpGet]
        public IHttpActionResult GetOrderByID(int id)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.OrderID)
            {
                return BadRequest();
            }

            db.Entry(order).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public ResponseResult SaveOrder(Order order)
        {
            try
            {
                var sendEmail = Convert.ToBoolean(ConfigurationManager.AppSettings["SendEmail"]);
                if (!ModelState.IsValid)
                {
                    return ResponseResult.GetErrorObject();
                }
                if(new DataService().SaveOrder(order))
                    if(sendEmail && (order.Customer.Email != null || !order.Customer.Email.Equals("")))
                    {
                        if(new DataService().SendEmail(order.Customer.Email))
                        {
                            return ResponseResult.GetSuccessObject("Order Has been placed saved & email is sent");
                        }
                    }
                return ResponseResult.GetSuccessObject(null,"Order Has been placed saved");
            }catch(Exception exp)
            {
                return ResponseResult.GetErrorObject();
            }
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(int id)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            db.SaveChanges();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return db.Orders.Count(e => e.OrderID == id) > 0;
        }

        [HttpGet]
        public ResponseResult GetOrderKinds()
        {
            try
            {
                var data = db.OrderKindsLkps.Where(x => x.IsActive == true)
                    .Select(y => new
                    {
                        id = y.ID,
                        value = y.Value
                    }).ToList();
                return ResponseResult.GetSuccessObject(data);
            }
            catch(Exception exp)
            {
                return ResponseResult.GetErrorObject();
            }
        }
    }
}