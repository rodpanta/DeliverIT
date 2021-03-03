using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Models
{

    public interface IPagamentoConta
    {
        ContasApagar Calcular(ContasApagar conta, bool simular);

        List<ContasApagar> TodasContas();

        List<ContasApagar> ContasEmAberto();

        List<ContasApagar> ContasPagas();

        ContasApagar Conta(int Id);

        ContasApagar ValorAtualConta(int Id);

        ContasApagar EfetuarPagamentoConta(int id);

        ContasApagar CriarConta(ContasApagar conta);

        ContasApagar AlterarConta(ContasApagar conta);

        void ExcluirConta(int id);

    }
}
