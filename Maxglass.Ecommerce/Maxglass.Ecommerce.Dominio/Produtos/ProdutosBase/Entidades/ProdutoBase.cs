using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Categorias.Entidades;
using Maxglass.Ecommerce.Dominio.Equivalencias.Entidades;
using Maxglass.Ecommerce.Dominio.Imagens.Entidades;
using Maxglass.Ecommerce.Dominio.Marcas.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Enumeradores;

namespace Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades
{
    public class ProdutoBase
    {
        private SituacaoProdutoBaseEnum status;

        public virtual int Id {get; protected set;}
        public virtual TipoProdutoBaseEnum Tipo {get; protected set;}
        public virtual string? Nome {get; protected set;}
        public virtual decimal Altura {get; protected set;}
        public virtual decimal Profundidade {get; protected set;}
        public virtual decimal Largura {get; protected set;}
        public virtual decimal Valor {get; protected set;}
        public virtual SituacaoProdutoBaseEnum Situacao {get; protected set;}
        public virtual IList<Imagem>? Imagens {get; protected set;}
        public virtual Marca? Marca {get; protected set;}
        public virtual Categoria? Categoria {get; protected set;}
        public virtual decimal? ValorAreaProduto {get; protected set;}

        // SUJEITO A MUDANÇAS CASO NECESSARIO CRIAR UMA CLASSE PARA CHAVE
        // DE EQUIVALENCIA 
        public virtual Equivalencia? ChaveEquivalencia {get; protected set;} 

        protected ProdutoBase()
        {
            
        }

        public ProdutoBase(

            TipoProdutoBaseEnum tipo,
            string? nome, 
            decimal altura, 
            decimal profundidade, 
            decimal largura, 
            decimal valor,
            SituacaoProdutoBaseEnum status,
            IList<Imagem>? imagens, 
            Marca? marca, 
            Categoria? categoria, 
            Equivalencia? chaveEquivalencia
            )
        {
            SetTipo(tipo);
            SetNome(nome);
            SetAltura(altura);
            SetProfundidade(profundidade);
            SetLargura(largura);
            SetValor(valor);
            SetSituacao(Situacao);
            SetImagens(imagens);
            SetMarca(marca);
            SetCategoria(categoria);
            SetChaveEquivalencia(chaveEquivalencia);
            SetValorAreaProduto();
        }
        public virtual void SetValorAreaProduto()
        {
            this.ValorAreaProduto = (Altura * Largura * Profundidade) / 1000;
        }

        public virtual void SetTipo(TipoProdutoBaseEnum tipo)
        {
            this.Tipo = tipo;
        }

        public virtual void SetNome(string? nome)
        {
            if (string.IsNullOrEmpty(nome)) throw new Exception ("Produto precisa de uma nome");
            this.Nome = nome;   
        }

        public virtual void SetAltura(decimal altura)
        {
            if (altura <= 0) throw new Exception("Altura do produto invalida");
            this.Altura = altura;            
        }

        public virtual void SetProfundidade(decimal profundidade)
        {
            if (profundidade <= 0) throw new Exception("Profundidade do produto invalida");
            this.Profundidade = profundidade;
        }

        public virtual void SetLargura(decimal largura)
        {
            if (largura <= 0) throw new Exception("Largura do produto invalida");
            this.Largura = largura;
        }
    
        public virtual void SetValor(decimal valor)
        {
            if (valor <= 0) throw new Exception("Valor do produto invalida");
            this.Valor = valor;
        }

        public virtual void SetSituacao(SituacaoProdutoBaseEnum situacao)
        {
            this.Situacao = situacao;
        }

        public virtual void SetImagens(IList<Imagem>? imagens)
        {
            if (imagens is null || imagens.Count == 0) throw new Exception("O produto precisa ter ao menos uma imagem");
            this.Imagens = imagens;
        }

        public virtual void SetMarca(Marca? marca)
        {
            if (marca is null) throw new Exception("Produto precisa ter uma marca");
            this.Marca = marca;
        }
    
        public virtual void SetCategoria(Categoria? categoria)
        {
            if (categoria is null) throw new Exception("Produto precisa ter uma categoria");
            this.Categoria = categoria;
        }

        public virtual void SetChaveEquivalencia(Equivalencia? chaveEquivalencia)
        {
            if(chaveEquivalencia is null) throw new Exception("Produto precisa ter uma chave de equivalencia");
            this.ChaveEquivalencia = chaveEquivalencia;
        }

    }
}