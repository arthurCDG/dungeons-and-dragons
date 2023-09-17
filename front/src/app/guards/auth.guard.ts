import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { AuthService } from "../services";
import { Observable, map, tap } from "rxjs";

@Injectable({
	providedIn: 'root'
})
export class AuthGuard implements CanActivate {

	constructor(private authService: AuthService, private router: Router) { }

	canActivate(): Observable<boolean> {
		return this.authService.isLoggedIn$().pipe(
			tap(isLoggedIn => {
				if (isLoggedIn) {
				this.router.navigate([this.authService.INITIAL_PATH]);
				}
			}),
			map(isLoggedIn => !isLoggedIn)
		);
	}
}