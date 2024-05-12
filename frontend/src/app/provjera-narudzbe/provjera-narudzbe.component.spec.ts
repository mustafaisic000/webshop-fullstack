import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvjeraNarudzbeComponent } from './provjera-narudzbe.component';

describe('ProvjeraNarudzbeComponent', () => {
  let component: ProvjeraNarudzbeComponent;
  let fixture: ComponentFixture<ProvjeraNarudzbeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProvjeraNarudzbeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProvjeraNarudzbeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
