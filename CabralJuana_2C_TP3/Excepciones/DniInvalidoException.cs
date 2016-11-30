using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
   public class DniInvalidoException:Exception
    {
       protected string mensajeBase;

       public DniInvalidoException(string mensaje):base (mensaje)
        {
            mensajeBase = mensaje;
        }
    }
}
