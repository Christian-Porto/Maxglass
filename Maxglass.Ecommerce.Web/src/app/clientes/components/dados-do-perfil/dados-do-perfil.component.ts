import { ClientePessoaJuridicaResponse } from './../../models/cliente-pessoa-juridica.response';
import { DadosDoClienteService } from './../../services/dados-do-cliente.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import jwt_decode from 'jwt-decode';
import { Cliente } from '../../models/cliente';
import { ClientePessoaFisicaResponse } from '../../models/cliente-pessoa-fisica.response';

@Component({
  selector: 'app-dados-do-perfil',
  templateUrl: './dados-do-perfil.component.html',
  styleUrls: ['./dados-do-perfil.component.css'],
})
export class DadosDoPerfilComponent implements OnInit {
  token!: string;
  form: FormGroup;
  cliente!: Cliente;
  clienteResponsePj: ClientePessoaJuridicaResponse =
    new ClientePessoaJuridicaResponse({});
  clienteResponsePf: ClientePessoaFisicaResponse =
    new ClientePessoaFisicaResponse({});

  constructor(
    private formBuilder: FormBuilder,
    private dadosDoClienteService: DadosDoClienteService
  ) {
    this.token = localStorage.getItem('token');
    let user = jwt_decode(this.token);
    this.cliente = new Cliente(user['tipo'], user['id']);

    this.form = this.formBuilder.group({
      nome: ['', []],
      sobreNome: ['', []],
      telefone: ['', [Validators.pattern(/^\d{12,13}$/)]],
      cep: ['', [Validators.pattern(/^\d{8}$/)]],
      cpf: ['', [Validators.pattern(/^\d{11}$/)]],
      cnpj: ['', [Validators.pattern(/^\d{14}$/)]],
      ie: ['', []],
      razaoSocial: ['', []],
      email: ['', [Validators.email]],
    });

  }
  ngOnInit(): void {
    this.recuperaDadosCliente();
  }

  onSubmit() {
    let cliente = this.form.getRawValue();
    this.orquestraCliente(cliente);
    if(this.cliente.tipo == 2){
      this.dadosDoClienteService
      .putDadosCliente(this.clienteResponsePf).subscribe((x) => {
        console.log(x);
      });
    }
    if(this.cliente.tipo == 1){
      this.dadosDoClienteService
      .putDadosCliente(this.clienteResponsePj).subscribe((x) => {
        console.log(x);
      });
    }

    this.recuperaDadosCliente();
  }

  orquestraCliente(cliente: any) {
    if (this.cliente.tipo == 2) {
      this.montaClientePf(cliente);
    } else if (this.cliente.tipo == 1) {
      this.montaClientePj(cliente);
    }
  }
  montaClientePf(cliente: any) {
    if (cliente.email) {
      this.clienteResponsePf.email = cliente.email;
    }
    if (cliente.cep) {
      this.clienteResponsePf.cep = cliente.cep;
    }
    if (cliente.nome) {
      this.clienteResponsePf.nome = cliente.nome;
    }
    if (cliente.sobreNome) {
      this.clienteResponsePf.sobreNome = cliente.sobreNome;
    }
    if (cliente.cpf) {
      this.clienteResponsePf.cpf = cliente.cpf;
    }
    if (cliente.telefone) {
      this.clienteResponsePf.telefone = cliente.telefone;
    }

  }
  montaClientePj(cliente: any) {
    if (cliente.email) {
      this.clienteResponsePj.email = cliente.email;
    }
    if (cliente.cep) {
      this.clienteResponsePj.cep = cliente.cep;
    }
    if (cliente.cnpj) {
      this.clienteResponsePj.cnpj = cliente.cnpj;
    }
    if (cliente.razaoSocial) {
      this.clienteResponsePj.razaoSocial = cliente.razaoSocial;
    }
    if (cliente.inscricaoEstadual) {
      this.clienteResponsePj.inscricaoEstadual = cliente.ie;
    }
    if (cliente.nomeFantasia) {
      this.clienteResponsePj.nomeFantasia = cliente.nomeFantasia;
    }
  }

  recuperaDadosCliente() {
    if (this.cliente.tipo == 2) {
      this.dadosDoClienteService.getPessoaFisica().subscribe((x) => {
        console.log(x);
        this.clienteResponsePf = x;
      });
    } else if (this.cliente.tipo == 1) {
      this.dadosDoClienteService.getPessoaJuridica().subscribe((x) => {
        console.log(x);
        this.clienteResponsePj = x;
      });
    }
  }
}
