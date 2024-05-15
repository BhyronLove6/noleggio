using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace NoleggioVisual1
{
    public partial class Form1 : Form
    {
        string[] Usernames = new string[100];
        double latIniz = 45.6887943193688;
        double longtIniz = 9.67157363891602;
        bool Disponibile = true;
        int secondi = 0;
        int minuti = 0;
        int ore = 0;
        public Form1()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (textbox_password.Text.Length == 0 && textbox_username.Text.Length == 0)
            {
                dataerror.Show();
            }
            else
            {



                for (int i = 0; i < 100; i++)
                {
                    if (Usernames[i] == textbox_username.Text+","+textbox_password.Text)
                    {
                        textbox_password.Hide();
                        panelfinale.Hide();
                        textbox_username.Hide();
                        button_login.Hide();
                        label1.Hide();
                        label2.Hide();
                        label3.Hide();
                        label4.Hide();
                        panel1.Show();
                        label6.Show();
                        panelnoleggio.Hide();
                        checkBox_password.Visible = false;
                        gMapControl1.Show();
                        label_Mappa.Show();
                        textBox_ID.Show();
                        textBox_latitudine.Show();
                        textBox_longitudine.Show();
                        button_Noleggia.Show();
                        gMapControl1.DragButton = MouseButtons.Left;
                        //Mappa
                        gMapControl1.MapProvider = GMapProviders.GoogleMap;
                        double lat = latIniz;
                        double longt = longtIniz;
                        gMapControl1.Position = new PointLatLng(lat, longt);
                        gMapControl1.ShowCenter = false;
                        gMapControl1.Zoom = 14.5;
                        gMapControl1.MinZoom = 1;
                        gMapControl1.MaxZoom = 100;



                    }
                }
            }
        }

        private void textbox_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int j = 0; j < 100; j++)
            {
                Usernames[j] = "";
            }
            button_coord.Hide();
            panelnoleggio.Hide();
            panel1.Hide();
            label6.Hide();
            gMapControl1.Hide();
            dataerror.Hide();
            label_Mappa.Hide();
            textBox_ID.Hide();
            textBox_latitudine.Hide();
            textBox_longitudine.Hide();
            button_Noleggia.Hide();
            panelfinale.Hide();
            button_Indietro.Hide();
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            double lat = Convert.ToDouble(textBox_latitudine.Text);
            double longt = Convert.ToDouble(textBox_longitudine.Text);
            gMapControl1.Position = new PointLatLng(lat, longt);
            gMapControl1.Zoom = 10;
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 100;
            //MARKER1
            double latM = 45.6888242980996;
            double lonM = 9.68140125274658;
            PointLatLng point = new PointLatLng(latM, lonM);
            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(marker);
            gMapControl1.Overlays.Add(markers);
            //MARKER2
            double latM1 = 45.6857405033096;
            double lonM1 = 9.66036049649119;
            PointLatLng point1 = new PointLatLng(latM1, lonM1);
            GMapMarker marker1 = new GMarkerGoogle(point1, GMarkerGoogleType.red_dot);
            GMapOverlay markers1 = new GMapOverlay("markers1");
            markers1.Markers.Add(marker1);
            gMapControl1.Overlays.Add(markers1);

            string line = "";
            int i = 0;
            StreamReader sr = new StreamReader("account.txt");
            while (line != null)
            {
                line = sr.ReadLine();
                Usernames[i] = line;
                i++;
            }

        }

        private void checkBox_password_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_password.CheckState == CheckState.Checked)
            {
                textbox_password.UseSystemPasswordChar = true;
            }
            else
            {
                textbox_password.UseSystemPasswordChar = false;
            }
        }
        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }
        private void button_Indietro_Click(object sender, EventArgs e)
        {
            //bottone torna al login
        }
        private void button_Noleggia_Click(object sender, EventArgs e)
        {
            panelnoleggio.Show();
            panelfinale.Hide();
        }
        private void button_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            double lat = Convert.ToDouble(textBox_latitudine.Text);
            double longt = Convert.ToDouble(textBox_longitudine.Text);
            gMapControl1.Position = new PointLatLng(lat, longt);
            gMapControl1.Zoom = 10;
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 100;
        }
        private void timer_coord_Tick(object sender, EventArgs e)
        {
            PointLatLng a = new PointLatLng();
            a = gMapControl1.Position;
            textBox_latitudine.Text = a.Lat.ToString();
            textBox_longitudine.Text = a.Lng.ToString();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelnoleggio.Hide();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void panelnoleggio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Disponibile)
            {
                label39.Hide();
                label40.Hide();
                label42.Hide();
                label43.Hide();
                label44.Hide();
                label45.Hide();
                button4.Hide();
            }
            else
            {
                label25.Hide();
                label26.Hide();
                label24.Hide();
                button3.Hide();
                button5.Hide();
            }
            panelfinale.Show();
            label46.Text = ore.ToString() + ":" + minuti.ToString() + ":" + secondi.ToString();
            timer1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelfinale.Hide();
            panelnoleggio.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            ore = 0;
            minuti = 0;
            secondi = 0;
            panelfinale.Hide();
            button_coord.Hide();
            panelnoleggio.Hide();
            panel1.Hide();
            label6.Hide();
            gMapControl1.Hide();
            dataerror.Hide();
            label_Mappa.Hide();
            textBox_ID.Hide();
            textBox_latitudine.Hide();
            textBox_longitudine.Hide();
            button_Noleggia.Hide();
            panelfinale.Hide();
            button_Indietro.Hide();

            textbox_password.Show();
            panelfinale.Show();
            textbox_username.Show();
            button_login.Show();
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Disponibile)
            {
                secondi++;
                if (secondi == 60)
                {
                    secondi = 0;
                    minuti++;
                }
                if (minuti == 60)
                {
                    minuti = 0;
                    ore++;
                }
                label46.Text = ore.ToString() + ":" + minuti.ToString() + ":" + secondi.ToString();
            }
        }
    }
}



/*ID X veicoli: 
 * primo numero=
 * Tipo di veicolo:
 * -auto=1
 * -moto=2
 * -bicinormale=3
 * -E-Bike=4
 * -monopattino=5
 * 
 * secondo numero:
 * Tipo patente:
 * -A=1
 * -B=2
 * -None=3
 * 
 * Daterzo in poi ID PERSONA
*/

//ID PERSONA =NUMERO DI POSIZIONE ARRAY DI PERSONE LOGGATE

/*
 lA PATENTE DI DEFINISCE DAL VEICOLO:

-AUTO=B <------PER IL TIPO NOMI DI AUTO
-MOTO=A <------PER IL TIPO NOMI DI MOTO
-MONOPATTINO,BICINORMALE,E-BIKE =NONE <---- PER IL TIPO STESSA COSA

 */
