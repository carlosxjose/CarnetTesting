using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarnetTesting
{
    public partial class Form1 : Form
    {
        private readonly CardNetServices _cardNetServices;

        string local_ip_address = "192.168.0.242";
        int local_port = 2018;

        string remote_ip_address = "192.168.0.250";
        int remote_port = 7060;    

        private static int timeOut = 30900;

        public Form1()
        {
            InitializeComponent();

            try
            {
                _cardNetServices = new CardNetServices();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            InicializarCardNet();
            CardNetCloseDto respuesta = CardNetCloseDeserializeObject(_cardNetServices.ProcessClose());
            button1.Enabled = true;
        }

        private CardNetCloseDto CardNetCloseDeserializeObject(string data)
        {
            var Respuesta = new CardNetCloseDto();

            try
            {
                if (!string.IsNullOrWhiteSpace(data))
                {
                    string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " +
                        CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;

                    var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = sysFormat };

                    JsonSerializer serializer = new JsonSerializer();
                    Respuesta = JsonConvert.DeserializeObject<CardNetCloseDto>(data, dateTimeConverter);
                }
            }
            catch (Exception ex)
            {
               // log.Debug("CardNetClose, Frame: " + data);

                throw ex;
            }

            return Respuesta;
        }

        private bool InicializarCardNet(bool completo = true)
            {
                var response = CardNetResponseDeserializeObject(_cardNetServices.SetLocalEndPoint(local_ip_address, local_port));
                if (response.Status == "Failed")
                    throw new Exception(string.IsNullOrWhiteSpace(response.Messages[0]) ? "Sin respuesta" : response.Messages[0]);

                response = CardNetResponseDeserializeObject(_cardNetServices.SetRemoteEndPoint(remote_ip_address, remote_port));
                if (response.Status == "Failed")
                    throw new Exception(string.IsNullOrWhiteSpace(response.Messages[0]) ? "Sin respuesta" : response.Messages[0]);

                response = CardNetResponseDeserializeObject(_cardNetServices.SetTimeout(timeOut));
                if (response.Status == "Failed")
                    throw new Exception(string.IsNullOrWhiteSpace(response.Messages[0]) ? "Sin respuesta" : response.Messages[0]);

              //  if (completo)
                {
                    response = CardNetResponseDeserializeObject(_cardNetServices.Initialice());
                    if (response.Status == "Failed")
                        throw new Exception(string.IsNullOrWhiteSpace(response.Messages[0]) ? "Sin respuesta" : response.Messages[0]);
                }

                return true;
            }

        private Response CardNetResponseDeserializeObject(string data)
        {
            var Respuesta = new Response();

            try
            {
                if (!string.IsNullOrWhiteSpace(data))
                {
                    string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " +
                        CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;

                    var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = sysFormat };

                    JsonSerializer serializer = new JsonSerializer();
                    Respuesta = JsonConvert.DeserializeObject<Response>(data, dateTimeConverter);
                }
            }
            catch (Exception ex)
            {
                //log.Debug("CardNetResponse, Frame: " + data);

                throw ex;
            }

            return Respuesta;
        }

    }
}

public class Response
{
    public string Status { get; set; }
    public List<string> Messages { get; set; }
}
