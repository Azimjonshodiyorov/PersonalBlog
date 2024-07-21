import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotefoundComponent } from './notefound.component';

describe('NotefoundComponent', () => {
  let component: NotefoundComponent;
  let fixture: ComponentFixture<NotefoundComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NotefoundComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NotefoundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
