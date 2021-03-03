using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTest
{
    public class CRUD_ContasAPagar
    {

        int idTeste = 0;

        [Fact]
        public void CRUD()
        {
            Create();

            Read();

            Update();

            Delete();

        }

        private void Create()
        {
            RestAPI.Models.PagamentoConta opagamento = new RestAPI.Models.PagamentoConta();

            RestAPI.Models.ContasApagar novaconta;

            try
            {
                novaconta = opagamento.CriarConta(new RestAPI.Models.ContasApagar()
                {
                    DataVencimento = DateTime.Now,
                    ValorOriginal = 100,
                    Idfornecedor = 1,
                    Nome = "ContaTeste xUnit"
                });

                idTeste = novaconta.Id;

            }
            catch (Exception)
            {

                throw;
            }

            Assert.True(novaconta != null);

        }

        private void Read()
        {
            RestAPI.Models.PagamentoConta opagamento = new RestAPI.Models.PagamentoConta();

            Assert.True(opagamento.Conta(idTeste).Id == idTeste);

        }

        private void Update()
        {

            RestAPI.Models.PagamentoConta opagamento = new RestAPI.Models.PagamentoConta();


            try
            {
                RestAPI.Models.ContasApagar oconta = opagamento.Conta(idTeste);
                oconta.ValorOriginal = 1;
                opagamento.AlterarConta(oconta);
            
            }
            catch (Exception)
            {

                throw;
            }

            Assert.Equal(1, opagamento.Conta(idTeste).ValorOriginal);
        
        }

        private void Delete()
        {
            RestAPI.Models.PagamentoConta opagamento = new RestAPI.Models.PagamentoConta();


            try
            {

                opagamento.ExcluirConta(idTeste);

            }
            catch (Exception)
            {

                throw;
            }

            Assert.True(opagamento.Conta(idTeste) == null);


        }

    }
}
