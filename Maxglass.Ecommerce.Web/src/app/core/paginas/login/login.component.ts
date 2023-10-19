import { AutenticacaoLogin } from '../../services/login/autenticacao-login.service';

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  mensagemErro: string;


  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly router: Router,
    private loginService : AutenticacaoLogin ) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required]]
    });
  }

  logarUsuario(){
    this.loginService.logarUsuario(this.loginForm.value)
    .subscribe({
      next : response=> {
      let token = Object.values(response)[0];
      localStorage['token'] = token;
      this.router.navigate(['']);//rota principal

    },
      error: (error) =>{
        if(error.status === 500){
          this.mensagemErro = "E-mail ou senha inválidos"

        }
      }
  })
  }


}
