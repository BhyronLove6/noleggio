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
        double latIniz = 45.6887943193688;
        double longtIniz = 9.67157363891602;
        float PrezzoVeicoloNoleggiato;
        bool Disponibile = true;
        int secondi = 0, minuti = 0, ore = 0;
        int numVeic = 0;
        Veicolo[] veicoli = new Veicolo[100];
        User[] Utenti = new User[100];
        Auto auto = new Auto();
        Bici bici = new Bici();
        BiciElettrica biciElettrica = new BiciElettrica();
        Motorino motorino = new Motorino();
        Monopattino monopattino = new Monopattino();
        public GMapOverlay[] markers = new GMapOverlay[100];
        string Infotutto;


        #region CLASSI
        class Veicolo
        {
            protected string identificativo;
            protected float latitudine;
            protected float longitudine;
            protected float prezzo;
            protected string immagine;

            public Veicolo()
            {
                identificativo = "";
                latitudine = 0;
                longitudine = 0;
                prezzo = 0;
                immagine = "";
            }

            public Veicolo(string id)
            {
                identificativo = id;
                latitudine = 0;
                longitudine = 0;
                prezzo = 0;
                immagine = "";
            }

            public Veicolo(string id, float lat, float longi)
            {
                identificativo = id;
                latitudine = lat;
                longitudine = longi;
                prezzo = 0;
                immagine = "";
            }

            public Veicolo(string id, float pr)
            {
                identificativo = id;
                latitudine = 0;
                longitudine = 0;
                prezzo = pr;
                immagine = "";
            }

            public Veicolo(string id, float lat, float longi, float pr)
            {
                identificativo = id;
                latitudine = lat;
                longitudine = longi;
                prezzo = pr;
                immagine = "";
            }

            public Veicolo(string id, float lat, float longi, float pr, string img)
            {
                identificativo = id;
                latitudine = lat;
                longitudine = longi;
                prezzo = pr;
                immagine = img;
            }

            public Veicolo(string id, float pr, string img)
            {
                identificativo = id;
                latitudine = 0;
                longitudine = 0;
                prezzo = pr;
                immagine = img;
            }

            public Veicolo(float pr, float lat, float longi)
            {
                identificativo = "no id for you";
                latitudine = lat;
                longitudine = longi;
                prezzo = pr;
                immagine = "serio?";
            }

            public Veicolo(float pr, float lat, float longi, string img)
            {
                identificativo = "no id for you";
                latitudine = lat;
                longitudine = longi;
                prezzo = pr;
                immagine = img;
            }

            public Veicolo(string id, float lat, float longi, string img)
            {
                identificativo = id;
                latitudine = lat;
                longitudine = longi;
                prezzo = 0;
                immagine = img;
            }

            public float GetLatitudine()
            {
                return latitudine;
            }

            public float GetLongitudine()
            {
                return longitudine;
            }

            public string GetIdentificativo() { return identificativo; }

            public float GetPrezzo() { return prezzo; }

            public string GetImmagine() { return immagine; }

            public void SetLatitudine(float lat)
            {
                latitudine = lat;
            }

            public void SetLongitudine(float longi)
            {
                longitudine = longi;
            }

            public void SetIdentificativo(string id)
            {
                identificativo = id;
            }

            public void SetPrezzo(float pr)
            {
                if (pr > 0 && pr < 500)
                {
                    prezzo = pr;
                }
                else
                {
                    Console.WriteLine("Prezzo eccessivo!");
                }
            }

            public void SetImmagine(string img)
            {
                immagine = img;
            }

            public virtual void StampaScheda()
            {
                Console.WriteLine("ⓘ Informazioni: ");
                Console.WriteLine($"➤ Identificativo: {identificativo}");
                Console.WriteLine($"➤ Prezzo: {prezzo}");
                Console.WriteLine($"➤ Immagine: {immagine}");
                Console.WriteLine("➤ Posizione :");
                Console.WriteLine($"              Latitudine: {latitudine}\n              Longitudine: {longitudine}");
            }

        }
        class Auto : Veicolo
        {
            private int Nposti { get; set; }
            private int Potenza { get; set; }
            private int BagL { get; set; }

            public Auto() : base()
            {
                Nposti = 2;
                Potenza = 0;
                BagL = 0;
            }

            public Auto(string id) : base(id)
            {
                Nposti = 2;
                Potenza = 0;
                BagL = 0;
            }

            public Auto(string id, float lat, float longi) : base(id, lat, longi)
            {
                Nposti = 2;
                Potenza = 0;
                BagL = 0;
            }

            public Auto(string id, float pr) : base(id, pr)
            {
                Nposti = 2;
                Potenza = 0;
                BagL = 0;
            }

            public Auto(string id, float lat, float longi, float pr) : base(id, lat, longi, pr)
            {
                Nposti = 2;
                Potenza = 0;
                BagL = 0;
            }

            public Auto(string id, float lat, float longi, float pr, string img) : base(id, lat, longi, pr, img)
            {
                Nposti = 2;
                Potenza = 0;
                BagL = 0;
            }

            public Auto(string id, float pr, string img) : base(id, pr, img)
            {
                Nposti = 2;
                Potenza = 0;
                BagL = 0;
            }

            public Auto(float pr, float lat, float longi) : base(pr, lat, longi)
            {
                Nposti = 2;
                Potenza = 0;
                BagL = 0;
            }

            public Auto(float pr, float lat, float longi, string img) : base(pr, lat, longi, img)
            {
                Nposti = 2;
                Potenza = 0;
                BagL = 0;
            }

            public Auto(string id, float lat, float longi, float pr, string img, int np, int pot, int bag) : base(id, lat, longi, pr, img)
            {
                Nposti = np;
                Potenza = pot;
                BagL = bag;
            }

            public int GetNposti() { return Nposti; }

            public int GetPotenza() { return Potenza; }

            public int GetBagL() { return BagL; }

            public void SetNposti(int np)
            {
                if (np <= 9)
                {
                    Nposti = np;
                }
                else
                {
                    Console.WriteLine("Questa non è un auto!!!");
                }
            }

            public void SetPotenza(int pot)
            {
                if (pot <= 1000)
                {
                    Potenza = pot;
                }
            }
            public void SetBagL(int bag)
            {
                if (bag >= 0)
                {
                    BagL = bag;
                }
            }

            public override void StampaScheda()
            {
                base.StampaScheda();
                Console.WriteLine($"➤ Posti: {Nposti}");
                Console.WriteLine($"➤ Potenza: {Potenza}");
                Console.WriteLine($"➤ Capacità bagagliaio: {BagL}");
            }
        }
        class Bici : Veicolo
        {
            private bool Casco { get; set; }
            private bool Cestino { get; set; }
            private bool SedileBimbo { get; set; }
            public Bici() : base()
            {
                Casco = true;
                Cestino = false;
                SedileBimbo = false;
            }
            public Bici(string id, float pr, string img, bool casco, bool cestino, bool sedileBimbo) : base(id, pr, img)
            {
                Casco = casco;
                Cestino = cestino;
                SedileBimbo = sedileBimbo;
            }

            public override void StampaScheda()
            {
                Console.WriteLine("Bici");
                base.StampaScheda();
                Console.WriteLine($"➤ Casco: {Casco}");
                Console.WriteLine($"➤ Cestino: {Cestino}");
                Console.WriteLine($"➤ Sedile Bambino: {SedileBimbo}");
            }
        }
        class BiciElettrica : Bici
        {
            public int Batteria { get; set; }
            public BiciElettrica() : base()
            {
                Batteria = 80;

            }

            public BiciElettrica(string id, float lat, float longi, float pr, string img, bool casco, bool cestino, bool sedileBimbo, int batteria) : base(id, pr, img, casco, cestino, sedileBimbo)
            {
                Batteria = batteria;
            }

            public override void StampaScheda()
            {
                Console.WriteLine("Bici Elettrica");
                base.StampaScheda();
                Console.WriteLine($"➤ Batteria: {Batteria}%");
            }
        }
        class Motorino : Veicolo
        {
            public string Azienda { get; set; }
            public int Cilindrata { get; set; }
            public Motorino() : base()
            {
                Azienda = "Si spera che non sia tarocca";
                Cilindrata = 50;

            }

            public Motorino(string id, float lat, float longi, float pr, string img, string azienda, int cilindrata) : base(id, lat, longi, pr, img)
            {
                Azienda = azienda;
                Cilindrata = cilindrata;
            }

            public override void StampaScheda()
            {
                Console.WriteLine("Motorino");
                base.StampaScheda();
                Console.WriteLine($"➤ Azienda: {Azienda}");
                Console.WriteLine($"➤ Cilindrata: {Cilindrata}");
            }
        }
        class Monopattino : Veicolo
        {
            public string Azienda { get; set; }
            public int Batteria { get; set; }
            public bool Casco { get; set; }

            public Monopattino() : base()
            {
                Azienda = "Si spera che non sia tarocca";
                Batteria = 80;
                Casco = false;

            }

            public Monopattino(string id, float lat, float longi, float pr, string img, int batteria, bool casco, string azienda) : base(id, lat, longi, pr, img)
            {
                Azienda = azienda;
                Batteria = batteria;
                Casco = casco;
            }

            public override void StampaScheda()
            {
                Console.WriteLine("Monopattino");
                base.StampaScheda();
                Console.WriteLine($"➤ Azienda: {Azienda}");
                Console.WriteLine($"➤ Batteria: {Batteria}");
                Console.WriteLine($"➤ Casco: {Casco}");
            }
        }
        class User
        {
            private string Usernames;
            private string Passwords;

            public string GetUsername()
            {
                return Usernames;
            }

            public void SetUsername(string username)
            {
                Usernames = username;
            }

            public string GetPassword()
            {
                return Passwords;
            }

            public void SetPassword(string password)
            {
                Passwords = password;
            }
        }
        #endregion

        public void creamarker(double lat, double lon, int type)
        {
           
            //MessageBox.Show(lat.ToString()); //PROBLEMA QUA, TOGLIE IL PUNTO
            GMapOverlay mk = new GMapOverlay("markers");
            PointLatLng point = new PointLatLng(lat, lon);
                

                switch (type)
                {
                    case 0:
                        {
                            Bitmap bmpMarker1 = (Bitmap)Image.FromFile("img/car.png");
                            GMapMarker marker = new GMarkerGoogle(point, bmpMarker1);
                            marker.ToolTipText = $"{numVeic}";

                            mk.Markers.Add(marker);
                            gMapControl1.Overlays.Add(mk);
                            markers[numVeic] = mk;
                            numVeic++;
                            break;
                        }
                    case 1:
                        {
                            Bitmap bmpMarker1 = (Bitmap)Image.FromFile("img/moto-removebg-preview (1).png");
                            GMapMarker marker = new GMarkerGoogle(point, bmpMarker1);
                            marker.ToolTipText = $"{numVeic}";
                            mk.Markers.Add(marker);
                            gMapControl1.Overlays.Add(mk);
                            markers[numVeic] = mk;
                            numVeic++;
                            break;
                        }
                    case 2:
                        {
                            Bitmap bmpMarker1 = (Bitmap)Image.FromFile("img/monopattino1.png");
                            GMapMarker marker = new GMarkerGoogle(point, bmpMarker1);
                            marker.ToolTipText = $"{numVeic}";
                            mk.Markers.Add(marker);
                            gMapControl1.Overlays.Add(mk);
                            markers[numVeic] = mk;
                            numVeic++;
                            break;
                        }
                    case 3:
                        {
                            Bitmap bmpMarker1 = (Bitmap)Image.FromFile("img/bici.png");
                            GMapMarker marker = new GMarkerGoogle(point, bmpMarker1);
                            marker.ToolTipText = $"{numVeic}";
                            mk.Markers.Add(marker);
                            gMapControl1.Overlays.Add(mk);
                            markers[numVeic] = mk;
                            numVeic++;
                            break;
                        }
                    case 4:
                        {
                            Bitmap bmpMarker1 = (Bitmap)Image.FromFile("img/bici.png");
                            GMapMarker marker = new GMarkerGoogle(point, bmpMarker1);
                            marker.ToolTipText = $"{numVeic}";
                            mk.Markers.Add(marker);
                            gMapControl1.Overlays.Add(mk);
                            markers[numVeic] = mk;
                            numVeic++;
                            break;
                        }
                }
            
        }
        public Form1()
        {
            InitializeComponent();

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
                    if (Utenti[i].GetUsername() == textbox_username.Text && Utenti[i].GetPassword() == textbox_password.Text)
                    {
                        textbox_password.Hide();
                        panelfinale.Hide();
                        textbox_username.Hide();
                        button_login.Hide();
                        label_username.Hide();
                        label_password.Hide();
                        label_titolo.Hide();
                        label_sottotitolo.Hide();
                        panel1.Show();
                        label_veicoli.Show();
                        panelnoleggio.Hide();
                        checkBox_password.Visible = false;
                        gMapControl1.Show();
                        label_Mappa.Show();
                        textBox_latitudine.Show();
                        textBox_longitudine.Show();
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
                        id1.Text = "ID: "+veicoli[0].GetIdentificativo();
                        prezzo1.Text = "Prezzo: " + Convert.ToString(veicoli[0].GetPrezzo()) + " €";
                        flowLayoutPanel1.BackgroundImage = Image.FromFile("img/carnoleggio1.png");
                        id2.Text = "ID: "+veicoli[0].GetIdentificativo();
                        prezzo2.Text = "Prezzo: " + Convert.ToString(veicoli[1].GetPrezzo()) + " €";
                        flowLayoutPanel7.BackgroundImage = Image.FromFile("img/bici-removebg-preview1.png");
                        id3.Text = "ID: "+veicoli[2].GetIdentificativo();
                        prezzo3.Text = "Prezzo: " + Convert.ToString(veicoli[2].GetPrezzo()) + " €";
                        flowLayoutPanel8.BackgroundImage = Image.FromFile("img/EBIKE-removebg-preview1.png");
                        id4.Text = "ID: "+veicoli[3].GetIdentificativo();
                        prezzo4.Text = "Prezzo: " + Convert.ToString(veicoli[3].GetPrezzo()) + " €";
                        flowLayoutPanel9.BackgroundImage = Image.FromFile("img/motorino-removebg-preview1.png");
                        id5.Text = "ID: "+veicoli[4].GetIdentificativo();
                        prezzo5.Text = "Prezzo: " + Convert.ToString(veicoli[4].GetPrezzo())+ " €";
                        flowLayoutPanel10.BackgroundImage = Image.FromFile("img/monopattinonoleggio1.png");

                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int numVeicoli = 0;

            // Leggi il file veicoli.txt riga per riga
            using (StreamReader sar = new StreamReader("veicoli.txt"))
            {
                string lines;
                while ((lines = sar.ReadLine()) != null)
                {
                    // Dividi la riga in base alla virgola
                    string[] parts = lines.Split(',');
                    // Verifica che ci siano abbastanza parti nella riga
                    if (parts.Length >= 3)
                    {
                        // Estrai i dettagli del veicolo dalla riga
                        string tipoVeicolo = parts[0].Trim();

                        #region Latitudine(Calcolo)
                        double latitudine;
                        {
                            string latS = parts[1];
                            double latitudine1 = Convert.ToDouble(latS.Split('.')[0]);
                            double latitudine2 = Convert.ToDouble(latS.Split('.')[1]);
                            string decim = latS.Split('.')[1];
                            double a = decim.Length;
                            latitudine2 = latitudine2 / Math.Pow((double)10, a);
                            latitudine = (double)latitudine1 + (double)latitudine2;
                        }
                        #endregion

                        #region Longitudine(Calcolo)
                        double longitudine;
                        {
                            string lngS = parts[2];
                            double longitudine1 = Convert.ToDouble(lngS.Split('.')[0]);
                            double longitudine2 = Convert.ToDouble(lngS.Split('.')[1]);
                            string decim = lngS.Split('.')[1];
                            double a = decim.Length;
                            longitudine2 = longitudine2 / Math.Pow((double)10, a);
                            longitudine = (double)longitudine1 + (double)longitudine2;
                        }
                        #endregion

                        //ERRORE : MI METTE LE POSIZIONE SBAGLIATE
                        Console.WriteLine(longitudine);
                        float prezzo = float.Parse(parts[3].Trim());
                        string identificativo = parts[4].Trim();
                        bool Casco;
                        bool Cestino;
                        bool SedileBimbo;
                        int Nposti;
                        int Potenza;
                        int BagL;
                        string Azienda;
                        int Cilindrata;
                        int Batteria;
                        // In base al tipo di veicolo, crea un'istanza corrispondente e inseriscila nel vettore
                        switch (tipoVeicolo)
                        {
                            case "AUTO":
                                
                                Nposti = int.Parse(parts[6].Trim());
                                Potenza = int.Parse(parts[7].Trim());
                                BagL = int.Parse(parts[8].Trim());
                                veicoli[numVeicoli] = new Auto(identificativo, (float)latitudine, (float)longitudine, prezzo, "img/carnoleggio.png", Nposti, Potenza, BagL);
                                creamarker(latitudine, longitudine, 0);
                                break;
                            case "BICI":
                                
                                Casco = bool.Parse(parts[6].Trim());
                                Cestino = bool.Parse(parts[7].Trim());
                                SedileBimbo = bool.Parse(parts[8].Trim());
                                veicoli[numVeicoli] = new Bici(identificativo, prezzo, "img/bici-removebg-preview.png", Casco, Cestino, SedileBimbo);
                                creamarker(latitudine, longitudine, 3);
                                break;
                            case "BICI_ELETTRICA":
                                
                                Casco = bool.Parse(parts[6].Trim());
                                Cestino = bool.Parse(parts[7].Trim());
                                SedileBimbo = bool.Parse(parts[8].Trim());
                                Batteria = int.Parse(parts[9].Trim());
                                veicoli[numVeicoli] = new BiciElettrica(identificativo, (float)latitudine, (float)longitudine, prezzo, "img/EBIKE-removebg-preview.png", Casco, Cestino, SedileBimbo, 100);
                                creamarker(latitudine, longitudine, 4);
                                break;
                            case "MOTORINO":
                                
                                Azienda = parts[5].Trim();
                                Cilindrata = int.Parse(parts[6].Trim());
                                veicoli[numVeicoli] = new Motorino(identificativo, (float)latitudine, (float)longitudine, prezzo, "img/motorino-removebg-preview.png", Azienda, Cilindrata);
                                creamarker(latitudine, longitudine, 1);
                                break;
                            case "MONOPATTINO":
                                creamarker(latitudine, longitudine, 2);
                                Azienda = parts[6].Trim();
                                Batteria = int.Parse(parts[7].Trim());
                                Casco = bool.Parse(parts[8].Trim());
                                veicoli[numVeicoli] = new Monopattino(identificativo, (float)latitudine, (float)longitudine, prezzo, "img/monopattinonoleggio.png", Batteria, Casco, Azienda);
                                break;
                            default:
                                Console.WriteLine($"Tipo di veicolo non supportato: {tipoVeicolo}");
                                continue;
                        }

                        // Incrementa il contatore dei veicoli
                        numVeicoli++;

                        // Se hai raggiunto la dimensione massima del vettore, esci dal ciclo
                        if (numVeicoli >= veicoli.Length)
                        {
                            break;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            for (int j = 0; j < 100; j++)
            {
                Utenti[j] = new User();
                Utenti[j].SetUsername("");
                Utenti[j].SetPassword("");
            }
            panel1.Hide();
            panelnoleggio.Hide();
            gMapControl1.OnMarkerClick += gmap_OnMarkerClick;
            button_coord.Hide();
            gMapControl1.Hide();
            dataerror.Hide();
            label_Mappa.Hide();
            textBox_latitudine.Hide();
            textBox_longitudine.Hide();
            button_Indietro.Hide();
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            double lat = Convert.ToDouble(textBox_latitudine.Text);
            double longt = Convert.ToDouble(textBox_longitudine.Text);
            gMapControl1.Position = new PointLatLng(lat, longt);
            gMapControl1.Zoom = 10;
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 100;

            string line = "";
            int i = 0;
            StreamReader sr = new StreamReader("account.txt");
            while ((line = sr.ReadLine()) != null) 
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 2) 
                {
                    Utenti[i].SetUsername(parts[0].Trim()); 
                    Utenti[i].SetPassword(parts[1].Trim()); 
                    i++;
                }
            }
            sr.Close();

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
        
        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {

            Infotutto = item.ToolTipText;

            // Puoi fare ciò che vuoi con le informazioni del marker, ad esempio stamparle
            Console.WriteLine("Marker info: " + Infotutto);

            // Puoi anche estrarre informazioni specifiche dal tooltip, se necessario
            //MessageBox.Show(markerInfo);
            panelnoleggio.Show();

            for (int i = 0; i < numVeic; i++)
            {
                if (i == Convert.ToInt32(Infotutto))
                {
                    
                    aziendanoleggiodefinitivo.Text = "unknown";
                    IDveicolofinale.Text =  Convert.ToString(veicoli[i].GetIdentificativo());
                    if (Convert.ToString(veicoli[i].GetPrezzo()) == "25")
                    {
                        tiponoleggiodefinitivo.Text = "Auto";
                        patentenoleggiodefinitivo.Text = "B";
                    }else if(Convert.ToString(veicoli[i].GetPrezzo()) == "12")
                    {
                        tiponoleggiodefinitivo.Text = "Motorino";
                        patentenoleggiodefinitivo.Text = "A";
                    }
                    else if (Convert.ToString(veicoli[i].GetPrezzo()) == "8")
                    {
                        tiponoleggiodefinitivo.Text = "E-Bike";
                        patentenoleggiodefinitivo.Text = "None";
                        latitudinenoleggiodefinitivo.Text=Convert.ToString(veicoli[i].GetLatitudine());
                    }
                    else if (Convert.ToString(veicoli[i].GetPrezzo()) == "15")
                    {
                        tiponoleggiodefinitivo.Text = "Bici";
                        patentenoleggiodefinitivo.Text = "None";
                    }
                    else if (Convert.ToString(veicoli[i].GetPrezzo()) == "10")
                    {
                        tiponoleggiodefinitivo.Text = "Monopattino";
                        patentenoleggiodefinitivo.Text = "None";
                    }
                    latitudinenoleggiodefinitivo.Text = Convert.ToString(veicoli[i].GetLatitudine());
                    longitudinenoleggiodefinitivo.Text = Convert.ToString(veicoli[i].GetLongitudine());
                    prezzonoleggio.Text = Convert.ToString(veicoli[i].GetPrezzo());
                    PrezzoVeicoloNoleggiato = veicoli[i].GetPrezzo();
                    flowLayoutPanel11.BackgroundImage=Image.FromFile(veicoli[i].GetImmagine());

                }
            }



        }
        private void button_Noleggia_Click(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            panelnoleggio.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (Disponibile)
            {
                label26.Text = "Tempo: ";
                label46.Show();
                button4.Hide();
                button6.Hide();
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
            if (Disponibile)
            {
                button6.Show();
                label46.Text = ore.ToString() + ":" + minuti.ToString() + ":" + secondi.ToString();
                timer1.Enabled = false;

                label25.Text = "Tempo utilizzo: " + ore.ToString() + ":" + minuti.ToString() + ":" + secondi.ToString();
                float CostoFinale = 0;
                if (minuti < 60 && ore < 1)
                {
                    CostoFinale = PrezzoVeicoloNoleggiato;
                }
                else
                {
                    float tempoUtilizzo;
                    tempoUtilizzo = (ore * 60) + minuti;
                    float PrezzoAlMinuti = PrezzoVeicoloNoleggiato / 60;
                    CostoFinale = tempoUtilizzo * PrezzoAlMinuti;
                }
                label46.Hide();
                label26.Text = "Devi pagare: " + CostoFinale.ToString();
                

            }
            
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

        private void button_register_Click(object sender, EventArgs e)
        {
            string username = textbox_username.Text;
            string password = textbox_password.Text;

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                // Apri il file in modalità di scrittura e aggiungi testo
                using (StreamWriter sw = new StreamWriter("account.txt", true))
                {
                    // Scrivi username e password separati da virgola su una nuova riga nel file
                    sw.WriteLine($"{username},{password}");
                    sw.WriteLine();
                }

                // Pulisci le caselle di testo dopo aver salvato
                textbox_username.Text = "";
                textbox_password.Text = "";

                // Messaggio di conferma
                MessageBox.Show("Account registrato con successo!");


                button_register.Hide();
                button_login.Show();
            }
            else
            {
                // Avvisa l'utente se username o password sono vuoti
                MessageBox.Show("Inserisci username e password.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (lats.Text != null && longitudinenewpos.Text != null)
            {

                for (int i = 0; i < numVeic; i++)
                {
                    if (markers[i].Markers[0].ToolTipText == Infotutto &&lats.Text!="" && longitudinenewpos.Text !="")
                    {
                        markers[i].Markers[0].Position = new PointLatLng(Convert.ToDouble(lats.Text), Convert.ToDouble(longitudinenewpos.Text));
                    }
                    else {
                        markers[i].Markers[0].Position = markers[i].Markers[0].Position;
                    }
                }
                ore = 0;
                minuti = 0;
                secondi = 0;
                label25.Text = "Noleggio avvenuto con successo";
                panelfinale.Hide();
                button_coord.Hide();
                panelnoleggio.Hide();
                panel1.Hide();
                label_veicoli.Hide();
                gMapControl1.Hide();
                dataerror.Hide();
                label_Mappa.Hide();
                textBox_latitudine.Hide();
                textBox_longitudine.Hide();
                panelfinale.Hide();
                button_Indietro.Hide();

                textbox_password.Show();
                panelfinale.Show();
                textbox_username.Show();
                button_login.Show();
                label_username.Show();
                label_password.Show();
                label_titolo.Show();
                label_sottotitolo.Show();
                timer1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Inserisci dove hai lasciato il veicolo");
            }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            Console.WriteLine(String.Format("Marker {0} was clicked.", item.Tag));
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
