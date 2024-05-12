import { MojConfig } from '../moj-config';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { AutentifikacijaHelper } from '../helper/autentifikacija-helper';
import { Component, OnInit } from '@angular/core';
import { KorisnickiNalog } from '../helper/korisnicki-nalog';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  kategorije: any;
  loggedIn: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private httpClient: HttpClient,
    private router: Router,
    private autentifikacijaHelper: AutentifikacijaHelper
  ) {}

  ngOnInit(): void {
    this.autentifikacijaHelper.loggedInEvent.subscribe((loggedIn: boolean) => {
      this.loggedIn = loggedIn;
    });
    this.loggedIn = this.autentifikacijaHelper.stanjePrijave();
    this.loadKorisnik();
    this.getSveKategorije();
  }

  loadKorisnik() {
    this.httpClient
      .get(
        MojConfig.adresa_servera + `/Autentifikacija/Get`,
        MojConfig.http_opcije()
      )
      .subscribe((x: any) => {
        this.loggedIn = this.autentifikacijaHelper.stanjePrijave();
      });
  }

  getSveKategorije() {
    let url = MojConfig.adresa_servera + '/Kategorija/GetSveKategorije';
    fetch(url).then((response) => {
      if (response.status != 200) {
        alert('error...' + response.statusText);
        return;
      }
      response.json().then((getKategorije) => {
        this.kategorije = getKategorije;
        this.prikaziKategorije();
      });
    });
  }

  prikaziKategorije() {
    const dropdownContent = document.getElementById('dropdownContent');
    if (dropdownContent && this.kategorije && this.kategorije.length > 0) {
      dropdownContent.innerHTML = '';
      this.kategorije.forEach((kategorija: { naziv: string }) => {
        const link = document.createElement('a');
        link.classList.add('dropdown-item');
        link.href = '#';
        link.textContent = kategorija.naziv;
        dropdownContent.appendChild(link);
      });
    }
  }

  odjaviSe() {
    let token = window.localStorage.getItem('my-auth-token') ?? '';
    window.localStorage.setItem('my-auth-token', '');
    this.httpClient
      .post(
        MojConfig.adresa_servera + '/Autentifikacija/Logout/',
        token,
        MojConfig.http_opcije()
      )
      .subscribe(() => {
        localStorage.setItem('loggedOut', 'true');
        localStorage.setItem('loggedIn', 'false');
        localStorage.setItem('autentifikacija-token', '');
        this.loggedIn = false;
        this.router.navigate(['/login']);
      });
  }
}
