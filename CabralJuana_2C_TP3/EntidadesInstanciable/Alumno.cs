using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.Xml;
using System.Xml.Serialization;
using Archivos;


namespace EntidadesInstanciable
{[Serializable]
    public  class Alumno:PersonaGimnasio 
    {
        public  enum EEstadoCuenta
	    {
            MesPrueba, Deudor, AlDia
	         
	    }
          public  Gimnasio.EClases _claseQueToma;
          protected EEstadoCuenta _estadoCuenta;

          public Alumno() { }

          public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad)
          {
              this._claseQueToma = claseQueToma;
          }
          public Alumno(int id, string nombre, string apellido,string dni,  ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma,EEstadoCuenta estadoCuenta):this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
          {
              this._estadoCuenta = estadoCuenta;
          }
          protected override string MostrarDatos()
          {
              StringBuilder sb = new StringBuilder();
              sb.AppendLine(base.MostrarDatos());
              sb.AppendLine("Clase que toma: "+this._claseQueToma);
              sb.AppendLine("Estado Cuenta: "+this._estadoCuenta);
              return sb.ToString();
          }

          public static bool operator ==(Alumno a, Gimnasio.EClases clase)
          {
              return (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor);
          }
          public static bool operator !=(Alumno a, Gimnasio.EClases clase)
          {
              return !(a == clase);
          }
          protected override string ParticiparEnClase()
          {
              return "TOMA CLASE DE "+this._claseQueToma;
          }
          public override string ToString()
          {
              return MostrarDatos().ToString();
          }
           

    }
}
