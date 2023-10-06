using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;

namespace Maxglass.Ecommerce.Dominio.Autenticacoes.Servicos.Interfaces
{
    public interface IAutenticacoesServico
    {
        Cliente ValidarCadastro(string email, string senha);

        Cliente ValidarLogin(Cliente cliente, String senha);

        String GerarToken(Cliente cliente);

        
    }
}