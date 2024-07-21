using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace Controller
{
    public class PersonaController
    {
        
        public static void CrearPersona(uint id,string name,string lastname)
        {
            PersonaModel Persona = new PersonaModel();
            Persona.SetID(id);
            Persona.SetNombre(name);
            Persona.SetApellido(lastname);
            Persona.Guardar(Persona);
        }
        public static void EliminarPersona(uint id)
        {
            PersonaModel Persona = new PersonaModel();
            Persona.Eliminar(id);
        }
        public static void ModificarPersona(uint Id = 0,string Nombre = null ,string Apellido = null)
        {
            PersonaModel Persona = new PersonaModel();

            Persona.ModificarPersona(Persona.BuscarPersona(Persona.GetId()), Id, Nombre, Apellido);
        }
        public static DataTable BuscarPersona(uint id)
        {
            PersonaModel Persona = new PersonaModel();
            DataTable tabla = new DataTable();

            Persona = Persona.BuscarPersona(id);
            DataRow Fila = tabla.NewRow();
            Fila["ID"] = Persona.GetId();
            Fila["Nombre"] = Persona.GetNombre();
            Fila["Apellido"] = Persona.GetApellido();
            tabla.Rows.Add(Fila);

            return tabla;
        }
        public static DataTable ListarPersonas()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Id", typeof(uint));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Apellido", typeof(string));




            PersonaModel Persona = new PersonaModel();
            List<PersonaModel> Personas = new List<PersonaModel>();

            foreach (PersonaModel p in Persona.ListarPersonas())
            {
                DataRow fila = tabla.NewRow();
                fila["Id"] = p.GetId();
                fila["Nombre"] = p.GetNombre();
                fila["Apellido"] = p.GetApellido();
                tabla.Rows.Add(fila);
            }

            return tabla;
        }
    }
}
