import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";


@Injectable()

export class TokenInterceptorService implements HttpInterceptor{

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        const token = localStorage['token'];
        let newHeaders = req.headers;
        if(token !== undefined){

            newHeaders = newHeaders.append('Authorization', `Bearer ${token}`);

        }
        const authReq = req.clone({headers:newHeaders});
        return next.handle(authReq);

    }



}
