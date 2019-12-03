using System;
using System.Collections.Generic;
using System.Linq;

namespace Inter2.Models
{
    public class Orcamento
    {
        public int IdOrcamento { get; set; }
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public List<Item> Itens { get; set; } = new List<Item>();
        public int Status { get; set; }
        public DateTime Data { get; set; }
        public decimal Total {
            get {
                return Itens.Sum(i => i.ValorTotal);
            }
        }
    }
}