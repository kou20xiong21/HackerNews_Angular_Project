import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Article } from 'src/app/model/article';


@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.css']
})
export class ArticleListComponent implements OnInit {

  public articles: Article[];
  private articlesToSearch: Article[];
  public isLoading: boolean;
  public startPage: number;

  constructor (private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    this.getArticles();
  }

  getArticles() {
    this.isLoading = true;
    this.startPage = 1;

    this.http.get<Article[]>(this.baseUrl + 'articles/').pipe(
      map((response: Article[]) =>
        response.filter(article => article && article.url))).subscribe(response => {
          this.articles = response;
          this.articlesToSearch = response;
          this.isLoading = false;
        },
          error => console.log(error));
  }

  onSearch(searchString) {
    this.articles = this.articlesToSearch;

    if (searchString) {
      this.articles = this.articles.filter(article => article.title.toLocaleLowerCase().includes(searchString.toLowerCase()));
    }
  }

}
