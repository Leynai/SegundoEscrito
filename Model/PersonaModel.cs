using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PersonaModel : MysqlModel
    {
        private string nombre = null;
        private string apellido = null;
        private uint id = 0;

        public string GetNombre()
        {
            return this.nombre;
        }
        public string GetApellido()
        {
            return this.apellido;
        }
        public uint GetId()
        {
            return this.id;
        }


        public void SetNombre(string Nom)
        {
            this.nombre = Nom;
        }
        public void SetApellido(string Apellido)
        {
            this.apellido = Apellido;
        }
        public void SetID(uint ID)
        {
            this.id = ID;
        }


        public void Guardar(PersonaModel Persona)
        {
            string sql = $"INSERT INTO Personas (id,nombre,apellido) VALUES('{Persona.GetId()}','{Persona.GetNombre()}','{Persona.GetApellido()}')";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void Eliminar(uint id)
        {
            string sql = $"DELETE FROM Personas WHERE id = {id}";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public PersonaModel BuscarPersona(uint ID)
        {
            PersonaModel Persona = new PersonaModel();
            string sql = $"SELECT * FROM Personas WHERE ID = '{ID}'";
            this.Comando.CommandText = sql;
            this.Lector = this.Comando.ExecuteReader();

            Persona.SetID(UInt32.Parse(this.Lector["id"].ToString()));
            Persona.SetNombre(this.Lector["nombre"].ToString());
            Persona.SetApellido(this.Lector["apellido"].ToString());

            return Persona;
        }
        public List<PersonaModel> ListarPersonas()
        {
            List<PersonaModel> Personas = new List<PersonaModel>();

            string sql = $"SELECT * FROM personas";
            this.Comando.CommandText = sql;
            this.Lector = this.Comando.ExecuteReader();

            while (this.Lector.Read())
            {
                PersonaModel Persona = new PersonaModel();
                Persona.SetID(UInt32.Parse(this.Lector["id"].ToString()));
                Persona.SetNombre(this.Lector["nombre"].ToString());
                Persona.SetApellido(this.Lector["apellido"].ToString());
                Personas.Add(Persona);
            }

            return Personas;
        }

        public void ModificarPersona(PersonaModel Persona, uint ID = 0, string Nombre = null, string Apellido = null)
        {
            if (ID == 0)
            {
                ID = Persona.GetId();
            }
            if (Nombre == null)
            {
                Nombre = Persona.GetNombre();
            }
            if (Apellido == null)
            {
                Apellido = Persona.GetApellido();
            }

            string sql = $"UPDATE personas SET nombre = '{Nombre}', apellido = '{Apellido}', id = '{ID}' WHERE id = '{Persona.GetId()}'";

        }


    }
}
