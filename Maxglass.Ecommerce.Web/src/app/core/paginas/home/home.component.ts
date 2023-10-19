import { PaginacaoResponse } from '../../../shared/models/paginacao/response/paginacao.response';
import { Component, OnInit } from '@angular/core';
import { ProdutoResponse } from 'src/app/shared/models/produtos/responses/produto.response';
import { ProdutoListarService } from 'src/app/shared/services/produtos/produto-listar.service';
import { ProdutoListarRequest } from 'src/app/shared/models/produtos/requests/produto-listar.request';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  produtos: PaginacaoResponse<ProdutoResponse>;

  constructor(
    private produtoService : ProdutoListarService
    ) { }

  ngOnInit(): void {

    let request = new ProdutoListarRequest({pagina:1, quantidade: 9});
    this.produtoService.listarProdutos(request).subscribe((response)=>{
      this.produtos = response;
    });
  }

}
