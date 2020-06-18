import { Injectable, Inject } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthorizeService } from './authorize.service';
import { tap } from 'rxjs/operators';
import { ApplicationPaths, QueryParameterNames } from '../authorization.constants';

@Injectable({
  providedIn: 'root'
})
export class AuthorizeGuard implements CanActivate {
  private baseUrl: string;
  constructor(private authorize: AuthorizeService, private router: Router, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  canActivate(
    _next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    console.log('AuthorizeGuard canActivate state', state)
    return this.authorize.isAuthenticated()
      .pipe(tap(isAuthenticated => this.handleAuthorization(isAuthenticated, state)));
  }

  private handleAuthorization(isAuthenticated: boolean, state: RouterStateSnapshot) {
    console.log('base_url', this.baseUrl)
    console.log('state.url', state.url);
    if (!isAuthenticated) {
      this.router.navigate(ApplicationPaths.LoginPathComponents, {
        queryParams: {
          [QueryParameterNames.ReturnUrl]: this.baseUrl + state.url
        }
      });
    }
  }
}
