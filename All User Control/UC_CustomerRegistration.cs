using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelManagementSystem1.All_User_Control
{
    public partial class UC_CustomerRegistration : UserControl
    {
        Function fn = new Function();
        string query;
        public UC_CustomerRegistration()
        {
            InitializeComponent();
        }

        public void setComboBox(string query, ComboBox combo)
        {
            SqlDataReader sdr = fn.getForCombo(query);
            while (sdr.Read())
            {
                for(int i = 0; i<sdr.FieldCount; i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }

        private void txtRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomNo.Items.Clear();
            query = "SELECT roomNo FROM rooms WHERE bad ='" + txtBed.Text + "' AND roomType='" + txtRoom.Text + "' AND booked ='NO'";
            setComboBox(query, txtRoomNo);
        }

        private void txtBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoom.SelectedIndex = -1;
            txtRoomNo.Items.Clear();
        }
        int rid;
        private void txtRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "SELECT price,roomid FROM rooms WHERE roomNo ='" + txtRoomNo.Text + "'";
            DataSet ds = fn.getData(query);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
        }

        private void btnAllocateRoom_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "" && txtContact.Text !="" && txtNationality.Text != "")
            {
                string name = txtName.Text;
                Int64 mobile = Int64.Parse(txtContact.Text);
                string national = txtNationality.Text;
                string gender = txtGender.Text;
                string dob = txtDob.Text;
                string idproof = txtIdProof.Text;
                string address = txtAddress.Text;
                string checkin = txtCheckIn.Text;

                query = "INSERT INTO customer (cname,mobile,nationality,gender,dob,idproof,addres,checkin,roomid) VALUES ('" + name + "'," + mobile + ",'" + national + "','" + gender + "','" + dob + "','" + idproof + "','" + address + "','" + checkin + "'," + rid + ")UPDATE rooms SET booked ='YES' WHERE roomNo ='" + txtRoomNo.Text + "'";
                fn.setData(query, "Room No" + txtRoom.Text + " Allocation Succcessfully");
                clearAll();
            }
            else
            {
                MessageBox.Show("All Field Are Required!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clearAll()
        {
            txtName.Clear();
            txtContact.Clear();
            txtNationality.Clear();
            txtGender.SelectedIndex = -1;
            txtDob.ResetText();
            txtIdProof.Clear();
            txtAddress.Clear();
            txtCheckIn.ResetText();
            txtBed.SelectedIndex = -1;
            txtRoom.SelectedIndex = -1;
            txtRoomNo.Items.Clear();
            txtPrice.Clear();

        }
    }


}
