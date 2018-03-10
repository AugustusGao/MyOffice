using System;
using System.Collections.Generic;
using System.Text;
using MyOffice.DAL;
using MyOffice.Models;

namespace MyOffice.BLL
{
    public class ManualSignManager
    {
        /// <summary>
        ///  ������ͳ����Ϣ
        /// </summary>
        /// <param name="msList">���뿼����Ϣ����</param>
        /// <param name="beginTime">��ʼʱ��</param>
        /// <param name="endTime">����ʱ��</param> 
        /// <returns>���ش�����ͳ�ƽ��</returns>
        public static IList<ManualSign> GetManualSignCountInfo(IList<ManualSign> msList, string beginTime, string endTime)
        {   //���ս����
            List<ManualSign> countList = new List<ManualSign>();
            #region ������װ�û���Ϣ
            List<User> users = new List<User>();
            foreach (ManualSign sign in msList)
            {
                if (!users.Contains(sign.User))
                {
                    users.Add(sign.User);
                }
            }
            #endregion
            //���·�װ 
            // WorkTime wt = WorkTimeManager.GetWorkTimeByWorkTimeId(1);
            TimeSpan signInTime = TimeSpan.Parse("8:30:00");//ǩ��ʱ��
            TimeSpan signOutTime = TimeSpan.Parse("17:30:00");//ǩ��ʱ��
            //��������
          //  int workDay = GetWorkDays(DateTime.Parse(beginTime.Trim()), DateTime.Parse(endTime.Trim()));
            int workDay = DifferDate(DateTime.Parse(beginTime.Trim()), DateTime.Parse(endTime.Trim()));
            foreach (User us in users)
            {
                #region
                //�ٵ�        ����         �󹤴���     ǩ������
                int late = 0, earlyOut = 0, ruancy = 0, qRuancy=0; 
                //�ٵ����˲�������
                List<string> lateSignOut = new List<string>();
                foreach (ManualSign sign in msList)
                {
                    TimeSpan recordTime = TimeSpan.Parse(string.Format("{0:HH:mm:ss}", sign.SignTime));//ʵ�ʼ�¼ʱ��
                    //�ٵ�
                    if (us.UserId.Equals(sign.User.UserId) && recordTime.CompareTo(signInTime) > 0 && sign.SignTag == 0)
                    {
                        ++late;
                        if (!lateSignOut.Contains(string.Format("{0:yyyy-MM-dd}", sign.SignTime))) lateSignOut.Add(string.Format("{0:yyyy-MM-dd}", sign.SignTime));
                    }
                    //����
                    if (us.UserId.Equals(sign.User.UserId) && recordTime.CompareTo(signInTime) >= 0 && recordTime.CompareTo(signOutTime) < 0 && sign.SignTag ==1)
                    {
                        ++earlyOut;
                        if (!lateSignOut.Contains(string.Format("{0:yyyy-MM-dd}", sign.SignTime))) lateSignOut.Add(string.Format("{0:yyyy-MM-dd}", sign.SignTime));
                    }
                    //ǩ������
                    if (us.UserId.Equals(sign.User.UserId))
                    {
                        if (sign.SignTag == 0)
                        {
                            ++qRuancy;
                        }                        
                    }
                    
                }

                //���������������Ĵ���=��������-ǩ���Ĵ�����
                ruancy = workDay - qRuancy ;
                //������(������=����������+�ٵ����˴�����/ȫ����)
                double orate = qRuancy / workDay;// Math.Round(Convert.ToDouble(qRuancy / workDay), 2) * 100;
                double signORate = Math.Round(orate,2)*100;
                ruancy = ruancy < 0 ? 0 : ruancy;
                #endregion
                countList.Add(new ManualSign(us, late, earlyOut, ruancy, signORate));
            }
            return countList;
        }

        /// <summary>
        /// ���ȫ�ڹ�����
        /// </summary>
        /// <param name="beginTime">��ʼ</param>
        /// <param name="endTime">����</param>
        /// <returns>���ط�Χ�ڹ�����</returns>
        //private static int GetWorkDays(DateTime beginTime, DateTime endTime)
        //{
        //    int s = 0;
        //    int week = (int)beginTime.DayOfWeek;
        //    int end = ((TimeSpan)endTime.Subtract(beginTime)).Days;
        //    if (week != 0)
        //    {
        //        s = 6 - week;
        //        end = end - 8 + week;
        //    }
        //    return ((end / 7) * 5) + (((end % 7) < 6) ? (end % 7) : 0);
        //}

        private static int DifferDate(DateTime startTime, DateTime endTime)
        {
            int result = 0;//����ֵ����endTime��startTime֮��Ĺ�������

            TimeSpan ts = endTime - startTime;//����endTime��startTime֮����������
            double totalDays = ts.TotalDays;
            //Math.Ceiling(double d) ���ڻ���� d ����С����
            double intTotalDays = Math.Ceiling(totalDays);
            int differDays = int.Parse(intTotalDays.ToString());//���������intֵ
            //ѭ���ж���ʱ������ֵ�ǲ����������������죬
            //����Ȳ�����������Ҳ���������죬�����Ϊ�����գ�result��1
            for (int i = 0; i < differDays; i++)
            {
                DateTime dtTemp = startTime.AddDays(i);
                if ((dtTemp.DayOfWeek != DayOfWeek.Sunday) && (dtTemp.DayOfWeek != DayOfWeek.Saturday))
                {
                    result++;
                }

            }
            return result;

        }

        public static ManualSign AddManualSign(ManualSign manualSign)
        {
            return ManualSignService.AddManualSign(manualSign);
        }
        public static ManualSign GetManualSignById(int newId)
        {
            return ManualSignService.GetManualSignById(newId);
        }
        public static void DeleteManualSignBySignId(int signId)
        {
            ManualSignService.DeleteManualSignBySignId(signId);
        }
        public static void ModifyManualSign(ManualSign manualSign)
        {
            ManualSignService.ModifyManualSign(manualSign);
        }
        public static int GetManualSignState(bool sign, string userId)
        {
            return ManualSignService.GetManualSignState(sign, userId);
        }
        /// <summary>
        /// Ա �� �� �� �� ʷ �� ¼ ��  ѯ
        /// </summary>
        /// <param name="beginTime">��ʼʱ��</param>
        /// <param name="endTime">����ʱ��</param>
        /// <param name="branchId">����</param>
        /// <param name="departId">����</param>
        /// <param name="userId">�û�Id</param>
        /// <param name="userName">�û���</param>
        /// <returns>��ʷ��¼����</returns>
        public static IList<ManualSign> SearchManualSignByCondition(string beginTime, string endTime, string branchId, string departId, string userId, string userName)
        {
            if (beginTime != null && !beginTime.Equals("") && endTime != null && !endTime.Equals(""))
            {
                #region
                string sqlview = "select * from viewManualSignHistory where SignTime between '" + string.Format("{0:yyyy-MM-dd 0:00:00}", DateTime.Parse(beginTime.Trim())) + "' and '" + string.Format("{0:yyyy-MM-dd 23:59:59}", DateTime.Parse(endTime.Trim())) + "' ";
                if (userId != null && !userId.Equals(""))
                {
                    sqlview += " and UserId = '" + userId + "'";
                }


                if (userName != null && !userName.Equals(""))
                {
                    sqlview += " and UserName like '" + userName + "%'";
                }


                //�����������û�������Ϊ��ʱ
                if (branchId != null && !branchId.Equals("") && departId != null && !departId.Equals("") && userName != null && !userName.Equals(""))
                {
                    sqlview += " and BranchId = '" + branchId + "' and DepartId='" + departId + "' and UserName like'" + userName + "%'";
                }

                //���������Ŷ���Ϊ��ʱ
                if (branchId != null && !branchId.Equals("") && departId != null && !departId.Equals(""))
                {
                    sqlview += " and BranchId = '" + branchId + "' and DepartId='" + departId + "'";
                }

                //��������������Ϊ��ʱ
                if (branchId != null && !branchId.Equals("") && userName != null && !userName.Equals(""))
                {
                    sqlview += " and BranchId = '" + branchId + "' and UserName like '" + userName + "%'";
                }
                //��������Ϊ��ʱ
                if (branchId != null && !branchId.Equals(""))
                {
                    sqlview += " and BranchId = '" + branchId + "'";
                }
                #endregion
                return ManualSignService.GetManualSignBySql(sqlview);
            }
            return null;
        }
    }

}
