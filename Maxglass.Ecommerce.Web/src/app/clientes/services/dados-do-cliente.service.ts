import { ClientePessoaJuridicaResponse } from './../models/cliente-pessoa-juridica.response';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ClientePessoaFisicaResponse } from '../models/cliente-pessoa-fisica.response';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DadosDoClienteService {
  baseApiUrl = environment.baseApiUrl;

  constructor(private httpClient: HttpClient) {

  }

  putDadosCliente(cliente: any): Observable<any>{
    console.log("oh aqui");
    console.log(cliente);
   return this.httpClient.put(`${this.baseApiUrl}Clientes`, cliente);
  }

  getPessoaFisica() : Observable<ClientePessoaFisicaResponse>{
   return this.httpClient.get<ClientePessoaFisicaResponse>(`${this.baseApiUrl}Clientes/pf`)
  }
  getPessoaJuridica() : Observable<ClientePessoaJuridicaResponse>{
    return this.httpClient.get<ClientePessoaJuridicaResponse>(`${this.baseApiUrl}Clientes/pj`)
  }

}
