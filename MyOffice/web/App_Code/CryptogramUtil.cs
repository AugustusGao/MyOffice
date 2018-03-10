using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.IO;
using System.Text;

    //���������
    public  class CryptogramUtil
    {
        private bool isReturnNum;//�Ƿ񷵻�Ϊ���ܺ��ַ���Byte����
        private bool isCaseSensitive;//�Ƿ����ִ�Сд��

        /// <summary>
        /// ���ܴ��ι��췽��
        /// </summary>
        /// <param name="IsCaseSensitive">�Ƿ񷵻�Ϊ���ܺ��ַ���Byte����</param>
        /// <param name="IsReturnNum">�Ƿ����ִ�Сд</param>
        public CryptogramUtil(bool isCaseSensitive, bool isReturnNum)
		{
			this.isReturnNum = isReturnNum;
			this.isCaseSensitive = isCaseSensitive;
		}

        /// <summary>
        /// ���ַ�������SHA256����
        /// </summary>
        /// <param name="strIN">����</param>
        /// <returns>����</returns>
        public string SHA256Encrypt(string strIN)
        {
            strIN = GetStrIN(strIN);
            byte[] tmpByte;
            SHA256 sha256 = new SHA256Managed();

            tmpByte =
                sha256.ComputeHash(GetKeyByteArray(strIN));
            sha256.Clear();

            return GetStringValue(tmpByte);

        }
        /// <summary>
        /// ���ַ�������SHA512����
        /// </summary>
        /// <param name="strIN"></param>
        /// <returns></returns>
        public string SHA512Encrypt(string strIN)
        {
            strIN = GetStrIN(strIN);
            byte[] tmpByte;
            SHA512  sha512 = new SHA512Managed();
            tmpByte =
                sha512.ComputeHash(GetKeyByteArray(strIN));
            sha512.Clear();

            return GetStringValue(tmpByte);

        }

        /// <summary>
        /// ʹ��DES����
        /// </summary>
        /// <param name="originalValue">�����ܵ��ַ���</param>
        /// <param name="key">��Կ(��󳤶�8)</param>
        /// <param name="IV">��ʼ������(��󳤶�8)</param>
        /// <returns>���ܺ���ַ���</returns>
        public string DESEncrypt(string originalValue, string key, string IV)
        {
            //��key��IV�����8���ַ�
            key += "12345678";
            IV += "12345678";
            key = key.Substring(0, 8);
            IV = IV.Substring(0, 8);

            SymmetricAlgorithm sa;
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;

            sa = new DESCryptoServiceProvider();
            sa.Key = Encoding.UTF8.GetBytes(key);
            sa.IV = Encoding.UTF8.GetBytes(IV);
            ct = sa.CreateEncryptor();

            byt = Encoding.UTF8.GetBytes(originalValue);

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct,
                CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            return Convert.ToBase64String(ms.ToArray());

        }

        /// <summary>
        /// ʹ��DES����
        /// </summary>
        /// <param name="originalValue">�����ܵ��ַ���</param>
        /// <param name="key">��Կ(��󳤶�8)</param>
        /// <returns>���ܺ���ַ���</returns>
        public string DESEncrypt(string originalValue, string key)
        {
            return DESEncrypt(originalValue, key, key);
        }
        /// <summary>
        ///  ʹ��DES����
        /// </summary>
        /// <param name="encryptedValue">�����ܵ��ַ���</param>
        /// <param name="key">��Կ(��󳤶�8)</param>
        /// <returns>���ܺ���ַ���</returns>
        public string DESDecrypt(string encryptedValue, string key)
        {
            return DESDecrypt(encryptedValue, key, key);
        }

        /// <summary>
        /// ʹ��DES����
        /// </summary>
        /// <param name="encryptedValue">�����ܵ��ַ���</param>
        /// <param name="key">��Կ(��󳤶�8)</param>
        /// <param name="IV">m��ʼ������(��󳤶�8)</param>
        /// <returns>���ܺ���ַ���</returns>
        public string DESDecrypt(string encryptedValue, string key, string IV)
        {
            //��key��IV�����8���ַ�
            key += "12345678";
            IV += "12345678";
            key = key.Substring(0, 8);
            IV = IV.Substring(0, 8);

            SymmetricAlgorithm sa;
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;

            sa = new DESCryptoServiceProvider();
            sa.Key = Encoding.UTF8.GetBytes(key);
            sa.IV = Encoding.UTF8.GetBytes(IV);
            ct = sa.CreateDecryptor();

            byt = Convert.FromBase64String(encryptedValue);

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct,
                CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            return Encoding.UTF8.GetString(ms.ToArray());

        }

        /// <summary>
        /// ������ܣ�Web��
        /// </summary>
        /// <param name="PasswordString">����</param>
        /// <param name="format">���ܸ�ʽö������(Clear��MD5��SHA1)</param>
        /// <returns>����</returns>
        public  string Encrypt(string PasswordString,FormsAuthPasswordFormat format) {
            string password = string.Empty;
            if (!string.IsNullOrEmpty(PasswordString)) {
                password = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString,format.ToString());
            }
            return password;
        }

        /// <summary>
        /// �����֤�������Ȩ���ã�
        /// </summary>
        /// <param name="username"></param>
        /// <param name="sign"></param>
        public void AuthenticationUsers(string username,bool sign) {
            if (sign)
            {
                //����Ʊ֤
                FormsAuthenticationTicket tichet =new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddHours(24), true, "");
               //��Ʊ�ݼ���
                string hashTicket = FormsAuthentication.Encrypt(tichet);
                //����Cookie���洢Ʊ��
                HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName);
                userCookie.Value = hashTicket;
                //��Cookie����ʱ����ΪƱ�ݹ���ʱ��
                userCookie.Expires = tichet.Expiration;
                userCookie.Domain = FormsAuthentication.CookieDomain;
                //����ͻ���Cookies��
                HttpContext.Current.Response.Cookies.Add(userCookie);
            }
            else {
                //����ͬ��
                FormsAuthentication.SetAuthCookie(username,true);
            }
        
        }

		/// <summary>
		/// �жϼ����ַ����Ƿ�ռ����ִ�Сд
		/// </summary>
		/// <param name="strIN"></param>
		/// <returns></returns>
        private string GetStrIN(string strIN)
		{
			if (strIN.Length == 0)
			{
				strIN = "~NULL~";
			}
			if (isCaseSensitive == false)
			{
				strIN = strIN.ToUpper();
			}
			return strIN;
		}
		/// <summary>
		/// ���ַ�������MD5����
		/// </summary>
		/// <param name="strIN">��Ҫ���ܵ��ַ���</param>
		/// <returns>����</returns>
		public string MD5Encrypt(string strIN)
		{
            strIN = GetStrIN(strIN);
			byte[] tmpByte;
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            
			tmpByte =md5.ComputeHash(GetKeyByteArray(strIN));
			md5.Clear();

			return GetStringValue(tmpByte);

		}

        /// <summary>
        /// ���ַ�������SHA1����
        /// </summary>
        /// <param name="strIN">��Ҫ���ܵ��ַ���</param>
        /// <returns>����</returns>
        public string SHA1Encrypt(string strIN)
        {
            strIN = GetStrIN(strIN);
            byte[] tmpByte;
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            
            tmpByte = sha1.ComputeHash(GetKeyByteArray(strIN));
            sha1.Clear();

            return GetStringValue(tmpByte);

        }

		/// <summary>
		/// ���ֽ�����ת�����ַ���
		/// </summary>
		/// <param name="Byte"></param>
		/// <returns></returns>
		private string GetStringValue(byte[] Byte)
		{
			string tmpString = "";

			if (this.isReturnNum == false)
			{
				ASCIIEncoding Asc = new ASCIIEncoding();
				tmpString = Asc.GetString(Byte);
			}
			else
			{
				int iCounter;

				for(iCounter=0;iCounter<Byte.Length;iCounter++)
				{
					tmpString = tmpString +
						Byte[iCounter].ToString();
				}

			}

			return tmpString;
		}

		/// <summary>
		/// ���ַ������б���,����������ֽ�������
		/// </summary>
		/// <param name="strKey"></param>
		/// <returns></returns>
		private byte[] GetKeyByteArray(string strKey)
		{

			ASCIIEncoding Asc = new ASCIIEncoding();

			int tmpStrLen = strKey.Length;
			byte[] tmpByte = new byte[tmpStrLen-1];

			tmpByte = Asc.GetBytes(strKey);

			return tmpByte;

		}
    }

