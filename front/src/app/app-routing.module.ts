import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CampaignComponent } from './components/campaign/campaign.component';
import { MainPageComponent } from './pages/main-page/main-page.component';

const routes: Routes = [
	{
		path: '',
		component: MainPageComponent,
		children: [
			{ path: 'campaigns', component: CampaignComponent }
		]
	}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
