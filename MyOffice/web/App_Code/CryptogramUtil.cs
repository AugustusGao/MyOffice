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

    //密码加密类
    public  class CryptogramUtil
    {
        private bool isReturnNum;//是否返回为加密后字符的Byte代码
        private bool isCaseSensitive;//是否区分大小写。

        /// <summary>
        /// 加密带参构造方法
        /// </summary>
        /// <param name="IsCaseSensitive">是否返回为加密后字符的Byte代码</param>
        /// <param name="IsReturnNum">是否区分大小写</param>
        public CryptogramUtil(bool isCaseSensitive, bool isReturnNum)
		{
			this.isReturnNum = isReturnNum;
			this.isCaseSensitive = isCaseSensitive;
		}

        /// <summary>
        /// 对字符串进行SHA256加密
        /// </summary>
        /// <param name="strIN">密码</param>
        /// <returns>密文</returns>
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
        /// 对字符串进行SHA512加密
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
        /// 使用DES加密
        /// </summary>
        /// <param name="originalValue">待加密的字符串</param>
        /// <param name="key">密钥(最大长度8)</param>
        /// <param name="IV">初始化向量(最大长度8)</param>
        /// <returns>加密后的字符串</returns>
        public string DESEncrypt(string originalValue, string key, string IV)
        {
            //将key和IV处理成8个字符
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
        /// 使用DES加密
        /// </summary>
        /// <param name="originalValue">待加密的字符串</param>
        /// <param name="key">密钥(最大长度8)</param>
        /// <returns>加密后的字符串</returns>
        public string DESEncrypt(string originalValue, string key)
        {
            return DESEncrypt(originalValue, key, key);
        }
        /// <summary>
        ///  使用DES解密
        /// </summary>
        /// <param name="encryptedValue">待解密的字符串</param>
        /// <param name="key">密钥(最大长度8)</param>
        /// <returns>解密后的字符串</returns>
        public string DESDecrypt(string encryptedValue, string key)
        {
            return DESDecrypt(encryptedValue, key, key);
        }

        /// <summary>
        /// 使用DES解密
        /// </summary>
        /// <param name="encryptedValue">待解密的字符串</param>
        /// <param name="key">密钥(最大长度8)</param>
        /// <param name="IV">m初始化向量(最大长度8)</param>
        /// <returns>解密后的字符串</returns>
        public string DESDecrypt(string encryptedValue, string key, string IV)
        {
            //将key和IV处理成8个字符
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
        /// 密码加密（Web）
        /// </summary>
        /// <param name="PasswordString">密码</param>
        /// <param name="format">加密格式枚举类型(Clear、MD5或SHA1)</param>
        /// <returns>密文</returns>
        public  string Encrypt(string PasswordString,FormsAuthPasswordFormat format) {
            string password = string.Empty;
            if (!string.IsNullOrEmpty(PasswordString)) {
                password = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString,format.ToString());
            }
            return password;
        }

        /// <summary>
        /// 身份验证（配合授权配置）
        /// </summary>
        /// <param name="username"></param>
        /// <param name="sign"></param>
        public void AuthenticationUsers(string username,bool sign) {
            if (sign)
            {
                //创建票证
                FormsAuthenticationTicket tichet =new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddHours(24), true, "");
               //给票据加密
                string hashTicket = FormsAuthentication.Encrypt(tichet);
                //创建Cookie，存储票据
                HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName);
                userCookie.Value = hashTicket;
                //将Cookie过期时间设为票据过期时间
                userCookie.Expires = tichet.Expiration;
                userCookie.Domain = FormsAuthentication.CookieDomain;
                //放入客户端Cookies中
                HttpContext.Current.Response.Cookies.Add(userCookie);
            }
            else {
                //作用同上
                FormsAuthentication.SetAuthCookie(username,true);
            }
        
        }

		/// <summary>
		/// 判断加密字符串是否空及区分大小写
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
		/// 对字符串进行MD5加密
		/// </summary>
		/// <param name="strIN">需要加密的字符串</param>
		/// <returns>密文</returns>
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
        /// 对字符串进行SHA1加密
        /// </summary>
        /// <param name="strIN">需要加密的字符串</param>
        /// <returns>密文</returns>
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
		/// 将字节数组转换成字符串
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
		/// 对字符串进行编码,将结果存在字节数组中
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

