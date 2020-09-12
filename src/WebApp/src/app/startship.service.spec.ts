import { TestBed, inject } from '@angular/core/testing';

import { StartshipService } from './startship.service';

describe('StartshipService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [StartshipService]
    });
  });

  it('should be created', inject([StartshipService], (service: StartshipService) => {
    expect(service).toBeTruthy();
  }));
});
