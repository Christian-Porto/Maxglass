import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProdutoResponse } from '../../models/produtos/responses/produto.response';
import { ProdutosFavoritosService } from '../../services/produtos/produtos-favoritos.service';

@Component({
  selector: 'app-card',
  templateUrl: './card-produto.component.html',
  styleUrls: ['./card-produto.component.css']
})
export class CardComponent implements OnInit {

  @Input() produtoCard : ProdutoResponse;
  @Input() estoquesProdutos: { [produtoId: number]: boolean };
  @Output() navegarProduto = new EventEmitter();
  @Output() adicionarCarrinho = new EventEmitter();


  favoritado:string ;
  mostraMensagem = false;


  constructor(
    private favoritoService: ProdutosFavoritosService
    ) { }


  ngOnInit(): void {
    this.mudarIconeFav();
  }

  mudarIconeFav() {
    if(localStorage.getItem('token')){
      this.favoritoService.verificarProdutoFavorito(this.produtoCard.id).subscribe((response)=>{
        console.log(response)
        if(response){
          this.favoritado = 'ativo';
        }else{
          this.favoritado = 'inativo';
        }
      },()=>{
        this.favoritado = 'inativo';
      })
    }else{
      this.favoritado = 'inativo';
    }


  }

  favoritar(){

    this.favoritoService.favoritarProduto(this.produtoCard.id).subscribe((response)=>{
      this.mudarIconeFav();
    });
  }

}
