using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem1
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            uC_AddRoom1.Visible = false;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            btnAddRoom.PerformClick();
            panelMoving.Visible = false;
     
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            panelMoving.Left = btnAddRoom.Left;
            panelMoving.Visible = true;
            uC_AddRoom1.Visible = true;

        }

        private void btnCustReg_Click(object sender, EventArgs e)
        {
            panelMoving.Left = btnCustReg.Left;
            panelMoving.Visible = true;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            panelMoving.Left = btnCheckOut.Left;
            panelMoving.Visible = true;
        }

        private void btnCustDetail_Click(object sender, EventArgs e)
        {
            panelMoving.Left = btnCustDetail.Left;
            panelMoving.Visible = true;
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            panelMoving.Left = btnEmployee.Left;
            panelMoving.Visible = true;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
