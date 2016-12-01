using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using Excepciones;
using Archivos;

namespace Archivos
{
   public class Xml<T>:IArchivo<T>
    {

       public bool Guardar(string archivo, T datos)
       {
            try
            {
                //XmlTextWriter tw = new XmlTextWriter(archivo, Encoding.UTF8);
                //XmlSerializer ser = new XmlSerializer(typeof(T));
                //ser.Serialize(tw, datos);
                //tw.Close();
                XmlSerializer ser = new XmlSerializer(typeof(T));
                TextWriter writer = new StreamWriter(archivo);
                ser.Serialize(writer, datos);
                writer.Close();
                return true;
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.InnerException);
                Console.ReadLine();
                return false;

            }
            

        }

       public bool Leer(string archivo, T datos)
       {
            try
            {
                XmlTextReader tr = new XmlTextReader(archivo);
                XmlSerializer ser = new XmlSerializer(typeof(T));

                datos = (T)ser.Deserialize(tr);
                tr.Close();
                return true;
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.InnerException);
                Console.ReadLine();
                return false;
            }

        }
    }
}
