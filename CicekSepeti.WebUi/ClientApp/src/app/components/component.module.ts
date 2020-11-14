import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { CategoryModule } from './category/category.module';




@NgModule({
   declarations: [
      HomeComponent,
   ],
   exports:[
   ],
   imports: [
      CategoryModule,
   ],
   providers: [
   ]

})
export class ComponentsModule { }
