import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PlayersPageComponent } from './pages/players-page/players-page.component';
import { MainCampaignPageComponent } from './pages/campaigns/main-campaign-page/main-campaign-page.component';
import { AdventurePageComponent } from './pages/adventure-page/adventure-page.component';
import { PlayerCreationPageComponent } from './pages/player-creation-page/player-creation-page.component';
import { CampaignCreationPageComponent } from './pages/campaigns/campaign-creation-page/campaign-creation-page.component';
import { WelcomePageComponent } from './pages/welcome-page/welcome-page.component';
import { CampaignsPageComponent } from './pages/campaigns/campaigns-page/campaigns-page.component';
import { SignupComponent } from './pages/user-authentification/sign-up/sign-up.component';
import { LoginComponent } from './pages/user-authentification/login/login.component';

const routes: Routes = [
	{
		path: '',
		component: WelcomePageComponent
	},
	{
		path: 'login',
		component: LoginComponent
	},
	{
		path: 'signup',
		component: SignupComponent
	},
	{
		path: 'users/:userId/players',
		children: [
			{
				path: '',
				component: PlayersPageComponent,
			},
			{
				path:'new',
				component: PlayerCreationPageComponent
			},
			{
				path: ':playerId/campaigns',
				children: [
					{
						path: '',
						component: CampaignsPageComponent,
					},
					{
						path: 'new',
						component: CampaignCreationPageComponent
					},
					{
						path:':campaignId',
						children: [
							{
								path: '',
								component: MainCampaignPageComponent,
							},
							{
								path: 'adventures/:adventureId',
									component: AdventurePageComponent
							}
						]
					}
				]
			},
		]
	}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
