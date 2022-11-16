using System;
using Mssql_connection_crud_operations.Connect;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Deployment.Internal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace Mssql_connection_crud_operations
{
    public partial class frm_database : Form
    {
        public frm_database()
        {
            InitializeComponent();
        }
        CRUD studentdalc = new CRUD();

        private void btn_insert_Click(object sender, EventArgs e)
        {
        if(txtbox_name.Text=="" || txtbox_surname.Text=="")
            {
                MessageBox.Show("Name and Surname cannot be empty! Please fill the name and surname","Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int a=studentdalc.Insert(txtbox_name.Text, txtbox_surname.Text, txtbox_fname.Text, txtbox_birthdate.Text, txtbox_adres.Text, txtbox_email.Text, comboBox_gender.Text, comboBox_status.Text);
            if (a == 1)
            {
                MessageBox.Show("Insert has succesfully!");
            }
            else
                MessageBox.Show("Insert has not sucessfully!");

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtbox_id.Text, @"[a-zA-Z]"))
            {
                MessageBox.Show("Please enter numbers only!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtbox_id.Text == "")
                {
                    MessageBox.Show("Please enter the ID!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            int b = Convert.ToInt32(txtbox_id.Text);


            if (b <= 0)
                {
                    MessageBox.Show("ID cannot be zero or negative number!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            if (!studentdalc.selectId(Convert.ToInt32(txtbox_id.Text)))
            {
                MessageBox.Show("Invalid ID,please correct ID!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            else
                {
                    int id = Convert.ToInt32(txtbox_id.Text);
                    int a = studentdalc.Update(id, txtbox_name.Text, txtbox_surname.Text, txtbox_fname.Text, txtbox_birthdate.Text, txtbox_adres.Text, txtbox_email.Text, comboBox_gender.Text, comboBox_status.Text);
                    if (a == 1)
                    {
                        MessageBox.Show("Update has succesfully!");
                    }
                    else
                        MessageBox.Show("Update has not sucessfully!");
                }
          
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(txtbox_id.Text, @"[a-zA-Z]"))
            {
                MessageBox.Show("Please enter numbers only!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtbox_id.Text == "")
                {
                    MessageBox.Show("Please enter the ID!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
                if (Convert.ToInt32(txtbox_id.Text) <= 0)
                {
                    MessageBox.Show("ID cannot be zero or negative number!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
            
            if (!studentdalc.selectId(Convert.ToInt32(txtbox_id.Text)))
                {
                    MessageBox.Show("Invalid ID,please correct ID!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int id = Convert.ToInt32(txtbox_id.Text);
                int a = studentdalc.Delete(id);
                if (a == 1)
                {
                    MessageBox.Show("Delete has succesfully!");
                }
                else
                    MessageBox.Show("Delete has not sucessfully!");
            
            
            
        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            dataGridView_show.DataSource = studentdalc.Select();
        }
    }
    }
