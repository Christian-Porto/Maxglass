import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProdutoListarRequest } from '../../models/produto-listar.request';

@Component({
  selector: 'app-filtros',
  templateUrl: './filtros.component.html',
  styleUrls: ['./filtros.component.css']
})
export class FiltrosComponent implements OnInit {
  @Input() produtoListarRequest: ProdutoListarRequest;
  @Output() onFilter = new EventEmitter<void>();

  constructor() { }

  ngOnInit(): void {
  }

  

}
