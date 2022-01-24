using System;
using System.Collections.Generic;
using System.Data;

namespace Backend
{
    public class Utilities
    {
        public List<EmpleadoModel> fnGet_Empleados()
        {
            List<EmpleadoModel> informacion = new List<EmpleadoModel>();

            try
            {
                string query = "EXEC sp_Get_Empleados";
                DataTable result;

                result = new DataAccess().executeTable(query);

                foreach (var item in result.Rows)
                {
                    EmpleadoModel empleado = new EmpleadoModel();

                    empleado.id = Convert.ToString(((System.Data.DataRow)item).ItemArray[0]);
                    empleado.nombre_completo = Convert.ToString(((System.Data.DataRow)item).ItemArray[1]);
                    empleado.email = Convert.ToString(((System.Data.DataRow)item).ItemArray[2]);
                    empleado.puesto = Convert.ToString(((System.Data.DataRow)item).ItemArray[3]);
                    empleado.rfc = Convert.ToString(((System.Data.DataRow)item).ItemArray[4]);
                    empleado.fecha_alta = Convert.ToString(((System.Data.DataRow)item).ItemArray[5]);

                    informacion.Add(empleado);
                }              

            }
            catch
            {
                //No realiza nada y envia los valores encontrados
            }

            return informacion;
        }

        public EmpleadoModel fnGet_Empleado(int id)
        {
            EmpleadoModel informacion = new EmpleadoModel();

            try
            {
                string query = "EXEC sp_Get_Empleado " + id;
                DataTable result;

                result = new DataAccess().executeTable(query);

                informacion.id = Convert.ToString(result.Rows[0]["id"]);
                informacion.nombre = Convert.ToString(result.Rows[0]["nombre"]);
                informacion.apellido_paterno = Convert.ToString(result.Rows[0]["apellido_paterno"]);
                informacion.apellido_materno = Convert.ToString(result.Rows[0]["apellido_materno"]);
                informacion.edad = Convert.ToString(result.Rows[0]["edad"]);
                informacion.fecha_nacimiento = Convert.ToString(result.Rows[0]["fecha_nacimiento"]);
                informacion.genero = Convert.ToString(result.Rows[0]["genero"]);
                informacion.estado_civil = Convert.ToString(result.Rows[0]["estado_civil"]);
                informacion.rfc = Convert.ToString(result.Rows[0]["rfc"]);
                informacion.direccion = Convert.ToString(result.Rows[0]["direccion"]);
                informacion.email = Convert.ToString(result.Rows[0]["email"]);
                informacion.telefono = Convert.ToString(result.Rows[0]["telefono"]);
                informacion.puesto = Convert.ToString(result.Rows[0]["puesto"]);
                informacion.fecha_alta = Convert.ToString(result.Rows[0]["fecha_alta"]);
                informacion.fecha_baja = Convert.ToString(result.Rows[0]["fecha_baja"]);

            }
            catch
            {
                //No realiza nada y envia los valores encontrados
            }

            return informacion;
        }

        public List<EmpleadoModel> fnBuscar_Empleados(string nombre, string rfc, string estatus, string fecha_actual)
        {
            List<EmpleadoModel> informacion = new List<EmpleadoModel>();

            try
            {
                string query = "EXEC sp_Buscar_Empleados '" + nombre + "','" + rfc + "','" + estatus + "','" + fecha_actual + "'";
                DataTable result;

                result = new DataAccess().executeTable(query);

                foreach (var item in result.Rows)
                {
                    EmpleadoModel empleado = new EmpleadoModel();

                    empleado.id = Convert.ToString(((System.Data.DataRow)item).ItemArray[0]);
                    empleado.nombre_completo = Convert.ToString(((System.Data.DataRow)item).ItemArray[1]);
                    empleado.email = Convert.ToString(((System.Data.DataRow)item).ItemArray[2]);
                    empleado.puesto = Convert.ToString(((System.Data.DataRow)item).ItemArray[3]);
                    empleado.rfc = Convert.ToString(((System.Data.DataRow)item).ItemArray[4]);
                    empleado.fecha_alta = Convert.ToString(((System.Data.DataRow)item).ItemArray[5]);

                    informacion.Add(empleado);
                }

            }
            catch
            {
                //No realiza nada y envia los valores encontrados
            }

            return informacion;
        }

        public int fnInsert_Empleado( EmpleadoModel obj)
        {
            int result=0;

            try
            {
                string query = "EXEC sp_Insert_Empleado '" + obj.nombre + "','" + obj.apellido_paterno + "','" + obj.apellido_materno + "'," + obj.edad + ",'" + obj.fecha_nacimiento + "','" + obj.genero + "','" + obj.estado_civil + "','" + obj.rfc + "','" + obj.direccion + "','" + obj.email + "','" + obj.telefono + "','" + obj.puesto + "','" + obj.fecha_alta + "','" + obj.fecha_baja + "'";
                result = new DataAccess().executeCommand(query);                

            }
            catch
            {
                //No realiza nada y envia los valores encontrados
            }

            return result;
        }

        public int fnUpdate_Empleado(EmpleadoModel obj)
        {
            int result = 0;

            try
            {
                string query = "EXEC sp_Update_Empleado " + obj.id + ",'" + obj.estado_civil + "','" + obj.direccion + "','" + obj.email + "','" + obj.telefono + "','" + obj.puesto + "','" + obj.fecha_baja + "'";
                result = new DataAccess().executeCommand(query);

            }
            catch
            {
                //No realiza nada y envia los valores encontrados
            }

            return result;
        }

        public int fnDelete_Empleado(int id, string fecha_baja)
        {
            int result = 0;

            try
            {
                string query = "EXEC sp_Delete_Empleado " + id + ",'" + fecha_baja + "'";
                result = new DataAccess().executeCommand(query);

            }
            catch
            {
                //No realiza nada y envia los valores encontrados
            }

            return result;
        }

    }
}
