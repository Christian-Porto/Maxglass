using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.DataTransfer.Autenticacoes.Requests
{
    public class LoginRequest
    {
        public string Email{get;set;}
        public string Senha{get;set;}
    }
}