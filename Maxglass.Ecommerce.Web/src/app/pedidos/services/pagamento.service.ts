import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { PagamentoInserirRequest } from '../models/pagamento-request';


@Injectable({
  providedIn: 'root'
})
export class PagamentoService {

  baseApiUrl = environment.baseApiUrl;

  constructor(
    private httpService: HttpClient,
    private router: Router) { }

    pagarPedido(pagamentoInserirRequest: PagamentoInserirRequest) : Observable<any> {
      console.log(pagamentoInserirRequest);
      return this.httpService.post(`${this.baseApiUrl}Pagamentos/pagamento`, pagamentoInserirRequest);
    }


}
