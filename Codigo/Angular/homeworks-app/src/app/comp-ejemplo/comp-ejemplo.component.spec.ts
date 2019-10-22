import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompEjemploComponent } from './comp-ejemplo.component';

describe('CompEjemploComponent', () => {
  let component: CompEjemploComponent;
  let fixture: ComponentFixture<CompEjemploComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompEjemploComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompEjemploComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
