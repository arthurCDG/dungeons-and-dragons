import { Routes } from '@angular/router';

import { appGuard } from './guards/app.guard';
import { authGuard } from './guards/auth.guard';
import { AdventurePageComponent } from './pages/adventure-page/adventure-page.component';
import { CampaignCreationPageComponent } from './pages/campaigns/campaign-creation-page/campaign-creation-page.component';
import { CampaignsPageComponent } from './pages/campaigns/campaigns-page/campaigns-page.component';
import { MainCampaignPageComponent } from './pages/campaigns/main-campaign-page/main-campaign-page.component';
import { PlayerCreationPageComponent } from './pages/players/player-creation-page/player-creation-page.component';
import { PlayersPageComponent } from './pages/players/players-page/players-page.component';
import { LoginComponent } from './pages/user-authentification/login/login.component';
import { SignupComponent } from './pages/user-authentification/sign-up/sign-up.component';
import { WelcomePageComponent } from './pages/welcome-page/welcome-page.component';

export const routes: Routes = [
	{
		path: '',
		component: WelcomePageComponent
	},
	{
		path: 'login',
		component: LoginComponent,
		canActivate: [authGuard]
	},
	{
		path: 'signup',
		component: SignupComponent,
		canActivate: [authGuard]
	},
	{
		path: 'users/:userId/players',
		canActivate: [appGuard],
		children: [
			{
				path: '',
				component: PlayersPageComponent,
			},
			{
				path: 'new',
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
						path: ':campaignId',
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