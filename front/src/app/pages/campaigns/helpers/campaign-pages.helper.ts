import { CampaignType } from "../../../models";
import { ImageType } from "../../../components";

export const getBackgroundImage = (type: CampaignType): ImageType => {
	switch(type) {
		case CampaignType.HollbrooksLiberation:
			return 'hollbrook-background-campaign-image';
		case CampaignType.InpursuitOfTheDarkArmy:
			return 'inpursuit-of-the-dark-army-campaign-image';
		case CampaignType.WrathOfTheLich:
			return 'wrath-of-the-lich-campaign-image';
		default:
			return 'campaigns-page';
	}
}