using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entidades
{
    public class Venda
    {
        public DateTime Data { get;  }

        private List<ItemVenda> itens;  // ArrayList do java

        public int NroVenda { get; }

        public Status Status { get; set; }

        public static int proxVenda = 3000;

         

        public Venda()
        {
            NroVenda = proxVenda++;
            Data = DateTime.Now;
            itens = new List<ItemVenda>();
            Status = Status.ABERTA;
        }

        public void inserir(int qtde, IProduto prod)
        {
            // regra de negocio... status == aberta!
             ItemVenda item = new ItemVenda()
            {
                Quantidade = qtde,
                Produto = prod
            };
            itens.Add(item);
        }

        public decimal getValor()
        {
            decimal total = 0;

            // java
            // for  (ItemVenda item :  itens)
            foreach (ItemVenda item in itens)
            {
                total += item.getValor();
            }
            return total;
        }

        public void fechar()
        {
            Status = Status.FECHADA;
        }

        public String gerarNota() {
            // requisito: this.Status == Status.FECHADA;
            String nota = "PSA Lanches " + Data.ToShortDateString() + 
                          "\t NF.: " + NroVenda+"\n";

            foreach (ItemVenda item in itens)
            {                        // %-20s  %7.2f...
                nota += String.Format("{0,-20} {1,7:#.00} {2,3} {3,7:#.00}\n",
                    item.Produto.Nome,  
                    item.Produto.Preco, 
                    item.Quantidade,
                    item.getValor());
            }

            nota += String.Format("\nValor total: {0,7:#.00}",
                      this.getValor());
            return nota;
        } 

    }
}
