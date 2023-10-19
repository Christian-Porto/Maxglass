import { FormsModule } from '@angular/forms';
import { ProdutoResponse } from 'src/app/shared/models/produtos/responses/produto.response';
import { ResumoPedidoComponent } from './components/resumo-pedido/resumo-pedido.component';
import { Router, RouterModule } from '@angular/router';
import { TokenInterceptorService } from './interceptors/http.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardComponent } from './components/card-produto/card-produto.component';
import { CarrosselProdutoComponent } from './components/carrossel-produto/carrossel-produto.component';
import { HeaderPrincipalComponent } from './components/header-principal/header-principal.component';
import { HeaderAmbienteSeguroComponent } from './components/header-ambiente-seguro/header-ambiente-seguro.component';
import { FooterComponent } from './components/footer/components/footer/footer.component';
import { MainComponent } from './components/main/main.component';
import { PaginacaoComponent } from './components/paginacao/paginacao.component';
import { ResumoPedidoEnderecoComponent } from './components/resumo-pedido-endereco/resumo-pedido-endereco.component';

@NgModule({
  declarations: [
    CardComponent,
    CarrosselProdutoComponent,
    HeaderPrincipalComponent,
    HeaderAmbienteSeguroComponent,
    FooterComponent,
    MainComponent,
    ResumoPedidoComponent,
    ResumoPedidoEnderecoComponent,
    PaginacaoComponent
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    }
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ],
  exports:[
    CardComponent,
    CarrosselProdutoComponent,
    HeaderPrincipalComponent,
    FooterComponent,
    PaginacaoComponent,
    HeaderAmbienteSeguroComponent,
    PaginacaoComponent,
    ResumoPedidoEnderecoComponent,
    ResumoPedidoComponent

  ]
})
export class SharedModule{};
