import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { PaginacaoResponse } from '../../models/paginacao/response/paginacao.response';
import { ProdutoResponse } from '../../models/produtos/responses/produto.response';
import { ProdutoListarRequest } from '../../models/produtos/requests/produto-listar.request';

@Injectable({
  providedIn: 'root'
})
export class ProdutoListarService {

  baseUrl = environment.baseApiUrl;

  constructor(
    private readonly httpService: HttpClient) {}

  listarProdutos(params:ProdutoListarRequest): Observable<PaginacaoResponse<ProdutoResponse>>{
    return this.httpService.get<PaginacaoResponse<ProdutoResponse>>(`${this.baseUrl}Produtos`, {params: params as any});
  }
}
