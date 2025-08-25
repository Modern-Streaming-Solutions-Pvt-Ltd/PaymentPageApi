
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using PlanPaymentPage.Model;
using System.Threading.Tasks;
//using static PlanPaymentPage.Model.Content;
//using static PlanPaymentPage.Model.GetCategoriesResponse;

namespace PlanPaymentPage.Contracts
{
    public interface IPlanOfferRepository
    {
        Task<string> GenerateOTP(PlanOtpModel model);
        Task<string> ValidateOTP(PlanValidateOtpModel model);
        Task<string> FetchLandingPageDetail(LandingPageRequest model);
        Task<string> FetchPlanDetail(LandingPageRequest model);
        Task<string> FetchPassDetail(MobileVerificationRequest model);
        Task<string> VaildatePromoCode(VaildatePromoCodeRequest model);
        Task<string> SubmitPaymentFeedback(SubmitPaymentFeedbackRequest model);
        Task<string> FetchPaymentFeedback(PlanValidateOtpModel model);
        Task<string> TransactionAcknowledgment(TransactionAcknowledgmentRequest model);
        Task<string> GenerateSubscriptionRequest(GenerateSubscriptionRequestModel model);
    }
}