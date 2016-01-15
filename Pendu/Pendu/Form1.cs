using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pendu
{
    public partial class Form1 : Form
    {
        MotMystere m;

        public Form1()
        {
            InitializeComponent();
            m = new MotMystere();
            m.init();
            update();
        }

        private void buttoninit_Click(object sender, EventArgs e)
        {
            m.init();
            update();
        }

        private void inlettre_TextChanged(object sender, EventArgs e)
        {
            if (inlettre.Text.Length != 0)
            {
                m.revelelettre(inlettre.Text[0]);
                inlettre.Text = "";
            }
            update();
        }

        private void validermot_Click(object sender, EventArgs e)
        {
            if (inmot.Text.Length != 0)
            {
                m.revelemot(inmot.Text);
            }
            inmot.Text = "";
            update();
        }

        public void update()
        {
            fin.Text = "";
            motaff.Text = m.getmotflou();
            fautes.Text = "Erreurs : " + m.getfautes();

            if (!m.getetat())
            {
                if (m.gagner())
                {
                    fin.Text = "Gagné !!!!!";
                }
                else
                {
                    fin.Text = "Perdu : " + m.getmot();
                }

            }
        }
    }
}
