import { ProdutoResponse } from 'src/app/shared/models/produtos/responses/produto.response';
import { ProdutoService } from './../../../produtos/services/produto.service';
import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from "@auth0/angular-jwt";
import { ActivatedRoute, Router } from '@angular/router';
import { ProdutoListarService } from 'src/app/shared/services/produtos/produto-listar.service';
import { ProdutoListarRequest } from 'src/app/produtos/models/produto-listar.request';

@Component({
  selector: 'app-header-principal',
  templateUrl: './header-principal.component.html',
  styleUrls: ['./header-principal.component.css']
})
export class HeaderPrincipalComponent  implements OnInit{

  token!: string;
  usuarioLogado: boolean = false;
  filtroProdutos : Array<ProdutoResponse>;
  listagemProdutosRequest : ProdutoListarRequest = new ProdutoListarRequest ({});
  nome! : string;

  constructor(
    private produtoService : ProdutoService,
    private activatedRoute : ActivatedRoute,
    private produtoListarService : ProdutoListarService,
    private router : Router ) {

    this.token = localStorage.getItem("token");
    this.validaToken();

  }

  ngOnInit(): void {
    

  }
  buscarProduto(): void {
    this.router.navigate(['/produtos/pesquisa/',this.nome]);
  }

  validaToken(): void {
    const helper = new JwtHelperService();
    this.usuarioLogado = !helper.isTokenExpired(this.token);
  }

  logout(){
    localStorage.removeItem("token");
    window.location.reload();
  }

}
