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
                IMemberRepository memberRepository = new MemberRepository();
                Member member = memberRepository.GetMemebers().SingleOrDefault(pro => pro.Email == txtEmail.Text && pro.Password == txtPassword.Text);
                if (member != null)
                {
                    frmMemberManagement memberManagement = new frmMemberManagement(member);
                    memberManagement.Show();
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
