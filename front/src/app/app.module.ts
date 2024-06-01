import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { AuthService } from './services';
import { registerLocaleData } from '@angular/common';
import localeFr from '@angular/common/locales/fr';
import { HeaderComponent } from './components/header/header.component';

registerLocaleData(localeFr);

@NgModule({
	declarations: [AppComponent],
    bootstrap: [AppComponent],
	imports: [
		BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
		HeaderComponent
	],
	providers: [
        AuthService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AuthInterceptor,
            multi: true
        },
        {
            provide: LOCALE_ID,
            useValue: 'fr-FR' // See how to modulate from requester real locale
        },
        provideHttpClient(withInterceptorsFromDi())
    ] })
export class AppModule { }
