import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PlayersPageComponent } from './pages/players-page/players-page.component';
import { UserAuthentificationComponent } from './pages/user-authentification/user-authentification.component';
import { MainCampaignPageComponent } from './pages/main-campaign-page/main-campaign-page.component';
import { AdventurePageComponent } from './pages/adventure-page/adventure-page.component';
import { PlayerCreationPageComponent } from './pages/player-creation-page/player-creation-page.component';
import { CampaignCreationPageComponent } from './pages/campaign-creation-page/campaign-creation-page.component';
import { WelcomePageComponent } from './pages/welcome-page/welcome-page.component';

const routes: Routes = [
	{
		path: '',
		component: WelcomePageComponent
	},
	{
		path: 'auth',
		component: UserAuthentificationComponent
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
