// app.module.ts
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './home-page/home-page.component';
import { HeaderComponent } from './header/header.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { DetaljiProizvodaComponent } from './detalji-proizvoda/detalji-proizvoda.component';
import { KorpaProduktComponent } from './korpa-produkt/korpa-produkt.component';
import { ProvjeraNarudzbeComponent } from './provjera-narudzbe/provjera-narudzbe.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { FooterComponent } from './footer/footer.component';
import { AutorizacijaLoginProvjera } from './guards/autorizacija-login-provjera.service';
import { AutentifikacijaHelper } from './helper/autentifikacija-helper';
import { AuthInterceptor } from './helper/auth/auth-interceptor.service';
import { KategorijeComponent } from './kategorije/kategorije.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    HeaderComponent,
    DetaljiProizvodaComponent,
    KorpaProduktComponent,
    ProvjeraNarudzbeComponent,
    LoginComponent,
    FooterComponent,
    KategorijeComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, FormsModule],
  providers: [
    AutorizacijaLoginProvjera,
    AutentifikacijaHelper,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
