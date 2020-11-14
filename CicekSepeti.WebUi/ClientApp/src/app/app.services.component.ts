import { NgModule, Provider } from "@angular/core";
import { Globals } from "./helpers/global";
import { ICategoryService } from "./services/abstract/serviceProduct/ICategoryService.service";
import { IProductService } from "./services/abstract/serviceProduct/IProductService.service";
import { CategoryManager } from "./services/concrate/managerProduct/CategoryManager.service";
import { ProductManager } from "./services/concrate/managerProduct/ProductManager.service";

const services: Provider[] = [
    //#region product
    { provide: IProductService, useClass: ProductManager },
    { provide: ICategoryService, useClass:CategoryManager },
    //#endregion
];

@NgModule({
    imports: [
    ],
    exports: [
    ],
    providers: [services, Globals],
    declarations: []
})
export class AppServiceModule { }
