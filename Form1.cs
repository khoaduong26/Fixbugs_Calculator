using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExtendedNumerics;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;             //đầu tiên chọn phép cộng
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                                 "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Close();
        }
        //Hàm kiểm tra nhập hợp lệ
        private bool TryParseBigDecimal(string input, out BigDecimal result)
        {
            try
            {
                result = BigDecimal.Parse(input);
                return true;
            }
            catch
            {
                result = 0;
                return false;
            }
        }
        private void btnTinh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSo1.Text))
            {
                MessageBox.Show(
                    "Không để trống số thứ 1",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSo1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSo2.Text))
            {
                MessageBox.Show(
                    "Không để trống số thứ 2",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSo2.Focus();
                return;
            }
            //Đổi kiểu dữ liệu thành BigDecimal để hỗ trợ số rất lớn
            BigDecimal so1, so2, kq = 0;

            // Đổi dấu , thành . để hỗ trợ cả hai kiểu nhập
            string input1 = txtSo1.Text.Replace(',', '.');
            string input2 = txtSo2.Text.Replace(',', '.');

            // Kiểm tra nhập hợp lệ
            bool kt1 = TryParseBigDecimal(input1, out so1);
            bool kt2 = TryParseBigDecimal(input2, out so2);

            if (!kt1 || !kt2)
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!");
                return;
            }

            // Thực hiện phép tính
            if (radCong.Checked)
                kq = so1 + so2;
            else if (radTru.Checked)
                kq = so1 - so2;
            else if (radNhan.Checked)
                kq = so1 * so2;
            else if (radChia.Checked)
            {
                if (so2 == 0)
                {
                    MessageBox.Show("Không thể chia cho 0");
                    return;
                }

                kq = so1 / so2;
            }

            txtKq.Text = kq.ToString();
        }
    }
}
