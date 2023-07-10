using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StackAuth
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if(User.Username == null)
            {
                Application.Exit();
            }

            this.Text = $"{OnProgramStart.Name} - {OnProgramStart.Version}";

            try
            {
                pictureBox1.ImageLocation = User.ProfilePicture;
            }
            catch { }
            label1.Text = $"Username: {User.Username}";
            label2.Text = $"Email: {User.Email}";
            label3.Text = $"Expire: {User.Expiry}";
            label4.Text = $"Register On: {User.RegisterDate}";
            label5.Text = $"HWID: {User.HWID}";

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Cal calu = new Cal();
            calu.MdiParent = this;
            calu.Show();
        }

        private void OpenForm(Form strform) //Open Form or Bring to front
        {
            FormCollection fc = Application.OpenForms;
            bool open = false;
            foreach (Form frm in fc)
            {
                //iterate through
                if (frm.Name == strform.Name)
                {
                    open = true;
                    frm.Activate();
                    frm.BringToFront();
                }
            }

            if (!open)
            {
                strform.MdiParent = this;
                strform.Show();
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.Profile prof = new Forms.Profile();
            OpenForm(prof);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Forms.Form3 webhook = new Forms.Form3();
            OpenForm(webhook);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StackAPI.Ban("Test Ban");
        }
    }
}
