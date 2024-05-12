import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {AutentifikacijaToken} from "../helper/autentifikacija-token";

@Injectable({providedIn: 'root'})
export class AuthService{
  constructor(private httpClient: HttpClient) {
  }
  isLogiran():boolean{
    return this.getLogiraniKorisnik() != null;
  }
  getLogiraniKorisnik():AutentifikacijaToken | null{
    let item = window.localStorage.getItem("my-auth-token")
    if (item)
    {
      try {
        return JSON.parse(item);
      }
      catch (e){
        return null;
      }

    }
    return null;
  }
  getAuthorizationToken():string{
    return this.getLogiraniKorisnik()?.vrijednost??'';
  }
  isAdmin():boolean{
    return this.getLogiraniKorisnik()?.korisnickiNalog?.isAdministrator??false;
  }
 isKorisnik():boolean{
   return this.getLogiraniKorisnik()?.korisnickiNalog?.isKorisnik??false;
 }
  is2FActive():boolean{
    return this.getLogiraniKorisnik()?.korisnickiNalog?.is2FActive ?? false;
  }
  setLogiraniKorisnik(token: AutentifikacijaToken |null){
    if (token) {
      window.localStorage.setItem("my-auth-token", JSON.stringify(token))
    }
    else{
      window.localStorage.setItem("my-auth-token", '')
    }
  }

}
