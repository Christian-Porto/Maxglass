import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-item-pedido',
  templateUrl: './item-pedido.component.html',
  styleUrls: ['./item-pedido.component.css']
})
export class ItemPedidoComponent implements OnInit {
@Input() itensPedido;
mostraProdutos : boolean = false;
  constructor() { }

  ngOnInit(): void {
  }
  mostraModal(){
    this.mostraProdutos = !this.mostraProdutos;
  }
}
