import { inject } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";
import { User } from "../models/user";


export const canActivate: CanActivateFn = async (
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
) => {

    const router = inject(Router);
    
    const jwtHelperService = inject(JwtHelperService);
    var user= JSON.parse(localStorage.getItem("user")!) as User
    var isTokenExpired = jwtHelperService.isTokenExpired(user.token)

    if (isTokenExpired) {
        router.navigateByUrl("/auth/login")
        return false;
    } else {
        return true;
    }
};