import { Component, Input, OnInit } from '@angular/core';
import { ProdutoService } from 'src/app/produtos/services/produto.service';
import { ProdutoResponse } from '../../models/produtos/responses/produto.response';

@Component({
  selector: 'app-carrossel-produto',
  templateUrl: './carrossel-produto.component.html',
  styleUrls: ['./carrossel-produto.component.css']
})
export class CarrosselProdutoComponent implements OnInit {

  @Input() produtos : ProdutoResponse[];


  constructor( private produtoService : ProdutoService) { }

  ngOnInit(): void {

  }

  adicionarAoCarrinho(idProduto : number){
    let quantidade = 1;
    this.produtoService.adicionarProdutoAoCarrinho(idProduto, quantidade);
  }

}
