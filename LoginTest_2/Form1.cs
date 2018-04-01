using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;//MD5算法需要

namespace LoginTest_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username=this.textBoxUsername.Text.ToString();
            string userpassword=this.textBoxUserpassword.Text.ToString();

            #region md5算法转化过程
            byte[] result = Encoding.Default.GetBytes(userpassword);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string userpassword_md5 = BitConverter.ToString(output).Replace("-", "");//所得md5结果为大写字母
            #endregion

            string str = "null";
            if (String.Compare(username, "jxl") == 0 && String.Compare(userpassword_md5, "838ddf2b74575f929e247c8f81a14ed7", true/*比较忽略大小写*/) == 0)//md5(jxl)="838ddf2b74575f929e247c8f81a14ed7"
            {
                str = "succeed";
            }
            else
            {
                str = "fail";
            }
            MessageBox.Show(str);
        }
    }
}
