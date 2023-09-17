import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, throwError } from "rxjs";
import { AuthService } from "../services";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
	constructor(private readonly authService: AuthService) { }

	public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		if (request.url.includes('/services/auth')) {
			return next.handle(request);
		}
		
		if (this.authService.getToken()) {
			request = this.addToken(request, this.authService.getToken());
		}

		return next.handle(request).pipe(catchError(error => {
			if (error.status === 401) {
				this.authService.doLogoutAndRedirectToLogin();
			}
			return throwError(error);
		}));
	}

	private addToken(request: HttpRequest<any>, token: string | null) {
		return request.clone({
			setHeaders: { 'Authorization': `Bearer ${token}` }
		});
	}
}