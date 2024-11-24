import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CollectionsHeaderComponent } from './collections-header.component';

describe('CollectionsHeaderComponent', () => {
  let component: CollectionsHeaderComponent;
  let fixture: ComponentFixture<CollectionsHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CollectionsHeaderComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CollectionsHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
