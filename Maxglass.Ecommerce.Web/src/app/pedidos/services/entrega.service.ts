import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaginacaoResponse } from 'src/app/shared/models/paginacao/response/paginacao.response';
import { environment } from 'src/environments/environment';
import { FreteResponse } from '../models/entrega-response';
import { PedidoCadastroRequest } from '../models/pedido-cadastro-request';

@Injectable({
  providedIn: 'root'
})
export class EntregaService {
  baseApiUrl = environment.baseApiUrl;

  constructor(private httpService: HttpClient) { }

  recuperarArrayRegistros(params: HttpParams) {
    return this.httpService.get<PaginacaoResponse<FreteResponse>>(
      `${this.baseApiUrl}fretes`,
      { params }
    );
  }

  cadastrarEntrega(pedidoCadastroRequest: PedidoCadastroRequest): Observable<any> {
    return this.httpService.post(`${this.baseApiUrl}Pedidos`, pedidoCadastroRequest);
  }
}
