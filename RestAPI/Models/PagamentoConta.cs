using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class PagamentoConta : IPagamentoConta
    {
        public ContasApagar Calcular(ContasApagar conta,bool simular)
        {

            if (simular && conta.DataPagamento == null)
            {
                conta.DataPagamento = DateTime.Now;
            }

            if (conta.DataVencimento < conta.DataPagamento)
            {
                conta.DiasEmAtraso = (int)(conta.DataPagamento.Value.Date - conta.DataVencimento.Date).TotalDays;

                decimal multa = 0;
                decimal multadiaria = 0;

                if (conta.DiasEmAtraso <= 3)
                {
                    multa = 2;
                    multadiaria = 0.1M;
                }
                else if (conta.DiasEmAtraso > 3 && conta.DiasEmAtraso <= 5)
                {
                    multa = 3;
                    multadiaria = 0.2M;
                }
                else if (conta.DiasEmAtraso > 5)
                {
                    multa = 5;
                    multadiaria = 0.3M;
                }


                decimal valormulta = (conta.ValorOriginal * multa / 100);
                decimal valormultadiaria = (conta.ValorOriginal * multadiaria / 100) * conta.DiasEmAtraso.Value;

                conta.ValorCorrigido = conta.ValorOriginal + valormulta + valormultadiaria;
            }
            else
            {
                conta.DiasEmAtraso = 0;
                conta.ValorCorrigido = conta.ValorOriginal;
            }


            return conta;
        }

        public List<ContasApagar> TodasContas()
        {

            using (var context = new TesteDeliverItContext())
            {
                var olst = context.ContasApagars.Include(x => x.fornecedor).ToList();

                return olst;
            }
        }

        public List<ContasApagar> ContasEmAberto()
        {
            using (var context = new TesteDeliverItContext())
            {
                var olst = context.ContasApagars.Include(x => x.fornecedor).Where(x=> x.DataPagamento== null).ToList();

                return olst.Select(x=> Calcular(x,true)).ToList() ;
            }
        }

        public List<ContasApagar> ContasPagas()
        {
            using (var context = new TesteDeliverItContext())
            {
                var olst = context.ContasApagars.Include(x => x.fornecedor).Where(x => x.DataPagamento != null).ToList();

                return olst;
            }
        }

        public ContasApagar Conta(int id)
        {
            using (var context = new TesteDeliverItContext())
            {
                var oconta = context.ContasApagars.Include(x => x.fornecedor).Where(x => x.Id == id).FirstOrDefault();
                return oconta;
            }
        }

        public ContasApagar ValorAtualConta(int id)
        {
            using (var context = new TesteDeliverItContext())
            {
                var oconta = context.ContasApagars.Include(x => x.fornecedor).Where(x => x.Id == id).FirstOrDefault();

                oconta.DataPagamento = DateTime.Now;

                return Calcular(oconta,true);
            }

        }

        public ContasApagar EfetuarPagamentoConta(int id)
        {
            using (var context = new TesteDeliverItContext())
            {
                var todoItemDTO = context.ContasApagars.Include(x => x.fornecedor).Where(x => x.Id == id && x.DataPagamento == null).FirstOrDefault();

                todoItemDTO.DataPagamento = DateTime.Now;

                Calcular(todoItemDTO,false);

                context.SaveChanges();

                return todoItemDTO;

            }

        }

        public ContasApagar CriarConta(ContasApagar conta)
        {
            using (var context = new TesteDeliverItContext())
            {

                context.ContasApagars.Add(conta);
                context.SaveChanges();

                return conta;

            }


        }

        public ContasApagar AlterarConta(ContasApagar conta)
        {

            using (var context = new TesteDeliverItContext())
            {
                context.Entry(conta).State = EntityState.Modified;
                context.SaveChanges();

                return conta;
            }
        }

        public void ExcluirConta(int id)
        {
            using (var context = new TesteDeliverItContext())
            {
                var deleteItem = context.ContasApagars.Where(x => x.Id == id).FirstOrDefault();

                context.ContasApagars.Remove(deleteItem);
                context.SaveChanges();
            }

        }
    }
}
