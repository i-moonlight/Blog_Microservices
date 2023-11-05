import { inject } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from "@angular/router";


export const canActivate: CanActivateFn = async (
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
) => {

    const router = inject(Router);

    console.log(localStorage.getItem("token"))

    if (localStorage.getItem("token") == "" || localStorage.getItem("token") == undefined) {
        router.navigateByUrl("/auth/login")
        return false;
    } else {
        return true;
    }
};