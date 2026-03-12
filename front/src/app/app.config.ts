import { registerLocaleData } from '@angular/common';
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import localeFr from '@angular/common/locales/fr';
import { ApplicationConfig, LOCALE_ID } from '@angular/core';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideRouter } from '@angular/router';

import { AuthInterceptor } from './interceptors/auth.interceptor';
import { routes } from './app.routes';

registerLocaleData(localeFr);

export const appConfig: ApplicationConfig = {
	providers: [
		provideAnimations(),
		provideHttpClient(withInterceptorsFromDi()),
		provideRouter(routes),
		{
			provide: HTTP_INTERCEPTORS,
			useClass: AuthInterceptor,
			multi: true
		},
		{
			provide: LOCALE_ID,
			useValue: 'fr-FR'
		}
	]
};