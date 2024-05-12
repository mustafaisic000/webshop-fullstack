
export class LoginInformacije {
  autentifikacijaToken?:        AutentifikacijaToken;
  isLogiran:                   boolean=false;
  isPermisijaKorisnik:         boolean=false;
  //isPermsijaAdministrator: boolean=false;
  isPermisijaGost: boolean=false;
}
export interface AutentifikacijaToken {
  id:                   number;
  vrijednost:           string;
  korisnickiNalogId:    number;
  korisnickiNalog:      KorisnickiNalog;
  vrijemeEvidentiranja: Date;
  ipAdresa:             string;
}

export interface KorisnickiNalog {
  id: number
  ime: string
  prezime: string
  korisnickoIme: string
  lozinka: string
  email: string
  isKorisnik: boolean
  isAdministrator: boolean ;

}
