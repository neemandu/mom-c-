
 
 

 

/// <reference path="Enums.ts" />

declare namespace a1 {
	interface Ivhunim {
		Address: string;
		Background: string;
		BirthDate: string;
		Diyuk592: string;
		DiyukYahalom: string;
		Email: string;
		EranutMorfoTahbirit: string;
		EranutTahbirit: string;
		FirstName: string;
		Gender: string;
		GlanzAnalogya: number;
		GlanzHagdara: number;
		GlanzHasakatMaskanot: number;
		GlanzMahutiyot: number;
		GlanzMiyun: number;
		GlanzNigudiyut: number;
		GlanzNirdafot: number;
		GlanzPitgamim: number;
		GlanzSikum: string;
		GlanzSivug: number;
		Grade: string;
		HabaaBektav: string;
		Hamlazot: string;
		HatamotLedarkayHibahanut: string;
		Id: number;
		Institue: string;
		IptaRightAnswers: number;
		IsEranutMetaLeshonitEnabled: boolean;
		IsGlanzEnabled: boolean;
		IsHabaBealpeEnabled: boolean;
		IsHavanatHanikraEnabled: boolean;
		IsHavanatHanishmaEnabled: boolean;
		IsIptaEnabled: boolean;
		IsKtivaEnabled: boolean;
		IsToniEnabled: boolean;
		IsZikaronmMiluliEnabled: boolean;
		ItzurimVetnuotDiyuk: number;
		ItzurimVetnuotKetzev: number;
		KeshevHazuti: string;
		Ketzev592: string;
		KetzevYahalom: string;
		Kidron: string;
		KidudVehasmala: string;
		KimGame: string;
		Ktav: string;
		Ktiv: string;
		LastName: string;
		MilimBeheksherDiyuk: number;
		MilimBeheksherKetzev: number;
		MilimBodedotDiyuk: number;
		MilimBodedotKetzev: number;
		MilotTefelDiyuk: number;
		MilotTefelKetzev: number;
		MudautFonologit: string;
		OverallImpression: string;
		ParentEmail: string;
		ParentName: string;
		ParentPhone: string;
		Ran: string;
		ReadyToBeSent: boolean;
		Reason: string;
		Rey: string;
		Rey1: string;
		Rey2: string;
		Rey3: string;
		Rey4: string;
		Rey5: string;
		Rey6: string;
		Rey7: string;
		Rey8: string;
		Rey9: string;
		School: string;
		ShetefMiluli: string;
		Sikum: string;
		SikumHabaBealpe: string;
		SikumHavanatHanikra: string;
		SikumHavanatHanishma: string;
		SikumTahaliheyKria: string;
		TifkudimNuhuliyim: string;
		ToniRightAnswers: number;
		TshuvotLesheelotBezikaLetext: string;
		Tz: string;
		WhoSent: string;
		YedaOrtography: string;
		ZikaronAvoda: string;
		ZikaronMiyadiShlifa: string;
		ZikaronMoshheShlifa: string;
	}
}
declare namespace a1.Models {
	interface IvhunimAndActions {
		Actions: a1.Models.RolesAction[];
		Ivhunim: a1.Ivhunim[];
	}
	interface RolesAction {
		Action: string;
		RoleId: number;
	}
}


