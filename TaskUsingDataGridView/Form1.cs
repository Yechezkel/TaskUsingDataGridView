using System.Data;

namespace TaskUsingDataGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DBContext dBContext = new DBContext();
            DataTable dataTable = dBContext.MakeQueryDT("select * from Person;");
            dataGridView1.DataSource = dataTable;
        }
    }
}
