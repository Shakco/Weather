using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Weather
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label4.Text = "";
            label5.Text = "";
            label8.Text = "";
            label9.Text = "";
            button1.BackColor = BackColor;
            KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Enter) button1_Click(button1, null); };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = textBox1.Text;
            webBrowser1.Visible = true;
            string city = textBox1.Text;
            webBrowser1.Url = new Uri($"https://www.google.com/maps/place/{city}");
            getWeather();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "Enter your city";
        }
        string APIKey = "Your API";

        void getWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", textBox1.Text, APIKey);
                var json = web.DownloadString(url);
                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
                double Kelvin = Info.main.temp;
                double Celsius = Math.Round(Kelvin - 273.15, 1);
                label4.Text = Celsius.ToString();
                label5.Text = Info.weather[0].main;
                double Kelvin1 = Info.main.feels_like;
                double Celsius1 = Math.Round(Kelvin1 - 273.15, 1);
                label8.Text = Celsius1.ToString();
                label9.Text = Info.sys.country;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
