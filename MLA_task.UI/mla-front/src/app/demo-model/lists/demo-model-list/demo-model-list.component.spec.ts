import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DemoModelListComponent } from './demo-model-list.component';

describe('DemoModelListComponent', () => {
  let component: DemoModelListComponent;
  let fixture: ComponentFixture<DemoModelListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DemoModelListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DemoModelListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
