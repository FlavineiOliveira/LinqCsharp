using System.Collections.Generic;

namespace ColecoesLinq.Models
{
    public class Operacao
    {
        public string NumeroOperacao { get; set; }
        public double ValorTotal { get; set; }
        public List<Parcela> Parcelas { get; set; }
    }
}
