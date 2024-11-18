using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanCaPhe
{

    public partial class Form1 : Form
    {
        private List<NhanVien> dsNhanVien = new List<NhanVien>();
      
        private int viTri = -1;
        public Form1()
        {
            InitializeComponent();
            cbChucVu.Items.Add("Quản lý");
            cbChucVu.Items.Add("Nhân viên vệ sinh");
            cbChucVu.Items.Add("Thu ngân");
            cbChucVu.Items.Add("Nhân viên pha chế");
            cbChucVu.Items.Add("Nhân viên phục vụ");
            cbChucVu.Items.Add("Bảo vệ");
        }

        
        private void HienThiDanhSachNhanVien(DataGridView dgv, List<NhanVien> dsNhanVien)
        {
            dgv.DataSource = dsNhanVien.ToList();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                viTri = e.RowIndex;
                NhanVien nv = new NhanVien();
                nv = dsNhanVien[viTri];
                txtID.Text = nv.ID;
                txtHoTen.Text = nv.HoTen;
                dtNgaySinh.Value = nv.NgaySinh.Date;
                txtSĐT.Text = nv.SĐT;
                dtNgayVaoLam.Value = nv.NgayVaoLam.Date;
                cbChucVu.Text = nv.ViTriLamViec;
                gbGioiTinh.Text = nv.GioiTinh;
            }
            catch (Exception error)
            {

            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            DanhSachNhanVien ds = new DanhSachNhanVien(dsNhanVien);
            string iD = txtID.Text;
            string hoTen = txtHoTen.Text;
            DateTime ngaySinh = dtNgaySinh.Value.Date;
            if(ds.tinhTuoi(ngaySinh)<18)
            {
                MessageBox.Show("Không đủ tuổi .Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
            string sĐT = txtSĐT.Text;
            DateTime ngayVaoLam = dtNgayVaoLam.Value.Date;
            string viTriLamViec = cbChucVu.SelectedItem.ToString();
            string gioiTinh = null;
            if (radNam.Checked == true)
                gioiTinh = "Nam";
            else if (radNu.Checked == true)
                gioiTinh = "Nữ";
            else { 
                MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
             }
            if (ds.kiemTraMa(iD) == true)
            {
                MessageBox.Show("ID đã tồn tại.Vui lòng nhập ID khác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
         
            else
            {
                NhanVien nv = new NhanVien(iD, hoTen, ngaySinh, sĐT, ngayVaoLam, viTriLamViec, gioiTinh);
                dsNhanVien.Add(nv);
                HienThiDanhSachNhanVien(dgvNhanVien, dsNhanVien);
            }
        }
      
        private void btnSua_Click_1(object sender, EventArgs e)
        {
            string iD = txtID.Text;
            string hoTen = txtHoTen.Text;
            DateTime ngaySinh = dtNgaySinh.Value;
            string sĐT = txtSĐT.Text;
            DateTime ngayVaoLam = dtNgayVaoLam.Value;
            string viTriLamViec = cbChucVu.SelectedItem.ToString();
            string gioiTinh = null;
            if (radNam.Checked == true)
                gioiTinh = "Nam";
            else
                gioiTinh = "Nữ";
            NhanVien nv = new NhanVien(iD, hoTen, ngaySinh, sĐT, ngayVaoLam, viTriLamViec, gioiTinh);
            dsNhanVien[viTri] = nv;
            MessageBox.Show("Đã cập nhật thông tin", "Thông báo", MessageBoxButtons.OK);
            HienThiDanhSachNhanVien(dgvNhanVien, dsNhanVien);
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {

            DialogResult ketQua = MessageBox.Show("Bạn muốn xóa thông tin sinh viên này hả?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ketQua == DialogResult.Yes)
            {
                if (viTri != -1)
                {
                    dsNhanVien.RemoveAt(viTri);
                    MessageBox.Show("Xóa thành công!");
                    HienThiDanhSachNhanVien(dgvNhanVien, dsNhanVien);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            DialogResult ketQua = MessageBox.Show("Bạn thật sự muốn thoát!", "Thông báo", MessageBoxButtons.OK);
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

            if (radTimTen.Checked)
                {
                DanhSachNhanVien ds = new DanhSachNhanVien(dsNhanVien);
                List<NhanVien> ketQua = ds.TimTheoTen(txtTimTen.Text);
                if (ketQua.Count > 0)
                {
                    HienThiDanhSachNhanVien(dgvNhanVien, ketQua);
                }
                else
                    MessageBox.Show("Không tìm thấy!", "Thông báo", MessageBoxButtons.OK);
            }
            if(radTimMa.Checked)
            {
                DanhSachNhanVien ds = new DanhSachNhanVien(dsNhanVien);
                List<NhanVien>ketQua=ds.TimTheoMa(txtTimMa.Text);   
                if(ketQua.Count > 0)
                {
                    HienThiDanhSachNhanVien(dgvNhanVien, ketQua);
                }
                else
                    MessageBox.Show("Không tìm thấy!", "Thông báo", MessageBoxButtons.OK);
            
            
            }    
        }
       
      
    }
}
