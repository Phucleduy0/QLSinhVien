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
        //private void btn_Save_Click(object sender, EventArgs e)
        //{
        //    SinhVien sv = GetSinhVien();
        //    if (sv == null)
        //    {
        //        MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    else
        //    {
        //        if (sv.ID < 0)
        //        {
        //            string query = $"exec InsertStudent N'" + sv.HoTen + "', " + sv.MaLop + "";
        //            if (SaveSinhVien(sv, query) == 1)
        //                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            string query = $"update SinhVien set HoTen = N'" + sv.HoTen + "' where ID =" + sv.ID + "";
        //            if (SaveSinhVien(sv, query) == 1)
        //                MessageBox.Show("Thay đổi thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        btn_ReLoad.PerformClick();
        //    }
        //}
        //private int SaveSinhVien(SinhVien sv, string query)
        //{
        //    string connectionString = @"Data Source=Asus\SQLEXPRESS;Initial Catalog=QLSinhVien;Integrated Security=True";
        //    SqlConnection connection = new SqlConnection(connectionString);

        //    SqlCommand command = connection.CreateCommand();

        //    command.CommandText = query;

        //    connection.Open();

        //    int data = command.ExecuteNonQuery();

        //    connection.Close();
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
        //    dsSinhVien = new List<SinhVien>();
        //    string query = @"select * from SinhVien";
        //    DataTable data = getDataADO(query);
        //    foreach (DataRow row in data.Rows)
        //    {
        //        dsSinhVien.Add(new SinhVien(row));
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