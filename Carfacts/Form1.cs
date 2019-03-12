using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using Newtonsoft.Json;


namespace Carfacts
{

    public partial class Form1 : Form
    {
        static string findPlaca;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            findPlaca = textBox1.Text;

            dataGridView1.Rows.Clear();

            string placa = string.Empty;
            string marca = string.Empty;
            string modelo = string.Empty;
            string anoFab = string.Empty;
            string anoMod = string.Empty;
            string cor = string.Empty;
            string combustivel = string.Empty;
            

            WebBrowser oWebBrowser = new WebBrowser();

            oWebBrowser.Refresh(WebBrowserRefreshOption.Completely);


            oWebBrowser.ScriptErrorsSuppressed = true;
            oWebBrowser.Navigate("https://carfacts.com.br/ConsultaGratis");


            while (oWebBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            HtmlElement questionInput = oWebBrowser.Document.GetElementById("Placa");
            if (questionInput != null)
            {
                questionInput.SetAttribute("value", findPlaca);
            }

            HtmlElement questionForm = oWebBrowser.Document.GetElementById("btnConsultar");
            if (questionForm != null)
            {
                questionForm.InvokeMember("button");
            }

            while (oWebBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            HtmlDocument atm = oWebBrowser.Document;

            if (!string.IsNullOrEmpty(placa))
            {
                placa = atm.GetElementById("Placa").InnerHtml.ToUpper();
                marca = atm.GetElementById("Marca").InnerHtml.ToUpper();
                modelo = atm.GetElementById("Modelo").InnerHtml.ToUpper();
                anoFab = atm.GetElementById("AnoFab").InnerHtml;
                anoMod = atm.GetElementById("AnoMod").InnerHtml;
                cor = atm.GetElementById("Cor").InnerHtml.ToUpper();
                combustivel = atm.GetElementById("lblCombustivel").InnerHtml.ToUpper();
            }

            Carro carro = new Carro(placa, marca, modelo, anoFab, anoMod, cor, combustivel);

            var jsonSerializado = JsonConvert.SerializeObject(carro);


            

            if (!string.IsNullOrEmpty(placa))
            {
                FileStream fs = new FileStream(@"Json.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(jsonSerializado);
                sw.Flush();
                sw.Close();
                fs.Close();
                dataGridView1.Rows.Add(placa, marca, modelo, anoFab, anoMod, cor, combustivel);
                return;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
