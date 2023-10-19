import { environment } from './../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProdutoResponse } from '../../models/produtos/responses/produto.response';

@Injectable({
  providedIn: 'root'
})
export class ProdutosFavoritosService {

  baseUrl = environment.baseApiUrl;
  constructor(
    private readonly httpService: HttpClient

  ) { }

  recuperarFavoritos(){
    this.setProdutosFavoritos();

    return JSON.parse(localStorage.getItem("produtosFav"));
  }

  setProdutosFavoritos(){
    this.httpService.get<ProdutoResponse[]>(`${this.baseUrl}Clientes/produtos/favoritos`).subscribe((response)=>{
      let produtosFavoritos = [];

      response.forEach((prod)=>{
        produtosFavoritos.push(prod.id);
      });

      localStorage.setItem("produtosFav", JSON.stringify(produtosFavoritos));
    });
  }

  favoritarProduto(id: number){
    return this.httpService.post(`${this.baseUrl}Clientes/produtos/favoritar/${id}`,{});
  }

  verificarProdutoFavorito(id: number){
    return this.httpService.get(`${this.baseUrl}Clientes/produtos/favoritado/${id}`,{});
  }



}
