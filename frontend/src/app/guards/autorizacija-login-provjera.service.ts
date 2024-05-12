import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import {AutentifikacijaHelper} from "../helper/autentifikacija-helper";
import {AuthService} from "../services/AuthService";



@Injectable()
export class AutorizacijaLoginProvjera implements CanActivate {

  constructor(private router: Router, private authService: AuthService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (this.authService.isLogiran()) {
      return true; // Korisnik je prijavljen, dopusti pristup ruti
    } else {
      // Korisnik nije prijavljen, preusmjeri na stranicu za prijavu
      this.router.navigate(['login'], { queryParams: { returnUrl: state.url }});
      return false;
    }
  }
}
