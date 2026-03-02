namespace TalentApi.Models
{
    public class TalentInfo
    {
        public string TalentID { get; set; } = string.Empty;
        public string TalentName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public bool Sex { get; set; }
        public string? Phone { get; set; }
        public string? MobilePhone { get; set; }
        public string? WorkAreas { get; set; }
        public string? Skills { get; set; }
        public bool Status { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
