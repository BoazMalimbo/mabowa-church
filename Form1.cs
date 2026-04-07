using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eglise_mambowa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void LoadForm(object Form)
        {
            // vérifier si le panel contient déjà un formulaire
            if (this.main_forms.Controls.Count > 0)
                // supprimer le formulaire existant
                this.main_forms.Controls.RemoveAt(0);

            // convertir l'objet en formulaire
            Form f = Form as Form;

            // indiquer que le formulaire n'est pas une fenêtre indépendante
            f.TopLevel = false;

            // enlever les bordures du formulaire
            f.FormBorderStyle = FormBorderStyle.None;

            // faire occuper tout l'espace du panel
            f.Dock = DockStyle.Fill;

            // ajouter le formulaire dans le panel
            this.main_forms.Controls.Add(f);

            // mémoriser le formulaire
            this.main_forms.Tag = f;

            // afficher le formulaire
            f.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadForm(new Form2());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadForm(new revenus());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadForm(new depenses());
        }

        private void btn_tablaBord_Click(object sender, EventArgs e)
        {
            LoadForm(new Form2());
        }

        private void btn_rapport_Click(object sender, EventArgs e)
        {
            LoadForm(new rapport());
        }
    }
}
