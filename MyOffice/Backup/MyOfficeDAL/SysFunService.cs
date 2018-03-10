using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using MyOffice.Models;
using System.Data.SqlClient;
using System.Data;

namespace MyOffice.DAL
{
    public class SysFunService
    {

        private  static IList<SysFun> GetSysFunBySql(string sql) {
            IList<SysFun> lists = new List<SysFun>();
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow row in table.Rows)
            {
                SysFun sysFun = new SysFun();
                sysFun.NodeId = Convert.ToInt32(row["nodeId"]);
                sysFun.DisplayName = Convert.ToString(row["displayName"]);
                sysFun.NodeURL = Convert.ToString(row["NodeURL"]);
                sysFun.DisplayOrder = Convert.ToInt32(row["DisplayOrder"]);
                sysFun.ParentNodeId = Convert.ToInt32(row["ParentNodeId"]);
                lists.Add(sysFun);
            }

            return lists;
        }
        private static IList<SysFun> GetSysFunBySql(string sql, params SqlParameter[] parameters)
        {
            IList<SysFun> lists = new List<SysFun>();
            DataTable table = DBHelper.GetDataSet(sql,parameters);
            foreach (DataRow row in table.Rows)
            {
                SysFun sysFun = new SysFun();
                sysFun.NodeId = Convert.ToInt32(row["nodeId"]);
                sysFun.DisplayName = Convert.ToString(row["displayName"]);
                sysFun.NodeURL = Convert.ToString(row["NodeURL"]);
                sysFun.DisplayOrder = Convert.ToInt32(row["DisplayOrder"]);
                sysFun.ParentNodeId = Convert.ToInt32(row["ParentNodeId"]);
                lists.Add(sysFun);
            }
           
            return lists;
        }

        /// <summary>
        /// ��������Id���Ҷ���
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public static SysFun GetSysFunById(int nodeId) {
            string sql = "select * from sysFun where NodeId=@NodeId";
            SqlParameter[] parameters ={new SqlParameter("@NodeId",nodeId) };
            return GetSysFunBySql(sql,parameters)[0];
        }

        /// <summary>
        /// �������и��ڵ�
        /// </summary>
        /// <returns></returns>
        public static IList<SysFun> GetAllParentSys() {
            string sql = "select * from sysFun where parentNodeId=0";
            return GetSysFunBySql(sql);
        }

        /// <summary>
        /// ���ݽ�ɫId����Ȩ�����ڵ�
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static IList<SysFun> GetParentNodeByRoleId(int  roleId) {
            string sql = "select s.nodeId,s.DisplayName,s.NodeURL,s.DisplayOrder,s.parentNodeId  from roleRight as r inner join sysfun as s on r.nodeId=s.nodeId  where r.roleId=@roleId and s.parentNodeId=0  order by s.DisplayOrder";
            SqlParameter[] parameters ={ new SqlParameter("@roleId",roleId) };
            return GetSysFunBySql(sql,parameters);
        }

       /// <summary>
        /// ���ݽ�ɫId�͸��ڵ�Id����Ȩ���ӽڵ�
       /// </summary>
       /// <param name="roleId"></param>
       /// <param name="parentNodeId"></param>
       /// <returns></returns>
        public static IList<SysFun> GetNodeByParentIdAndRoleId(int roleId,int parentNodeId)
        {
            string sql = "select s.nodeId,s.DisplayName,s.NodeURL,s.DisplayOrder,s.parentNodeId  from roleRight as r inner join sysfun as s on r.nodeId=s.nodeId  where r.roleId=@roleId and s.parentNodeId=@parentNodeId  order by s.DisplayOrder ";
            SqlParameter[] parameters ={ new SqlParameter("@roleId", roleId), new SqlParameter("@parentNodeId",parentNodeId) };
            return GetSysFunBySql(sql, parameters);
        }


        /// <summary>
        /// ���ݸ��ڵ�Id�����ӽڵ㼯��
        /// </summary>
        /// <param name="parentNodeId"></param>
        /// <returns></returns>
        public static IList<SysFun> GetNodeByParentId(int parentNodeId) {
            string sql = "select * from sysFun where parentNodeId=@parentNodeId order by displayOrder";
            SqlParameter[] parameters ={ new SqlParameter("@parentNodeId",parentNodeId) };
            return GetSysFunBySql(sql, parameters);
        }

        /// <summary>
        /// ��ô˸��ڵ����ӽڵ������
        /// </summary>
        /// <param name="parentNodeId"></param>
        /// <returns></returns>
        public static int GetCountByParentId(int parentNodeId) {
            string sql = "select count(*) from sysFun where parentNodeId=0";
            SqlParameter[] parameters ={ new SqlParameter("@parentNodeId", parentNodeId) };
            return Convert.ToInt32(DBHelper.GetScalar(sql,parameters));
        }
        /// <summary>
        /// ��������ID���Row_number   (�˵�����ʱ��)
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns>SQL2005�е�row_number()����  �����ӽڵ����丸�ڵ�ĵڼ�λ</returns>
        public static int GetRow_NumberByNodeId(int nodeId,int parentNodeId) {
            string sql = "select number from(select row_number() over(order by displayOrder) as number ,nodeId,displayOrder from sysFun where parentNodeId=@parentNodeId) as sysFunByNumber where nodeId=@nodeId";
            SqlParameter[] parameters ={ new SqlParameter("@parentNodeId", parentNodeId), new SqlParameter("@nodeId", nodeId) };
            return Convert.ToInt32(DBHelper.GetScalar(sql, parameters));
        }

        /// <summary>
        /// ����Row_Number(sql����е���) ��ö�Ӧ������ID (�˵�����ʱ��)
        /// </summary>
        /// <param name="row_Number"></param>
        /// <returns></returns>
        public static int GetNodeIdByRow_Number(int row_Number, int parentNodeId)
        {
            string sql = "select nodeId from(select row_number() over(order by displayOrder) as number ,nodeId,displayOrder from sysFun where parentNodeId=@parentNodeId) as sysFunByNumber where number=@number";
            SqlParameter[] parameters ={new SqlParameter("@parentNodeId",parentNodeId), new SqlParameter("@number",row_Number)};
            return Convert.ToInt32(DBHelper.GetScalar(sql, parameters));
        }

        /// <summary>
        /// �޸�NodeId����Ӧ�ļ�¼ (ֻ�޸�DisplayOrder����)
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="sys"></param>
        /// <returns></returns>
        public static int UpdateSysFun(int nodeId,SysFun sys) {
            string sql = "update SysFun set DisplayOrder=@DisplayOrder where nodeId=@nodeId";
            SqlParameter[] parameters ={ new SqlParameter("@DisplayOrder", sys.DisplayOrder), new SqlParameter("@nodeId", nodeId) };
            return DBHelper.ExecuteCommand(sql,parameters);
        }


        /// <summary>
        /// ��������ɾ������
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public static int delSysByNodeId(int nodeId) {
            string sql = "delete from SysFun where nodeId=@nodeId";
            SqlParameter[] parameters ={ new SqlParameter("@nodeId", nodeId) };
            return DBHelper.ExecuteCommand(sql,parameters);
        }
    }
}
