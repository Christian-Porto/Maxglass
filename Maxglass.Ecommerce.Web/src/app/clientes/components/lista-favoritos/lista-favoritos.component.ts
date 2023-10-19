import { Component, OnInit } from '@angular/core';
import { ProdutoResponse } from 'src/app/produtos/models/produto.response';
import { ListarFavoritosService } from '../../services/listar-favoritos.service';

@Component({
  selector: 'app-lista-favoritos',
  templateUrl: './lista-favoritos.component.html',
  styleUrls: ['./lista-favoritos.component.css']
})
export class ListaFavoritosComponent implements OnInit {

  produtos : ProdutoResponse[];
  constructor(private listarFavoritosService: ListarFavoritosService) { }

  ngOnInit(): void {
    this.listarFavoritosService.recuperarFavoritos().subscribe((response)=>{
      this.produtos = response;
      console.log(response);
    });

  }

}
