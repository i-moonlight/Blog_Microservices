import { inject } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from "@angular/router";


export const canActivate: CanActivateFn = async (
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
) => {

    const router = inject(Router);
    let user ="user..."

    

    return true;
};