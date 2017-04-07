using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase5_TP
{
    class Numero
    {
        private double _numero;

        /// <summary>
        /// constructor sin parametros
        /// </summary>
        public Numero()
        { 
          this._numero = 0.0;
        }
        /// <summary>
        /// constructor con un parametro double
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this._numero = numero;
        }
        /// <summary>
        /// constructor con un parametro string 
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            setNumero(numero);
        
        }

        //www.UtnFravirtual.org.ar
        /// <summary>
        /// propiedad getter
        /// </summary>
        /// <returns></returns>
        public double getNumero()
        {
            return this._numero;
        }

        /// <summary>
        /// propiedad de setter 
        /// </summary>
        /// <param name="numero"></param>
        private void setNumero(string numero)
        {
          this._numero =  validarNumero( numero);
        }

        /// <summary>
        /// metodo que valida un caracter y devuelve un numero
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns></returns>
        private static double validarNumero(string numeroString)
       {

           double numero = 0;
           if (double.TryParse(numeroString, out numero))
           {
               return numero;
           }
           return numero;

        }

        
       

    }
}
