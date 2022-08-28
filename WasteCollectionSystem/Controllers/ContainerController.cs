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
        [HttpGet]
        public List<Container> Get()
        {
            List<Container> result = session.Containers.ToList();
            return result;
        }

        [HttpGet("{vehicleId}")]
        public List<Container> Get(long vehicleId)
        {
           List<Container> result = session.Containers.Where(x => x.VehicleId == vehicleId).ToList();
            return result;
        }

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
