using ColecoesLinq.Models;
using System.Collections.Generic;
using System.Linq;

namespace ColecoesLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Operacao1
            //  Lista de Operações
            List<Operacao> operacoes1 = new List<Operacao>()
            {
                new Operacao{NumeroOperacao = "0111" },
                new Operacao{NumeroOperacao = "0222" },
                new Operacao{NumeroOperacao = "0333" },
            };

            //  Lista das parcelas genéricas para a operação
            List<Parcela> parcelaOperacao1 = new List<Parcela>()
            {
                new Parcela{ Numero = 1, Valor = 100 },
                new Parcela{ Numero = 2, Valor = 150 },
                new Parcela{ Numero = 3, Valor = 200 },
                new Parcela{ Numero = 4, Valor = 250 },
                new Parcela{ Numero = 5, Valor = 300 },
                new Parcela{ Numero = 6, Valor = 350 }
            };

            //  Adicionado parcelas genéricas para cada operação da lista
            operacoes1.ForEach(x => x.Parcelas = new List<Parcela>(parcelaOperacao1));
            #endregion

            #region Operacao2
            //  Lista de Operações
            List<Operacao> operacoes2 = new List<Operacao>()
            {
                new Operacao{NumeroOperacao = "0111" },
                new Operacao{NumeroOperacao = "0222" },
                new Operacao{NumeroOperacao = "0333" },
            };

            //  Lista das parcelas genéricas para a operação
            List<Parcela> parcelaOperacao2 = new List<Parcela>()
            {
                new Parcela{ Numero = 1, Valor = 100 },
                new Parcela{ Numero = 2, Valor = 150 },
                new Parcela{ Numero = 3, Valor = 200 },
                new Parcela{ Numero = 4, Valor = 250 },
                new Parcela{ Numero = 5, Valor = 300 },
                new Parcela{ Numero = 6, Valor = 350 }
            };

            //  Adicionado parcelas genéricas para cada operação da lista
            operacoes2.ForEach(x => x.Parcelas = new List<Parcela>(parcelaOperacao2));
            #endregion

            #region Parcelas para remover
            //  Lista de parcelas para remover
            var parcelasParaRemover = new List<Parcela>()
            {
                new Parcela{ Numero = 3, Valor = 200 },
                new Parcela{ Numero = 5, Valor = 300 }
            };

            //  Lista de operações para remover
            List<Operacao> operacoesParaRemover = new List<Operacao>()
            {
                new Operacao{NumeroOperacao = "0222" }
            };
            //  Adicionado parcelas genéricas para remover
            operacoesParaRemover.ForEach(x => x.Parcelas = new List<Parcela>(parcelasParaRemover));
            #endregion

            #region Busca simples
            var operacaoTeste1 = new List<Operacao>(operacoes1);

            //  Obtém a operação que contém o número "0333"
            var localizarOperacao = operacaoTeste1.Where(x => x.NumeroOperacao == "0333").FirstOrDefault();

            //  Remove todas as parcelas onde o número for igual ao número da parcela da lista parcelasParaRemover
            localizarOperacao.Parcelas.RemoveAll(x => parcelasParaRemover.Any(y => y.Numero == x.Numero));
            #endregion

            #region Filtro avançado com linq
            var operacaoTeste2 = new List<Operacao>(operacoes2);

            //  Filtra cada lista de parcelas onde analisa cada item da lista auxiliar para remover
            operacaoTeste2.ForEach(x => x.Parcelas
                                    .RemoveAll(y => operacoesParaRemover 
                                                    .Where(z => z.NumeroOperacao == x.NumeroOperacao)
                                                    .Any(w => w.Parcelas
                                                               .Exists(a => a.Numero == y.Numero))));

            //  Soma todos os valores das parcelas e atribui a propriedade ValorTotal
            operacaoTeste2.ForEach(x => x.ValorTotal = x.Parcelas.Sum(y => y.Valor));
            #endregion
        }
    }
}
