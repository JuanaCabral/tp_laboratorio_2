using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Archivos
{
  public  class Texto: IArchivo<T>
  {
      public bool Guardar(string archivo, T datos)
      {
          archivo = @"c:\Archivo.Xml";
          datos = archivo;
          return true;
        //  return false;
      }
      
      public bool Leer(string archivo, out T datos)
      {
          archivo = @"c:\Archivo.Xml";
          datos = true;
         // return datos[0];
          
          
          
          
      }
    }
}
