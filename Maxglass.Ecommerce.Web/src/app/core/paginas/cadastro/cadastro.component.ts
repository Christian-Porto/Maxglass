import { AutenticacaoCadastroService } from '../../services/cadastro/autenticacaocadastro.service';

import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { faEye, faEyeSlash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-components',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {

  cadastroForm: FormGroup;
  faEye = faEye;
  faEyeSlash = faEyeSlash;
  mostrarSenha: any;
  termos: any;
  campoPreenchido: boolean = false;

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly router: Router,
    private autenticacaoService : AutenticacaoCadastroService
  )
  {  }


  ngOnInit(): void {

    this.cadastroForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required]],
      confirmaSenha: ['', [Validators.required]],
      tipo: ['2', [Validators.required]]
    });

  }

  cadastroUsuario(){
    this.autenticacaoService.cadastrarUsuario(this.cadastroForm.value);
    this.limpaFormulario();
    this.router.navigate(['login']);
  }

  limpaFormulario(){
    this.cadastroForm.reset();
    this.cadastroForm.setValue({email: '', senha: '', confirmaSenha: '', tipo: '2'});
  }

  tornarSenhaVisivel(){
   this.mostrarSenha =! this.mostrarSenha;
  }

  atualizarEstadoCampo(event:Event) {
    this.campoPreenchido = event.target['checked'];
  }

}
