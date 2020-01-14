import { TestBed } from '@angular/core/testing';

import { LectionService } from './lection.service';

describe('LectionService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LectionService = TestBed.get(LectionService);
    expect(service).toBeTruthy();
  });
});
