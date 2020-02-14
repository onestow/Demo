using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChkDetailCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void btnCreateData_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tbSeed.Text, out int seed))
            {
                MessageBox.Show("请输入整数", "错误");
                return;
            }

            int rowCnt = 2, colCnt = 8;

            var dt = new DataTable();
            for (int i = 0; i < colCnt; i++)
                if (i == 0)
                    dt.Columns.Add("Column" + i, typeof(int));
                else
                    dt.Columns.Add("Column" + i);

            var random = new Random(seed);
            for (int i = 0; i < rowCnt; i++)
            {
                var val = random.Next();
                dt.Rows.Add(Enumerable.Range(0, colCnt).Select(item => (item + val) as object).ToArray());
            }

            if (dataGridView1.DataSource == null)
                dataGridView1.DataSource = dt;
            else
            {
                dt.Rows.Add((dataGridView1.DataSource as DataTable).Rows[0].ItemArray);
                dataGridView2.DataSource = dt;
            }
            var strZipped = GzipHelper.Compress(dt);
            var dtNew = GzipHelper.Decompress(strZipped);
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            var dt1 = dataGridView1.DataSource as DataTable;
            var dt2 = dataGridView2.DataSource as DataTable;

            var colNames = new List<string>();
            foreach (DataColumn dc in dt1.Columns)
                colNames.Add(dc.ColumnName);

            var exceptColl1 = dt1.AsEnumerable().Except(dt2.AsEnumerable(), new DataRowComparer(colNames));
            var exceptColl2 = dt2.AsEnumerable().Except(dt1.AsEnumerable(), new DataRowComparer(colNames));

            dataGridView1.DataSource = exceptColl1.Any() ? exceptColl1.CopyToDataTable() : null;
            dataGridView2.DataSource = exceptColl2.Any() ? exceptColl2.CopyToDataTable() : null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
        }
    }

    class DataRowComparer : IEqualityComparer<DataRow>
    {
        private IEnumerable<string> _ColNames;
        public DataRowComparer(IEnumerable<string> colNames)
        {
            _ColNames = colNames;
        }

        public bool Equals(DataRow x, DataRow y)
        {
            foreach (var colName in _ColNames)
                if (x[colName].ToString() != y[colName].ToString())
                    return false;
            return true;
        }

        public int GetHashCode(DataRow obj)
        {
            var hashCode = -1599007192;
            foreach (var colName in _ColNames)
                hashCode = hashCode * -1521134295 + colName.GetHashCode() * 17 * obj[colName].GetHashCode();
            return hashCode;
        }
    }
}
