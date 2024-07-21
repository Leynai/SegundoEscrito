using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Controller;
namespace SegundoEscritoGF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tablaDeDatos.Rows.Add("ID", typeof(uint));
            tablaDeDatos.Rows.Add("Nombre", typeof(string));
            tablaDeDatos.Rows.Add("Apellido", typeof(string));
        }

        private void GuardarPersonaButton_Click(object sender, EventArgs e)
        {

            PersonaController.CrearPersona(UInt32.Parse(IdTextBox.Text), NombreTextBox.Text, ApellidoTextBox.Text);
            refrescarTablaDeDatos();

        }

        private void refrescarTablaDeDatos()
        {
            tablaDeDatos.Refresh();
            tablaDeDatos.DataSource = PersonaController.ListarPersonas();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            string id = tablaDeDatos.SelectedRows[0].Cells["ID"].Value.ToString();
            PersonaController.EliminarPersona(UInt32.Parse(id));
            refrescarTablaDeDatos();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            tablaDeDatos.Rows.Clear();
            tablaDeDatos.Refresh();
            tablaDeDatos.DataSource = PersonaController.BuscarPersona(UInt32.Parse(IdBuscarBox.Text));
           
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            uint id = 0;
            string nom = null;
            string ape = null;

            if (!string.IsNullOrWhiteSpace(IdModificarText.Text))
            {
                id = UInt32.Parse(IdModificarText.Text);
            }
            if (!string.IsNullOrWhiteSpace(NombreModificarText.Text))
            {
                nom = NombreModificarText.Text;
            }
            if (!string.IsNullOrWhiteSpace(ApellidoModificarText.Text))
            {
                ape = ApellidoModificarText.Text;
            }

            PersonaController.ModificarPersona(id, nom, ape);
            refrescarTablaDeDatos();
        }

        private void MostrarDatosButton_Click(object sender, EventArgs e)
        {
            refrescarTablaDeDatos();
        }
    }
}
