using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using gofer.Models;

namespace gofer.Controllers
{
    public class TestController : ODataController
    {
        private static List<Test> tests = new List<Test>([ new Test { Id = 10001, Text = "Barney Rubble" } ]);

        public ActionResult<IEnumerable<Test>> Post()
        {
            return Ok(tests);
        }
    }
}
