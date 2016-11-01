using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Galletita : Producto
    {

        protected float _peso;

        protected static bool DeConsumo;

        public Galletita() { }

        static Galletita()
        {
            DeConsumo = true;
        }

        public Galletita(int codigoBarra, EMarcaProducto marca, float precio, float peso)
            : base(codigoBarra, marca, precio)
        {
            this._peso = peso;
        }

        public override float CalcularCostoDeProducto
        {
            get
            {
                return this.Precio * 0.33f;
            }
        }
        public override string Consumir()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("COMESTIBLE");
            return sb.ToString();
        }

        private static string MostrarGalletita(Galletita g)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MARCA: " + g._marca.ToString());
            sb.AppendLine("CODIGO DE BARRA: " + g._codigoBarra.ToString());
            sb.AppendLine("PRECIO: " + g._precio.ToString());
            sb.AppendLine("PESO:" + g._peso.ToString());
            return sb.ToString();
        }
        /// <summary>
        /// como llamar a un metodo estatico
        /// en uno que no es estatico y no recibe
        ///  parametros
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

         return    Galletita.MostrarGalletita(this);
          
        }

    }
}
