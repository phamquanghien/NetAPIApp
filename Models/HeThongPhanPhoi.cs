using System.ComponentModel.DataAnnotations;

namespace NetAPIApp.Models
{
    public class HeThongPhanPhoi
    {
        [Key]
        public string MaHTPP { get; set; }
        public string TenHTPT { get; set; }
    }
}