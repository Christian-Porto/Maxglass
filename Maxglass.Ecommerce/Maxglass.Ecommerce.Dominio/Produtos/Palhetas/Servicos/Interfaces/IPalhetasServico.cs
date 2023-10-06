using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Palhetas.Entidades;

namespace Maxglass.Ecommerce.Dominio.Produtos.Palhetas.Servicos.Interfaces
{
    public interface IPalhetasServico
    {
        Palheta Validar(int id);
        Palheta ValidarAutenticado(Palheta palheta, Cliente cliente);
    }
}