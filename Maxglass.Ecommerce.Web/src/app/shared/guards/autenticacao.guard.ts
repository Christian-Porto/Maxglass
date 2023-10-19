import { AutenticacaoLogin } from './../../core/services/login/autenticacao-login.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AutenticacaoGuard implements CanActivate {

  constructor(
    private router: Router,
    private LoginService: AutenticacaoLogin) {

  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

      if(!this.LoginService.autenticado())
    {
      this.router.navigate(['login']);
      return false;
    }
    else{
      return true;
    }
  }



}
