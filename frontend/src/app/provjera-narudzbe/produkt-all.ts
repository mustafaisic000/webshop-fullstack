export type ProduktAllResponse=ProduktAll[]

export interface ProduktAll {
  korpaProduktId: string
  korisnikId: string
  produktId: string
}
export interface ProizvodIdResponse{
  produktId: string
  naziv: string
  opis: string
  cijena: number
  datumObjave: string
  slika: string
  kategorijaId: number
  jelObrisan: boolean
  kolicina: number
  jelProdan: boolean
}
