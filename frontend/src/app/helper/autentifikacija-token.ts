import {KorisnickiNalog} from "./korisnicki-nalog";

export class AutentifikacijaToken {
  id?: number;
  vrijednost?: string;
  korisnickiNalogId?: number;
  korisnickiNalog?: KorisnickiNalog;
  vrijemeEvidentiranja?: Date;
  ipAdresa?: string;
}
