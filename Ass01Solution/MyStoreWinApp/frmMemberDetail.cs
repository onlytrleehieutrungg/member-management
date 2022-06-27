using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreWinApp
{
    public partial class frmMemberDetail : Form
    {
        public frmMemberDetail()
        {
            InitializeComponent();
        }

        public IMemberRepository MemberRepository { get; set; }

        public bool InsertOrUpdate { get; set; }

        public Member MemberInfo { get; set; }

    

        private void frmMemberDetail_Load(object sender, EventArgs e)
        {
            txtMemberId.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtMemberId.Text = MemberInfo.MemberId;
                txtMemberName.Text = MemberInfo.MemberName;
                txtEmail.Text = MemberInfo.Email;
                txtCountry.Text = MemberInfo.Country;
                txtPassword.Text = MemberInfo.Password;
                txtCity.Text = MemberInfo.City;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var member = new Member
                {
                    MemberId = txtMemberId.Text,
                    MemberName = txtMemberName.Text,
                    Email = txtEmail.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text,
                    City = txtCity.Text,
                };
                if (InsertOrUpdate == false)
                {
                    MemberRepository.AddMember(member);
                    MessageBox.Show("Add Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MemberRepository.UpdateMember(member);
                    MessageBox.Show("Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "add a new member" : "Update a member");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
