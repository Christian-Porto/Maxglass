using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Estoques.Entidades;
using Maxglass.Ecommerce.Dominio.Estoques.Repositorios;
using Maxglass.Ecommerce.Dominio.Estoques.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Pedidos.Entidades;

namespace Maxglass.Ecommerce.Dominio.Estoques.Servicos
{
    public class EstoquesServico : IEstoquesServico
    {
        private readonly IEstoquesRepositorio estoquesRepositorio;
        public EstoquesServico(IEstoquesRepositorio estoquesRepositorio)
        {
            this.estoquesRepositorio = estoquesRepositorio;
        }


        public Estoque Validar(int id)
        {
            var estoque = estoquesRepositorio.Recuperar(id);
            if (estoque is null)
            {
                throw new Exception("Esse estoque não existe");
            }
            return estoque;
        }


        public void DecrementaUnidadeNoEstoque(int quantidade, int idItem)
        {
            var estoque = estoquesRepositorio.Recuperar(1); // incluir busca dinamica de estoque.
        
            foreach (var item in estoque.EstoqueProduto)
            {
                if (item.Produto.Id == idItem)
                {
                    item.SetQuantidade(item.Quantidade - quantidade);
                    break;
                }
            
            }

            estoquesRepositorio.Atualizar(estoque);
        }

        public void IncrementaUnidadeEstoque(int quantidade, int idItem)
        {
            var estoque = estoquesRepositorio.Recuperar(1);
            foreach (var item in estoque.EstoqueProduto)
            {
                if (item.Produto.Id == idItem)
                {
                    item.SetQuantidade(item.Quantidade + quantidade);
                }
            }
            estoquesRepositorio.Atualizar(estoque);
        }
    }
}