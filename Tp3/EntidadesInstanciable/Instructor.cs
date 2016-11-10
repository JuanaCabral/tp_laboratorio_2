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
    public class Instructor:PersonaGimnasio
    {
        protected Queue<EClases> _clasesDelDia;
        protected static Random _random;

    public Instructor(){}

        private void RandomClase()
        {
          _random.Next(0, 2);
        }
       
        static Instructor()
        {
            _random = new Random();

        }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id, nombre, apellido, dni, nacionalidad)
        {
            _clasesDelDia = new Queue<EClases>();
            RandomClase();
            
        }

        protected override string MostrarDatos() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            return sb.ToString();
        
        }

        public static bool operator ==(Instructor i, EClases clase) 
         {
             foreach (EClases item in i._clasesDelDia)
             {
                 if (item == clase)
                 {
                     return true;
                 }
     
            }
                return false;
        }

        public static bool operator !=(Instructor i, EClases clase) 
        {
            return !(i == clase);
        }

        protected override string ParticiparEnClase()
        {
            return "CLASE DEL DIA" + this._clasesDelDia;
        }

        public override string ToString()
        {
            return MostrarDatos();
        }

    }
}
