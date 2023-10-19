import { ProdutoService } from './../../../produtos/services/produto.service';
import { ItemPedidoResponse } from './../../models/pedido-carrinho.response';
import { CarrinhoService } from './../../services/carrinho.service';
import { Component, OnInit } from '@angular/core';
import { faMinus, faPlus, faXmark } from '@fortawesome/free-solid-svg-icons';
import { Location } from '@angular/common'; //Um serviço que os aplicativos podem usar para interagir com o URL de um navegador
import { ItemPedidoRequest } from '../../models/pedido-carrinho-request';

@Component({
  selector: 'app-carrinho',
  templateUrl: './carrinho.component.html',
  styleUrls: ['./carrinho.component.css']
})
export class CarrinhoComponent implements OnInit {
  faXmark = faXmark;
  faPlus = faPlus;
  faMinus = faMinus;
  listaProdutos: ItemPedidoResponse[] = [];
  produtos : ItemPedidoRequest[];

  valorTotal : number;

  constructor(private carrinhoService: CarrinhoService, private produtoService: ProdutoService, private location: Location) { }

  ngOnInit(): void {
     this.produtos  = this.carrinhoService.recuperaItensCarrinho();
     console.log(this.produtos);
     this.produtos.forEach(produto => {
      this.produtoService.recuperarProduto(produto.idProduto).subscribe(
        response => {
          this.listaProdutos.push({produto: response, quantidade: produto.quantidade})
          this.atualizaValorTotal();
          this.atualizarCarrinho();
        }
      );
    });
  }

  excluirItemCarrinho(id: number){
    for (let index = 0; index < this.produtos.length; index++) {
      if(this.produtos[index].idProduto == id){
        this.produtos.splice(index,1);
      }
      
      localStorage.clear();
      this.reload();
    }
    this.atualizarCarrinho();
  }

  reload() {
    (<any>(localStorage)).refresh == 'true' || ! (<any>(localStorage)).refresh
        && location.reload();
        (<any>(localStorage)).refresh = false;
    }


  incrementaQuantidade(item: ItemPedidoResponse ) {
    this.produtos.forEach(produto=>{
      if(produto.idProduto == item.produto.id)
      {
        item.quantidade++;
        produto.quantidade++;
      }
    });
    this.atualizarCarrinho();
    this.atualizaValorTotal();
}

  decrementaQuantidade(item: ItemPedidoResponse) {
    this.produtos.forEach(produto=>{
      if(produto.idProduto == item.produto.id && produto.quantidade > 0)
      {
        item.quantidade--;
        produto.quantidade--;
        if(produto.quantidade == 0){
          this.excluirItemCarrinho(item.produto.id);
        }
      }
    });
    this.atualizarCarrinho();
    this.atualizaValorTotal();
  }

  atualizarCarrinho(){
    localStorage.setItem('itens', JSON.stringify(this.produtos));
  }

  atualizaValorTotal(){
    this.valorTotal = 0;
    console.log(this.listaProdutos.length);
    this.listaProdutos.forEach(produto=>{
      this.valorTotal = this.valorTotal + (produto.quantidade * produto.produto.valor)
    });
  }

}
