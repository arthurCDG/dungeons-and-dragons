import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { AuthService } from './services';
import { registerLocaleData } from '@angular/common';
import localeFr from '@angular/common/locales/fr';

registerLocaleData(localeFr);

@NgModule({
  declarations: [
    AppComponent
],
  imports: [
    BrowserModule,
    AppRoutingModule,
	HttpClientModule,
	BrowserAnimationsModule
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
	}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
