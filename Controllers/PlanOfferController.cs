using PlanPaymentPage.Contracts;
using PlanPaymentPage.Model;
using PlanPaymentPage.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;



namespace PlanPaymentPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanOfferController : ControllerBase
    {
        private readonly IPlanOfferRepository _planofferRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;        
        private readonly IConfiguration _configuration;

        public PlanOfferController(IPlanOfferRepository planofferRepository, IWebHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _planofferRepository = planofferRepository;
            _hostingEnvironment = hostingEnvironment;            
            _configuration = configuration;
        }
        [HttpPost("GenerateOTP")]
        public async Task<IActionResult> GenerateOTP(PlanOtpModel model)
        {
            try
            {
                var encryptedResponse = await _planofferRepository.GenerateOTP(model);

                if (!string.IsNullOrEmpty(encryptedResponse))
                {
                    return Content(encryptedResponse, "application/json");
                }
                else
                {
                    return NotFound(new
                    {
                        ResultStatus = "Failed",
                        ResultMessage = "data not found.",
                        ResultCode = (int)HttpStatusCode.NotFound
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                });
            }
        }
        [HttpPost("ValidateOTP")]
        public async Task<IActionResult> ValidateOTP(PlanValidateOtpModel model)
        {
            try
            {
                var encryptedResponse = await _planofferRepository.ValidateOTP(model);

                if (!string.IsNullOrEmpty(encryptedResponse))
                {
                    return Content(encryptedResponse, "application/json");
                }
                else
                {
                    return NotFound(new
                    {
                        ResultStatus = "Failed",
                        ResultMessage = "data not found.",
                        ResultCode = (int)HttpStatusCode.NotFound
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                });
            }
        }
        [HttpPost("FetchLandingPageDetail")]
        public async Task<IActionResult> FetchLandingPageDetail(LandingPageRequest model)
        {
            try
            {
                var encryptedResponse = await _planofferRepository.FetchLandingPageDetail(model);

                if (!string.IsNullOrEmpty(encryptedResponse))
                {
                    return Content(encryptedResponse, "application/json");
                }
                else
                {
                    return NotFound(new
                    {
                        ResultStatus = "Failed",
                        ResultMessage = "data not found.",
                        ResultCode = (int)HttpStatusCode.NotFound
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                });
            }
        }
        [HttpPost("FetchPlanDetail")]
        public async Task<IActionResult> FetchPlanDetail(LandingPageRequest model)
        {
            try
            {
                var encryptedResponse = await _planofferRepository.FetchPlanDetail(model);

                if (!string.IsNullOrEmpty(encryptedResponse))
                {
                    return Content(encryptedResponse, "application/json");
                }
                else
                {
                    return NotFound(new
                    {
                        ResultStatus = "Failed",
                        ResultMessage = "Plan Detail not found.",
                        ResultCode = (int)HttpStatusCode.NotFound
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                });
            }
        }
        [HttpPost("FetchPassDetail")]
        public async Task<IActionResult> FetchPassDetail(MobileVerificationRequest model)
        {
            try
            {
                var encryptedResponse = await _planofferRepository.FetchPassDetail(model);

                if (!string.IsNullOrEmpty(encryptedResponse))
                {
                    return Content(encryptedResponse, "application/json");
                }
                else
                {
                    return NotFound(new
                    {
                        ResultStatus = "Failed",
                        ResultMessage = "data not found.",
                        ResultCode = (int)HttpStatusCode.NotFound
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                });
            }
        }
        [HttpPost("VaildatePromoCode")]
        public async Task<IActionResult> VaildatePromoCode(VaildatePromoCodeRequest model)
        {
            try
            {
                var encryptedResponse = await _planofferRepository.VaildatePromoCode(model);

                if (!string.IsNullOrEmpty(encryptedResponse))
                {
                    return Content(encryptedResponse, "application/json");
                }
                else
                {
                    return NotFound(new
                    {
                        ResultStatus = "Failed",
                        ResultMessage = "PromoCode not found.",
                        ResultCode = (int)HttpStatusCode.NotFound
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                });
            }
        }
        [HttpPost("SubmitPaymentFeedback")]
        public async Task<IActionResult> SubmitPaymentFeedback(SubmitPaymentFeedbackRequest model)
        {
            try
            {
                var encryptedResponse = await _planofferRepository.SubmitPaymentFeedback(model);

                if (!string.IsNullOrEmpty(encryptedResponse))
                {
                    return Content(encryptedResponse, "application/json");
                }
                else
                {
                    return NotFound(new
                    {
                        ResultStatus = "Failed",
                        ResultMessage = "data not found.",
                        ResultCode = (int)HttpStatusCode.NotFound
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                });
            }
        }
        [HttpPost("FetchPaymentFeedback")]
        public async Task<IActionResult> FetchPaymentFeedback(PlanValidateOtpModel model)
        {
            try
            {
                var encryptedResponse = await _planofferRepository.FetchPaymentFeedback(model);

                if (!string.IsNullOrEmpty(encryptedResponse))
                {
                    return Content(encryptedResponse, "application/json");
                }
                else
                {
                    return NotFound(new
                    {
                        ResultStatus = "Failed",
                        ResultMessage = "data not found.",
                        ResultCode = (int)HttpStatusCode.NotFound
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                });
            }
        }
        [HttpPost("TransactionAcknowledgment")]
        public async Task<IActionResult> TransactionAcknowledgment(TransactionAcknowledgmentRequest model)
        {
            try
            {
                var encryptedResponse = await _planofferRepository.TransactionAcknowledgment(model);

                if (!string.IsNullOrEmpty(encryptedResponse))
                {
                    return Content(encryptedResponse, "application/json");
                }
                else
                {
                    return NotFound(new
                    {
                        ResultStatus = "Failed",
                        ResultMessage = "data not found.",
                        ResultCode = (int)HttpStatusCode.NotFound
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                });
            }
        }

        [HttpPost("GenerateSubscriptionRequest")]
        public async Task<IActionResult> GenerateSubscriptionRequest(GenerateSubscriptionRequestModel model)
        {
            try
            {
                var encryptedResponse = await _planofferRepository.GenerateSubscriptionRequest(model);

                if (!string.IsNullOrEmpty(encryptedResponse))
                {
                    return Content(encryptedResponse, "application/json");
                }
                else
                {
                    return NotFound(new
                    {
                        ResultStatus = "Failed",
                        ResultMessage = "data not found.",
                        ResultCode = (int)HttpStatusCode.NotFound
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                });
            }
        }
        [HttpPost("ValidationToken")]
        public async Task<IActionResult> ValidationToken(PlanValidateOtpModel model)
        {
            try
            {
                var encryptedResponse = await _planofferRepository.ValidationToken(model);

                if (!string.IsNullOrEmpty(encryptedResponse))
                {
                    return Content(encryptedResponse, "application/json");
                }
                else
                {
                    return NotFound(new
                    {
                        ResultStatus = "Failed",
                        ResultMessage = "data not found.",
                        ResultCode = (int)HttpStatusCode.NotFound
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                });
            }
        }

        [HttpPost("CancelSubscription")]
        public async Task<IActionResult> CancelSubscription(CancelSubscriptionRequest model)
        {
            try
            {
                var encryptedResponse = await _planofferRepository.CancelSubscription(model);

                if (!string.IsNullOrEmpty(encryptedResponse))
                {
                    return Content(encryptedResponse, "application/json");
                }
                else
                {
                    return NotFound(new
                    {
                        ResultStatus = "Failed",
                        ResultMessage = "data not found.",
                        ResultCode = (int)HttpStatusCode.NotFound
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                });
            }
        }
        [HttpPost("GetAvailableCouponDetailsForSubscriber")]
        public async Task<IActionResult> GetAvailableCouponDetailsForSubscriber(PlanValidateOtpModel model)
        {
            try
            {
                var encryptedResponse = await _planofferRepository.GetAvailableCouponDetailsForSubscriber(model);

                if (!string.IsNullOrEmpty(encryptedResponse))
                {
                    return Content(encryptedResponse, "application/json");
                }
                else
                {
                    return NotFound(new
                    {
                        ResultStatus = "Failed",
                        ResultMessage = "data not found.",
                        ResultCode = (int)HttpStatusCode.NotFound
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                });
            }
        }
        [HttpGet("TestApi")]
        public async Task<IActionResult> TestApi()
        {
            try
            {       return Content("Api is Working");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                });
            }
        }
    }
}