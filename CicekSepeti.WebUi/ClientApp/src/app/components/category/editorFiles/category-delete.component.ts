import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'category-delete',
  templateUrl: 'category-delete.component.html',
})
export class CategoryDeleteComponent {

  constructor(
    public dialogRef: MatDialogRef<CategoryDeleteComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Categories ) { }

}
