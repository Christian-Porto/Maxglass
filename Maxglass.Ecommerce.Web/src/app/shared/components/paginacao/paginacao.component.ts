import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PaginacaoRequest } from '../../../produtos/models/paginacao.request';

@Component({
  selector: 'app-paginacao',
  templateUrl: './paginacao.component.html',
  styleUrls: ['./paginacao.component.css']
})
export class PaginacaoComponent implements OnInit {
  ngOnInit(): void {
  }

  @Input() paginaAtual: number;
  @Input() produtosPorPagina: number;
  @Input() totalRegistros: number;
  @Output() mudarPagina = new EventEmitter();

  get paginaNumeros(): number[] {
    return Array(this.totalPaginas).fill(0).map((x, i) => i + 1);
  }

  get totalPaginas(): number {
    return Math.ceil(this.totalRegistros / this.produtosPorPagina);
  }

  voltarPagina(): void {
    this.mudarPagina.emit(this.paginaAtual - 1);
  }

  avancarPagina(): void {
    this.mudarPagina.emit(this.paginaAtual + 1);
  }
}
