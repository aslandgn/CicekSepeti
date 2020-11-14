import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CategoryComponent } from './components/category/category.component';
import { CommonModule } from '@angular/common';
import { AppMainComponent } from './app.main.component';
const routes: Routes = [
    {
        path: '', component: AppMainComponent,
        children: [
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'category', component: CategoryComponent },
        ]
    },
];
@NgModule({
    imports: [
        CommonModule,
        RouterModule.forRoot(routes),
    ],
    exports: [
        RouterModule
    ],
})
export class AppRouterModule { }
