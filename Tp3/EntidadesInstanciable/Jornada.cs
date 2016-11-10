using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Archivos;


namespace EntidadesInstanciable
{[Serializable]
  public  class Jornada
    {
      private List<Alumno> _alumno;
      public EClases _clase;
      private Instructor _instructor;

      public Jornada this [int i]
      {
          get { return this[0]; }
          set { this[0] = value; }
      }

      public bool Guardar(Jornada jornada)
      {
          //StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory+"MiArchivo.txt",true);//Doble barra para que no lo tome como caracter de escape o le antepongo @ al stream
          StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MiArchivo.txt", true);//Para elegir la carpeta donde guardar
          sw.WriteLine("Persona");
          sw.WriteLine("Clase: "+this._clase);
          sw.WriteLine("Instructor: " + this._instructor);
          foreach(Alumno item in jornada._alumno)
          {
              sw.WriteLine(item);
          }
          sw.Close();

          return true;
      }

      public bool Leer(Jornada jornada)
      {
          if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MiArchivo.txt"))
          {

              StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MiArchivo.txt", true);
              //Console.WriteLine(" " + sr.Read());//un solo caracter
              //Console.WriteLine(" " + sr.ReadLine());//Una linea
              //Console.WriteLine(" " + sr.ReadToEnd());//Todo
              string L;
              while ((L = sr.ReadLine()) != null)//Muestra renglon por renglon 
              {
                  Console.WriteLine(L);
              }
              sr.Close();
          }               
          return true;
      }


      private Jornada()
      {
          this._alumno = new List<Alumno>();
      }

      public Jornada(EClases clase, Instructor instructor)
      {
          this._clase = clase;
          this._instructor = instructor;
      }

      public static bool operator !=(Jornada j, Alumno a) 
      {
          return !(j == a);
      }

      public static bool operator ==(Jornada j, Alumno a) 
      {
          foreach (Alumno item in j._alumno)
          {
              if (item == a)
                  return true;
          }
          return false;
      }

      public static Jornada operator +(Jornada j, Alumno a) 
      {
          if (j == a)
          {
              j._alumno.Add(a);
          }
          return j;
      }

      public override string ToString()
      {

          StringBuilder sb = new StringBuilder();
          sb.AppendLine("Instructor: " + this._instructor);
          sb.AppendLine("Clase: " + this._clase);
          foreach (Alumno item in _alumno)
          {
              sb.AppendLine(item.ToString());
          }

          return sb.ToString();
      }
           


    }
}
