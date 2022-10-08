using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem1.All_User_Control
{
    public partial class UC_AddRoom : UserControl
    {
        Function fn = new Function();
        String query;
        public UC_AddRoom()
        {
            InitializeComponent();
        }

        private void UC_AddRoom_Load(object sender, EventArgs e)
        {
            query = "SELECT * FROM rooms";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
            

        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomNumber.Text != "" && txtRoomType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                string roomno = txtRoomNumber.Text;
                string type = txtRoomType.Text;
                string bed = txtBed.Text;
                Int64 price = Int64.Parse(txtPrice.Text) ;

                query = "INSERT INTO rooms (roomNo,roomType,bad,price) VALUES ('" + roomno + "','" + type + "','" + bed + "'," + price + ")";
                fn.setData(query, "Room Added!");
                UC_AddRoom_Load(null, null);
                clearAll();


            }
            else
            {
                MessageBox.Show("Fill All Fields noori", "Warring!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public void clearAll()
        {
            txtRoomNumber.Clear();
            txtRoomType.SelectedIndex = -1;
            txtBed.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void UC_AddRoom_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_AddRoom_Enter(object sender, EventArgs e)
        {
            //btnAddRoom_Click(null, null);//By entering in AddRoom tab, the form will be loaded.
            UC_AddRoom_Load(null, null);
        }
    }
}
