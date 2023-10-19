import { CadastroCompletoGuard } from './../shared/guards/cadastro-completo.guard';
import { CompletarCadastroComponent } from './../pedidos/paginas/completar-cadastro/completar-cadastro.component';
import { AutenticacaoGuard } from './../shared/guards/autenticacao.guard';
import { HomeComponent } from './paginas/home/home.component';
import { LoginComponent } from './paginas/login/login.component';
import { CadastroComponent } from './paginas/cadastro/cadastro.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from '../shared/components/main/main.component';
import { CarrinhoComponent } from '../pedidos/paginas/carrinho/carrinho.component';
import { DadosDoClienteComponent } from '../clientes/paginas/dados-do-cliente/dados-do-cliente.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  { path: 'home', component: HomeComponent}, //canActivate:[AutenticacaoGuard, CadastroCompletoGuard]
  { path: 'cadastro', component: CadastroComponent },
  { path: 'login', component: LoginComponent },
  { path: 'carrinho', component: CarrinhoComponent },
  {
    path: 'user', component: DadosDoClienteComponent,
    loadChildren: () => import('../clientes/clientes.module').then(m => m.ClientesModule)},
  { path: 'pedidos',
  component: MainComponent,
  loadChildren: () => import('../pedidos/pedidos.module').then(m => m.PedidosModule),
  },
  {
    path: 'produtos',
    component: MainComponent,
    loadChildren: () => import('../produtos/produtos.module').then(m => m.ProdutosModule),
  },

  { path: '**', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class CoreRoutingModule {}
