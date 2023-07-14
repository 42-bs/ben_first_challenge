import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DataEnergyComponent } from './data-energy.component';

describe('DataEnergyComponent', () => {
  let component: DataEnergyComponent;
  let fixture: ComponentFixture<DataEnergyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DataEnergyComponent]
    });
    fixture = TestBed.createComponent(DataEnergyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
