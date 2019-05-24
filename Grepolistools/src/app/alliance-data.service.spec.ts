import { TestBed } from '@angular/core/testing';

import { AllianceDataService } from './alliance-data.service';

describe('AllianceDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AllianceDataService = TestBed.get(AllianceDataService);
    expect(service).toBeTruthy();
  });
});
