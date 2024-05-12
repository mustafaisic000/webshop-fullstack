import { Component, OnInit } from '@angular/core';
import { ProduktGetSve } from './ProduktGetSve';
import { MojConfig } from '../moj-config';
import { LoginInformacije } from '../helper/login-informacije';
import { AutentifikacijaHelper } from '../helper/autentifikacija-helper';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent implements OnInit {
  currentIndex: number = 0;
  currentProduct!: ProduktGetSve; // Adding ! to declare currentProduct as non-nullable
  produkti: ProduktGetSve[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.fetchAllProducts().subscribe((data: ProduktGetSve[]) => {
      this.produkti = data;
      this.currentProduct = this.produkti[this.currentIndex];
    });
  }
  loginInfo(): LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }
  changeProduct(direction: 'prev' | 'next'): void {
    if (this.produkti.length > 0) {
      if (direction === 'prev') {
        this.currentIndex =
          this.currentIndex === 0
            ? this.produkti.length - 1
            : this.currentIndex - 1;
      } else {
        this.currentIndex =
          this.currentIndex === this.produkti.length - 1
            ? 0
            : this.currentIndex + 1;
      }
      this.currentProduct = this.produkti[this.currentIndex];
    }
  }

  fetchAllProducts(): Observable<ProduktGetSve[]> {
    const url = `${MojConfig.adresa_servera}/Produkt/GetSveProdukte`;
    return this.http.get<ProduktGetSve[]>(url);
  }

  getProductsByCategory1(category: number): ProduktGetSve[] {
    return this.produkti.filter((produkt) => produkt.kategorijaId === category);
  }

  getProductsByCategory7(category: number): ProduktGetSve[] {
    return this.produkti.filter((produkt) => produkt.kategorijaId === category);
  }
}
