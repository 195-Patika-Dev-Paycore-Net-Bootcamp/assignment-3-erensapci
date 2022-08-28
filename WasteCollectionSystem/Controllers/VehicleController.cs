using Microsoft.AspNetCore.Mvc;
using WasteCollectionSystem.Context;
using WasteCollectionSystem.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;


namespace WasteCollectionSystem.Controllers
{
    [ApiController]
    [Route("api/vehicle/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IMapperSession session;
        public VehicleController(IMapperSession session)
        {
            this.session = session;
        }

        //The section where all vehicle information is taken
        [HttpGet]
        public List<Vehicle> Get()
        {
            List<Vehicle> result = session.Vehicles.ToList();
            return result;
        }

        //The section wherw vehicle informations taken by Id 
        [HttpGet("{id}")]
        public Vehicle Get(int id)
        {
            Vehicle result = session.Vehicles.Where(x => x.Id == id).FirstOrDefault();
            return result;
        }

        //New vehicle information entered post attribute
        [HttpPost]
        public void Post([FromBody] Vehicle vehicle)
        {
            try
            {
                session.BeginTransaction();
                session.Save(vehicle);
                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                Log.Error(ex, "Vehicle Insert Error");
            }
            finally
            {
                session.CloseTransaction();
            }
        }
        //Put attribute section where vehicle information is updated
        [HttpPut]
        public ActionResult<Vehicle> Put([FromBody] Vehicle request)
        {
            Vehicle vehicle = session.Vehicles.Where(x => x.Id == request.Id).FirstOrDefault();
            if (vehicle == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTransaction();

                vehicle.Id = request.Id;
                vehicle.VehicleName = request.VehicleName;
                vehicle.VehiclePlate = request.VehiclePlate;

                session.Update(vehicle);

                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                Log.Error(ex, "Vehicle Insert Error");
            }
            finally
            {
                session.CloseTransaction();
            }
            return Ok();
        }

        //The part where existing vehicles can be deleted by entering id information
        [HttpDelete("{id}")]
        public ActionResult<Vehicle> Delete(long id)
        {
            Container container = session.Containers.Where(x => x.VehicleId == id).FirstOrDefault();
        
            try
            {
                session.BeginTransaction();
                session.Delete(container);
                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                Log.Error(ex, "Container Insert Error");
            }
            finally
            {
                session.CloseTransaction();
            }

            Vehicle vehicle = session.Vehicles.Where(x => x.Id == id).FirstOrDefault();
            if (vehicle == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTransaction();
                session.Delete(vehicle);
                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                Log.Error(ex, "Container Insert Error");
            }
            finally
            {
                session.CloseTransaction();
            }

            return Ok();
        }

    }
}
