import { Injectable } from "@angular/core";
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { IUserService } from "../services/abstract/serviceUser/UserService.service";
import { Globals } from "./global.helper";

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(
        private router: Router,
        private global: Globals
    ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.global.hasValidToken())
            return true;

        // not logged in so redirect to login page with the return url
        this.router.navigate(['/login']);
        return false;
    }
}