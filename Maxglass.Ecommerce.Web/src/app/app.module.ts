import { CoreModule } from './core/core.module';
import { ClientesModule } from './clientes/clientes.module';
import { SharedModule } from './shared/shared.module';
import { CoreRoutingModule } from './core/core-routing.module';
import { RouterModule } from '@angular/router';

import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { ProdutosModule } from './produtos/produtos.module';



@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    RouterModule,
    BrowserModule,
    BrowserAnimationsModule,
    CoreModule,
    ProdutosModule,
    CoreRoutingModule,
    SharedModule,
    FontAwesomeModule,
    ClientesModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule{}
