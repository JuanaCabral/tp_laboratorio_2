using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugo : Producto
    {
        protected ESaborJugo _sabor;

        protected static bool DeConsumo;
        /// <summary>
        /// Recordar que el constructor no recibe
        /// Los constructores estaticos no llevar el acceso es por defecto privado
        /// </summary>

        static Jugo()
        {
            DeConsumo = true;
        }


        public Jugo(int codigoBarra, EMarcaProducto marca, float precio, ESaborJugo sabor)
            : base(codigoBarra, marca, precio)
        {
            this._sabor = sabor;
        }
        public enum ESaborJugo
        {
            Asqueroso, Pasable
        }
        public override string Consumir()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BEBIBLE");
            return sb.ToString();
        }

        public override float CalcularCostoDeProducto
        {
            get
            {
                return this.Precio * 0.40f;
            }
        }
        /// <summary>
        /// Aca tenemos que mencionar todos los atributos
        /// DE JUGO
        /// </summary>
        /// <returns></returns>
        private string MostrarJugo()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("MARCA: " + this._marca.ToString());
            //sb.AppendLine("CODIGO DE BARRA: " + this._codigoBarra.ToString());
            //sb.AppendLine("PRECIO: " + this._precio.ToString());
            sb.AppendLine("SABOR: " + this._sabor.ToString());
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarJugo();
        }
    }

}
