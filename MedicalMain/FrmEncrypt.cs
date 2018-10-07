using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encrypt
{
    public partial class Main : Form
    {
        private string sEncryptionKey = "";
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="stringToDecrypt">待解密字符串</param>
        /// <param name="sEncryptionKey">密钥</param>
        /// <returns>解密后的字符串</returns>
        public string Decrypt(string stringToDecrypt, string sEncryptionKey)
        {
            try
            {
                byte[] rgbIV = { 10, 20, 30, 40, 50, 60, 70, 80 };
                byte[] rgbKey = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                byte[] buffer = Convert.FromBase64String(stringToDecrypt);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="stringToEncrypt">待加密字符串</param>
        /// <param name="sEncryptionKey">密钥</param>
        /// <returns>加密后的字符串</returns>
        public string Encrypt(string stringToEncrypt, string sEncryptionKey)
        {
            try
            {
                byte[] rgbIV = { 10, 20, 30, 40, 50, 60, 70, 80 };
                byte[] rgbKey = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                byte[] bytes = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                return Convert.ToBase64String(stream.ToArray());
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="sender">原字符串</param>
        /// <param name="e">加密密钥</param>
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtEncryptKey.Text.Count<char>() < 8)
            {
                MessageBox.Show("密钥不能少于8位");
                return;
            }
            if (!string.IsNullOrEmpty(txtDecrypt.Text) && !string.IsNullOrEmpty(txtEncryptKey.Text))
            {
                txtEncrypt.Text = Encrypt(txtDecrypt.Text, txtEncryptKey.Text);
                if (!string.IsNullOrEmpty(txtEncrypt.Text))
                {
                    txtDecrypt.Clear();
                }
            }
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="sender">加密字符串</param>
        /// <param name="e">解密密钥</param>
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (txtDecryptKey.Text.Count<char>() < 8)
            {
                MessageBox.Show("密钥不能少于8位");
                return;
            }
            if (!string.IsNullOrEmpty(txtEncrypt.Text) && !string.IsNullOrEmpty(txtDecryptKey.Text))
            {
                txtDecrypt.Text = Decrypt(txtEncrypt.Text, txtDecryptKey.Text);
                if (!string.IsNullOrEmpty(txtDecrypt.Text))
                {
                    txtEncrypt.Clear();
                }
            }
        }

        private void txtEncryptKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEncrypt_Click(null,null);
            }
        }

        private void txtDecryptKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDecrypt_Click(null,null);
            }
        }
    }
}
