using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BanCaPhe
{
    internal class NhanVien
    {
        private string iD;
        private string hoTen;
        private DateTime ngaySinh;
        private string sĐT;
        private DateTime ngayVaoLam;
        private string viTriLamViec;
        private string gioiTinh;

        public NhanVien()
        {
            this.iD = null;
            this.hoTen = null;
            this.ngaySinh=System.DateTime.Now;
            this.sĐT = null;
            this.ngayVaoLam = System.DateTime.Now;
            this.viTriLamViec = null;
            this.gioiTinh = null;

        }
        public NhanVien(string iD, string hoTen, DateTime ngaySinh, string sĐT,DateTime ngayVaoLam, string viTriLamViec,string gioiTinh)
        {
            this.iD = iD;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.ngayVaoLam = ngayVaoLam;
            this.sĐT = sĐT;
            this.viTriLamViec = viTriLamViec;
            this.gioiTinh=gioiTinh;
        }
        public string ID
        {
            get { return this.iD; }
            set { this.iD = value; }
        }
        public string HoTen
        {
            get { return this.hoTen; }
            set { this.hoTen = value; }
        }
        public DateTime NgaySinh
        {
            get { return this.ngaySinh; }
            set { this.ngaySinh = value; }
        }
        public DateTime NgayVaoLam
        {
            get { return this.ngayVaoLam; }
            set { this.ngayVaoLam = value; }
        }
        public string SĐT
        {
            get { return this.sĐT; }
            set { this.sĐT = value; }
        }
        public string ViTriLamViec
        {
            get { return this.viTriLamViec; }
            set { this.viTriLamViec = value; }
        }
       public string GioiTinh
        {
            get { return this.gioiTinh; }
            set { this.gioiTinh = value; }
        }
        public string TachTen()
        {
            string ten= null;
            int viTriKhoangTrangCuoi = this.HoTen.Trim().LastIndexOf(" ");
            ten = this.hoTen.Substring(viTriKhoangTrangCuoi + 1);
            return ten;
        }
    }
}
