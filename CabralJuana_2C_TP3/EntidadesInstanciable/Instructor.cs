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
        protected Queue<Gimnasio.EClases> _clasesDelDia;
        protected static Random _random;

    public Instructor(){}

        private void _randomClases()
        {
            string[] rClase =  Enum.GetNames(typeof(Gimnasio.EClases));
            Random _random = new Random();
            int randomEnum = _random.Next(rClase.Length);
            var rClaseDia = Enum.Parse(typeof(Gimnasio.EClases), rClase[randomEnum]);
            Console.WriteLine(rClaseDia.ToString());
          // _random.Next(0, 3);
        }
       
        static Instructor()
        {
            _random = new Random();

        }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id, nombre, apellido, dni, nacionalidad)
        {
           // this.StringToDNI = dni;
            _clasesDelDia = new Queue<Gimnasio.EClases>();
            //_clasesDelDia.Enqueue
            //_clasesDelDia.Enqueue(_randomClases());

            _randomClases();
            
        }

        protected override string MostrarDatos() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            return sb.ToString();
        
        }

        public static bool operator ==(Instructor i, Gimnasio.EClases clase) 
         {
             foreach (Gimnasio.EClases item in i._clasesDelDia)
             {
                 if (item == clase && i == clase)
                 {
                     return true;
                 }
     
            }
                return false;
        }

        public static bool operator !=(Instructor i, Gimnasio.EClases clase) 
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
