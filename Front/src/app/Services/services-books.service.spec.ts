import { TestBed } from '@angular/core/testing';

import { ServicesBooksService } from './services-books.service';

describe('ServicesBooksService', () => {
  let service: ServicesBooksService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServicesBooksService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
