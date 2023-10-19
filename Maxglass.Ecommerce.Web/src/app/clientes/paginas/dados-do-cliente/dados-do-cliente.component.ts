import { Component, OnInit } from '@angular/core';
import { faHeart, faList, faUser } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-dados-do-cliente',
  templateUrl: './dados-do-cliente.component.html',
  styleUrls: ['./dados-do-cliente.component.css']
})
export class DadosDoClienteComponent implements OnInit {

  faUser = faUser;
  faHeart = faHeart;
  faList = faList;

  constructor() { }

  ngOnInit(): void {
  }

}
