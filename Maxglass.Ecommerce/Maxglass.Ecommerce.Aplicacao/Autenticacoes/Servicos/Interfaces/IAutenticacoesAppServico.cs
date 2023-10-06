using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Autenticacoes.Requests;
using Maxglass.Ecommerce.DataTransfer.Autenticacoes.Responses;

namespace Maxglass.Ecommerce.Aplicacao.Autenticacoes.Servicos.Interfaces
{
    public interface IAutenticacoesAppServico
    {
        LoginResponse Logar(LoginRequest loginRequest);
        CadastroResponse Cadastrar(CadastroRequest cadastroRequest);
    }
}