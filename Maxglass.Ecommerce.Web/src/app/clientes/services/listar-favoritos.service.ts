import { Observable } from 'rxjs';
import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProdutoResponse } from 'src/app/produtos/models/produto.response';

@Injectable({
  providedIn: 'root'
})
export class ListarFavoritosService {

  baseUrl = environment.baseApiUrl;

  constructor(private httpClient : HttpClient) { }

  recuperarFavoritos(): Observable<ProdutoResponse[]>{
    return this.httpClient.get<ProdutoResponse[]>(`${this.baseUrl}Clientes/produtos/favoritos`);
  }
}
