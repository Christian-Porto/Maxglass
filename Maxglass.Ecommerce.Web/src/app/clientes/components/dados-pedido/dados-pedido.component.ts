import { PedidoService } from './../../../shared/services/pedidos/pedido.service';
import { Component, OnInit } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { PaginacaoRequest } from 'src/app/produtos/models/paginacao.request';
import { PaginacaoResponse } from 'src/app/shared/models/paginacao/response/paginacao.response';
import { PedidoResponse } from '../../models/pedido.response';
import { SituacaoEnum } from '../../enumeradores/situacao.enum';

@Component({
  selector: 'app-dados-pedido',
  templateUrl: './dados-pedido.component.html',
  styleUrls: ['./dados-pedido.component.css'],
})
export class DadosPedidoComponent implements OnInit {

  paginacaoRequest: PaginacaoRequest = new PaginacaoRequest({});
  pedidos!: PaginacaoResponse<PedidoResponse>;

  enumMap = {
    [SituacaoEnum.Cancelado]: 'Cancelado',
    [SituacaoEnum.Entregue]: 'Entregue',
    [SituacaoEnum.AguardandoPagamento]: 'Aguardando pagamento',
    [SituacaoEnum.Enviado]: 'Enviado',
    [SituacaoEnum.SeparandoPedido]: 'Separando pedido'
  };


  constructor(private pedidoService: PedidoService) {
    this.paginacaoRequest.quantidadeProdutosPorPagina = 9;
  }

  ngOnInit(): void {

    this.recuperarPedidos();
  }

  montaQuery() : HttpParams{
    let params = new HttpParams();

    params = params.set('pagina', this.paginacaoRequest.pagina);

    params = params.set('quantidade', this.paginacaoRequest.quantidadeProdutosPorPagina);

    return params;
  }

  atualizaPagina(pagina: number) {
    this.paginacaoRequest.pagina = pagina;
    this.recuperarPedidos();
  }
  recuperarPedidos(){
    this.pedidoService.listar(this.montaQuery()).subscribe((x) => {
      console.log(x);
      this.pedidos = x;
      this.pedidos.registros.forEach((pedido) => (pedido.isExpanded = false));
      this.paginacaoRequest.totalRegistros = this.pedidos.quantidade;
      this.paginacaoRequest.totalPaginas = Math.ceil(this.pedidos.quantidade /
        this.paginacaoRequest.quantidadeProdutosPorPagina);
    });
  }



}
