namespace AppCeramicProAng.Models.DTO
{
    public class WebAccountLstDTO
    {
        public long AccountID { get; set; } = 0;
        public string? AcUser { get; set; } = string.Empty;
        public string? AcPassword { get; set; } = string.Empty;
        public string? AcEmailAddress { get; set; } = string.Empty;
        public string? AcPhoneNumber { get; set; } = string.Empty;
        public bool AcVerifyEmail { get; set; } = false;
        public string? AcStatus { get; set; } = string.Empty;
        public string? AcRDate { get; set; } = "";
        public string? Token { get; set; } = "";
        public long PeopleID { get; set; } = 0;
        public long ProfileID { get; set; } = 0;
        public WebPeopleDTO? PeopleVM { get; set; }
        public WebProfileDTO? ProfileVM { get; set; }
    }
}