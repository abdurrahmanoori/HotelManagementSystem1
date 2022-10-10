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
    public partial class UC_CustomerCheckOut : UserControl
    {
        Function fn = new Function();
        string query;
        public UC_CustomerCheckOut()
        {
            InitializeComponent();
        }

        private void UC_CustomerCheckOut_Load(object sender, EventArgs e)
        {
            query = "SELECT customer.cid,customer.cname, customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkin,rooms.roomNo,rooms.roomType,rooms.bad,rooms.price FROM customer INNER JOIN rooms ON customer.roomid = rooms.roomId WHERE chekout = 'NO'";
             DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0]; 
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT customer.cid,customer.cname, customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkin,rooms.roomNo,rooms.roomType,rooms.bad,rooms.price FROM customer INNER JOIN rooms ON customer.roomid = rooms.roomId WHERE cname like '"+txtName.Text+"%'  AND chekout = 'NO'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtCName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtRoomNo.Text = guna2DataGridView1[9, e.RowIndex].Value.ToString();

          //MessageBox.Show("Id =" + id);
          // MessageBox.Show("ID= "+guna2DataGridView1[0, e.RowIndex].Value.ToString() + "\nValue: " + guna2DataGridView1[e.ColumnIndex, e.RowIndex].Value + "\n\nRowIndex ="+ e.RowIndex+" | ColumnIndex"+e.ColumnIndex);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if(txtCName.Text != "")
            {
                if(MessageBox.Show("Are You Srue?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    string cdate = txtCheckOutDate.Text;
                    query = "UPDATE customer SET chekout ='YES',checkout ='" + cdate + "' WHERE cid=" + id + "UPDATE rooms SET booked ='NO' WHERE roomNo ='" + txtRoomNo.Text + "'";
                    fn.setData(query, "Check Out Successfully.");
                    UC_CustomerCheckOut_Load(this, null);
                    clearAll();
                }

            }
            else
            {
                MessageBox.Show("No Custmoer Selected!", "Inforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clearAll()
        {
            txtCName.Clear();
            txtName.Clear();
            txtRoomNo.Clear();
            txtCheckOutDate.ResetText();

        }

        private void UC_CustomerCheckOut_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
