import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProdutoListarRequest } from 'src/app/produtos/models/produto-listar.request';

@Component({
  selector: 'app-filtros-farol',
  templateUrl: './filtros-farol.component.html',
  styleUrls: ['./filtros-farol.component.css']
})
export class FiltrosFarolComponent implements OnInit {
  @Input() produtoListarRequest: ProdutoListarRequest;
  @Output() onFilter = new EventEmitter<void>();
  constructor() { }

  ngOnInit(): void {
  }

}
