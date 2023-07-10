using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StackAuth
{
    public partial class Form1 : Form
    {
        //Move Borderless Form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        //End Move Borderless Form
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //Exit
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Minimize Form
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //Move form
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Login Button
            if (StackAPI.Login(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show($"Welcome {User.Username}!", OnProgramStart.Name);
                Form2 frm2 = new Form2();
                frm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect Details, Please Check you're username and password", OnProgramStart.Name);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StackAPI.ForgotPassword(textBox1.Text, textBox2.Text);
        }
    }
} 
