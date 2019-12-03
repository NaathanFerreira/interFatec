namespace Inter2.Models
{
    public class Item
    {        
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public Produto Produto { get; set; }
        
        public decimal ValorTotal {
            get {
                return Quantidade * Valor;
            }
        }
    }
}