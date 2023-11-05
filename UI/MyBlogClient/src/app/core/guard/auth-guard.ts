import { inject } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";


export const canActivate: CanActivateFn = async (
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
) => {

    const router = inject(Router);
    
    const jwtHelperService = inject(JwtHelperService);

    var isTokenExpired = jwtHelperService.isTokenExpired(localStorage.getItem("token"))

    if (isTokenExpired) {
        router.navigateByUrl("/auth/login")
        return false;
    } else {
        return true;
    }
};