import { ListaFavoritosComponent } from './components/lista-favoritos/lista-favoritos.component';
import { DadosDoClienteComponent } from './paginas/dados-do-cliente/dados-do-cliente.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DadosPedidoComponent } from './components/dados-pedido/dados-pedido.component';
import { DadosDoPerfilComponent } from './components/dados-do-perfil/dados-do-perfil.component';
import { AutenticacaoGuard } from '../shared/guards/autenticacao.guard';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: 'pedidos'
  },
  {
    path: 'pedidos', pathMatch: 'full' ,component: DadosPedidoComponent,  canActivate:[AutenticacaoGuard]
  },
  {
    path: 'perfil', pathMatch: 'full', component: DadosDoPerfilComponent,  canActivate:[AutenticacaoGuard]
  },
  { path: 'favoritos', component: ListaFavoritosComponent,  canActivate:[AutenticacaoGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientesRoutingModule { }
