import { TestBed } from '@angular/core/testing';

import { WorldDataService } from './world-data.service';

describe('WorldDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WorldDataService = TestBed.get(WorldDataService);
    expect(service).toBeTruthy();
  });
});
