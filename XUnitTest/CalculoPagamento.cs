using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using RestAPI;
using Xunit;

namespace XUnitTest
{
    public class CalculoPagamento
    {


        [Theory]
        [InlineData(0,100,100)]
        [InlineData(1, 100, 102.10)]
        [InlineData(3, 100, 102.30)]
        [InlineData(4, 100, 103.80)]
        [InlineData(5, 100, 104.00)]
        [InlineData(6, 100, 106.80)]

        public void ValidaValor(int diasatraso, decimal valororiginal, decimal experado)
        {

            RestAPI.Models.PagamentoConta opagamento = new RestAPI.Models.PagamentoConta();

            RestAPI.Models.ContasApagar actualconta = opagamento.Calcular(new RestAPI.Models.ContasApagar()
                                {
                                   DataPagamento = DateTime.Now,
                                   DataVencimento = DateTime.Now.AddDays(-1 * diasatraso),
                                   ValorOriginal = valororiginal,
                                },false);

            Assert.Equal(experado, actualconta.ValorCorrigido.Value);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(10)]
        public void ValidaDias(int diasatraso)
        {

            RestAPI.Models.PagamentoConta opagamento = new RestAPI.Models.PagamentoConta();

            RestAPI.Models.ContasApagar actualconta = opagamento.Calcular(new RestAPI.Models.ContasApagar()
            {
                DataPagamento = DateTime.Now,
                DataVencimento = DateTime.Now.AddDays(-1 * diasatraso),
                ValorOriginal = 100,
            },false);

            Assert.Equal(diasatraso, actualconta.DiasEmAtraso);

        }




    }
}
