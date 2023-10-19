import { PagamentoComponent } from './paginas/pagamento/pagamento.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EntregaComponent } from './paginas/entrega/pedidos/paginas/entrega/entrega.component';
import { AutenticacaoGuard } from '../shared/guards/autenticacao.guard';
import { CadastroCompletoGuard } from '../shared/guards/cadastro-completo.guard';
import { CompletarCadastroComponent } from './paginas/completar-cadastro/completar-cadastro.component';

const routes: Routes = [
  {
    path: 'pagamento/:id', component: PagamentoComponent,  canActivate:[AutenticacaoGuard]
  },
  {
    path: 'entrega', component: EntregaComponent,  canActivate:[AutenticacaoGuard]
  },
  { path: 'completar-cadastro', component: CompletarCadastroComponent , canActivate:[AutenticacaoGuard]},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PedidosRoutingModule { }
