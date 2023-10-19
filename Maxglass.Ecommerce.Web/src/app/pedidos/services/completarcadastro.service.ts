import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PessoaFisicaCadastroRequest } from '../models/cliente/pessoa-fisica-cadastro-request';
import { PessoaJuridicaCadastroRequest } from '../models/cliente/pessoa-juridica-cadastro.request';

@Injectable({
  providedIn: 'root'
})
export class CompletarcadastroService {

  baseApiUrl = environment.baseApiUrl;
  response: boolean;

  constructor(
    private httpClient: HttpClient
    ) { }

  cadastrar(cadastroRequest : PessoaFisicaCadastroRequest | PessoaJuridicaCadastroRequest) {
    return this.httpClient.post(`${this.baseApiUrl}Clientes/cadastro`, cadastroRequest);

  }

  verificarCadastro() : boolean{
    
    this.httpClient.get<boolean>(`${this.baseApiUrl}Clientes/verificar-cadastro`)
    .subscribe((response)=>{  
      console.log("response" + this.response)
       this.response = response;
    });
    return this.response;
  }




}
