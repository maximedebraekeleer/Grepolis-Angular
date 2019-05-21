import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCitybuilderComponent } from './add-citybuilder.component';

describe('AddCitybuilderComponent', () => {
  let component: AddCitybuilderComponent;
  let fixture: ComponentFixture<AddCitybuilderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddCitybuilderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCitybuilderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
