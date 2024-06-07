import { AdventureType, CampaignType } from "../../../models";
import { ImageType } from "../../../components";

export const getBackgroundImageForCampaign = (type: CampaignType): ImageType => {
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

export const getBackgroundImageForAdventure = (type: AdventureType): ImageType => {
	switch(type) {
		case AdventureType.GoblinBandits:
		case AdventureType.OnTheTrailOfEvil:
		case AdventureType.HauntedVillage:
			return 'hollbrook-background-campaign-image';
		case AdventureType.KallictakusKey:
		case AdventureType.DarknessArmy:
		case AdventureType.Pursuit:
			return 'inpursuit-of-the-dark-army-campaign-image';
		case AdventureType.TheTrollsDen:
		case AdventureType.AttackingBorashCastle:
		case AdventureType.TheSpiralOfFate:
		case AdventureType.TheRiseOfNecratim:
			return 'wrath-of-the-lich-campaign-image';
		default:
			return 'campaigns-page';
	}
}