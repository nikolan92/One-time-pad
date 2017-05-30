using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTP
{
    public partial class KeyForm : Form
    {
        bool keyStatus = false;
        public KeyForm()
        {
            InitializeComponent();
        }
        public KeyForm(string fileName)
        {
            InitializeComponent();
            fileNameLbl.Text = fileName;
        }
        public string Key
        {
            get { return textBoxKey.Text; }
        }
        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxKey.Text.All(chr => char.IsLetter(chr)) || string.IsNullOrEmpty(textBoxKey.Text))
            {
                keyStatusLbl.ForeColor = Color.Red;
                keyStatusLbl.Text = "Invalid!";
                encryptBtn.Enabled = false;
                keyStatus = false;
            }
            else
            {
                keyStatusLbl.ForeColor = Color.Green;
                keyStatusLbl.Text = "Valid.";
                encryptBtn.Enabled = true;
                keyStatus = true;
            }
        }
    }
}
