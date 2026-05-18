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

        private void btnTinh_Click(object sender, EventArgs e)
        {
            double so1, so2, kq = 0;

            // Đổi dấu , thành . để hỗ trợ cả hai kiểu nhập
            string input1 = txtSo1.Text.Replace(',', '.');
            string input2 = txtSo2.Text.Replace(',', '.');

            // Kiểm tra nhập hợp lệ
            bool kt1 = double.TryParse(input1, NumberStyles.Any,
                                       CultureInfo.InvariantCulture, out so1);

            bool kt2 = double.TryParse(input2, NumberStyles.Any,
                                       CultureInfo.InvariantCulture, out so2);

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
