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
            string id = tablaDeDatos.SelectedRows[0].Cells["id"].Value.ToString();
            PersonaController.EliminarPersona(UInt32.Parse(id));
            refrescarTablaDeDatos();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            PersonaController.BuscarPersona(UInt32.Parse(IdBuscarBox.Text));
        }
    }
}
