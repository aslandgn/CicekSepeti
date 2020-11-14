import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'category-edit',
  templateUrl: 'category-edit.component.html',
})
export class CategoryEditComponent {

  constructor(
    public dialogRef: MatDialogRef<CategoryEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: [Categories, Categories[]]) { }

  onNoClick(): void {
    this.dialogRef.close();
  }
  getCategoriesForModal(id: number, categories: Categories[]) {
    if (id == undefined || id == 0)
      return categories;
    return categories.filter(x => x.id != id);
  }

}
