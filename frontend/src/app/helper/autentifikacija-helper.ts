import {LoginInformacije} from "./login-informacije";
import {EventEmitter} from "@angular/core";

export class AutentifikacijaHelper{
  loggedInEvent: EventEmitter<boolean> = new EventEmitter<boolean>(); // Definirajte loggedInEvent EventEmitter

  stanjePrijave(): boolean {
    const loggedInValue = localStorage.getItem('loggedIn');
    return loggedInValue === 'true'; // Convert to boolean explicitly
  }
  static setLoginInfo(loginInformacije: LoginInformacije | null, zapamtiMe: boolean = false): void {
    if (loginInformacije == null)
      loginInformacije = new LoginInformacije();
    if (zapamtiMe) localStorage.setItem("autentifikacija-token", JSON.stringify(loginInformacije));
   if (!zapamtiMe) localStorage.setItem("autentifikacija-token", JSON.stringify(loginInformacije));
  }

  static getLoginInfo():LoginInformacije{
    let x = localStorage.getItem("autentifikacija-token") == null ?
      localStorage.getItem("autentifikacija-token") : localStorage.getItem("autentifikacija-token");
    if (x == null)
      return new LoginInformacije();

    try{
      let loginInformacije : LoginInformacije = JSON.parse(x);
      return loginInformacije;
    }
    catch(e){
      return new LoginInformacije();
    }
  }

  static ocistiMemoriju() {
    localStorage.removeItem("autentifikacija-token");
    localStorage.removeItem("autentifikacija-token");
  }
}
