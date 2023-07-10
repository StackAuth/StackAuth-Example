using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StackAuth.Forms
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StackAPI.ResetHwid(User.Username, User.Password);
            MessageBox.Show("Next time you login, a new HWID will be set!", OnProgramStart.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           textBox2.Text = App.GrabVariable(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StackAPI.UpdateInformation(textBox4.Text, textBox5.Text);
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            label3.Text = User.Username;
            textBox4.Text = User.Email;
            textBox5.Text = User.Password;
            try
            {
                pictureBox1.ImageLocation = User.ProfilePicture;
            }
            catch { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog1 = new OpenFileDialog();
            filedialog1.Title = "Choose a Profile Picture!";
            filedialog1.Filter = "png files (*.png)|*.png";

            if (filedialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(filedialog1.FileName);
                StackAPI.ChangeProfilePic(filedialog1.FileName);
            }

            filedialog1.Dispose();

        }
    }
}
