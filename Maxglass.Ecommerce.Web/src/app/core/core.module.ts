import { RouterModule } from '@angular/router';
import { SharedModule } from './../shared/shared.module';
import { LoginComponent } from './paginas/login/login.component';
import { CadastroComponent } from './paginas/cadastro/cadastro.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { CoreRoutingModule } from './core-routing.module';
import { HomeComponent } from './paginas/home/home.component';
import { PedidosModule } from '../pedidos/pedidos.module';
import { BeneficiosComponent } from './paginas/home/components/beneficios/beneficios.component';
import { CarrosselComponent } from './paginas/home/components/carrossel/carrossel.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CarouselModule } from 'ngx-bootstrap/carousel';



@NgModule({
  declarations: [
    CadastroComponent,
    LoginComponent,
    HomeComponent,
    BeneficiosComponent,
    CarrosselComponent,
  ],
  imports: [
    CoreRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    FontAwesomeModule,
    FormsModule,
    SharedModule,
    RouterModule,
    CarouselModule.forRoot()
  ]
})
export class CoreModule { }
