using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Archivos;

namespace EntidadesInstanciable
{
    public enum EClases
    {
        CrossFit, Natacion, Pilates
    }
  
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Instructor))]
    public  class Gimnasio
    {
        private List<Alumno> _alumno;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;
       // private EClases _claseQueToma;
        public Gimnasio() { }

        
        public static bool Guardar(Gimnasio gim)
        {
            XmlTextWriter ser = new XmlTextWriter(@"c:\Archivo.Xml", Encoding.UTF8);
            XmlSerializer escribir = new XmlSerializer(typeof(Gimnasio));
            escribir.Serialize(ser, gim);
            ser.Close();
            return true;

        }
        public static bool Leer(Gimnasio gim)
        {
            Gimnasio aux;

            XmlTextReader leer = new XmlTextReader(@"c:\Archivo.Xml");
            XmlSerializer a = new XmlSerializer((typeof(Gimnasio)));



            aux = (Gimnasio)a.Deserialize(leer);
            Console.WriteLine(aux.ToString());
            leer.Close();
            return true;
        
        }

        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(gim._alumno.ToString());
            sb.AppendLine(gim._instructores.ToString());
            sb.AppendLine(gim._jornada.ToString());
            return sb.ToString();
        }

        public static bool operator ==(Gimnasio g, Alumno a)
        {
            foreach (Alumno item in g._alumno)
            {
                if (item == a)
                    return true;
            }
           
            return false;
        }

        public static bool operator !=(Gimnasio g, Alumno a) 
        {
            return !(g == a);
        }

        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            return(g != clase);
        }

        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            try
            {
                
                if (g._instructores.Count != 0)

                    return g._instructores[0];
            }
            catch (Exception e)
            {
             throw   new Exception("SinInstructorException"  + e.Message);
            }
           
           return g._instructores[0];
        }

        public static Gimnasio  operator +(Gimnasio g, Alumno a) 
        {
            if (g != a)
            {
                g._alumno.Add(a);
            }
            return g;
        }

        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            Instructor e;
            Jornada a;
            g = (g)clase;
            g._jornada.Add(a);
            g._instructores.Add(e);            
           
        }

        public static Gimnasio operator +(Gimnasio g, Instructor i) 
        {
            if (g != i)
            {
                g._instructores.Add(i);
            }
            return g;
        }

        public static bool operator ==(Gimnasio g, Instructor i) 
        {
            foreach (Instructor item in g._instructores)
            {
                if (item == i)
                    return true;
            }

            return false;
        }

        public static bool operator !=(Gimnasio g, Instructor i) 
        {
            return !(g == i);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this._alumno.ToString());
            sb.AppendLine(this._instructores.ToString());
            sb.AppendLine(this._jornada.ToString());
            return sb.ToString();
           
        }



    }
}
