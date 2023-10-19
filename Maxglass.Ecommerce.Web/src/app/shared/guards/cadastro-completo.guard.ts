import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { CompletarcadastroService } from 'src/app/pedidos/services/completarcadastro.service';

@Injectable({
  providedIn: 'root'
})
export class CadastroCompletoGuard implements CanActivate {


  constructor(
    private  completarCadastroService : CompletarcadastroService,
    private router: Router) {


  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      var teste = this.completarCadastroService.verificarCadastro();
      console.log("oi" + teste);
      if(teste){
        
        return true;
      }else{
        this.router.navigate(['pedidos/completar-cadastro']);
        return false;
      }
      
  }

}
