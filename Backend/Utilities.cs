using System;
using System.Collections.Generic;
using System.Data;
using Models;
using Newtonsoft.Json;
using RestSharp;

namespace Backend
{
    public class Utilities
    {
        public List<Empleado> fnGet_Empleados()
        {
            List<Empleado> informacion = new List<Empleado>();

            try
            {
                string query = "EXEC sp_Get_Empleados";
                DataTable result;

                result = new DataAccess().executeTable(query);

                foreach (var item in result.Rows)
                {
                    Empleado empleado = new Empleado();

                    empleado.id = Convert.ToInt32(((System.Data.DataRow)item).ItemArray[0]);
                    empleado.nombre = Convert.ToString(((System.Data.DataRow)item).ItemArray[1]);                    
                    empleado.puesto = Convert.ToString(((System.Data.DataRow)item).ItemArray[2]);
                    empleado.salario = decimal.Round(Convert.ToDecimal(((System.Data.DataRow)item).ItemArray[3]), 2, MidpointRounding.ToEven); 
                    empleado.salarioUSD = decimal.Round(fnConvert_USD(empleado.salario), 2, MidpointRounding.ToEven) ;

                    informacion.Add(empleado);
                }              

            }
            catch (Exception error)
            {
                //No realiza nada y envia los valores encontrados
            }

            return informacion;
        }

        public Response fnInsert_Empleado(Empleado obj)
        {
            Response result = new Response();

            try
            {
                string query = "EXEC sp_Insert_Empleado '" + obj.nombre + "','" + obj.puesto + "'," + obj.salario;
                int exec = new DataAccess().executeCommand(query);

                if (exec == 1)
                    result.Success = true;

            }
            catch
            {
                //No realiza nada y envia los valores encontrados
            }

            return result;
        }

        private decimal fnConvert_USD(decimal salario)
        {

            var client = new RestClient("https://www.banxico.org.mx/SieAPIRest/service/v1/series/SF43718/datos/oportuno");
            client.Timeout = -1;
            client.FollowRedirects = false;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Bmx-Token", "bf25c07f1b07b7b134f689ce6a7281ee4ef92db266e92a88c31d974f9e5a7ff1");
            request.AddHeader("Cookie", "Hex25802680=!e6cqiSCLJ2Prc833AjKmtUwBnOY1oTDq9I0ELj4ov/Jm4jKhmb0Decxal2YWeXILiEaQS8g5cekfwA==; SRVCOOKIE=!Qt9klwSePr1Bzgj3AjKmtUwBnOY1oeHjeBTgH5j5rADmEb/VwVtAPt5pbNFfmH3i4M5dx7GfkauPRg==; TS012f422b=01ab44a5a88726e14b6cecb84482460af35b33c0c8a2df8043f9bb993c056293d9048b35c48af95f423469ca814fde33ad4918024cc507586cb41e3955f78f7407036b9349ad2ebb752f5871cb0718abe7257b0eba");

            IRestResponse response = client.Execute(request);
            string jsonString = response.Content;

            Banxico Respuesta = JsonConvert.DeserializeObject<Banxico>(jsonString);

            decimal tipo_cambio = Convert.ToDecimal(Respuesta.bmx.series[0].datos[0].dato);

            return salario / tipo_cambio;
        }


    }
}
