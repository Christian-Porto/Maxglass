import { HttpParams } from '@angular/common/http';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProdutoResponse } from 'src/app/shared/models/produtos/responses/produto.response';
import { FiltrosComponent } from '../../components/filtros/filtros.component';
import { PaginacaoConsulta } from '../../models/paginacao-consulta';
import { PaginacaoRequest } from '../../models/paginacao.request';
import { ProdutoListarRequest } from '../../models/produto-listar.request';
import { ProdutoService } from '../../services/produto.service';


@Component({
  selector: 'app-listagem',
  templateUrl: './listagem.component.html',
  styleUrls: ['./listagem.component.css']
})
export class ListagemComponent implements OnInit {


  @ViewChild('form') form: NgForm;

  paginacaoRequest: PaginacaoRequest = new PaginacaoRequest({});
  produtos!: PaginacaoConsulta<ProdutoResponse>;
  tipoProduto!: string;
  produtoListarRequest: ProdutoListarRequest = new ProdutoListarRequest({});
  estoqueProdutos: { [produtoId: number]: boolean } = {};
  mostraMensagemSucesso = false;
  campoPesquisa! : string;


  constructor(private produtoService: ProdutoService, private route: ActivatedRoute, private router: Router) {
    this.tipoProduto = route.snapshot.params['tipo'];
    this.campoPesquisa = route.snapshot.params['query'];
    this.defineTipo();
  }

  ngOnInit(): void {
    this.recuperarProdutos();
    this.atualizaRotaTipo();
    this.atualizaRotaPesquisa();
  }

  defineTipo() {
    switch (this.tipoProduto) {
      case this.tipoProduto = "vidro": {
        this.produtoListarRequest.tipo = 1;
        break;
      }
      case this.tipoProduto = "farol": {
        this.produtoListarRequest.tipo = 2;
        break;
      }
      case this.tipoProduto = "palheta": {
        this.produtoListarRequest.tipo = 3;
        break;
      }
      case this.tipoProduto = "retrovisor": {
        this.produtoListarRequest.tipo = 4;
        break;
      }
      case this.tipoProduto = "parachoque": {
        this.produtoListarRequest.tipo = 5;
        break;
      }
      default: {
        break;
      }
    }

  }
  filtrarProdutos() {
    this.recuperarProdutos();
  }

  verificaEstoqueProduto(produtoId: number): void {

    this.produtoService.recuperarQuantidade(produtoId).subscribe((x) => {
      if (x.quantidade > 1) {
        this.estoqueProdutos[produtoId] = true;
      }
      else {
        this.estoqueProdutos[produtoId] = false;
      }
    });
  }


  adicionarAoCarrinho(idProduto: number) {
    let quantidade = 1;
    this.produtoService.adicionarProdutoAoCarrinho(idProduto, quantidade);
    this.mostraMensagemSucesso = true;
    setTimeout(() => {
      this.mostraMensagemSucesso = false
    }, 5000);
  }

  desativaMensagem(){
    this.mostraMensagemSucesso = false;
  }


  montaQuery(): HttpParams {
    let params = new HttpParams();
    
    params = params.set('pagina', this.paginacaoRequest.pagina);
    this.paginacaoRequest.quantidadeProdutosPorPagina = 9;
    params = params.set('quantidade', this.paginacaoRequest.quantidadeProdutosPorPagina);

    if (this.campoPesquisa)
    {
      this.produtoListarRequest.nome = this.campoPesquisa;
    }

    if (this.produtoListarRequest.tipo) {
      params = params.set('tipo', this.produtoListarRequest.tipo);
    }
    if (this.produtoListarRequest.nome) {
      params = params.set('nome', this.produtoListarRequest.nome);
    }
    if (this.produtoListarRequest.categoria) {
      params = params.set('categoria', this.produtoListarRequest.categoria);
    }
    if (this.produtoListarRequest.aro) {
      params = params.set('aro', this.produtoListarRequest.aro);
    }
    if (this.produtoListarRequest.borda) {
      params = params.set('borda', this.produtoListarRequest.borda);
    }
    if (this.produtoListarRequest.carcaca) {
      params = params.set('carcaca', this.produtoListarRequest.carcaca);
    }
    if (this.produtoListarRequest.lente) {
      params = params.set('lente', this.produtoListarRequest.lente);
    }
    if (this.produtoListarRequest.friso) {
      params = params.set('friso', this.produtoListarRequest.friso);
    }
    if (this.produtoListarRequest.posicao) {
      params = params.set('posicao', this.produtoListarRequest.posicao);
    }
    if (this.produtoListarRequest.material) {
      params = params.set('material', this.produtoListarRequest.material);
    }
    if (this.produtoListarRequest.materialBorracha) {
      params = params.set('materialBorracha', this.produtoListarRequest.materialBorracha);
    }
    if (this.produtoListarRequest.aberturaFriso) {
      params = params.set('aberturaFriso', this.produtoListarRequest.aberturaFriso);
    }
    if (this.produtoListarRequest.moldura) {
      params = params.set('moldura', this.produtoListarRequest.moldura);
    }
    if (this.produtoListarRequest.furoEscapamento) {
      params = params.set('furoEscapamento', this.produtoListarRequest.furoEscapamento);
    }
    if (this.produtoListarRequest.aberturaSpoiler) {
      params = params.set('aberturaSpoiler', this.produtoListarRequest.aberturaSpoiler);
    }
    if (this.produtoListarRequest.capa) {
      params = params.set('capa', this.produtoListarRequest.capa);
    }
    if (this.produtoListarRequest.piscaAlerta) {
      params = params.set('piscaAlerta', this.produtoListarRequest.piscaAlerta);
    }
    if (this.produtoListarRequest.sensorPontoCego) {
      params = params.set('sensorPontoCego', this.produtoListarRequest.sensorPontoCego);
    }
    if (this.produtoListarRequest.faixa) {
      params = params.set('faixa', this.produtoListarRequest.faixa);
    }
    if (this.produtoListarRequest.marca) {
      params = params.set('marca', this.produtoListarRequest.marca);
    }
    return params;
  }

  atualizaPagina(pagina: number) {
    this.paginacaoRequest.pagina = pagina;
    this.recuperarProdutos();
  }

  recuperarProdutos() {
    this.produtoService.recuperarProdutos(this.montaQuery()).subscribe(products => {
      this.produtos = products;
      this.produtos.registros.forEach(produto => {
        this.verificaEstoqueProduto(produto.id);
      });
      this.paginacaoRequest.totalRegistros = products.quantidade;
      this.paginacaoRequest.totalPaginas = Math.ceil(products.quantidade /
        this.paginacaoRequest.quantidadeProdutosPorPagina);
      console.log(products);
    });
  }

  atualizaRotaPesquisa(){

    this.route.paramMap.subscribe((paramMap) => {
      if (paramMap.has('query') && paramMap.get('query') !== this.campoPesquisa) {
        const currentRoute = this.router.url;
        this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          this.router.navigate([currentRoute]);
        });
      }
    });
  }

  atualizaRotaTipo(){
    this.route.paramMap.subscribe((paramMap) => {
      if (paramMap.has('tipo') && paramMap.get('tipo') !== this.tipoProduto) {
        const currentRoute = this.router.url;
        this.router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          this.router.navigate([currentRoute]);
        });
      }
    });
  }

}
