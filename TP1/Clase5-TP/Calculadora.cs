using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase5_TP
{
      class Calculadora
    {
        /// <summary>
        /// Realiza la operacion matematica deseada
        /// </summary>
        /// <param name="numero1">Recibe el operando1</param>
        /// <param name="numero2">Recibe el operando2</param>
        /// <param name="operador">Recibe el operador</param>
        /// <returns></returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            //double num1 = 0, num2 = 0;
      
          double resultado=0;
            switch (operador)
            {
                case "+":
                    resultado = numero1.getNumero() + numero2.getNumero();
                    break;
                case "-":
                    resultado = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*":
                    resultado = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    if (numero2.getNumero() != 0)
                    {
                        resultado = numero1.getNumero() / numero2.getNumero();
                    }
                    else
                        return 0;

                    break;
                     
            }
            return resultado;
            

        }

        /// <summary>
        /// Valida el operador
        /// </summary>
        /// <param name="operador">Recibe un operador</param>
        /// <returns>Devuelve el operador correcto o + en caso de error como valor por defecto</returns>
        public static string validarOperador(string operador)
        {
          
                if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
                {
                    return operador;
           
                    }

                return "+";
        }
    }
}

