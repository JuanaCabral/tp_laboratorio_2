using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Harina : Producto
    {
        protected ETipoHarina _tipo;
        protected static bool DeConsumo;

        public Harina()
        { }

        static Harina()
        {
            DeConsumo = false;
        }
        public enum ETipoHarina
        {
            Integral, CuatroCeros
        }

        public Harina(int codigoBarra, EMarcaProducto marca, float precio, ETipoHarina tipo)
            : base(codigoBarra, marca, precio)
        {
            this._tipo = tipo;
        }
        public override float CalcularCostoDeProducto
        {
            get
            {
                return this.Precio * 0.60f;
            }
        }

        private string MostrarHarina()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MARCA: " + this._marca.ToString());
            sb.AppendLine("CODIGO DE BARRA: " + this._codigoBarra.ToString());
            sb.AppendLine("PRECIO: " + this._precio.ToString());
            sb.AppendLine("TIPO: " + this._tipo.ToString());
            return sb.ToString();

        }

        public override string ToString()
        {
            return MostrarHarina();
        }

    }
}
