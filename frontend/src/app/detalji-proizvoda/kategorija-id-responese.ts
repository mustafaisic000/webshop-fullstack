export class KategorijaIdResponese{
  kategorijaId: number
  naziv: string
  opis: string
  constructor(kategorijaId: number, naziv: string, opis: string) {
    this.kategorijaId = kategorijaId;
    this.naziv = naziv;
    this.opis = opis;
  }
}
