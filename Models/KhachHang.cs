using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.Models
{
    public partial class KhachHang
    {
        public int MaKh { get; set; }
        public string TenKh { get; set; }
        public string SoDt { get; set; }
        public string DiaChi { get; set; }
        public DateTime Birthday { get; set; }
    }
}
