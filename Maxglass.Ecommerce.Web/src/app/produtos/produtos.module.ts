import { SharedModule } from './../shared/shared.module';
import { ProdutoRoutingModule } from './produto-routing.module';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DetalhesComponent } from './paginas/detalhes/detalhes.component';
import { ListagemComponent } from './paginas/listagem/listagem.component';
import { FormsModule } from '@angular/forms';
import { FiltrosComponent } from './components/filtros/filtros.component';
import { FiltrosVidroComponent } from './components/filtros/filtros-vidro/filtros-vidro.component';
import { FiltrosFarolComponent } from './components/filtros/filtros-farol/filtros-farol.component';
import { FiltrosPalhetaComponent } from './components/filtros/filtros-palheta/filtros-palheta.component';
import { FiltrosRetrovisorComponent } from './components/filtros/filtros-retrovisor/filtros-retrovisor.component';
import { FiltrosParachoqueComponent } from './components/filtros/filtros-parachoque/filtros-parachoque.component';
import { PaginacaoComponent } from '../shared/components/paginacao/paginacao.component';
import { NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    DetalhesComponent,
    ListagemComponent,
    FiltrosComponent,
    FiltrosVidroComponent,
    FiltrosFarolComponent,
    FiltrosPalhetaComponent,
    FiltrosRetrovisorComponent,
    FiltrosParachoqueComponent,


  ],
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule,
    ProdutoRoutingModule,
    FormsModule,
    NgbAlertModule,
    SharedModule,
  ]
})
export class ProdutosModule { }
