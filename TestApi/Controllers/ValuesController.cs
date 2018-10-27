using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApi.Models;
using TestApi.Service;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ITestService _TestService;

        public ValuesController()
        {
            _TestService = new TestService();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("Get")]
        public List<PersonsModel> GetValue()
        {
            return _TestService.GetValue();
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult AddPerson(PersonsModel req)
        {
            _TestService.AddPerson(req);
            return Ok();
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult UpdatePerson(PersonsModel req)
        {
            _TestService.EditPerson(req);
            return Ok();
        }



    }
}
