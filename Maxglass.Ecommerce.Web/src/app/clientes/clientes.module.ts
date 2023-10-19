import { ListaFavoritosComponent } from './components/lista-favoritos/lista-favoritos.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ClientesRoutingModule } from './clientes-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DadosDoClienteComponent } from './paginas/dados-do-cliente/dados-do-cliente.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { DadosPedidoComponent } from './components/dados-pedido/dados-pedido.component';
import { ItemPedidoComponent } from './components/item-pedido/item-pedido.component';
import { SharedModule } from '../shared/shared.module';
import { DadosDoPerfilComponent } from './components/dados-do-perfil/dados-do-perfil.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    DadosDoClienteComponent,
    DadosPedidoComponent,
    ItemPedidoComponent,
    DadosDoPerfilComponent,
    ListaFavoritosComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ClientesRoutingModule,
    FontAwesomeModule,
    SharedModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class ClientesModule { }
