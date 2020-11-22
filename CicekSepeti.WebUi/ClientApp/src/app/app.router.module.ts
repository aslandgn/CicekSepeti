import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CategoryComponent } from './components/category/category.component';
import { CommonModule } from '@angular/common';
import { AppMainComponent } from './app.main.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './helpers/AuthGuard.helper';
const routes: Routes = [
    {
        path: '', component: AppMainComponent, canActivate: [AuthGuard],
        children: [
            { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
            { path: 'category', component: CategoryComponent, canActivate: [AuthGuard] },
        ]
    },
    { path: 'login', component: LoginComponent },
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
