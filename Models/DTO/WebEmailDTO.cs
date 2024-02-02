namespace AppCeramicProAng.Models.DTO
{
    public class WebEmailDTO
    {
        public long EmailID { get; set; }
        public string? EmSubject { get; set; } = string.Empty;
        public string? EmBody { get; set; } = string.Empty;
        public string? EmEmail { get; set; } = string.Empty;
        public string? EmPassword { get; set; } = string.Empty;
        public bool EmEnviarSts { get; set; }
        public string? EmEnviarEmail { get; set; } = string.Empty;
        public string? EmEmailCC { get; set; } = string.Empty;
        public string? EmSTS { get; set; } = string.Empty;
    }
}