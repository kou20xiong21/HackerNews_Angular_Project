
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';

import { ArticleListComponent } from './article-list.component';


describe('ArticleListComponent', () => {
  let component: ArticleListComponent;
  let fixture: ComponentFixture<ArticleListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientModule,
        HttpClientTestingModule,
        FormsModule,
        NgxPaginationModule
      ],
      declarations: [ArticleListComponent],
      providers: [{ provide: 'BASE_URL' }]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArticleListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeDefined();
  });

  // it('should get news articles and return count > 20', () => {
  //   const windowOpenSpy = spyOn(window, 'open');
  //   component.getArticles();
  //   expect(windowOpenSpy.calls.count()).toBeGreaterThanOrEqual(20);
  // });

  // it('should get news articles and return count > 20', () => {
  //   expect(component.getArticles()).toBeGreaterThanOrEqual(20);
  // });

  // it('should search/filter', () => {
  //   const searchString = 'software';
  //   var result = component.onSearch(searchString);
  //   expect(result).toBeGreaterThan(1);
  // });


});
