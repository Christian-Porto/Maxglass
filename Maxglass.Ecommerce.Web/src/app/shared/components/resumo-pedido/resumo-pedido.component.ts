import { Component, OnInit } from '@angular/core';
import { ItemPedidoResponse } from 'src/app/pedidos/models/pedido-carrinho.response';
import { CarrinhoService } from 'src/app/pedidos/services/carrinho.service';
import { ProdutoService } from 'src/app/produtos/services/produto.service';
import { Location } from '@angular/common';
import { ItemPedidoRequest } from 'src/app/pedidos/models/pedido-carrinho-request';

@Component({
  selector: 'app-resumo-pedido',
  templateUrl: './resumo-pedido.component.html',
  styleUrls: ['./resumo-pedido.component.css']
})
export class ResumoPedidoComponent implements OnInit{

  listaProdutos: ItemPedidoResponse[] = [];
  produtos : ItemPedidoRequest[];
  valorTotal : number;

  constructor(private carrinhoService: CarrinhoService, private produtoService: ProdutoService, private location: Location) { }

  ngOnInit(): void {
    const itensCarrinho : ItemPedidoRequest[] = this.carrinhoService.recuperaItensCarrinho();

    itensCarrinho.forEach(item => {
      this.produtoService.recuperarProduto(item.idProduto).subscribe((response)=>{
        this.listaProdutos.push({
          quantidade: item.quantidade,
          produto: response
        });
        this.atualizaValorTotal();
      });
    });
 }

 atualizarCarrinho(){
  localStorage.setItem('itens', JSON.stringify(this.produtos));}

  atualizaValorTotal(){
    this.valorTotal = 0;
    console.log(this.listaProdutos.length);
    this.listaProdutos.forEach(itemPedido=>{
      this.valorTotal = this.valorTotal + (itemPedido.quantidade * itemPedido.produto.valor)
    });
  }
}
