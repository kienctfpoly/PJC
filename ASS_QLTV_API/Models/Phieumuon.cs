using System;
using System.Collections.Generic;

#nullable disable

namespace ASS_QLTV_API.Models
{
    public partial class Phieumuon
    {
        public Phieumuon()
        {
            Ctpms = new HashSet<Ctpm>();
        }

        public string MaPm { get; set; }
        public string MaDg { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayHenTra { get; set; }
        public int SoLuongMuon { get; set; }
        public string User { get; set; }

        public virtual Docgium MaDgNavigation { get; set; }
        public virtual Taikhoan UserNavigation { get; set; }
        public virtual ICollection<Ctpm> Ctpms { get; set; }
    }
}
