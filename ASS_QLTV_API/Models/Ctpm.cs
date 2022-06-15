using System;
using System.Collections.Generic;

#nullable disable

namespace ASS_QLTV_API.Models
{
    public partial class Ctpm
    {
        public string MaCtpm { get; set; }
        public string MaPm { get; set; }
        public string MaSach { get; set; }
        public DateTime? NgayTra { get; set; }
        public int TinhTrangSach { get; set; }
        public int? TinhTrangTra { get; set; }
        public string User { get; set; }
        public string GhiChu { get; set; }
        public double? TienPhat { get; set; }

        public virtual Phieumuon MaPmNavigation { get; set; }
        public virtual Sach MaSachNavigation { get; set; }
        public virtual Taikhoan UserNavigation { get; set; }
    }
}
