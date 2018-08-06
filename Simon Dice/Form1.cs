using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Xml;

namespace Simon_Dice
{
    public partial class Form1 : Form
    {
        simon Juego = new simon();
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                XmlReader r = XmlReader.Create("Record.xml");
                r.ReadStartElement("Rec");
                txtRecord.Text = r.ReadElementContentAsString();
                r.Close();
            }
            catch (Exception)
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            Juego.NuevoNumero();
            timer2.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = Simon_Dice.Properties.Resources.Boton4Off;
            pictureBox2.Image = Simon_Dice.Properties.Resources.Boton3Off;
            pictureBox3.Image = Simon_Dice.Properties.Resources.Boton1Off;
            pictureBox4.Image = Simon_Dice.Properties.Resources.Boton2Off;
            timer1.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Simon_Dice.Properties.Resources.Boton4On;
            timer1.Enabled = true;
            SoundPlayer Mu = new SoundPlayer(Simon_Dice.Properties.Resources.Nota1);
            Mu.Play();
            ComprobarBoton("1");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Simon_Dice.Properties.Resources.Boton3On;
            timer1.Enabled = true;
            SoundPlayer Mu = new SoundPlayer(Simon_Dice.Properties.Resources.Nota2);
            Mu.Play();
            ComprobarBoton("2");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Simon_Dice.Properties.Resources.Boton1On;
            timer1.Enabled = true;
            SoundPlayer Mu = new SoundPlayer(Simon_Dice.Properties.Resources.Nota3);
            Mu.Play();
            ComprobarBoton("3");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = Simon_Dice.Properties.Resources.Boton2On;
            timer1.Enabled = true;
            SoundPlayer Mu = new SoundPlayer(Simon_Dice.Properties.Resources.Nota4);
            Mu.Play();
            ComprobarBoton("4");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;
            Juego.Error();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;
            switch (Juego.Recorrer())
            {
                case "1":
                    pictureBox1.Image = Simon_Dice.Properties.Resources.Boton4On;
                    timer1.Enabled = true;
                    SoundPlayer Mu1 = new SoundPlayer(Simon_Dice.Properties.Resources.Nota1);
                    Mu1.Play();
                    break;
                case "2":
                    pictureBox2.Image = Simon_Dice.Properties.Resources.Boton3On;
                    timer1.Enabled = true;
                    SoundPlayer Mu2 = new SoundPlayer(Simon_Dice.Properties.Resources.Nota2);
                    Mu2.Play();
                    break;
                case "3":
                    pictureBox3.Image = Simon_Dice.Properties.Resources.Boton1On;
                    timer1.Enabled = true;
                    SoundPlayer Mu3 = new SoundPlayer(Simon_Dice.Properties.Resources.Nota3);
                    Mu3.Play();
                    break;
                case "4":
                    pictureBox4.Image = Simon_Dice.Properties.Resources.Boton2On;
                    timer1.Enabled = true;
                    SoundPlayer Mu4 = new SoundPlayer(Simon_Dice.Properties.Resources.Nota4);
                    Mu4.Play();
                    break;
                default:
                    pictureBox1.Enabled = true;
                    pictureBox2.Enabled = true;
                    pictureBox3.Enabled = true;
                    pictureBox4.Enabled = true;
                    timer2.Enabled = false;
                    break;
            }
        }

        private void ComprobarBoton(string Dato)
        {
            switch (Juego.ComprobarNumero(Dato))
            {
                case "1":
                    //MessageBox.Show("Continua", "Bien", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    timer2.Enabled = false;
                    break;
                case "2":
                    //MessageBox.Show("Pefecto", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Estado.Image = Simon_Dice.Properties.Resources.E2;
                    txtAciertos.Text = Juego.Aciertos().ToString();
                    if (Convert.ToInt16(txtAciertos.Text) > Convert.ToInt16(txtRecord.Text))
                        txtRecord.Text = txtAciertos.Text;
                    SoundPlayer Acierto = new SoundPlayer(Simon_Dice.Properties.Resources.Acierto);
                    Acierto.Play();
                    Juego.NuevoNumero();
                    timer3.Enabled = true;
                    
                    break;
                case "0":
                    //MessageBox.Show("Fallaste", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Estado.Image = Simon_Dice.Properties.Resources.E0;
                    Juego.Error();
                    txtAciertos.Text = "0";
                    SoundPlayer Error = new SoundPlayer(Simon_Dice.Properties.Resources.Error);
                    Error.Play();
                    Juego.NuevoNumero();
                    timer3.Enabled = true;
                    break;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Estado.Image = Simon_Dice.Properties.Resources.E1;
            timer2.Enabled = true;
            timer3.Enabled = false;
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;
        }

        private void txtRecord_TextChanged(object sender, EventArgs e)
        {
            try
            {
                XmlWriter w = XmlWriter.Create("Record.xml");
                w.WriteStartElement("Rec");
                w.WriteElementString("TextBox", txtRecord.Text);
                w.WriteEndElement();
                w.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
