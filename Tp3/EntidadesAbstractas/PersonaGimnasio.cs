using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
  public abstract  class PersonaGimnasio:Persona
    {
      protected int _identificador;

      public PersonaGimnasio() { }

      public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre, apellido, nacionalidad)
      {
          this._identificador = id;
      }

      public override bool Equals(object obj)
      {
          if (obj is PersonaGimnasio)
              return true;
          return false;
      }

      protected virtual string MostrarDatos()
      {
          StringBuilder sb = new StringBuilder();
          sb.AppendLine("Identificador"+this._identificador);
          sb.AppendLine(base.ToString());
          return sb.ToString();
      
      }

      public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
      {
          return (pg1._identificador == pg2._identificador || pg1._dni == pg2._dni && pg1.Equals(pg2));
      
      }
      public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
      {
          return !(pg1 == pg2);
      }
      protected abstract string ParticiparEnClase();
      
      
      }
}
