using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace FinalPojectPRG282
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }
        DataHandler dh = new DataHandler();
        private void pic_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            int studentNumber = int.Parse(txtStudentNum.Text);
            string studentName = txtname.Text;
            string studentSurname = txtsurname.Text;
            string imgLoc = "";
            byte[] studentFoto;
         
                
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Select Picture";
                dlg.Filter = "JPG | *.jpg| PNG | *.png";
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    pic.ImageLocation = imgLoc;
                }
  
            
      
                studentFoto = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                studentFoto = br.ReadBytes((int)fs.Length);               
     
            


            DateTime dOB = DOB.Value;
            string studentGender = string.Empty;
            if (Male.Checked == true)
            {
                studentGender = "Male";
            }
            else if (Female.Checked == true)
            {
                studentGender = "Female";
            }
            else
            {
                MessageBox.Show("Please select A gender");
            }
            string studentPhone = txtNumber.Text;
            string studentModule = txtModule.Text;
            string studentAddres = txtAddress.Text;
            Student temp = new Student(studentNumber, studentName, studentSurname, studentFoto, dOB, studentGender, studentPhone, studentAddres, studentModule);

            if (dh.Create(temp))
            {
                MessageBox.Show("Details saved!");
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dh.getStudents();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            int studentNumber = int.Parse(txtStudentNum.Text);
            string studentName = txtname.Text;
            string studentSurname = txtsurname.Text;
            string imgLoc = "";
            byte[] studentFoto;


            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select Picture";
            dlg.Filter = "JPG | *.jpg| PNG | *.png";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imgLoc = dlg.FileName.ToString();
                pic.ImageLocation = imgLoc;
            }



            studentFoto = null;
            FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            studentFoto = br.ReadBytes((int)fs.Length);




            DateTime dOB = DOB.Value;
            string studentGender = string.Empty;
            if (Male.Checked == true)
            {
                studentGender = "Male";
            }
            else if (Female.Checked == true)
            {
                studentGender = "Female";
            }
            else
            {
                MessageBox.Show("Please select A gender");
            }
            string studentPhone = txtNumber.Text;
            string studentModule = txtModule.Text;
            string studentAddres = txtAddress.Text;
            Student temp = new Student(studentNumber, studentName, studentSurname, studentFoto, dOB, studentGender, studentPhone, studentAddres, studentModule);
            if (dh.Update(temp))
            {
                MessageBox.Show("Successfully updated");
            }
            else
            {
                MessageBox.Show("User does not exist");
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            int sNum = int.Parse(txtStudentNum.Text);
            dataGridView1.DataSource = dh.Search(sNum);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            dh.Delete(int.Parse(txtStudentNum.Text));
            if (dh.Delete(int.Parse(txtStudentNum.Text)))
            {
                MessageBox.Show($"Deleted details of student number: {int.Parse(txtStudentNum.Text)}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtStudentNum.Text = row.Cells["StudentNum"].Value.ToString();
                txtname.Text = row.Cells["StudentName"].Value.ToString();
                txtsurname.Text = row.Cells["StudentSurname"].Value.ToString();
                txtNumber.Text = row.Cells["StudentPhone"].Value.ToString();
                txtAddress.Text = row.Cells["StudentAddress"].Value.ToString();
                txtModule.Text = row.Cells["StudentModule"].Value.ToString();
            }
        }
    }
}
