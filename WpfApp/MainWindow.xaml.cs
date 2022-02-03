using Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using System.Windows.Input;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string URL_base = "https://localhost:44367";

        public MainWindow()
        {
            InitializeComponent();
            Get_Empleados();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 && e.Key == Key.OemPeriod)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Response Respuesta = new Response();

            try
            {

                API API = new API();

                //Se especifican los parametros de consumo para la API
                var strBody = @"{
                            " + "\n" +
                            @"""nombre"": """ + txtnombre.Text + '"' + "," +
                            "\n" +
                            @"""puesto"": """ + txtpuesto.Text + '"' + "," +
                            "\n" +
                            @"""salario"": " + txtsalario.Text + "" +
                            "\n" +
                            @"}";

                APIModel apiModel = new APIModel { URL_base = URL_base, Route = "/empleado/Insert/", MethodAPI = Method.POST, Body = strBody };
                string jsonString = API.consumir(apiModel);

                Respuesta = JsonConvert.DeserializeObject<Response>(jsonString);

                if (Respuesta.Success)
                {
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
                Respuesta.Message = "Ocurrio un problema al agregar el registro [" + error.Message + "]";
            }

            MessageBox.Show(Respuesta.Message, "Mensaje");
        }


        protected void Get_Empleados()
        {
            try
            {
                API API = new API();

                var strBody = "";
                APIModel apiModel = new APIModel { URL_base = URL_base, Route = "/empleado/Get/", MethodAPI = Method.GET, Body = strBody };
                string jsonString = API.consumir(apiModel);

                List<Empleado> Respuesta = JsonConvert.DeserializeObject<List<Empleado>>(jsonString);
                grdempleados.ItemsSource = Respuesta;
            }
            catch
            {
                grdempleados.ItemsSource = null;
            }
        }

        protected void Insert_Empleado(object sender, EventArgs e)
        {
            

        }

        protected void Refresh_Campos()
        {
            txtnombre.Text = "";
            txtpuesto.Text = "";
            txtsalario.Text = "";
        }


    }
}
