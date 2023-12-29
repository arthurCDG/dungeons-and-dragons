import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { AuthService } from './services';
import { PlayerCardComponentComponent } from './components/player-card-component/player-card-component.component';
import { PlayerInformationCardComponent } from './components/player-information-card/player-information-card.component';

@NgModule({
  declarations: [
    AppComponent,
    PlayerCardComponentComponent,
    PlayerInformationCardComponent
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
	}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
