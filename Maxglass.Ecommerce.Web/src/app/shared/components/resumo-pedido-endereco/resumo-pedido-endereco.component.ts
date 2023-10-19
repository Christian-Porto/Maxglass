import { ItemPedidoService } from './../../services/pedidos/item-pedido.service';
import { Component, OnInit } from '@angular/core';
import { ItemPedidoRequest } from 'src/app/pedidos/models/pedido-carrinho-request';
import { ItemPedidoResponse } from 'src/app/pedidos/models/pedido-carrinho.response';
import { CarrinhoService } from 'src/app/pedidos/services/carrinho.service';
import { ProdutoService } from 'src/app/produtos/services/produto.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { ResumoPedidoResponse } from '../../models/pedidos/responses/resumo-pedido-response';

@Component({
  selector: 'app-resumo-pedido-endereco',
  templateUrl: './resumo-pedido-endereco.component.html',
  styleUrls: ['./resumo-pedido-endereco.component.css']
})
export class ResumoPedidoEnderecoComponent implements OnInit {

  valorTotal : number;
  pedido : ResumoPedidoResponse;

  constructor(
    private pedidoService : ItemPedidoService,
    private activatedRoute : ActivatedRoute) { }

  ngOnInit(): void {
    let id = this.activatedRoute.snapshot.params['id'];
    this.pedidoService.recuperarPedido(id).subscribe((response)=>{
      this.pedido = response;
      this.atualizaValorTotal();
    });
 }

  atualizaValorTotal(){
    this.valorTotal = 0;
    this.pedido.itensPedido.forEach(itemPedido=>{
      this.valorTotal = this.valorTotal + (itemPedido.quantidade * itemPedido.produto.valor)
    });
  }
}
