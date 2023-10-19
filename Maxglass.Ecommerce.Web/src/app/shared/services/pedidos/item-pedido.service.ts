import { ResumoPedidoResponse } from './../../../shared/models/pedidos/responses/resumo-pedido-response';
import { environment } from './../../../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProdutoListarRequest } from '../../models/produtos/requests/produto-listar.request';
import { Observable } from 'rxjs/internal/Observable';
import { PaginacaoResponse } from '../../models/paginacao/response/paginacao.response';
import { ProdutoResponse } from '../../models/produtos/responses/produto.response';

@Injectable({
  providedIn: 'root'
})
export class ItemPedidoService {

  baseUrl = environment.baseApiUrl;

  constructor(private httpService: HttpClient) {}

  recuperarArrayPedidos(params: ProdutoListarRequest) :Observable<PaginacaoResponse<ProdutoResponse>>{
    return this.httpService.get<PaginacaoResponse<ProdutoResponse>>(`${this.baseUrl}Produtos`, {params: params as any});
  }

  recuperarPedido(id : number) : Observable<ResumoPedidoResponse> {
    return this.httpService.get<ResumoPedidoResponse>(`${this.baseUrl}Pedidos/${id}`);
  }
}
