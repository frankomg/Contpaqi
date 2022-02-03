using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.UI;
using Models;
using Newtonsoft.Json;
using RestSharp;

namespace WebApplication1
{
    public partial class Empleados : System.Web.UI.Page
    {
        string URL_base = ConfigurationManager.AppSettings["URL_base"];
        string gl_script = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Get_Empleados();
            }
        }

        protected void Get_Empleados()
        {
            try {
                API API = new API();

                var strBody = "";
                APIModel apiModel = new APIModel { URL_base = URL_base, Route = "/empleado/Get/", MethodAPI = Method.GET, Body = strBody };
                string jsonString = API.consumir(apiModel);

                List<Empleado> Respuesta = JsonConvert.DeserializeObject<List<Empleado>>(jsonString);               
                grdempleados.DataSource = Respuesta;                
            }
            catch {
                grdempleados.DataSource = new DataTable();
            }

            grdempleados.DataBind();
        }

        protected void Insert_Empleado(object sender, EventArgs e)
        {
            Response Respuesta = new Response();

            try
            { 

                API API = new API();

                //Se especifican los parametros de consumo para la API
                var strBody = @"{
                            " + "\n" +
                            @"""nombre"": """ + txtnombre.Value + '"' + "," +
                            "\n" +
                            @"""puesto"": """ + txtpuesto.Value + '"' + "," +
                            "\n" +
                            @"""salario"": " + txtsalario.Value + "" +
                            "\n" +
                            @"}";

                APIModel apiModel = new APIModel { URL_base = URL_base, Route = "/empleado/Insert/", MethodAPI = Method.POST, Body = strBody };
                string jsonString = API.consumir(apiModel);

                Respuesta = JsonConvert.DeserializeObject<Response>(jsonString);

                if (Respuesta.Success) { 
                    Respuesta.Message = "Registro agregado correctamente!";
                    Get_Empleados();
                    Refresh_Campos();
                }
                else
                    Respuesta.Message = "El registro no fue agregado, intentar nuevamente.";               

            }
            catch (Exception error)
            {
                Respuesta.Success = false;
                Respuesta.Message = "Ocurrio un problema al agregar el registro [" + error.Message +"]";
            }

            gl_script = "mensaje('" + Respuesta.Success + "','" + Respuesta.Message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", gl_script, true);

        }

        protected void Refresh_Campos()
        {
            txtnombre.Value = "";
            txtpuesto.Value = "";
            txtsalario.Value = "";
        }

    }
}