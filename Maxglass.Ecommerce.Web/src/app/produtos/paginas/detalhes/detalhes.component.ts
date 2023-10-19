import { ProdutoQuantidadeResponse } from './../../models/produto-quantidade.response';
import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  OnDestroy,
  OnInit,
} from '@angular/core';

import { map, Observable, Subject, Subscription, takeUntil } from 'rxjs';

import { ProdutoService } from '../../services/produto.service';
import { ProdutoResponse } from 'src/app/shared/models/produtos/responses/produto.response';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html',
})

export class DetalhesComponent implements OnDestroy {
  productId!: number;
  produto!: ProdutoResponse;
  produtoQuantidade!: ProdutoQuantidadeResponse;
  disponibilidade!: boolean;
  disponibilidadeString!: string;
  quantidade: number = 1;
  valorTotal!: number;
  valorParcela!: number;
  anosCompativeis: any = [];
  destroy$: Subject<boolean> = new Subject<boolean>();

  constructor(
    private route: ActivatedRoute,
    private produtoService: ProdutoService,
    private cd: ChangeDetectorRef
  ) {
    this.productId = route.snapshot.params['id'];

    this.recuperarProduto();
    this.recuperaQuantidadeProduto();
  }
  ngOnDestroy(): void {
    this.destroy$.next(true);
    this.destroy$.unsubscribe();
  }



  recuperaListaAnosCompativeis() {
    if (
      this.produto &&
      this.produto.chaveEquivalencia &&
      this.produto.chaveEquivalencia.veiculos
    ) {
      let veiculos = this.produto.chaveEquivalencia.veiculos;
      for (let i = 0; i < veiculos.length; i++) {
        if (veiculos[i].anosCompativeis) {
          let listaAnosCompativeis = veiculos[i].anosCompativeis;
          listaAnosCompativeis.forEach((element) => {
            if (element.ano) {
              let ano = element.ano;
              if (this.anosCompativeis.indexOf(ano) < 0) {
                this.anosCompativeis.push(element.ano);
              }
            }
          });
        }
      }
    }
  }

  recuperarProduto() {
    this.produtoService
      .recuperarProduto(this.productId)
      .pipe(takeUntil(this.destroy$))
      .subscribe((x) => {
        this.produto = x;
        this.recuperaListaAnosCompativeis();
        this.defineParcela();
      });
  }
  defineParcela() {
    this.valorTotal = this.produto?.valor;
    this.valorParcela = this.valorTotal / 5;
  }
  atualizaValor(quantidade: number) {
    this.valorTotal = this.produto.valor * quantidade;
    this.valorParcela = this.valorTotal / 5;
  }

  incrementaUnidade() {
    this.quantidade++;
    this.atualizaValor(this.quantidade);
  }

  decrementaUnidade() {
    if (this.quantidade == 1) {
      this.quantidade = 1;
    } else {
      this.quantidade--;
    }
    this.atualizaValor(this.quantidade);
  }

  comprar() {
    this.produtoService.adicionarAoCarrinho(this.productId, this.quantidade);
  }
  recuperaQuantidadeProduto() {
    this.produtoService
      .recuperarQuantidade(this.productId)
      .pipe(takeUntil(this.destroy$))
      .subscribe((x) => {
        this.produtoQuantidade = x;
        this.verificaDisponibilidade();
      });
  }

  verificaDisponibilidade() {
    if (this.produtoQuantidade.quantidade > 0) {
      this.disponibilidadeString = 'Disponível em estoque';
      this.disponibilidade = false;
    } else {
      this.disponibilidadeString = 'Produto não disponível';
      this.disponibilidade = true;
    }
  }
}
