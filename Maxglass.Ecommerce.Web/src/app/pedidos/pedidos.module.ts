import { RouterModule } from '@angular/router';
import { PagamentoComponent } from './paginas/pagamento/pagamento.component';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CarrinhoComponent } from './paginas/carrinho/carrinho.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CompletarCadastroComponent } from './paginas/completar-cadastro/completar-cadastro.component';
import { PedidosRoutingModule } from './pedidos-routing.module';
import { SharedModule } from '../shared/shared.module';
import { EntregaComponent } from './paginas/entrega/pedidos/paginas/entrega/entrega.component';

@NgModule({
    declarations: [
        CarrinhoComponent,
        PagamentoComponent,
        CompletarCadastroComponent,
        EntregaComponent
    ],
    exports: [
        CarrinhoComponent,
        EntregaComponent,
        CompletarCadastroComponent
    ],
    imports: [
        CommonModule,
        FontAwesomeModule,
        ReactiveFormsModule,
        HttpClientModule,
        RouterModule,
        FormsModule,
        PedidosRoutingModule,
        SharedModule
    ]
})
export class PedidosModule { }
