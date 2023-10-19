import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProdutoListarRequest } from 'src/app/produtos/models/produto-listar.request';

@Component({
  selector: 'app-filtros-vidro',
  templateUrl: './filtros-vidro.component.html',
  styleUrls: ['./filtros-vidro.component.css']
})
export class FiltrosVidroComponent implements OnInit {
  @Input() produtoListarRequest: ProdutoListarRequest;
  @Output() onFilter = new EventEmitter<void>();

  constructor() { }

  ngOnInit(): void {
  }

}
