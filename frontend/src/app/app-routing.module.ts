import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { DetaljiProizvodaComponent } from './detalji-proizvoda/detalji-proizvoda.component';
import { KorpaProduktComponent } from './korpa-produkt/korpa-produkt.component';
import { ProvjeraNarudzbeComponent } from './provjera-narudzbe/provjera-narudzbe.component';
import { LoginComponent } from './login/login.component';
import { FooterComponent } from './footer/footer.component';
import { AutorizacijaLoginProvjera } from './guards/autorizacija-login-provjera.service';
import { KategorijeComponent } from './kategorije/kategorije.component';

const routes: Routes = [
  {
    component: HomePageComponent,
    path: '',
  },
  {
    component: DetaljiProizvodaComponent,
    path: 'detalji-produkta/:productId',
    canActivate: [AutorizacijaLoginProvjera],
  },
  {
    component: KorpaProduktComponent,
    path: 'korpa-produkt',
    canActivate: [AutorizacijaLoginProvjera],
  },
  {
    component: ProvjeraNarudzbeComponent,
    path: 'provjera-narudzbe',
    canActivate: [AutorizacijaLoginProvjera],
  },
  {
    component: LoginComponent,
    path: 'login',
  },
  {
    component: FooterComponent,
    path: 'footer',
  },
  {
    component: KategorijeComponent,
    path: 'kategorije',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
