import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Router } from '@angular/router';


import { map, Observable, Subject } from 'rxjs';
import { ProdutoResponse } from 'src/app/shared/models/produtos/responses/produto.response';
import { environment } from 'src/environments/environment';
import { PaginacaoConsulta } from '../models/paginacao-consulta';
import { ProdutoQuantidadeResponse } from '../models/produto-quantidade.response';


@Injectable({
  providedIn: 'root',
})
export class ProdutoService {
  baseApiUrl = environment.baseApiUrl;

  constructor(private httpService: HttpClient, private router: Router) {}

  recuperarProdutos(params: HttpParams) {
    return this.httpService.get<PaginacaoConsulta<ProdutoResponse>>(
      `${this.baseApiUrl}produtos`,
      { params }
    );
  }

  recuperarQuantidade(
    productId: number
  ): Observable<ProdutoQuantidadeResponse> {
    return this.httpService.get<ProdutoQuantidadeResponse>(
      `${this.baseApiUrl}estoques/quantidade/${productId}`
    );
  }

  recuperarProduto(productId: number): Observable<ProdutoResponse> {
    return this.httpService.get<ProdutoResponse>(
      `${this.baseApiUrl}produtos/${productId}`
    );
  }
  adicionarProdutoAoCarrinho(idProduto: number, quantidade: number) {
    let listItems = JSON.parse(localStorage.getItem("itens") || "[]");

    let produtoExiste = listItems.find(item => item.idProduto === idProduto);

    if (produtoExiste) {
        produtoExiste.quantidade += 1;
    } else {
        listItems.push({ idProduto, quantidade });
    }
    localStorage.setItem("itens", JSON.stringify(listItems));
}

  adicionarAoCarrinho(idProduto: number, quantidade: number) {
    let listItems = JSON.parse(localStorage.getItem('itens') || '[]');
    listItems.push({ quantidadeProduto: quantidade, codigoProduto: idProduto });
    localStorage.setItem('itens', JSON.stringify(listItems));
    this.router.navigate(['pedido']);
  }
}
