import {AutentifikacijaToken} from "./helper/login-informacije";
import {AutentifikacijaHelper} from "./helper/autentifikacija-helper";

export class MojConfig{
    static adresa_servera = "https://localhost:7138"
  static http_opcije = function () {
    let autentifikacijaToken: AutentifikacijaToken | undefined = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken;
    let mojtoken = "";

    if (autentifikacijaToken !== undefined) {
      mojtoken = autentifikacijaToken.vrijednost;
    }
    return {
      headers: {
        'autentifikacija-token': mojtoken,
      }
    };
  }

}
