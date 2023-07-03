import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CampaignComponent } from './components/campaign/campaign.component';
import { AdventurePageComponent } from './pages/adventure-page/adventure-page.component';
import { UserAuthentificationComponent } from './pages/user-authentification/user-authentification.component';

const routes: Routes = [
	{
		path: 'authentification',
		component: UserAuthentificationComponent
	},
	{
		path: 'campaigns',
		component: CampaignComponent
	},
	{
		path: 'adventure',
		component: AdventurePageComponent,
	}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
