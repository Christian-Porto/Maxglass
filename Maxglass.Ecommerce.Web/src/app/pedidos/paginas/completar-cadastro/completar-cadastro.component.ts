import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import jwt_decode from 'jwt-decode';
import { ClientePayload } from 'src/app/shared/models/cliente/cliente-payload';

import { CompletarcadastroService } from '../../services/completarcadastro.service';

@Component({
  selector: 'app-completar-cadastro',
  templateUrl: './completar-cadastro.component.html',
  styleUrls: ['./completar-cadastro.component.css']
})
export class CompletarCadastroComponent implements OnInit {

  tipoCliente : number;
  cadastroForm : FormGroup;

  constructor(
    private completarcadastroService : CompletarcadastroService,
    private formBuilder : FormBuilder,
    private router : Router ) { }

  ngOnInit(): void {
    let payload = jwt_decode<ClientePayload>(localStorage.getItem("token"));
    this.tipoCliente = parseInt(payload.tipo);

    switch(this.tipoCliente)
    {
      case 1:
        this.cadastroForm = this.formBuilder.group({
          cnpj: ['', [Validators.required]],
          razaoSocial: ['', [Validators.required]],
          inscricaoEstadual: ['', [Validators.required]],
          nomeFantasia: ['', [Validators.required]]
        })
        break;
      case 2:
        this.cadastroForm = this.formBuilder.group({
          nome: ['', [Validators.required]],
          sobreNome: ['', [Validators.required]],
          cpf: ['', [Validators.required]],
          telefone: ['', [Validators.required]]
        })
        break;
;
      }
  }

  completarcadastro(){
    this.completarcadastroService.cadastrar(this.cadastroForm.value).subscribe(()=>{
     
    });
  }

}
