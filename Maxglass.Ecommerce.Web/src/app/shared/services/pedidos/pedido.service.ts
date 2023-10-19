import { PedidoResponse } from './../../../clientes/models/pedido.response';
import { PedidoListarRequest } from './../../models/pedidos/pedido-listar-request';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { PaginacaoResponse } from '../../models/paginacao/response/paginacao.response';

@Injectable({
  providedIn: 'root'
})
export class PedidoService {
  baseUrl = environment.baseApiUrl;

  constructor(private httpService: HttpClient) { }


  listar (params: HttpParams){
   return this.httpService.get<PaginacaoResponse<PedidoResponse>>(`${this.baseUrl}Pedidos`, {params});
  }
}
