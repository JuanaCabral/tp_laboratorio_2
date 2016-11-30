using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Archivos;
using EntidadesAbstractas;
using EntidadesInstanciable;
using Excepciones;

namespace EntidadesInstanciable
{
    
  
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Instructor))]

    public  class Gimnasio
    {
        private List<Alumno> _alumno;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;
        public EClases _claseQueToma;
        


        public Gimnasio()
        {
            _alumno = new List<Alumno>();
            _instructores = new List<Instructor>();
            _jornada = new List<Jornada>();

            
        }

        public Jornada this[int i]
        {
            get { return this[i]; }
        }


        public List<Alumno> Alumno 
        {
            get { return this._alumno; } 
        }
        public List<Instructor> Instructores
        {
            get { return this._instructores; }
        }

        public List<Jornada> Jornada
        {
            get { return this._jornada; }
        }

        public enum EClases
        {
            CrossFit, Natacion, Pilates, yoga
        }
        /// <summary>
        ///Aca deberia reutizar el guarda de la classe archivo pero no se como 
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Guardar(Gimnasio gim)
        {

            try
            {

            //    XmlTextWriter ser = new XmlTextWriter(@"c:\Archivo.Xml", Encoding.UTF8);
            //    XmlSerializer escribir = new XmlSerializer(typeof(Gimnasio));
            //    escribir.Serialize(ser, gim);
            //    ser.Close();
                const string Archivo = @"c:\Archivo.Xml";
                Xml<Gimnasio> g = new Xml<Gimnasio>();
                g.Guardar(Archivo,gim);
                return true;
            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);
                return false;

            }

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
            foreach (Alumno a in gim._alumno)
            {
                sb.AppendLine(a.ToString());
            }
            foreach (Instructor i in gim._instructores)
            {
                sb.AppendLine(i.ToString());
            }
            foreach (Jornada j in gim._jornada)
            {
                sb.AppendLine(j.ToString());
            }

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
            try
            {
                if (!object.Equals(g, null))
                {
                    foreach (Instructor i in g._instructores)
                    {
                        if (i.Equals(clase))
                        {
                            return i;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            return g._instructores[0];

        }

        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            try
            {
                foreach (Instructor i in g._instructores)
                {
                    if (i.Equals(clase))
                    {
                        return i;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            return g._instructores[0];

        }

        public static Gimnasio  operator +(Gimnasio g, Alumno a) 
        {
            
            if (g != a)
            {
                g._alumno.Add(a);
            }

            else
                throw new AlumnoRepetidoException("Alumno repetido");
            return g;
        }

        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            if (((object)g != null) || ((object)clase != null))
            {
                Jornada j = new Jornada(clase, (g == clase));
                for (int i = 0; i < g._alumno.Count; i++)
                {

                    if (g.Equals(clase))
                    {
                        j = j + g._alumno[i];
                        g._jornada.Add(j);
                    }
                }
            }
            return g;
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
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine(this._alumno.ToString());
        //    sb.AppendLine(this._instructores.ToString());
        //    sb.AppendLine(this._jornada.ToString());
        //    return sb.ToString();
          return  MostrarDatos(this).ToString();
        }



    }
}
