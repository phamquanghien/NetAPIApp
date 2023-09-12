using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetAPIApp.Models
{
    public class DaiLy
    {
        [Key]
        public string MaDaiLy { get; set; }
        public string TenDaiLy { get; set; }
        public string DaiChi { get; set; }
        public string NguoiDaiDien { get; set; }
        public string DienThoai { get; set; }
        [ForeignKey("MaHTPP")]
        public string MaHTPP { get; set; }
        public HeThongPhanPhoi? HeThongPhanPhoi {get; set;}
    }
}