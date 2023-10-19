import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PedidoPagamentoResponse } from '../models/pedido-pagamento.response';

@Injectable({
  providedIn: 'root'
})
export class PedidoService {

  baseApiUrl = environment.baseApiUrl;

  constructor(
    private httpService: HttpClient,
    private router: Router
  ) { }

  recuperarValorPedido(id: number): Observable<PedidoPagamentoResponse> {
    return this.httpService.get<PedidoPagamentoResponse>(`${this.baseApiUrl}Pedidos/${id}`)
  }

}
