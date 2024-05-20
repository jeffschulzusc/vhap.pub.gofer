using gofer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace gofer.Controllers
{
    public class FeaturesController : ODataController
    {
        private static List<Feature> features= new List<Feature>([
            new Feature{ Id = 111111,Name = "Food Stuffs"},
            new Feature{ Id = 111112,Name = "Garage Shelving"},
            new Feature{ Id = 111113,Name = "Quantum Decoherence"},
            new Feature{ Id = 111114,Name = "Outboard Motors"},
            new Feature{ Id = 111115,Name = "Cancellations"},
            new Feature{ Id = 111116,Name = "Remunerations"},
            new Feature{ Id = 111117,Name = "Feedback Focus"}
            ]);

        [EnableQuery]
        public ActionResult<IEnumerable<Feature>> Get()
        {
            return Ok(features);
        }

        [EnableQuery]
        public ActionResult<Feature> Get([FromRoute] int key)
        {
            var item = features.SingleOrDefault(d => d.Id.Equals(key));

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}
