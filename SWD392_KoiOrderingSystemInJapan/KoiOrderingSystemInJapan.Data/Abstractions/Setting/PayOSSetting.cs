namespace KoiOrderingSystemInJapan.Data.Abstractions.Setting;

public class PayOSSetting
{
    public const string SectionName = "PayOSConfiguration";
    public string ClientId { get; set; }
    public string ApiKey { get; set; }
    public string ChecksumKey { get; set; }
    public string SuccessUrl { get; set; }
    public string ErrorUrl { get; set; }
}
