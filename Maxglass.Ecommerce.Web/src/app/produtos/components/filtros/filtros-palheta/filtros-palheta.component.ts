import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProdutoListarRequest } from 'src/app/produtos/models/produto-listar.request';

@Component({
  selector: 'app-filtros-palheta',
  templateUrl: './filtros-palheta.component.html',
  styleUrls: ['./filtros-palheta.component.css']
})
export class FiltrosPalhetaComponent implements OnInit {
  @Input() produtoListarRequest: ProdutoListarRequest;
  @Output() onFilter = new EventEmitter<void>();
  constructor() { }

  ngOnInit(): void {
  }

}
