using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Models;

namespace Backend.Controllers
{
    [EnableCors("CorsApi")]
    [ApiController]
    [Route("[controller]")]
    public class EmpleadoController : ControllerBase
    {

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            List<Empleado> model = new List<Empleado>();
            Utilities Util = new Utilities();

            //Obtiene informacion
            model = Util.fnGet_Empleados();

            return new JsonResult(model);
        }
        
        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert(Empleado obj)
        {
            Response model = new Response();
            Utilities Util = new Utilities();

            //Obtiene informacion
            model = Util.fnInsert_Empleado(obj);

            return new JsonResult(model);
        }

    }
}
