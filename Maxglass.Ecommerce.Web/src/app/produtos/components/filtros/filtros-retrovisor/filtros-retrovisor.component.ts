import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProdutoListarRequest } from 'src/app/produtos/models/produto-listar.request';

@Component({
  selector: 'app-filtros-retrovisor',
  templateUrl: './filtros-retrovisor.component.html',
  styleUrls: ['./filtros-retrovisor.component.css']
})
export class FiltrosRetrovisorComponent implements OnInit {
  @Input() produtoListarRequest: ProdutoListarRequest;
  @Output() onFilter = new EventEmitter<void>();
  constructor() { }

  ngOnInit(): void {
  }

}
