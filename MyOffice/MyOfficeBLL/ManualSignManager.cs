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
        ///  处理考勤统计信息
        /// </summary>
        /// <param name="msList">传入考勤信息集合</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param> 
        /// <returns>返回处理后的统计结果</returns>
        public static IList<ManualSign> GetManualSignCountInfo(IList<ManualSign> msList, string beginTime, string endTime)
        {   //最终结果集
            List<ManualSign> countList = new List<ManualSign>();
            #region 单独封装用户信息
            List<User> users = new List<User>();
            foreach (ManualSign sign in msList)
            {
                if (!users.Contains(sign.User))
                {
                    users.Add(sign.User);
                }
            }
            #endregion
            //重新封装 
            // WorkTime wt = WorkTimeManager.GetWorkTimeByWorkTimeId(1);
            TimeSpan signInTime = TimeSpan.Parse("8:30:00");//签到时间
            TimeSpan signOutTime = TimeSpan.Parse("17:30:00");//签退时间
            //正常出勤
          //  int workDay = GetWorkDays(DateTime.Parse(beginTime.Trim()), DateTime.Parse(endTime.Trim()));
            int workDay = DifferDate(DateTime.Parse(beginTime.Trim()), DateTime.Parse(endTime.Trim()));
            foreach (User us in users)
            {
                #region
                //迟到        早退         矿工次数     签到次数
                int late = 0, earlyOut = 0, ruancy = 0, qRuancy=0; 
                //迟到早退不良出勤
                List<string> lateSignOut = new List<string>();
                foreach (ManualSign sign in msList)
                {
                    TimeSpan recordTime = TimeSpan.Parse(string.Format("{0:HH:mm:ss}", sign.SignTime));//实际记录时间
                    //迟到
                    if (us.UserId.Equals(sign.User.UserId) && recordTime.CompareTo(signInTime) > 0 && sign.SignTag == 0)
                    {
                        ++late;
                        if (!lateSignOut.Contains(string.Format("{0:yyyy-MM-dd}", sign.SignTime))) lateSignOut.Add(string.Format("{0:yyyy-MM-dd}", sign.SignTime));
                    }
                    //早退
                    if (us.UserId.Equals(sign.User.UserId) && recordTime.CompareTo(signInTime) >= 0 && recordTime.CompareTo(signOutTime) < 0 && sign.SignTag ==1)
                    {
                        ++earlyOut;
                        if (!lateSignOut.Contains(string.Format("{0:yyyy-MM-dd}", sign.SignTime))) lateSignOut.Add(string.Format("{0:yyyy-MM-dd}", sign.SignTime));
                    }
                    //签到次数
                    if (us.UserId.Equals(sign.User.UserId))
                    {
                        if (sign.SignTag == 0)
                        {
                            ++qRuancy;
                        }                        
                    }
                    
                }

                //旷工次数（旷工的次数=正常出勤-签到的次数）
                ruancy = workDay - qRuancy ;
                //出勤率(出勤率=（旷工次数+迟到早退次数）/全勤数)
                double orate = qRuancy / workDay;// Math.Round(Convert.ToDouble(qRuancy / workDay), 2) * 100;
                double signORate = Math.Round(orate,2)*100;
                ruancy = ruancy < 0 ? 0 : ruancy;
                #endregion
                countList.Add(new ManualSign(us, late, earlyOut, ruancy, signORate));
            }
            return countList;
        }

        /// <summary>
        /// 获得全勤工作日
        /// </summary>
        /// <param name="beginTime">开始</param>
        /// <param name="endTime">结束</param>
        /// <returns>返回范围内工作日</returns>
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
            int result = 0;//返回值，即endTime和startTime之间的工作日数

            TimeSpan ts = endTime - startTime;//计算endTime和startTime之间相差多少天
            double totalDays = ts.TotalDays;
            //Math.Ceiling(double d) 大于或等于 d 的最小整数
            double intTotalDays = Math.Ceiling(totalDays);
            int differDays = int.Parse(intTotalDays.ToString());//相差天数的int值
            //循环判断临时的日期值是不是星期六或星期天，
            //如果既不是星期六，也不是星期天，则该天为工作日，result加1
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
        /// 员 工 考 勤 历 史 记 录 查  询
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="branchId">机构</param>
        /// <param name="departId">部门</param>
        /// <param name="userId">用户Id</param>
        /// <param name="userName">用户名</param>
        /// <returns>历史记录集合</returns>
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


                //当机构部门用户名都不为空时
                if (branchId != null && !branchId.Equals("") && departId != null && !departId.Equals("") && userName != null && !userName.Equals(""))
                {
                    sqlview += " and BranchId = '" + branchId + "' and DepartId='" + departId + "' and UserName like'" + userName + "%'";
                }

                //当机构部门都不为空时
                if (branchId != null && !branchId.Equals("") && departId != null && !departId.Equals(""))
                {
                    sqlview += " and BranchId = '" + branchId + "' and DepartId='" + departId + "'";
                }

                //当机构，姓名不为空时
                if (branchId != null && !branchId.Equals("") && userName != null && !userName.Equals(""))
                {
                    sqlview += " and BranchId = '" + branchId + "' and UserName like '" + userName + "%'";
                }
                //当机构不为空时
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
