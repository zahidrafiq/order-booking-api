using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Booking_order.Entity;
using orderBookingApi.DB.Model;
using orderBookingApi.Entity.DBEntities;

namespace Booking_order.Controllers
{
    public class DevicesController : BaseDataController
    {
        [HttpGet]
        public ResponseResult GetAllDevices()
        {
            try
            {  
                using (DBEntitiesModel db = new DBEntitiesModel())
                {
                    
                    var data = db.Devices.Where(x => x.ParentID == null).
                        Select(y => new DeviceDTO
                        {
                            DeviceID = y.DeviceID, DeviceName = y.DeviceName,
                            Description = y.Description, ImageName = y.ImageName,
                            IsActive = y.IsActive, ParentID = y.ParentID, CreatedBy = y.CreatedBy,
                            CreatedOn = y.CreatedOn
                        }
                        ).ToList();
                    return ResponseResult.GetSuccessObject(data);
                }
                //return a;// ResponseResult.GetSuccessObject(a);
            }
            catch (Exception exp) {
                return ResponseResult.GetErrorObject();
            }
        }

        // GET: api/Devices/5
        public ResponseResult GetDeviceByID(int id)
        {
            Device device = db.Devices.Find(id);
            if (device == null)
            {
                return ResponseResult.GetErrorObject();
            }

            return ResponseResult.GetSuccessObject(device);
        }

        [HttpGet]
        public ResponseResult GetAllModels(int id)
        {
            try
            {
                using (DBEntitiesModel db = new DBEntitiesModel())
                {

                    var data = db.Devices.Where(x => x.ParentID == id && x.IsActive == true).
                        Select(y => new DeviceDTO
                        {
                            DeviceID = y.DeviceID,
                            DeviceName = y.DeviceName,
                            Description = y.Description,
                            ImageName = y.ImageName,
                            IsActive = y.IsActive,
                            ParentID = y.ParentID,
                            CreatedBy = y.CreatedBy,
                            CreatedOn = y.CreatedOn
                        }
                        ).ToList();
                    return ResponseResult.GetSuccessObject(data);
                }
            }
            catch (Exception exp) {
                return ResponseResult.GetErrorObject();
            }
        }
        // PUT: api/Devices/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutDevice(int id, Device device)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != device.DeviceID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(device).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DeviceExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}
        [HttpPost]
        public ResponseResult a(int i)
        {
            return null;
        }
        // POST: api/Devices
        [HttpPost]
        public ResponseResult SaveDevice(Device device)
        {
            if (!ModelState.IsValid)
            {
                return ResponseResult.GetErrorObject("Invalid Model State");
            }

            db.Devices.Add(device);
            db.SaveChanges();
            return ResponseResult.GetSuccessObject(new { id = device.DeviceID },"");
            //return CreatedAtRoute("DefaultApi", new { id = device.DeviceID }, device);
        }

        // DELETE: api/Devices/5
        [ResponseType(typeof(Device))]
        public IHttpActionResult DeleteDevice(int id)
        {
            Device device = db.Devices.Find(id);
            if (device == null)
            {
                return NotFound();
            }

            db.Devices.Remove(device);
            db.SaveChanges();

            return Ok(device);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeviceExists(int id)
        {
            return db.Devices.Count(e => e.DeviceID == id) > 0;
        }
    }
}