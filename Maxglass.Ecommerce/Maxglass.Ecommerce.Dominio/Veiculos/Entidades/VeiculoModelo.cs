using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.AnosCompatibilidade.Entidades;
using Maxglass.Ecommerce.Dominio.Equivalencias.Entidades;

namespace Maxglass.Ecommerce.Dominio.Veiculos.Entidades
{
    public class VeiculoModelo
    {
        public virtual int Id { get; protected set; }
        public virtual Equivalencia? ChaveEquivalencia { get; protected set; }
        public virtual string? Descricao { get; protected set; }
        public virtual IList<AnoCompatibilidade>? AnosCompativeis { get; protected set; }

        public VeiculoModelo()
        {
        }

        public VeiculoModelo(
            int id, 
            Equivalencia chaveEquivalencia, 
            string descricao,
            IList<AnoCompatibilidade> anosCompativeis) 
            {
                SetId(id);
                SetChaveEquivalencia(chaveEquivalencia);
                SetDescricao(descricao);
                SetAnoCompatibilidade(anosCompativeis);
            }

        public virtual void SetId(int id)
        {
            Id = id;
        }
        public virtual void SetChaveEquivalencia (Equivalencia chaveEquivalencia)
        {
            ChaveEquivalencia = chaveEquivalencia;
        }

        public virtual void SetAnoCompatibilidade(IList<AnoCompatibilidade>? anosCompativeis)
        {
            AnosCompativeis = anosCompativeis;
        }

        public virtual void SetDescricao (string? descricao)
        {
            if(string.IsNullOrEmpty(descricao)) throw new Exception("Descrição precisa ter um campo diferente de nulo.");
            this.Descricao = descricao;
        }
    }
}