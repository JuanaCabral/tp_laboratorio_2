using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;



namespace Archivos
{
  public  class Texto: IArchivo<string>
  {
      public bool Guardar(string archivo, string datos)
      {
          try
          {
              StreamWriter sw = new StreamWriter(archivo, true);
              sw.WriteLine(datos);

              return true;
          }
          catch (ArchivosException e)
          {

              Console.WriteLine(e.InnerException);
              Console.ReadLine();
              return false;

          }
        
        }
      
      public bool Leer(string archivo,  string datos)
      {
            try
            {

                if (File.Exists(archivo))
                {
                    StreamReader sr = new StreamReader(archivo);
                    while ((datos = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(datos);
                      
                    }  //datos = sr.ReadToEnd();

                    sr.Close();
                }
               
                return true;
            }

            catch (ArchivosException e)
            {

                Console.WriteLine(e.InnerException); 
//datos = "";
                Console.ReadLine();
                return false;

            }
        }
    }
}
