using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Repository;
using BusinessObject;

namespace MyStoreWinApp
{
    public partial class frmMemberManagement : Form
    {
        public frmMemberManagement()
        {
            InitializeComponent();
        }

        IMemberRepository memberRepository = new MemberRepository();
        BindingSource source;
        Member memberLogin;

        public frmMemberManagement(Member member)
        {
            InitializeComponent();
            this.memberLogin = member;
            List<Member> members = new List<Member>();
            if (member.MemberName == "admin@fstore.com")
            {
                button1.Enabled = true;

            }
            else
            {
                button1.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;

            }
        }
        private void frmMemberManagement_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            dgvMemberList.CellDoubleClick += DgvMemberList_CellDoubleClick;
        }

        private void DgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmMemberDetail frmMemberDetail = new frmMemberDetail
            {
                Text = "update member",
                InsertOrUpdate = true,
                MemberInfo = GetMemberObject(),
                MemberRepository = memberRepository
            };
            if(frmMemberDetail.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                source.Position = source.Count - 1;
            }
        }

        private void ClearText()
        {
            txtMemberId.Text = string.Empty;
            txtMemberName.Text = string.Empty;
            txtEmail.Text = string.Empty;
  
            txtCity.Text = string.Empty;
            txtCountry.Text = string.Empty;

        }

        private void LoadMemberList()
        {
            var members = memberRepository.GetMemebers();
            try
            {
                source = new BindingSource();
                source.DataSource = members;

              



                txtMemberId.DataBindings.Add("Text", source, "MemberId");
                txtMemberName.DataBindings.Add("Text", source, "MemberName");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtPassword.DataBindings.Add("Text", source, "Password");
                txtCity.DataBindings.Add("Text", source, "City");
                txtCountry.DataBindings.Add("Text", source, "Country");
                txtMemberId.DataBindings.Clear();
                txtMemberName.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                abc.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtCountry.DataBindings.Clear();


                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
                if(members.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Member list");
            }
        }

        private Member GetMemberObject()
        {
            Member member = null;
            try
            {
                member = new Member()
                {
                    MemberId = txtMemberId.Text,
                    MemberName = txtMemberId.Text,
                    Email = txtEmail.Text,
                    Password = abc.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                };
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Member");
            }
            return member;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadMemberList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
          
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmMemberDetail frmMemberDetail = new frmMemberDetail
            {
                Text = "add member",
                InsertOrUpdate = false,
                MemberRepository = memberRepository
            };
            if(frmMemberDetail.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                source.Position = source.Count - 1;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var member = GetMemberObject();
                memberRepository.DeleteMember(member.MemberId);
                MessageBox.Show("Delete Successfully", "Detele", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a Member");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMemberId.Text.Equals("") || txtMemberName.Text.Equals(""))
            {
                MessageBox.Show("Missing input !", "Error");
            }
            else
            {
                List<Member> list = (List<Member>)memberRepository.GetMemebers();
                list = list.Where(pro => pro.MemberId.ToString().Contains(txtMemberId.Text) && pro.MemberName.ToString().Contains(txtMemberName.Text)).ToList();
                try
                {
                    source = new BindingSource();
                    source.DataSource = list;
                    dgvMemberList.DataSource = null;
                    dgvMemberList.DataSource = source;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Search Member");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtCity.Text.Equals("") || txtCountry.Text.Equals(""))
            {
                MessageBox.Show("Missing input !", "Error");
            }
            else
            {
                List<Member> list = (List<Member>)memberRepository.GetMemebers();
                list = list.Where(pro => pro.City.Contains(txtCity.Text) && pro.Country.Contains(txtCountry.Text)).ToList();
                try
                {
                    source = new BindingSource();
                    source.DataSource = list;
                    dgvMemberList.DataSource = null;
                    dgvMemberList.DataSource = source;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Filter Member");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Member> list = (List<Member>)memberRepository.GetMemebers();
            list = list.OrderByDescending(pro => pro.MemberName).ToList();
            try
            {
                source = new BindingSource();
                source.DataSource = list;
                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sort Member");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
