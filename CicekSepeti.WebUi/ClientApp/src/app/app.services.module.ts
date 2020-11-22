import { NgModule, Provider } from "@angular/core";
import { JwtHelperService } from "@auth0/angular-jwt";
import { Globals } from "./helpers/global.helper";
import { ICategoryService } from "./services/abstract/serviceProduct/ICategoryService.service";
import { IProductService } from "./services/abstract/serviceProduct/IProductService.service";
import { IUserService } from "./services/abstract/serviceUser/UserService.service";
import { CategoryManager } from "./services/concrate/managerProduct/CategoryManager.service";
import { ProductManager } from "./services/concrate/managerProduct/ProductManager.service";
import { UserManager } from "./services/concrate/managerUser/UserManager.service";

const services: Provider[] = [
    //#region product
    { provide: IProductService, useClass: ProductManager },
    { provide: ICategoryService, useClass: CategoryManager },
    //#endregion
    //#region user
    { provide: IUserService, useClass: UserManager },
    {provide: JwtHelperService}
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
