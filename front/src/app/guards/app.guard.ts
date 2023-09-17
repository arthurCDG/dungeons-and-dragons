import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { AuthService } from "../services";
import { Observable, tap } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AppGuard implements CanActivate {
	constructor(private authService: AuthService, private router: Router) { }

	canActivate(): Observable<boolean> {
		return this.authService.isLoggedIn$().pipe(
			tap(isLoggedIn => {
				if (!isLoggedIn) {
					this.router.navigate(['login']);
				}
			})
		);
	}
}