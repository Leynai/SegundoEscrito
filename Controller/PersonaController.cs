using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace Controller
{
    public class PersonaController
    {
        
        public void CrearPersona(uint id,string name,string lastname)
        {
            PersonaModel Persona = new PersonaModel();
            Persona.SetID(id);
            Persona.SetNombre(name);
            Persona.SetApellido(lastname);
            Persona.Guardar(Persona);
        }
        public void EliminarPersona(uint id)
        {
            PersonaModel Persona = new PersonaModel();
            Persona.Eliminar(id);
        }
        public void ModificarPersona(uint Id = 0,string Nombre = null ,string Apellido = null)
        {
            PersonaModel Persona = new PersonaModel();

            Persona.ModificarPersona(Persona.BuscarPersona(Persona.GetId()), Id, Nombre, Apellido);
        }
        public void BuscarPersona(uint id)
        {
            PersonaModel Persona = new PersonaModel();
            Persona.BuscarPersona(id);
        }
        public void ListarPersonas()
        {
            PersonaModel Persona = new PersonaModel();
            List<PersonaModel> Personas = new List<PersonaModel>();
            Personas = Persona.ListarPersonas();

        }
    }
}
