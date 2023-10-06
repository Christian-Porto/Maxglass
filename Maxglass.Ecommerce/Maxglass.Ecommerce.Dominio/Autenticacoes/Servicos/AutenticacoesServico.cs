using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Autenticacoes.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Microsoft.IdentityModel.Tokens;

namespace Maxglass.Ecommerce.Dominio.Autenticacoes.Servicos
{
    public class AutenticacoesServico : IAutenticacoesServico
    {
        public string GerarToken(Cliente cliente)
        {
            SymmetricSecurityKey chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn")
                );
            SigningCredentials credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            Claim[] claimsCliente = new Claim[]
            {
                new Claim("tipo", ((int)cliente.Tipo).ToString()),
                new Claim("id", cliente.Id.ToString())
            };
            
            JwtSecurityToken token = new JwtSecurityToken(
                claims: claimsCliente,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(1)    
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Cliente ValidarCadastro(string email, string senha)
        {
            if (string.IsNullOrEmpty(email)) //IMPLEMENTAR VALIDACOES
            {
                throw new Exception("Email invalido");
            }

            if (string.IsNullOrEmpty(senha)) //IMPLEMENTAR VALIDACOES
            {
               throw new Exception("Senha invalido"); 
            }

            var cliente = new Cliente(email, senha);
            return cliente;

        }

        public Cliente ValidarLogin(Cliente cliente, String senha)
        {
            if (cliente is null)
            {
                throw new Exception("Email incorreto");
            }
            if (!BCrypt.Net.BCrypt.Verify(senha, cliente.Senha))
            {
                throw new Exception("Senha incorreta");
            }
            return cliente;
        }

    }
}