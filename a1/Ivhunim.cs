//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace a1
{
    using System;
    using System.Collections.Generic;

    public partial class Ivhunim
    {
        public Ivhunim() { }
        public Ivhunim(Ivhunim ivhun)
        {
            ReadyToBeSent = false;
            FirstName = ivhun.FirstName + " - ����" ;
            LastName = ivhun.LastName;
            Email = ivhun.Email;
            Institue = ivhun.Institue;
            BirthDate = ivhun.BirthDate;
            Gender = ivhun.Gender;
            Grade = ivhun.Grade;
            School = ivhun.School;
            Address = ivhun.Address;
            ParentName = ivhun.ParentName;
            ParentPhone = ivhun.ParentPhone;
            ParentEmail = ivhun.ParentEmail;
            Reason = ivhun.Reason;
            WhoSent = ivhun.WhoSent;
            Background = ivhun.Background;
            OverallImpression = ivhun.OverallImpression;
            IsToniEnabled = ivhun.IsToniEnabled;
            ToniRightAnswers = ivhun.ToniRightAnswers;
            IsIptaEnabled = ivhun.IsIptaEnabled;
            IptaRightAnswers = ivhun.IptaRightAnswers;
            IsGlanzEnabled = ivhun.IsGlanzEnabled;
            GlanzNigudiyut = ivhun.GlanzNigudiyut;
            GlanzNirdafot = ivhun.GlanzNirdafot;
            GlanzMahutiyot = ivhun.GlanzMahutiyot;
            GlanzHagdara = ivhun.GlanzHagdara;
            GlanzMiyun = ivhun.GlanzMiyun;
            GlanzSivug = ivhun.GlanzSivug;
            GlanzPitgamim = ivhun.GlanzPitgamim;
            GlanzAnalogya = ivhun.GlanzAnalogya;
            GlanzHasakatMaskanot = ivhun.GlanzHasakatMaskanot;
            GlanzSikum = ivhun.GlanzSikum;
            YedaOrtography = ivhun.YedaOrtography;
            MilimBeheksherDiyuk = ivhun.MilimBeheksherDiyuk;
            MilimBodedotDiyuk = ivhun.MilimBodedotDiyuk;
            MilotTefelDiyuk = ivhun.MilotTefelDiyuk;
            ItzurimVetnuotDiyuk = ivhun.ItzurimVetnuotDiyuk;
            MilimBeheksherKetzev = ivhun.MilimBeheksherKetzev;
            MilimBodedotKetzev = ivhun.MilimBodedotKetzev;
            MilotTefelKetzev = ivhun.MilotTefelKetzev;
            ItzurimVetnuotKetzev = ivhun.ItzurimVetnuotKetzev;
            SikumTahaliheyKria = ivhun.SikumTahaliheyKria;
            IsHavanatHanikraEnabled = ivhun.IsHavanatHanikraEnabled;
            SikumHavanatHanikra = ivhun.SikumHavanatHanikra;
            IsHavanatHanishmaEnabled = ivhun.IsHavanatHanishmaEnabled;
            SikumHavanatHanishma = ivhun.SikumHavanatHanishma;
            IsKtivaEnabled = ivhun.IsKtivaEnabled;
            Ktav = ivhun.Ktav;
            Ktiv = ivhun.Ktiv;
            TshuvotLesheelotBezikaLetext = ivhun.TshuvotLesheelotBezikaLetext;
            HabaaBektav = ivhun.HabaaBektav;
            IsHabaBealpeEnabled = ivhun.IsHabaBealpeEnabled;
            SikumHabaBealpe = ivhun.SikumHabaBealpe;
            IsEranutMetaLeshonitEnabled = ivhun.IsEranutMetaLeshonitEnabled;
            MudautFonologit = ivhun.MudautFonologit;
            Ran = ivhun.Ran;
            ShetefMiluli = ivhun.ShetefMiluli;
            EranutMorfoTahbirit = ivhun.EranutMorfoTahbirit;
            EranutTahbirit = ivhun.EranutTahbirit;
            IsZikaronmMiluliEnabled = ivhun.IsZikaronmMiluliEnabled;
            Kidron = ivhun.Kidron;
            Rey = ivhun.Rey;
            Rey1 = ivhun.Rey1;
            Rey2 = ivhun.Rey2;
            Rey3 = ivhun.Rey3;
            Rey4 = ivhun.Rey4;
            Rey5 = ivhun.Rey5;
            Rey6 = ivhun.Rey6;
            Rey7 = ivhun.Rey7;
            Rey8 = ivhun.Rey8;
            Rey9 = ivhun.Rey9;
            ZikaronAvoda = ivhun.ZikaronAvoda;
            TifkudimNuhuliyim = ivhun.TifkudimNuhuliyim;
            ZikaronMiyadiShlifa = ivhun.ZikaronMiyadiShlifa;
            ZikaronMoshheShlifa = ivhun.ZikaronMoshheShlifa;
            KidudVehasmala = ivhun.KidudVehasmala;
            KimGame = ivhun.KimGame;
            KeshevHazuti = ivhun.KeshevHazuti;
            KetzevYahalom = ivhun.KetzevYahalom;
            DiyukYahalom = ivhun.DiyukYahalom;
            Ketzev592 = ivhun.Ketzev592;
            Diyuk592 = ivhun.Diyuk592;
            Sikum = ivhun.Sikum;
            Hamlazot = ivhun.Hamlazot;
            HatamotLedarkayHibahanut = ivhun.HatamotLedarkayHibahanut;
        }
                                       

        public int Id { get; set; }
        public Nullable<bool> ReadyToBeSent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Institue { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string Grade { get; set; }
        public string School { get; set; }
        public string Address { get; set; }
        public string ParentName { get; set; }
        public string ParentPhone { get; set; }
        public string ParentEmail { get; set; }
        public string Reason { get; set; }
        public string WhoSent { get; set; }
        public string Background { get; set; }
        public string OverallImpression { get; set; }
        public Nullable<bool> IsToniEnabled { get; set; }
        public Nullable<int> ToniRightAnswers { get; set; }
        public Nullable<bool> IsIptaEnabled { get; set; }
        public Nullable<int> IptaRightAnswers { get; set; }
        public Nullable<bool> IsGlanzEnabled { get; set; }
        public Nullable<int> GlanzNigudiyut { get; set; }
        public Nullable<int> GlanzNirdafot { get; set; }
        public Nullable<int> GlanzMahutiyot { get; set; }
        public Nullable<int> GlanzHagdara { get; set; }
        public Nullable<int> GlanzMiyun { get; set; }
        public Nullable<int> GlanzSivug { get; set; }
        public Nullable<int> GlanzPitgamim { get; set; }
        public Nullable<int> GlanzAnalogya { get; set; }
        public Nullable<int> GlanzHasakatMaskanot { get; set; }
        public string GlanzSikum { get; set; }
        public string YedaOrtography { get; set; }
        public Nullable<int> MilimBeheksherDiyuk { get; set; }
        public Nullable<int> MilimBodedotDiyuk { get; set; }
        public Nullable<int> MilotTefelDiyuk { get; set; }
        public Nullable<int> ItzurimVetnuotDiyuk { get; set; }
        public Nullable<int> MilimBeheksherKetzev { get; set; }
        public Nullable<int> MilimBodedotKetzev { get; set; }
        public Nullable<int> MilotTefelKetzev { get; set; }
        public Nullable<int> ItzurimVetnuotKetzev { get; set; }
        public string SikumTahaliheyKria { get; set; }
        public Nullable<bool> IsHavanatHanikraEnabled { get; set; }
        public string SikumHavanatHanikra { get; set; }
        public Nullable<bool> IsHavanatHanishmaEnabled { get; set; }
        public string SikumHavanatHanishma { get; set; }
        public Nullable<bool> IsKtivaEnabled { get; set; }
        public string Ktav { get; set; }
        public string Ktiv { get; set; }
        public string TshuvotLesheelotBezikaLetext { get; set; }
        public string HabaaBektav { get; set; }
        public Nullable<bool> IsHabaBealpeEnabled { get; set; }
        public string SikumHabaBealpe { get; set; }
        public Nullable<bool> IsEranutMetaLeshonitEnabled { get; set; }
        public string MudautFonologit { get; set; }
        public string Ran { get; set; }
        public string ShetefMiluli { get; set; }
        public string EranutMorfoTahbirit { get; set; }
        public string EranutTahbirit { get; set; }
        public Nullable<bool> IsZikaronmMiluliEnabled { get; set; }
        public string Kidron { get; set; }
        public string Rey { get; set; }
        public string Rey1 { get; set; }
        public string Rey2 { get; set; }
        public string Rey3 { get; set; }
        public string Rey4 { get; set; }
        public string Rey5 { get; set; }
        public string Rey6 { get; set; }
        public string Rey7 { get; set; }
        public string Rey8 { get; set; }
        public string Rey9 { get; set; }
        public string ZikaronAvoda { get; set; }
        public string TifkudimNuhuliyim { get; set; }
        public string ZikaronMiyadiShlifa { get; set; }
        public string ZikaronMoshheShlifa { get; set; }
        public string KidudVehasmala { get; set; }
        public string KimGame { get; set; }
        public string KeshevHazuti { get; set; }
        public string KetzevYahalom { get; set; }
        public string DiyukYahalom { get; set; }
        public string Ketzev592 { get; set; }
        public string Diyuk592 { get; set; }
        public string Sikum { get; set; }
        public string Hamlazot { get; set; }
        public string HatamotLedarkayHibahanut { get; set; }
    }
}
