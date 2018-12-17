namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ivhunim")]
    public partial class Ivhunim
    {
        public int Id { get; set; }

        [StringLength(15)]
        public string Tz { get; set; }

        public bool? ReadyToBeSent { get; set; }

        [StringLength(500)]
        public string FirstName { get; set; }

        [StringLength(500)]
        public string LastName { get; set; }

        [StringLength(500)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Institue { get; set; }

        [StringLength(500)]
        public string BirthDate { get; set; }

        [StringLength(500)]
        public string Gender { get; set; }

        [StringLength(500)]
        public string Grade { get; set; }

        [StringLength(500)]
        public string School { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(500)]
        public string ParentName { get; set; }

        [StringLength(500)]
        public string ParentPhone { get; set; }

        [StringLength(500)]
        public string ParentEmail { get; set; }

        public string Reason { get; set; }

        [StringLength(500)]
        public string WhoSent { get; set; }

        public string Background { get; set; }

        public string OverallImpression { get; set; }

        public bool? IsToniEnabled { get; set; }

        public int? ToniRightAnswers { get; set; }

        public bool? IsIptaEnabled { get; set; }

        public int? IptaRightAnswers { get; set; }

        public bool? IsGlanzEnabled { get; set; }

        public int? GlanzNigudiyut { get; set; }

        public int? GlanzNirdafot { get; set; }

        public int? GlanzMahutiyot { get; set; }

        public int? GlanzHagdara { get; set; }

        public int? GlanzMiyun { get; set; }

        public int? GlanzSivug { get; set; }

        public int? GlanzPitgamim { get; set; }

        public int? GlanzAnalogya { get; set; }

        public int? GlanzHasakatMaskanot { get; set; }

        public string GlanzSikum { get; set; }

        [StringLength(250)]
        public string YedaOrtography { get; set; }

        public int? MilimBeheksherDiyuk { get; set; }

        public int? MilimBodedotDiyuk { get; set; }

        public int? MilotTefelDiyuk { get; set; }

        public int? ItzurimVetnuotDiyuk { get; set; }

        public int? MilimBeheksherKetzev { get; set; }

        public int? MilimBodedotKetzev { get; set; }

        public int? MilotTefelKetzev { get; set; }

        public int? ItzurimVetnuotKetzev { get; set; }

        public string SikumTahaliheyKria { get; set; }

        public bool? IsHavanatHanikraEnabled { get; set; }

        public string SikumHavanatHanikra { get; set; }

        public bool? IsHavanatHanishmaEnabled { get; set; }

        public string SikumHavanatHanishma { get; set; }

        public bool? IsKtivaEnabled { get; set; }

        [StringLength(500)]
        public string Ktav { get; set; }

        [StringLength(500)]
        public string Ktiv { get; set; }

        public string TshuvotLesheelotBezikaLetext { get; set; }

        public string HabaaBektav { get; set; }

        public bool? IsHabaBealpeEnabled { get; set; }

        public string SikumHabaBealpe { get; set; }

        public bool? IsEranutMetaLeshonitEnabled { get; set; }

        [StringLength(500)]
        public string MudautFonologit { get; set; }

        [StringLength(500)]
        public string Ran { get; set; }

        [StringLength(500)]
        public string ShetefMiluli { get; set; }

        [StringLength(500)]
        public string EranutMorfoTahbirit { get; set; }

        [StringLength(500)]
        public string EranutTahbirit { get; set; }

        public bool? IsZikaronmMiluliEnabled { get; set; }

        [StringLength(500)]
        public string Kidron { get; set; }

        [StringLength(500)]
        public string Rey { get; set; }

        [StringLength(500)]
        public string Rey1 { get; set; }

        [StringLength(500)]
        public string Rey2 { get; set; }

        [StringLength(500)]
        public string Rey3 { get; set; }

        [StringLength(500)]
        public string Rey4 { get; set; }

        [StringLength(500)]
        public string Rey5 { get; set; }

        [StringLength(500)]
        public string Rey6 { get; set; }

        [StringLength(500)]
        public string Rey7 { get; set; }

        [StringLength(500)]
        public string Rey8 { get; set; }

        [StringLength(500)]
        public string Rey9 { get; set; }

        [StringLength(500)]
        public string ZikaronAvoda { get; set; }

        [StringLength(500)]
        public string TifkudimNuhuliyim { get; set; }

        [StringLength(500)]
        public string ZikaronMiyadiShlifa { get; set; }

        [StringLength(500)]
        public string ZikaronMoshheShlifa { get; set; }

        [StringLength(500)]
        public string KidudVehasmala { get; set; }

        [StringLength(500)]
        public string KimGame { get; set; }

        [StringLength(500)]
        public string KeshevHazuti { get; set; }

        [StringLength(500)]
        public string KetzevYahalom { get; set; }

        [StringLength(500)]
        public string DiyukYahalom { get; set; }

        [StringLength(500)]
        public string Ketzev592 { get; set; }

        [StringLength(500)]
        public string Diyuk592 { get; set; }

        public string Sikum { get; set; }

        public string Hamlazot { get; set; }

        public string HatamotLedarkayHibahanut { get; set; }
    }
}
