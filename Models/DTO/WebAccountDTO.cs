namespace AppCeramicProAng.Models.DTO
{
    public class WebAccountDTO
    {
        public long AccountID { get; set; } = 0;
        public string? AcUser { get; set; } = string.Empty;
        public string? AcPassword { get; set; } = string.Empty;
        public string? AcPhoneNumber { get; set; } = string.Empty;
        public string? Token { get; set; } = "";
        public long PeopleID { get; set; } = 0;
        public long ProfileID { get; set; } = 0;
        public WebPeopleDTO? PeopleVM { get; set; }
    }
}