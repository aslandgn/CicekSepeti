import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Globals } from 'src/app/helpers/global';
import { ICategoryService } from 'src/app/services/abstract/serviceProduct/ICategoryService.service';
import { CategoryEditComponent } from './editorFiles/category-edit.component';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html'
})
export class CategoryComponent implements OnInit {
  public categories: Categories[];
  public category: Categories = { id: 0, categoryName: null, rootCategoryId: null, rootCategoryName: null, status: true };
  constructor(private global: Globals, private categoryService: ICategoryService, private dialog: MatDialog) {
  }
  ngOnInit(): void {
    this.getCategories();
  }

  columnDefs = [
    { headerName: "SELECT", checkboxSelection: true, width: 50, rowMultiSelectWithClick: false },
    { field: 'id', hide: true, },
    { headerName: "CATEGORY NAME", field: 'categoryName', sortable: true, filter: true },
    { field: 'rootCategoryId', hide: true, },
    { headerName: "ROOT CATEGORY NAME", field: 'rootCategoryName', sortable: true, filter: true },
    { headerName: "STATUS", field: 'status', cellRenderer: this.global.statusRender, sortable: true, filter: true }
  ];

  getCategories() {
    this.categoryService.getAll()
      .subscribe((data) => {
        this.categories = data;
      });
  }

  openEditModal(): void {
    const dialogRef = this.dialog.open(CategoryEditComponent, {
      data: { category: this.category, categories: this.categories }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != undefined) {
        if (result.id == 0) {
          this.categoryService.add(result).subscribe(data => {
            this.getCategories();
          });
        }
        else {

          this.categoryService.update(result.id, result).subscribe(data => {
            console.log(2)
            this.getCategories();
          });
        }
      }
    });
  }
  editItem() {
    this.category = this.global.getSelectedRowData()[0];
    this.openEditModal();
  }
  deleteItem() {
    this.category = this.global.getSelectedRowData()[0];
    this.openEditModal();
  }
}

