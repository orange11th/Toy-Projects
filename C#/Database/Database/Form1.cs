using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gbShow.Visible = false;
            gbInsert.Visible = false;
            gbDelete.Visible = false;
        }
        private void rbShow_CheckedChanged(object sender, EventArgs e)
        {
            if (rbShow.Checked)
                gbShow.Visible = true;
            else
                gbShow.Visible = false;
        }
        private void rbInsert_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInsert.Checked)
                gbInsert.Visible = true;
            else
                gbInsert.Visible = false;
        }
        private void rbDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDelete.Checked)
                gbDelete.Visible = true;
            else
                gbDelete.Visible = false;
        }
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            this.studentTableAdapter.Fill(this.studentDataSet.Student);
        }
        private void btnShowEX_Click(object sender, EventArgs e)
        {
            this.studentTableAdapter.FillByAll(this.studentDataSet.Student);
        }
        private void btnID_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("아이디를 입력하세요");
                return;
            }
            try
            {
                studentTableAdapter.FillByID(studentDataSet.Student, id);
                int count = studentTableAdapter.GetDataByID(id).Rows.Count;
                if (count <= 0)
                {
                    throw new Exception("찾는 학생이 없습니다.");
                }
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }
        private void btnName_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("이름을 입력하세요");
                return;
            }
            try
            {
                studentTableAdapter.FillByName(studentDataSet.Student, "%" + name + "%");
                int count = studentTableAdapter.GetDataByName("%" + name + "%").Rows.Count;
                if (count <= 0)
                {
                    throw new Exception("찾는 학생이 없습니다.");
                }
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name)
                || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("빈칸이 존재합니다.");
                return;
            }
            int count = 0;
            try
            {
                count = studentTableAdapter.InsertQuery(id, name, phone, address);
                studentTableAdapter.FillByID(studentDataSet.Student, id);
                MessageBox.Show("학생을 추가했습니다.");
            }
            catch { MessageBox.Show("추가 실패"); }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name)
                || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("빈칸이 존재합니다.");
                return;
            }
            int count = 0;
            try
            {
                count = studentTableAdapter.UpdateQuery(name, phone, address,id);
                studentTableAdapter.FillByID(studentDataSet.Student, id);
                MessageBox.Show("갱신했습니다.");
            }
            catch { MessageBox.Show("갱신 실패"); }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtDelete.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("아이디를 입력하세요");
                return;
            }
            try
            {
                studentTableAdapter.DeleteQuery(id);
                int count = studentTableAdapter.GetDataByID(id).Rows.Count;
                if (count > 0)
                    throw new Exception("삭제 실패");
                MessageBox.Show("삭제되었습니다.");
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
            this.studentTableAdapter.FillByAll(this.studentDataSet.Student);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            string id = txtDelete.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("아이디를 입력하세요");
                return;
            }
            try
            {
                studentTableAdapter.ExitID(id);
                int count=studentTableAdapter.GetDataByExitID(id).Rows.Count;
                if (count <= 0)
                    throw new Exception("탈퇴 실패");
                MessageBox.Show("탈퇴되었습니다.");
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
            this.studentTableAdapter.FillByAll(this.studentDataSet.Student);
        }
    }
}