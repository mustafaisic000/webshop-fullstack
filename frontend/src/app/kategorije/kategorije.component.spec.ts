import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KategorijeComponent } from './kategorije.component';

describe('KategorijeComponent', () => {
  let component: KategorijeComponent;
  let fixture: ComponentFixture<KategorijeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KategorijeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KategorijeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
