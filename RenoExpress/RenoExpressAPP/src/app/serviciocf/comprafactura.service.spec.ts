import { TestBed } from '@angular/core/testing';

import { ComprafacturaService } from './comprafactura.service';

describe('ComprafacturaService', () => {
  let service: ComprafacturaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ComprafacturaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
