namespace AppCeramicProAng.Models.DTO
{
    public class WebQuotesDTO
    {
        public long QuotesID { get; set; } = 0;
        public long ServicePriceID { get; set; } = 0;
        public long ColorID { get; set; } = 0;
        public string ServiceDesc { get; set; } = string.Empty;
        public string ColorName { get; set; } = string.Empty;
        public string QuotesSTS { get; set; } = string.Empty;
        public long QuoteHoursID { get; set; } = 0;
        public long AccountID { get; set; } = 0;
        public long VehicleModelID { get; set; } = 0;
    }
}