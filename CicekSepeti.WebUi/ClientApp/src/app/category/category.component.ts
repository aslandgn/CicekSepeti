import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html'
})
export class CategoryComponent {
  public categories: Categories[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Categories[]>(baseUrl + 'api/category').subscribe(result => {
      this.categories = result;
    }, error => console.error(error));
  }
}

interface Categories {
  id: number;
  categoryName: string;
  status: boolean;
}
