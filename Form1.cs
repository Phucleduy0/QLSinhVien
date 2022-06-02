namespace QLSinhVien
{
    public partial class Form1 : Form
    {
       // private string _connectiontoString;
        private const string DefaultSerchText = "Nhập tên sinh viên";
       // private List<Lop> _dsLop;
       // private List<Lop> _dsSinhVien;
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
        
    }
}