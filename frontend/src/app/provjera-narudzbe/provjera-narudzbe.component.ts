import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {KorpaProduktAllProdukti, KorpaProduktAllResponse, ProizvodIdResponse} from "../korpa-produkt/korpa-produkt-all";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Component({
  selector: 'app-provjera-narudzbe',
  templateUrl: './provjera-narudzbe.component.html',
  styleUrls: ['./provjera-narudzbe.component.css']
})
export class ProvjeraNarudzbeComponent implements OnInit {
  korpaProdukti: KorpaProduktAllProdukti[] = [];
  proizvodi: { [key: string]: ProizvodIdResponse } = {};
  constructor(private httpClient: HttpClient,private router: Router) {
  }
  ngOnInit(): void {
    let url = MojConfig.adresa_servera + `/KorpaProdukt/GetSveKorpaProdukt`;
    this.httpClient.get<KorpaProduktAllResponse>(url).subscribe((x: KorpaProduktAllResponse) => {
      this.korpaProdukti = x;
      console.log('Korpa proizvoda:', this.korpaProdukti); // Ispis korpaProdukti
      for(let item of this.korpaProdukti) {
        this.proizvodID(item.produktId);
      }
    });
  }
  proizvodID(id:string){
    const url = MojConfig.adresa_servera + `/Produkt/PretraziProduktPoId?ProduktId=${id}`;
    return this.httpClient.get<ProizvodIdResponse>(url).subscribe((x) => {
      this.proizvodi[id] = x;
    });
  }


  getUkupnaCijena() {
    const total = this.korpaProdukti.reduce((total, item) => {
      const proizvod = this.proizvodi[item.produktId];
      if (proizvod) {
        total += proizvod.cijena;
      }
      return total;
    }, 0);

    return total.toFixed(2);
  }

}
