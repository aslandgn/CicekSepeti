import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Globals } from 'src/app/helpers/global';
import { ICategoryService } from 'src/app/services/abstract/serviceProduct/ICategoryService.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html'
})
export class CategoryComponent implements OnInit {
  public categories: Categories[];
  public category: Categories = {id:0, categoryName: null, rootCategoryId: null, status: true};
  constructor(private global: Globals, private categoryService: ICategoryService, private dialog: MatDialog) {
  }
  ngOnInit(): void {
    this.getCategories();
  }

  columnDefs = [
    { headerName: "SELECT", checkboxSelection: true, width:50, rowMultiSelectWithClick: false },
    { headerName: "ID", field: 'id', sortable: true, filter: true, hide: true, },
    { headerName: "CATEGORY NAME", field: 'categoryName', sortable: true, filter: true },
    { headerName: "STATUS", field: 'status', cellRenderer: this.global.statusRender, sortable: true, filter: true }
  ];

  getCategories() {
    this.categoryService.getAll()
      .subscribe((data) => {
        this.categories = data;
      });
  }
  openEditModal(): void {
    console.log(this.category)
    const dialogRef = this.dialog.open(DialogOverviewExampleDialog, {
      data: this.category
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result)
      if(result != undefined){
        if(result.id == 0){          
        this.categoryService.add(result).subscribe(data => {
          console.log(1)
          this.getCategories();
        });
        }
        else{
          
        this.categoryService.update(result.id, result).subscribe(data => {
          console.log(2)
          this.getCategories();
        });
        }
      }
    });
  }
  editItem(){
    this.category = this.global.getSelectedRowData()[0];
    this.openEditModal();
  }
}
@Component({
  selector: 'dialog-overview-example-dialog',
  templateUrl: 'edit-modal.html',
})
export class DialogOverviewExampleDialog {

  constructor(
    public dialogRef: MatDialogRef<DialogOverviewExampleDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Categories) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

}
