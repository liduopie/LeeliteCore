import { TestBed } from '@angular/core/testing';

import { LeeliteCoreService } from './leelite-core.service';

describe('LeeliteCoreService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LeeliteCoreService = TestBed.get(LeeliteCoreService);
    expect(service).toBeTruthy();
  });
});
