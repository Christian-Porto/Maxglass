import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProdutoListarRequest } from 'src/app/produtos/models/produto-listar.request';

@Component({
  selector: 'app-filtros-parachoque',
  templateUrl: './filtros-parachoque.component.html',
  styleUrls: ['./filtros-parachoque.component.css']
})
export class FiltrosParachoqueComponent implements OnInit {
  @Input() produtoListarRequest: ProdutoListarRequest;
  @Output() onFilter = new EventEmitter<void>();
  constructor() { }

  ngOnInit(): void {
  }

}
