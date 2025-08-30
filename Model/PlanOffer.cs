
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace PlanPaymentPage.Model
{
    public class PlanOffer
    {
        public string? LoginType { get; set; }
        public string? LoginId { get; set; }
        public int CountryCode { get; set; }
        public int? IsFromOutSide { get; set; }
        public string? UserType { get; set; }
        public string? ValidationCode { get; set; }

        public string? UserAgent { get; set; }
        public string? ProcessType { get; set; }
        public string? IPAddress { get; set; }
        public string? Source { get; set; }

        public deviceinfoo? DeviceInfo { get; set; }
    }


    public class PlanOtpModel
    {
        public string MobileNo { get; set; }
        public int CountryCode { get; set; }
        public string? Source { get; set; }
        public string? ProcessType { get; set; }
    }
    public class PlanValidateOtpModel
    {
        public string MobileNo { get; set; }
        public int? OTTSMSID { get; set; }
        public string? OTP { get; set; }
        public int? CountryCode { get; set; }
        public string? Source { get; set; }
        public string? ProcessType { get; set; }
        public string? BrowserDetail { get; set; }  
        public string? AuthToken { get; set; }

    }
    public class LandingPageRequest
    {
        public string MobileNo { get; set; }
        public int? OTTSmsID { get; set; }
        public string? LandingPageSlug { get; set; }
        public string? PlanCode { get; set; }
    }

    public class MobileVerificationRequest
    {
        public bool IsMobileVerified { get; set; }
        public string MobileNo { get; set; }
        public string PassCode { get; set; }
    }
    public class VaildatePromoCodeRequest
    {
        public string MobileNo { get; set; }
        public int? OTTSMSID { get; set; }
        public string PromoCode { get; set; }
        public string PaymentGateway { get; set; }
        public string SubscriptionPlanCode { get; set; }
        public string? Source { get; set; }
        public string? PromoCodeProvider { get; set; }
        public string? PromoCodeScratchCardNo { get; set; }
        public string? AuthToken { get; set; }
    }

    public class SubmitPaymentFeedbackRequest
    {
        public string MobileNo { get; set; }
        public int? OTTSMSID { get; set; }
        public string Code { get; set; }
        public string? Remarks { get; set; }
    }


    public class DiscountType
    {
        public string Type { get; set; }
        public decimal Value { get; set; }
    }

    public class SubscriptionParam
    {
        public string Key { get; set; }
    }

    public class deviceinfoo
    {
        public string? ip { get; set; }
        public string? useragent { get; set; }
    }

    public class SubsPGRequest
    {
        public string ReturnURL { get; set; }
        public deviceinfoo? DeviceInfo { get; set; }
    }

    public class TransactionAcknowledgmentRequest
    {
        public string MobileNo { get; set; }
        public int? OTTSMSID { get; set; }
        public string Source { get; set; }
        public string? OrderID { get; set; }
        public int Amount { get; set; }
        public string? Status { get; set; }
        public string? TransactionNo { get; set; }
        public string? PGMode { get; set; }
        public string? PGResponse { get; set; }
        public string PGSubscriptionID { get; set; }
        public string SubscriptionPlanCode { get; set; }
        public bool AutoRenewalStatus { get; set; }
        public string? AuthToken { get; set; }
    }
    public class GenerateSubscriptionRequestModel
    {
        public string MobileNo { get; set; }
        public int? OTTSMSID { get; set; }
        public string Source { get; set; }
        public string SubscriptionPlanCode { get; set; }
        public int SubscriptionAmount { get; set; }
        public int TransactionAmount { get; set; }
        public int Discount { get; set; }
        public string SubscriptionPlanType { get; set; }
        public string PromoCode { get; set; }
        public string PromoCodeProvider { get; set; }
        public string SubcriptionMode { get; set; }
        public string RequestMode { get; set; }
        public string TransactionType { get; set; }
        public bool AutoRenewalStatus { get; set; }
        //public int Iscouponvalidated { get; set; }
        //public int IsWalletBalanceisUsed { get; set; }
        //public DiscountType DiscountType { get; set; }
        //public decimal DTHBalanceAmount { get; set; }
        //public SubscriptionParam SubscriptionParam { get; set; }
        public SubsPGRequest SubsPGRequest { get; set; }
        public string PromoCodeScratchCardNo { get; set; }
        public string? Remarks { get; set; }
        public string BrowserDetails { get; set; }
        public string? AuthToken { get; set; }
    }

    public class CancelSubscriptionRequest
    {
        public string MobileNo { get; set; }
        public string Source { get; set; }
        public string PGMode { get; set; }
        public string PGSubscriptionID { get; set; }
        public string PlanType { get; set; }
        public string SubscriptionPlanCode { get; set; }
        public int OTTSMSID { get; set; }
        public string ReturnUrl { get; set; }
        public string? AuthToken { get; set; }
    }

}