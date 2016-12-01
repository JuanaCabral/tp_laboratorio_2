using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
  public  class SinInstructorException:Exception
    {
        public SinInstructorException()
        {
            Console.WriteLine("Sin instructor");
        }

    }
}
