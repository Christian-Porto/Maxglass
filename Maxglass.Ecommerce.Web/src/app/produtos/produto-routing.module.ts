import { AutenticacaoGuard } from './../shared/guards/autenticacao.guard';

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from '../shared/components/main/main.component';
import { DetalhesComponent } from '../produtos/paginas/detalhes/detalhes.component';
import { ListagemComponent } from './paginas/listagem/listagem.component';
import { FiltrosVidroComponent } from './components/filtros/filtros-vidro/filtros-vidro.component';
import { FiltrosRetrovisorComponent } from './components/filtros/filtros-retrovisor/filtros-retrovisor.component';
import { FiltrosParachoqueComponent } from './components/filtros/filtros-parachoque/filtros-parachoque.component';
import { FiltrosPalhetaComponent } from './components/filtros/filtros-palheta/filtros-palheta.component';
import { FiltrosFarolComponent } from './components/filtros/filtros-farol/filtros-farol.component';

const routes: Routes = [
  {
    path: '', pathMatch: 'full' ,component: ListagemComponent
  },
  {
    path: ':tipo', component: ListagemComponent
  },
  {
    path: 'detalhes/:id', component: DetalhesComponent
  },
  {
    path: 'pesquisa/:query', component: ListagemComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})

export class ProdutoRoutingModule { }
