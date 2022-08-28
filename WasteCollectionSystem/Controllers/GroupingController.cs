using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WasteCollectionSystem.Context;
using WasteCollectionSystem.Models;

namespace WasteCollectionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupingController : ControllerBase
    {
        private readonly IMapperSession session;
        public GroupingController(IMapperSession session)
        {
            this.session = session;
        }
        //The part where the grouping is made with the Id information and the number of clusters entered from the user.
        
        [HttpGet]
        public List<List<Container>> groups (long vehicleId, int numberOfGroups)
        {

            //Currently, the algorithm does not give very accurate results.

            var groups = new List<List<Container>>();
            List<Container> containerList = session.Containers.Where(x => x.VehicleId == vehicleId).ToList();
            for (int i=0; i<numberOfGroups;i++)
            {
                groups.Add(new List<Container>());
            }
            for (int j=0; j<containerList.Count;j++) 
            {
                var count = j;
                j = numberOfGroups * count;
                
                for (int i = 0; i < numberOfGroups; i++)
                {                  
                    if (count < containerList.Count)
                    {
                        groups[i].Add(containerList[count]);
                        count++;
                    }
                    else break;
                } 
            }
            return groups;
        }
    }
}
