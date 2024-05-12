import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { MojConfig } from '../moj-config';
import { KategorijeGetSve } from './KategorijeGetSve';
import { ProduktGetSve } from '../home-page/ProduktGetSve';

@Component({
  selector: 'app-kategorije',
  templateUrl: './kategorije.component.html',
  styleUrls: ['./kategorije.component.css']
})
export class KategorijeComponent implements OnInit {
  categories: KategorijeGetSve[] = [];
  produkti: ProduktGetSve[] = [];
  searchQuery: string = '';
  searchResults: ProduktGetSve[] = [];

  constructor(private http: HttpClient, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.fetchCategories();
    this.route.queryParams.pipe(
      switchMap(params => {
        const categoryId = params['categoryId'];
        if (categoryId) {
          return this.fetchProductsByCategoryId(categoryId);
        } else {
          return this.fetchAllProducts(); // Fetch all products if categoryId is not provided
        }
      })
    ).subscribe(
      (products: ProduktGetSve[]) => {
        this.produkti = products;
        this.searchResults = products; // Initially, set search results to all products
      },
      (error) => {
        console.error('Error fetching products:', error);
      }
    );
  }

  fetchCategories(): void {
    const url = `${MojConfig.adresa_servera}/Kategorija/GetSveKategorije`;
    this.http.get<KategorijeGetSve[]>(url).subscribe(
      (response) => {
        this.categories = response;
      },
      (error) => {
        console.error('Error fetching categories:', error);
      }
    );
  }

  fetchProductsByCategoryId(categoryId: number): Observable<ProduktGetSve[]> {
    const url = `${MojConfig.adresa_servera}/Produkt/GetProduktPoKategorijaId?categoryId=${categoryId}`;
    return this.http.get<ProduktGetSve[]>(url);
  }

  fetchAllProducts(): Observable<ProduktGetSve[]> {
    const url = `${MojConfig.adresa_servera}/Produkt/GetSveProdukte`;
    return this.http.get<ProduktGetSve[]>(url);
  }

  search(): void {
    // Check if search query is empty
    if (this.searchQuery.trim() === '') {
      // Reset search results to all products if search query is empty
      this.searchResults = this.produkti;
      return;
    }

    // Filter products based on search query
    this.searchResults = this.produkti.filter(product =>
      product.naziv.toLowerCase().includes(this.searchQuery.toLowerCase())
    );
  }
}
