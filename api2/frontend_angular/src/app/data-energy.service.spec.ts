import { TestBed } from '@angular/core/testing';

import { DataEnergyService } from './data-energy.service';

describe('DataEnergyService', () => {
  let service: DataEnergyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DataEnergyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
