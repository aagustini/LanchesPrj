using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entidades
{
    public class ItemVenda
    {
        public int Quantidade { get; set; }
        public IProduto Produto { get; set; }

        public decimal GetValor
        {
            get { return Quantidade * Produto.Preco; }
        }

        public decimal getValor()
        {
            return Quantidade * Produto.Preco;
        }
    }
}
