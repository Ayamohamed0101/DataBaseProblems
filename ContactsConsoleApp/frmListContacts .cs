using ContactsBusinessLayer;
using ContactsConsoleApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void _RefreshContactsList()
        {
              dgvAllContacts.DataSource = ContactsBusinessLayer.clsContact.__GetAllContacts();
        }
       
       

        private void Form1_Load(object sender, EventArgs e)
        {
            _RefreshContactsList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddEditContact frm = new frmAddEditContact(-1);
            frm.ShowDialog();
            _RefreshContactsList();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CurrentID = (int)dgvAllContacts.CurrentRow.Cells[0].Value;
            frmAddEditContact frm = new frmAddEditContact(CurrentID);
            frm.ShowDialog();
            _RefreshContactsList();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete contact [" +
          dgvAllContacts.CurrentRow.Cells[0].Value + "]", "Confirm Delete",
          MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                if (clsContact.__DeleteContact((int)dgvAllContacts.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Contact Deleted Successfully.");
                    _RefreshContactsList();
                }

                else
                { MessageBox.Show("Contact is not deleted."); }

            }

        }
    }
}
