using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   
  public  class Gaseosa:Producto
    {
        protected float _litros;
        protected static bool DeConsumo;

      public Gaseosa(){}


        static Gaseosa()
        {
            DeConsumo = true;
        }

        public Gaseosa(int codigoBarra, EMarcaProducto marca, float precio, float litros)
            :base(codigoBarra,marca,precio)
        {

            this._litros = litros;
        }
       public  Gaseosa(Producto p, float litros):this()
        {     
          
        }

        public override float CalcularCostoDeProducto
        {
            get
            {
                return this.Precio * 0.42f;
            }
        }
        public override string Consumir()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BEBIBLE");
            return sb.ToString();
        }

        private string MostrarGaseosa()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MARCA: " + this._marca.ToString());
            sb.AppendLine("CODIGO DE BARRA: " + this._codigoBarra.ToString());
            sb.AppendLine("PRECIO: " + this._precio.ToString());
            sb.AppendLine("LITROS: " + this._codigoBarra.ToString());
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarGaseosa();
        }

        

    }
}

