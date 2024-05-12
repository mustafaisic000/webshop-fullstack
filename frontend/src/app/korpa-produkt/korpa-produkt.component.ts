import { Component, OnInit } from '@angular/core';
import {ProduktGetSve} from "../home-page/ProduktGetSve";
import {
  KorpaProduktAllProdukti,
  KorpaProduktAllResponse,
  ProizvodIdResponse
} from "./korpa-produkt-all";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {DetaljiProizvodaIdResponse} from "../detalji-proizvoda/detalji-proizvoda-id-response";
import { Router } from '@angular/router';
import {ProduktAll} from "../provjera-narudzbe/produkt-all";




@Component({
  selector: 'app-korpa-produkt',
  templateUrl: './korpa-produkt.component.html',
  styleUrls: ['./korpa-produkt.component.css']
})
export class KorpaProduktComponent implements OnInit {

  proizvodi: { [key: string]: ProizvodIdResponse } = {};
  deletedSuccess: boolean = false;
  otvori=false;

  proizvodID(id:string){
        const url = MojConfig.adresa_servera + `/Produkt/PretraziProduktPoId?ProduktId=${id}`;
        return this.httpClient.get<ProizvodIdResponse>(url).subscribe((x) => {
          this.proizvodi[id] = x;
        });
    }
    constructor(private httpClient: HttpClient,private router: Router) {
    }

    korpaProdukti: ProduktAll[] = [];

    ngOnInit(): void {
      this.refreshCart();
        let url = MojConfig.adresa_servera + `/KorpaProdukt/GetSveKorpaProdukt`;
        this.httpClient.get<KorpaProduktAllResponse>(url).subscribe({
        next:(x: KorpaProduktAllResponse) => {
            this.korpaProdukti = x;
          for(let item of this.korpaProdukti) {
            this.proizvodID(item.produktId);
          }},error:x=>{
          alert("Greska "+ x.error)
          }
        });

    }
  goBack() {
    window.history.back();
  }

  deleteItem(produktId: string) {
    const deleteUrl=MojConfig.adresa_servera + `/KorpaProdukt/Obrisi?KorpaProduktId=${produktId}`;
    this.httpClient.delete(deleteUrl).subscribe(
      () => {
        this.deletedSuccess = true;
        this.ngOnInit();
        setTimeout(() => {
          this.deletedSuccess = false; // Hide the success message after 5 seconds
        }, 5000);
      },
      (error) => {

        console.error('Error deleting item:', error);
      }
    );

  }
  refreshCart() {
    let url = MojConfig.adresa_servera + `/KorpaProdukt/GetSveKorpaProdukt`;
    this.httpClient.get<KorpaProduktAllResponse>(url).subscribe({
    next:(x: KorpaProduktAllResponse) =>
    {
      this.korpaProdukti = x;
    },error:x=>
      {
        alert("Greska "+ x.error)
      }

    });
  }
  getUkupnaCijena(): number {
    const total = this.korpaProdukti.reduce((total, item) => {
      const proizvod = this.proizvodi[item.produktId];
      if (proizvod) {
        total += proizvod.cijena;
      }
      return total;
    }, 0);
    return parseFloat(total.toFixed(2)); // Zaokruživanje na dvije decimale
  }



  openModal() {
this.otvori=true;
  }

}
