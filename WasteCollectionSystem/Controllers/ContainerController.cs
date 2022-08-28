using Microsoft.AspNetCore.Mvc;
using WasteCollectionSystem.Context;
using WasteCollectionSystem.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BootcampWasteCollectionSystem.Controllers
{
    [Route("api/container/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IMapperSession session;
        public ContainerController(IMapperSession session)
        {
            this.session = session;
        }

        //get method to pull data of container table
        [HttpGet]
        public List<Container> Get()
        {
            List<Container> result = session.Containers.ToList();
            return result;
        }

        //The get method of the data drawn from the container table according to the vehicleId
        [HttpGet("{vehicleId}")]
        public List<Container> Get(long vehicleId)
        {
           List<Container> result = session.Containers.Where(x => x.VehicleId == vehicleId).ToList();
            return result;
        }
        //post method to add a new container
        [HttpPost]
        public void Post([FromBody] Container container)
        {
            try
            {
                session.BeginTransaction();
                session.Save(container);
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
        }

        //the field where the data of a container is updated (vehicle id should not be updated)
        [HttpPut]
        public ActionResult<Container> Put([FromBody] Container request)
        {
            Container container = session.Containers.Where(x => x.Id == request.Id).FirstOrDefault();
            if (container == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTransaction();

                container.Id = request.Id;
                container.ContainerName = request.ContainerName;
                container.Latitude = request.Latitude;
                container.Longitude = request.Longitude;

                session.Update(container);

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

        //delete method in which data is deleted according to container id
        [HttpDelete("{id}")]
        public ActionResult<Container> Delete(int id)
        {
            Container container = session.Containers.Where(x => x.Id == id).FirstOrDefault();
            if (container == null)
            {
                return NotFound();
            }

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

            return Ok();
        }


    }
}
