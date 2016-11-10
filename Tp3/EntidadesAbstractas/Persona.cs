using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;


namespace EntidadesAbstractas
{
    public abstract class  Persona
    {
        protected string _apellido;
        protected int _dni;
       protected ENacionalidad _nacionalidad;
       protected string _nombre;

    public  enum ENacionalidad
    {
        Argentino, Extranjero
    }

    public Persona() { }


    public string Apellido
    {
        get { return ValidaNombreApellido(this._apellido); }
        set { ValidaNombreApellido(this._apellido); }
    }

        public int DNI 
        {
            get { return ValidaDni(this._nacionalidad, this._dni); }
            set { ValidaDni(this._nacionalidad, this._dni); }
        }
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }
        public string Nombre 
        {
            get { return ValidaNombreApellido(this._nombre); }
            set { ValidaNombreApellido(this._nombre); }
        }

        public string StringToDNI
        {
            get;
            set;
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre, apellido, nacionalidad)
        {
            this._dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre, apellido, nacionalidad)
        {
           //jhbjebkjbfe
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nombre Completo: "+this._apellido+","+this._nombre);
            sb.AppendLine("DNI: " + this._dni);
            sb.AppendLine("Nacionalidad: " + this._nacionalidad);
            return sb.ToString();
        }

        private int ValidaDni(ENacionalidad nacionalidad, int dato)
        {

            int numero = 89999999;
            if (this._dni <= numero || numero > 0)
            {
                return this._dni;
            }
            else
            {
                throw new DniInvalidoException();
            }

        }
        private int ValidadDni(ENacionalidad nacionalidad, string dato)
        {
            int numero = 90000000;
            if (numero > 90000000 )
            {
                dato = "Es Estranjero";
            }
            return numero;      
        }

        private string ValidaNombreApellido(string dato)
        {
            dato = "";
            if (dato == "")
            {
                Console.WriteLine("el nombre es correcto" + dato);
            }
            return dato;
        }
    }
}
