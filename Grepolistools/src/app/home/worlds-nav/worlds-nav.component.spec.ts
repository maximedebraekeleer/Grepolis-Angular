import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorldsNavComponent } from './worlds-nav.component';

describe('WorldsNavComponent', () => {
  let component: WorldsNavComponent;
  let fixture: ComponentFixture<WorldsNavComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorldsNavComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorldsNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
