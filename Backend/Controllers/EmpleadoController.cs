using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            List<EmpleadoModel> model = new List<EmpleadoModel>();
            Utilities Util = new Utilities();

            //Obtiene informacion
            model = Util.fnGet_Empleados();

            return new JsonResult(model);
        }

        [HttpGet]
        [Route("GetxId")]
        public IActionResult GetxId(int id)
        {
            EmpleadoModel model = new EmpleadoModel();
            Utilities Util = new Utilities();

            //Obtiene informacion
            model = Util.fnGet_Empleado(id);

            return new JsonResult(model);
        }

        [HttpGet]
        [Route("Buscar")]
        public IActionResult Buscar(string nombre, string rfc, string estatus, string fecha_actual)
        {
            List<EmpleadoModel> model = new List<EmpleadoModel>();
            Utilities Util = new Utilities();

            //Obtiene informacion
            model = Util.fnBuscar_Empleados(nombre,rfc,estatus,fecha_actual);

            return new JsonResult(model);
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert(EmpleadoModel obj)
        {
            int model = 0;
            Utilities Util = new Utilities();

            //Obtiene informacion
            model = Util.fnInsert_Empleado(obj);

            return new JsonResult(model);
        }

        [HttpPatch]
        [Route("Update")]
        public IActionResult Update(EmpleadoModel obj)
        {
            int model = 0;
            Utilities Util = new Utilities();

            //Obtiene informacion
            model = Util.fnUpdate_Empleado(obj);

            return new JsonResult(model);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id, string fecha_baja)
        {
            int model = 0;
            Utilities Util = new Utilities();

            //Obtiene informacion
            model = Util.fnDelete_Empleado(id, fecha_baja);

            return new JsonResult(model);
        }
    }
}
