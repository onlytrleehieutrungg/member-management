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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        IMemberRepository memberRepository = new MemberRepository();
        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string Email = txtEmail.Text;
                string Password = txtPassword.Text;
                Member member = memberRepository.Login(Email, Password);
                if (Email.Equals("admin@fstore.com") && Password.Equals("admin@@"))
                {
                    frmMemberManagement memberManagement = new frmMemberManagement();
                    memberManagement.Show();
                }
                else if (member != null)
                {
                    MessageBox.Show("Login successfully", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMemberDetail frmMemberDetails = new frmMemberDetail
                    {
                        Text = "update Member",
                        MemberInfo = member,
                        InsertOrUpdate = true,
                        MemberRepository = memberRepository


                    };
                    frmMemberDetails.Show();
                }
                else
                {
                    if (MessageBox.Show("Login failed!!", "Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                    {
                        Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
