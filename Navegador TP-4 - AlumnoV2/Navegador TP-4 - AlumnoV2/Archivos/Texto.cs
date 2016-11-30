using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Hilo;
using System.IO;

namespace Archivos
{
    public class Texto: IArchivo<string>
    {
        public Texto(string archivo)
        {
            archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\miArchivo.Xml";


        }

        public bool guardar(string datos)
        {
            StreamWriter sw = new StreamWriter(datos,true);
            sw.WriteLine(datos);
            return true;
        }
       public   bool leer(out List<string> datos)
        {
            StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\miArchivo.Xml");
            datos = new List<string>();
            foreach (string item in datos)
            {
                Console.WriteLine(item);
            }
            sr.Close();
            return true;
            
       }
    }
}
