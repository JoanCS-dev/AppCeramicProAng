namespace AppCeramicProAng.Models.DTO
{
    public class WebPeopleDTO
    {
        public long PeopleID { get; set; } = 0;
        public string? PeFirstName { get; set; } = string.Empty;
        public string? PeLastName { get; set; } = string.Empty;
        public string FullName()
        {
            return $"{PeFirstName} {PeLastName}";
        }
    }
}