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
      public Gimnasio.EClases _clase;
      private Instructor _instructor;

      public Instructor MiInstructor 
      {
          get { return _instructor; }
          set { _instructor=value;} 
      }

      public Jornada 
          this[int i]
      {
          get { return this[i]; }
      }

      public static bool Guardar(Jornada jornada)
      {
            StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MiArchivo.txt", true);
            sw.WriteLine("Persona");
            sw.WriteLine("La Clase" + jornada._clase);
            sw.WriteLine("Instructor: " + jornada._instructor);
            foreach (Alumno item in jornada._alumno)
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
          _alumno = new List<Alumno>();
      }

      public Jornada(Gimnasio.EClases clase, Instructor instructor)
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
          if (((object)j == null) || ((object)a == null))
          {
              foreach (Alumno item in j._alumno)
              {
                  if (item == a)
                      return true;
              }
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
