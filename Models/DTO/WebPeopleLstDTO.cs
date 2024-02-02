namespace AppCeramicProAng.Models.DTO
{
    public class WebPeopleLstDTO
    {
        public long PeopleID { get; set; } = 0;
        public string? PeFirstName { get; set; } = string.Empty;
        public string? PeLastName { get; set; } = string.Empty;
        public string? PeDateOfBirth { get; set; } = string.Empty;
        public bool PeStatus { get; set; } = false;
        public string? PeRDate { get; set; } = string.Empty;
        public string? PeStreet { get; set; } = string.Empty;
        public string? PeOutsideCode { get; set; } = string.Empty;
        public string? PeInsideCode { get; set; } = string.Empty;
        public string? PeCP { get; set; } = string.Empty;
        public long? SettlementID { get; set; } = 0;
        public string FullName()
        {
            return $"{PeFirstName} {PeLastName}";
        }
    }
}