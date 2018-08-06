using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simon_Dice
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 sf = new Form1();
            sf.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 sf = new Form1();
            sf.Close();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Repetir cada vez la secuencia de pulsaciones que realiza Simon.\n\nSi se equivoca volverá a empezar.\n\nPuede ver los aciertos que lleva en la partidad asi como el nümero máximo de aciertos quee ha obtenido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
