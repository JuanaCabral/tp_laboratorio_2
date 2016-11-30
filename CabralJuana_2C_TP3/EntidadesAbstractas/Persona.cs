using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;


namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        protected string _apellido;
        protected int _dni;
        protected ENacionalidad _nacionalidad;
        protected string _nombre;

        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        public Persona() { }


        public string Apellido
        {
            get { return _apellido; }
            set { _apellido=ValidarNombreApellido(value); }
        }

        public int DNI
        {
            get { return _dni; }
            set { _dni= ValidarDni(this._nacionalidad, value); }
        }
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre=ValidarNombreApellido(value); }
        }

        public string StringToDNI
        {
            set
            {
                _dni = ValidarDni (this._nacionalidad, int.Parse( value));
            }
        }
        

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Nacionalidad = nacionalidad;
         }
        public Persona(string nombre, string apellido,  int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            DNI = dni;
        }

        public Persona(string nombre, string apellido,string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad) 
        {
            StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nombre Completo: " + this._apellido + "," + this._nombre);
            sb.AppendLine("DNI: " + this.DNI.ToString());
            sb.AppendLine("Nacionalidad: " + this._nacionalidad);
            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int dniReturn = 0;
            try
            {
                if (ENacionalidad.Argentino == nacionalidad)
                {
                    if (dato <= 89999999 && dato > 0)
                    {
                        return dato;
                    }
                    else
                        throw new DniInvalidoException("La nacionalidad no se condice con el número de DNI");
                }
                if (ENacionalidad.Extranjero == nacionalidad)
                {
                    if (dato > 89999999 && dato < 99999999)
                    {
                        return dato;
                    }
                    else
                        throw new DniInvalidoException("La nacionalidad no se condice con el número de DNI");
                }
            }
            catch (DniInvalidoException e)
            {
                Console.WriteLine(e.Message);
            }

            return dniReturn;
         }




        private int ValidadDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = 0;
            try
            {char[] aux = dato.ToCharArray();
                foreach (char item in aux)
	             {
		             if(char.IsNumber(item))
                     {
                       dato = " es valido";
                         retorno = int.Parse( dato);
                     }
	               }
                return retorno;
            
                       
            }
            catch (DniInvalidoException e)
            {
                Console.WriteLine(e.Message);
            }

            return retorno;
        }

        private string ValidarNombreApellido(string dato)
        {
            try
            {
                char[] aux = dato.ToCharArray();
                foreach (char c in aux)
                {
                    if (char.IsNumber(c))
                        dato="No es un nombre válido";
                }
                //if (Regex.IsMatch(dato, "^ [a-zA-Z] + $"))
                //{
                //    dato = " ";
                //}
                return dato;
            }
            catch (Exception e)
            {
                Console.WriteLine( e.Message);
            }
            return dato;
            
        }

    }
}

