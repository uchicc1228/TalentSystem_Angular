import { TestBed } from '@angular/core/testing';

import { TalentService } from './talent';

describe('Talent', () => {
  let service: TalentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TalentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
