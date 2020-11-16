import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule, MatInputModule, MatButtonModule, MatToolbarModule, MatIconModule, MatSelectModule, MatFormFieldModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { BrowserModule } from '@angular/platform-browser';
import { AgGridModule } from 'ag-grid-angular';
import { CategoryComponent } from './category.component';
import { CategoryDeleteComponent } from './editorFiles/category-delete.component';
import { CategoryEditComponent } from './editorFiles/category-edit.component';

@NgModule({
    declarations: [
        CategoryComponent,
        CategoryEditComponent,
        CategoryDeleteComponent,
    ],

    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        AgGridModule.withComponents([]),
        CommonModule,
        MatDialogModule,
        MatInputModule,
        MatButtonModule,
        MatToolbarModule,
        MatIconModule,
        MatSelectModule,
        MatFormFieldModule,
    ],
    providers: [
        { provide: MatDialogRef, useValue: {} },
        { provide: MAT_DIALOG_DATA, useValue: [] },
    ],
    entryComponents: [
        CategoryEditComponent,
        CategoryDeleteComponent
    ],

})
export class CategoryModule { }
