import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {DetaljiProizvodaIdResponse} from "./detalji-proizvoda-id-response";
import {MojConfig} from "../moj-config";
import {KategorijaIdResponese} from "./kategorija-id-responese";
import {KorpaProduktAllResponse} from "../korpa-produkt/korpa-produkt-all";
import {AutentifikacijaHelper} from "../helper/autentifikacija-helper";
import {LoginInformacije} from "../helper/login-informacije";



@Component({
  selector: 'app-detalji-proizvoda',
  templateUrl: './detalji-proizvoda.component.html',
  styleUrls: ['./detalji-proizvoda.component.css']
})
export class DetaljiProizvodaComponent implements OnInit {
    produkti: DetaljiProizvodaIdResponse ={produktId: '',
        naziv: '',
        opis: '',
        cijena: 0,
        datumObjave: '',
        slika: '',
        kategorijaId: 0,
        jelObrisan: false,
        kolicina: 0,

        jelProdan: false
    };
    kategorije: KategorijaIdResponese = {
        kategorijaId: 0,
        naziv: '',
        opis: ''
    };
   korpa: any;
   korpaProdukt: any;
   korpaProdukti: any;
   korisnikID: any;
  loginInformacije: LoginInformacije = {
    autentifikacijaToken: undefined,
    isLogiran: false,
    isPermisijaKorisnik: false,
    isPermisijaGost: false
  };

  povrat(id:string){
        const url = MojConfig.adresa_servera + `/Produkt/PretraziProduktPoId?ProduktId=${id}`;
        return this.httpClient.get<DetaljiProizvodaIdResponse>(url).subscribe({
          next:(x) => {
            this.produkti = x;
            this.kategorijePoID(this.produkti.kategorijaId);
          },
          error:x=>{
            alert("greska"+ x.error)
          }
        })
    }
    kategorijePoID(kategorijaID:number){
        const url = MojConfig.adresa_servera + `/Kategorija/PretraziKategorijuPoId?KategorijaId=${kategorijaID}`;
        return this.httpClient.get<KategorijaIdResponese>(url).subscribe((x) => {
           this.kategorije=x;
        });

    }
    constructor(private route: ActivatedRoute, private httpClient: HttpClient) {
      this.loginInformacije = AutentifikacijaHelper.getLoginInfo();
    }
  loadKorisnik()
  {
    this.httpClient.get(MojConfig.adresa_servera+ `/Autentifikacija/Get`, MojConfig.http_opcije()).subscribe((x:any)=> {
      this.korisnikID=x.korisnickiNalogId??null;
    });
  }
    ngOnInit(): void {
        const productId = this.route.snapshot.params['productId'];
        this.povrat(productId);
        this.loadKorisnik();
    }

  dodajUkorpu(produktId: string) {
    this.korpa = {
      korisnickiNalogId: this.korisnikID,
      produktId: produktId
    };

    this.httpClient.post(MojConfig.adresa_servera + "/KorpaProdukt/Dodaj", this.korpa).subscribe((x: any) => {
      this.korpaProdukt = x;
    });
    let url = MojConfig.adresa_servera + `/KorpaProdukt/GetSveKorpaProdukt`;
    this.httpClient.get<KorpaProduktAllResponse>(url).subscribe((x: KorpaProduktAllResponse) => {
      this.korpaProdukti = x;
    });
  }
}

