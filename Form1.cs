using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
namespace QLSinhVien

{
    public partial class Form1 : Form
    {
       
        private const string DefaultSerchText = "Nhập tên sinh viên";
        List<Lop> dsLop = new List<Lop>();
        List<SinhVien> dsSinhVien = new List<SinhVien>();
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            cbbLop.SelectedIndex = 0;
            txtMaSo.Text = "";
            txtHoTen.Text = "";
        }
        private void btn_Reload_Click(object sender, EventArgs e)
        {
           // GetAllSinhVien();
            DisplayDSSV(dsSinhVien);
        }
        //private void btn_save_click(object sender, eventargs e)
        //{
        //    sinhvien sv = getsinhvien();
        //    if (sv == null)
        //    {
        //        messagebox.show("chưa nhập đủ thông tin", "thông báo", messageboxbuttons.ok, messageboxicon.error);
        //        return;
        //    }
        //    else
        //    {
        //        if (sv.id < 0)
        //        {
        //            string query = $"exec insertstudent n'" + sv.hoten + "', " + sv.malop + "";
        //            if (savesinhvien(sv, query) == 1)
        //                messagebox.show("thêm sinh viên thành công!", "thông báo", messageboxbuttons.ok, messageboxicon.information);
        //        }
        //        else
        //        {
        //            string query = $"update sinhvien set hoten = n'" + sv.hoten + "' where id =" + sv.id + "";
        //            if (savesinhvien(sv, query) == 1)
        //                messagebox.show("thay đổi thông tin sinh viên thành công!", "thông báo", messageboxbuttons.ok, messageboxicon.information);
        //        }
        //        btn_reload.performclick();
        //    }
        //}
        //private int savesinhvien(sinhvien sv, string query)
        //{
        //    string connectionstring = @"data source=asus\sqlexpress;initial catalog=qlsinhvien;integrated security=true";
        //    sqlconnection connection = new sqlconnection(connectionstring);

        //    sqlcommand command = connection.createcommand();

        //    command.commandtext = query;

        //    connection.open();

        //    int data = command.executenonquery();

        //    connection.close();
        //    return data;
        //}

        private void TxtSearchOnLostFocus(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text =DefaultSerchText ;
                btn_ReLoad.PerformClick();
            }
        }
        private void TxtSearchOnGottFocus(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }
        private SinhVien GetSinhVien()
        {
            var sv = new SinhVien();
            if (!string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                sv.HoTen = txtHoTen.Text;
                sv.ID = string.IsNullOrWhiteSpace(txtMaSo.Text) ? -1 : int.Parse(txtMaSo.Text);
                sv.MaLop = Convert.ToInt32(cbbLop.SelectedValue);
            }
            return sv;
        }
        private void AddSVToLV(SinhVien sv)
        {
            ListViewItem item = new ListViewItem(sv.ID.ToString());
            item.SubItems.Add(sv.HoTen);
            item.SubItems.Add(sv.MaLop.ToString());
            lvDSSV.Items.Add(item);
        }
        //private void GetAllSinhVien()
        //{
        //    dsSinhVien = new list<SinhVien>();
        //    string query = @"select * from sinhvien";
        //    datatable data = getdataado(query);
        //    foreach (DataRow row in data.rows)
        //    {
        //        dsSinhVien.add(new SinhVien(row));
        //    }
        //}
        private void DisplayDSSV(List<SinhVien> list)
        {
            lvDSSV.Items.Clear();

            foreach (SinhVien sv in list)
            {
                AddSVToLV(sv);
            }
        }
        private void lvDSSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDSSV.SelectedItems.Count > 0)
            {
                var item = lvDSSV.SelectedItems[0];
                cbbLop.SelectedIndex = int.Parse(item.SubItems[2].Text) - 1;
                txtMaSo.Text = item.SubItems[0].Text;
                txtHoTen.Text = item.SubItems[1].Text;
            }
        }
    }
}