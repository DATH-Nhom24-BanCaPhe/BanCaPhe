using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanCaPhe
{
    internal class DanhSachNhanVien
    {

        private List<NhanVien> dsNV;

        public DanhSachNhanVien()
        {
            this.dsNV = new List<NhanVien>();
        }
        public DanhSachNhanVien(List<NhanVien> dsNV)
        {
            this.dsNV = dsNV;
        }
        public List<NhanVien> DsNV
        {
            get { return dsNV; }
            set { dsNV = value; }
        }
        public bool kiemTraMa(string m)
        {
            foreach (NhanVien nv in dsNV)
            {
                if (nv.ID.Equals(m))
                    return true;
            }
            return false;
        }
        public bool Them(NhanVien nv)
        {
            if (kiemTraMa(nv.ID) == true)
                return false;
            else
            {
                this.dsNV.Add(nv);
                return true;
            }
        }
        public bool Xoa(int viTri)
        {
            this.dsNV.RemoveAt(viTri);
            return true;
        }
        public bool Sua(NhanVien nv, int viTri)
        {
            this.dsNV[viTri] = nv;
            return true;
        }
        public List<NhanVien> TimTheoTen(string ten)
        {
            List<NhanVien> dsKetQua = new List<NhanVien>();
            foreach (NhanVien nv in this.dsNV)
            {
                if (nv.TachTen().Equals(ten))
                {
                    dsKetQua.Add(nv);
                }
            }
            return dsKetQua;
        }
        public List<NhanVien>TimTheoMa(string ma)
        {
            List<NhanVien> dsKetQua=new List<NhanVien>();
            foreach(NhanVien nv in this.dsNV)
            {
                if(nv.ID.Equals(ma))
                {
                    dsKetQua.Add(nv);
                }    
            }    
            return dsKetQua;
        }
        public int tinhTuoi(DateTime ngaySinh)
        {
            DateTime ngayHienTai = DateTime.Now;
            int tuoi = ngayHienTai.Year - ngaySinh.Year;
            if (ngayHienTai < ngaySinh)
            {
                return -1;
            }
            if (ngayHienTai.Month < ngaySinh.Month || (ngayHienTai.Month == ngaySinh.Month && ngayHienTai.Day < ngaySinh.Day))
            {
                tuoi--;
            }
            return tuoi;
        }

    }
}
