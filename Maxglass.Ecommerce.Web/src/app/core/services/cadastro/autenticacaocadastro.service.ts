import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { Injectable } from '@angular/core';
import { CadastroRequest } from '../../models/cadastro/cadastro.request';
import { HttpClient } from '@angular/common/http'



@Injectable({
  providedIn: 'root'
})
export class AutenticacaoCadastroService {

  baseApiUrl = environment.baseApiUrl;
  constructor(
    private httpService: HttpClient) { }

  cadastrarUsuario(cadastroRequest: CadastroRequest ) : void {
    this.httpService.post(`${this.baseApiUrl}Autenticacao/cadastro`, cadastroRequest)
    .subscribe();

  }
}
