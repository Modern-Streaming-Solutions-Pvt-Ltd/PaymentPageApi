
using System;
using System.Data;
using System.Net;
using PlanPaymentPage.Contracts;
using PlanPaymentPage.Model;
using System.Security.Cryptography;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace PlanPaymentPage.Repository
{
    public class PlanOfferRepository : IPlanOfferRepository
    {

        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        

        public PlanOfferRepository(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GenerateOTP(PlanOtpModel model)
        {
            try
            {
                var ipAddress = _httpContextAccessor?.HttpContext?.Request?.Headers["X-Forwarded-For"].FirstOrDefault()
                    ?? _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "";
                var userAgent = _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"].ToString() ?? "APP";

                var data = new
                {
                    MobileNo = model.MobileNo,
                    CountryCode = model.CountryCode,
                    Source = model.Source,
                    ProcessType = model.ProcessType,
                    ClientIP = ipAddress
                };

                string json = JsonConvert.SerializeObject(data);
                string encryptedData = EncryptString(json, _configuration["Secretkey"], _configuration["EncKey"]);
                var responseContent = await GenerateVerificationCodeForLoginAsync(encryptedData, _configuration, "GenerateOTP");
                string decryptedResponse = DecryptString(responseContent, _configuration["Secretkey"], _configuration["EncKey"]);

                return decryptedResponse;
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                };
                return JsonConvert.SerializeObject(errorResponse);
            }
        }
        public async Task<string> ValidateOTP(PlanValidateOtpModel model)
        {
            try
            {
                var ipAddress = _httpContextAccessor?.HttpContext?.Request?.Headers["X-Forwarded-For"].FirstOrDefault()
                    ?? _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "";
                var userAgent = _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"].ToString() ?? "APP";

                var data = new
                {
                    MobileNo = model.MobileNo,
                    OTTSMSID = model.OTTSMSID,
                    OTP = model.OTP,
                    CountryCode = model.CountryCode,
                    Source = model.Source,
                    ProcessType = model.ProcessType,
                    ClientIP = ipAddress
                };


                string json = JsonConvert.SerializeObject(data);
                string encryptedData = EncryptString(json, _configuration["Secretkey"], _configuration["EncKey"]);
                var responseContent = await GenerateVerificationCodeForLoginAsync(encryptedData, _configuration, "ValidateOTP");
                string decryptedResponse = DecryptString(responseContent, _configuration["Secretkey"], _configuration["EncKey"]);

                return decryptedResponse;
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                };
                return JsonConvert.SerializeObject(errorResponse);
            }
        }
        public async Task<string> FetchLandingPageDetail(LandingPageRequest model)
        {
            try
            {
                var ipAddress = _httpContextAccessor?.HttpContext?.Request?.Headers["X-Forwarded-For"].FirstOrDefault()
                    ?? _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "";
                var userAgent = _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"].ToString() ?? "APP";

                var data = new
                {
                    MobileNo = model.MobileNo,
                    OTTSmsID = model.OTTSmsID,
                    IPAddress = ipAddress,
                    UserAgent = userAgent,
                    LandingPageSlug = model.LandingPageSlug
                };



                string json = JsonConvert.SerializeObject(data);
                string encryptedData = EncryptString(json, _configuration["Secretkey"], _configuration["EncKey"]);
                var responseContent = await GenerateVerificationCodeForLoginAsync(encryptedData, _configuration, "FetchLandingPageDetail");
                string decryptedResponse = DecryptString(responseContent, _configuration["Secretkey"], _configuration["EncKey"]);

                return decryptedResponse;
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                };
                return JsonConvert.SerializeObject(errorResponse);
            }
        }
        public async Task<string> FetchPlanDetail(LandingPageRequest model)
        {
            try
            {
                var ipAddress = _httpContextAccessor?.HttpContext?.Request?.Headers["X-Forwarded-For"].FirstOrDefault()
                    ?? _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "";
                var userAgent = _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"].ToString() ?? "APP";

                var data = new
                {
                    MobileNo = model.MobileNo,
                    OTTSmsID = model.OTTSmsID,
                    IPAddress = ipAddress,
                    UserAgent = userAgent,
                    PlanCode = model.PlanCode
                };



                string json = JsonConvert.SerializeObject(data);
                string encryptedData = EncryptString(json, _configuration["Secretkey"], _configuration["EncKey"]);
                var responseContent = await GenerateVerificationCodeForLoginAsync(encryptedData, _configuration, "FetchPlanDetail");
                string decryptedResponse = DecryptString(responseContent, _configuration["Secretkey"], _configuration["EncKey"]);

                return decryptedResponse;
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                };
                return JsonConvert.SerializeObject(errorResponse);
            }
        }
        public async Task<string> FetchPassDetail(MobileVerificationRequest model)
        {
            try
            {
                var ipAddress = _httpContextAccessor?.HttpContext?.Request?.Headers["X-Forwarded-For"].FirstOrDefault()
                    ?? _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "";
                var userAgent = _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"].ToString() ?? "APP";

                var data = new
                {
                    IsMobileVerified = model.IsMobileVerified,
                    MobileNo = model.MobileNo,
                    PassCode = model.PassCode
                };



                string json = JsonConvert.SerializeObject(data);
                string encryptedData = EncryptString(json, _configuration["Secretkey"], _configuration["EncKey"]);
                var responseContent = await GenerateVerificationCodeForLoginAsync(encryptedData, _configuration, "FetchPassDetail");
                string decryptedResponse = DecryptString(responseContent, _configuration["Secretkey"], _configuration["EncKey"]);

                return decryptedResponse;
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                };
                return JsonConvert.SerializeObject(errorResponse);
            }
        }

        public async Task<string> VaildatePromoCode(VaildatePromoCodeRequest model)
        {
            try
            {
                var ipAddress = _httpContextAccessor?.HttpContext?.Request?.Headers["X-Forwarded-For"].FirstOrDefault()
                    ?? _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "";
                var userAgent = _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"].ToString() ?? "APP";

                var data = new
                {
                    MobileNo = model.MobileNo,
                    OTTSMSID = model.OTTSMSID,
                    Source = model.Source,
                    PromoCode = model.PromoCode,
                    PaymentGateway = model.PaymentGateway,
                    SubscriptionPlanCode = model.SubscriptionPlanCode,
                    PromoCodeProvider = model.PromoCodeProvider,
                    PromoCodeScratchCardNo = model.PromoCodeScratchCardNo
                };




                string json = JsonConvert.SerializeObject(data);
                string encryptedData = EncryptString(json, _configuration["Secretkey"], _configuration["EncKey"]);
                var responseContent = await GenerateVerificationCodeForLoginAsync(encryptedData, _configuration, "VaildatePromoCode", model.AuthToken);
                string decryptedResponse = DecryptString(responseContent, _configuration["Secretkey"], _configuration["EncKey"]);

                return decryptedResponse;
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                };
                return JsonConvert.SerializeObject(errorResponse);
            }
        }
        public async Task<string> SubmitPaymentFeedback(SubmitPaymentFeedbackRequest model)
        {
            try
            {
                var ipAddress = _httpContextAccessor?.HttpContext?.Request?.Headers["X-Forwarded-For"].FirstOrDefault()
                    ?? _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "";
                var userAgent = _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"].ToString() ?? "APP";

                var data = new
                {
                    MobileNo = model.MobileNo,
                    OTTSMSID = model.OTTSMSID,
                    IPAddress = ipAddress,
                    UserAgent = userAgent,
                    Code = model.Code,
                    Remarks = model.Remarks
                };





                string json = JsonConvert.SerializeObject(data);
                string encryptedData = EncryptString(json, _configuration["Secretkey"], _configuration["EncKey"]);
                var responseContent = await GenerateVerificationCodeForLoginAsync(encryptedData, _configuration, "SubmitPaymentFeedback");
                string decryptedResponse = DecryptString(responseContent, _configuration["Secretkey"], _configuration["EncKey"]);

                return decryptedResponse;
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                };
                return JsonConvert.SerializeObject(errorResponse);
            }
        }
        public async Task<string> FetchPaymentFeedback(PlanValidateOtpModel model)
        {
            try
            {
                var ipAddress = _httpContextAccessor?.HttpContext?.Request?.Headers["X-Forwarded-For"].FirstOrDefault()
                    ?? _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "";
                var userAgent = _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"].ToString() ?? "APP";

                var data = new
                {
                    MobileNo = model.MobileNo,
                    OTTSMSID = model.OTTSMSID
                };
                string json = JsonConvert.SerializeObject(data);
                string encryptedData = EncryptString(json, _configuration["Secretkey"], _configuration["EncKey"]);
                var responseContent = await GenerateVerificationCodeForLoginAsync(encryptedData, _configuration, "FetchPaymentFeedback", model.AuthToken);
                string decryptedResponse = DecryptString(responseContent, _configuration["Secretkey"], _configuration["EncKey"]);

                return decryptedResponse;
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                };
                return JsonConvert.SerializeObject(errorResponse);
            }
        }
        public async Task<string> TransactionAcknowledgment(TransactionAcknowledgmentRequest model)
        {
            try
            {
                var ipAddress = _httpContextAccessor?.HttpContext?.Request?.Headers["X-Forwarded-For"].FirstOrDefault()
                    ?? _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "";
                var userAgent = _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"].ToString() ?? "APP";

                var data = new
                {

                    MobileNo = model.MobileNo,
                    OTTSMSID = model.OTTSMSID,
                    Source = model.Source,
                    OrderID = model.OrderID,
                    Amount = model.Amount,
                    Status = model.Status,
                    TransactionNo = model.TransactionNo,
                    PGMode = model.PGMode,
                    PGResponse = model.PGResponse,
                    PGSubscriptionID = model.PGSubscriptionID,
                    AutoRenewalStatus = model.AutoRenewalStatus,
                    SubscriptionPlanCode = model.SubscriptionPlanCode
                };

                string json = JsonConvert.SerializeObject(data);
                string encryptedData = EncryptString(json, _configuration["Secretkey"], _configuration["EncKey"]);
                var responseContent = await GenerateVerificationCodeForLoginAsync(encryptedData, _configuration, "TransactionAcknowledgment", model.AuthToken);
                string decryptedResponse = DecryptString(responseContent, _configuration["Secretkey"], _configuration["EncKey"]);

                return decryptedResponse;
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                };
                return JsonConvert.SerializeObject(errorResponse);
            }
        }
        public async Task<string> GenerateSubscriptionRequest(GenerateSubscriptionRequestModel model)
        {
            try
            {
                var ipAddress = _httpContextAccessor?.HttpContext?.Request?.Headers["X-Forwarded-For"].FirstOrDefault()
                    ?? _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "";
                var userAgent = _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"].ToString() ?? "APP";
                model.SubsPGRequest.DeviceInfo = new deviceinfoo
                {
                    ip = ipAddress,
                    useragent = userAgent
                };
                //if (string.IsNullOrEmpty(userAgent))
                //    return "APP";  // fallback for mobile app or no UA
                //var parser = Parser.GetDefault();
                //ClientInfo clientInfo = parser.Parse(userAgent);
               ///model.BrowserDetails = model.BrowserDetails + " || " + userAgent;
                var data = new
                {

                    MobileNo = model.MobileNo,
                    OTTSMSID = model.OTTSMSID,
                    Source = model.Source,
                    SubscriptionPlanCode = model.SubscriptionPlanCode,
                    IPAddress = ipAddress,
                    UserAgent = userAgent,
                    SubscriptionAmount = model.SubscriptionAmount,
                    TransactionAmount = model.TransactionAmount,
                    Discount = model.Discount,
                    SubscriptionPlanType = model.SubscriptionPlanType,
                    PromoCode = model.PromoCode,
                    PromoCodeProvider = model.PromoCodeProvider,
                    SubcriptionMode = model.SubcriptionMode,
                    RequestMode = model.RequestMode,
                    TransactionType = model.TransactionType,
                    AutoRenewalStatus = model.AutoRenewalStatus,                    
                    SubsPGRequest = model.SubsPGRequest,
                    PromoCodeScratchCardNo = model.PromoCodeScratchCardNo,
                    Remarks = model.Remarks,
                    BrowserDetails = model.BrowserDetails
                };

                string json = JsonConvert.SerializeObject(data);
                string encryptedData = EncryptString(json, _configuration["Secretkey"], _configuration["EncKey"]);
                var responseContent = await GenerateVerificationCodeForLoginAsync(encryptedData, _configuration, "GenerateSubscriptionRequest", model.AuthToken);
                string decryptedResponse = DecryptString(responseContent, _configuration["Secretkey"], _configuration["EncKey"]);

                return decryptedResponse;
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                };
                return JsonConvert.SerializeObject(errorResponse);
            }
        }
        public async Task<string> ValidationToken(PlanValidateOtpModel model)
        {
            try
            {
                var ipAddress = _httpContextAccessor?.HttpContext?.Request?.Headers["X-Forwarded-For"].FirstOrDefault()
                    ?? _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "";
                var userAgent = _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"].ToString() ?? "APP";
                var data = new
                {

                    MobileNo = model.MobileNo,
                    OTTSMSID = model.OTTSMSID,
                    Source = model.Source,
                    BrowserDetail=model.BrowserDetail,
                    AuthToken=model.AuthToken
                };

                string json = JsonConvert.SerializeObject(data);
                string encryptedData = EncryptString(json, _configuration["Secretkey"], _configuration["EncKey"]);
                var responseContent = await GenerateVerificationCodeForLoginAsync(encryptedData, _configuration, "ValidationToken", model.AuthToken);
                string decryptedResponse = DecryptString(responseContent, _configuration["Secretkey"], _configuration["EncKey"]);

                return decryptedResponse;
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                };
                return JsonConvert.SerializeObject(errorResponse);
            }
        }
        public async Task<string> CancelSubscription(CancelSubscriptionRequest model)
        {
            try
            {
                var ipAddress = _httpContextAccessor?.HttpContext?.Request?.Headers["X-Forwarded-For"].FirstOrDefault()
                    ?? _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "";
                var userAgent = _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"].ToString() ?? "APP";
                var data = new
                {
                    MobileNo = model.MobileNo,
                    Source = model.Source,
                    PGMode = model.PGMode,
                    PGSubscriptionID = model.PGSubscriptionID,
                    PlanType = model.PlanType,
                    SubscriptionPlanCode = model.SubscriptionPlanCode,
                    OTTSMSID = model.OTTSMSID,
                    ReturnUrl = model.ReturnUrl
                };


                string json = JsonConvert.SerializeObject(data);
                string encryptedData = EncryptString(json, _configuration["Secretkey"], _configuration["EncKey"]);
                var responseContent = await GenerateVerificationCodeForLoginAsync(encryptedData, _configuration, "CancelSubscription",model.AuthToken);
                string decryptedResponse = DecryptString(responseContent, _configuration["Secretkey"], _configuration["EncKey"]);

                return decryptedResponse;
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                };
                return JsonConvert.SerializeObject(errorResponse);
            }
        }

        public async Task<string> GetAvailableCouponDetailsForSubscriber(PlanValidateOtpModel model)
        {
            try
            {
                var ipAddress = _httpContextAccessor?.HttpContext?.Request?.Headers["X-Forwarded-For"].FirstOrDefault()
                    ?? _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "";
                var userAgent = _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"].ToString() ?? "APP";
                var data = new
                {
                    MobileNo = model.MobileNo,
                    Source = model.Source,
                    OTTSMSID = model.OTTSMSID                 
                };


                string json = JsonConvert.SerializeObject(data);
                string encryptedData = EncryptString(json, _configuration["Secretkey"], _configuration["EncKey"]);
                var responseContent = await GenerateVerificationCodeForLoginAsync(encryptedData, _configuration, "GetAvailableCouponDetailsForSubscriber",model.AuthToken);
                string decryptedResponse = DecryptString(responseContent, _configuration["Secretkey"], _configuration["EncKey"]);

                return decryptedResponse;
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    ResultStatus = "Error",
                    ResultMessage = ex.Message,
                    ResultCode = (int)HttpStatusCode.InternalServerError
                };
                return JsonConvert.SerializeObject(errorResponse);
            }
        }
        public static async Task<string> GenerateVerificationCodeForLoginAsync(string inputParam, IConfiguration configuration, string ApiUrl, String Authtoken = null)
        {
            string _ClientKey = configuration["_ClientKey"].ToString();
            string _Apiurl = configuration["_ApiurlPlanOffer"].ToString() + ApiUrl;
            //var handler = new HttpClientHandler
            //{
            //    ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            //};
            //using (var client = new HttpClient(handler))
            using (var client = new HttpClient())
            {
                // Set headers
                client.DefaultRequestHeaders.Add("ClientKey", _ClientKey);
                if (Authtoken != null)
                {
                    Authtoken = "Bearer " + Authtoken;
                    client.DefaultRequestHeaders.Add("Authorization", Authtoken);
                }
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // Prepare the content
                var bodyContent = $@"{{""InputParam"":""{inputParam}""}}";
                var content = new StringContent(bodyContent, Encoding.UTF8, "application/json");
                // Send the POST request
                var response = await client.PostAsync(_Apiurl, content);
                response.EnsureSuccessStatusCode();
                // Read and return the response content
                return await response.Content.ReadAsStringAsync();
            }
        }
        public static Aes GetEncryptionAlgorithm(string Secretkey, string Encryptionkey)
        {
            Aes aes;
            try
            {
                byte[] passBytes = Encoding.UTF8.GetBytes(Convert.ToString(Secretkey));
                byte[] saltBytes = Encoding.UTF8.GetBytes(Convert.ToString(Encryptionkey));
                var key = new Rfc2898DeriveBytes(passBytes, saltBytes, 1000, HashAlgorithmName.SHA256);
                aes = Aes.Create();
                aes.KeySize = 256;
                aes.Key = key.GetBytes(aes.KeySize / 8);
                aes.IV = key.GetBytes(aes.BlockSize / 8);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
            return aes;
        }
        public static string EncryptString(string cipherText, string Secretkey, string Encryptionkey)
        {
            string encryptedstring = string.Empty;
            MemoryStream responseStream = new MemoryStream();
            byte[] buffer = Encoding.UTF8.GetBytes(cipherText);
            CryptoStream cryptoStream;
            try
            {
                Aes aes = GetEncryptionAlgorithm(Secretkey, Encryptionkey);
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                cryptoStream = new CryptoStream(responseStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(buffer, 0, buffer.Length);
                cryptoStream.FlushFinalBlock();
                cryptoStream.Close();
                encryptedstring = Convert.ToBase64String(responseStream.ToArray());
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return encryptedstring;
        }



        public static string DecryptString(string cipherText, string Secretkey, string Encryptionkey)
        {
            try
            {
                Aes aes = GetEncryptionAlgorithm(Secretkey, Encryptionkey);
                byte[] buffer = Convert.FromBase64String(cipherText);

                MemoryStream memoryStream = new MemoryStream(buffer);
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                StreamReader streamReader = new StreamReader(cryptoStream);
                return streamReader.ReadToEnd();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
    }
}