using System;
using System.Collections.Generic;
using System.Text;
namespace MyOffice.Utils
{
    /**
     * 分页函数参数
     */
    public class PageProcParam
    {
        private String tables;// 要查询的表或表字符串
        private String pukeyId;// 主键或唯一键
        private int count;// 0 不返回 1 返回带条件统计记录和记录 2 只统计所有记录 3 统计所有记录并返回带条件记录
        private int index;// 页数
        private int paginationScheme;// 分页方案
        private int orderType;// 排序类型 0 升序 １降序 ２ 组合排序
        private int pageSize;// 每页大小
        private String fldOrder;// 自定义排序列不含Order by
        private String showColumn;// 要显示的列，全部 "*"
        private String where;// 查询条件 不含where
        private String className;
        private Object[] obj; // 参数

        public PageProcParam()
        {
        }

        /**
         * 返回综合分页信息
         * 
         * @param tables
         *            表示 表名1，表名2...
         * @param pukeyId
         *            主键或唯一键
         * @param count
         *            0 不返回 1 返回带条件统计记录和记录 2 只统计所有记录 3 统计所有记录并返回带条件记录
         * @param index
         *            页数
         * @param paginationScheme
         *            排序方案
         * @param orderType
         *            排序类型
         * @param pageSize
         *            当前页大小
         * @param fldOrder
         *            自定义排序字段 不包含Order by
         * @param showColumn
         *            要显示的列，全部 "*"
         * @param where
         *            查询条件
         * @param className
         *            类名
         */
        public PageProcParam(String tables, String pukeyId, int count, int index,
                int paginationScheme, int orderType, int pageSize, String fldOrder,
                String showColumn, String where, string className)
        {
            this.tables = tables;
            this.pukeyId = pukeyId;
            this.count = count;
            this.index = index;
            this.paginationScheme = paginationScheme;
            this.orderType = orderType;
            this.pageSize = pageSize;
            this.fldOrder = fldOrder;
            this.showColumn = showColumn;
            this.where = where;
            this.className = className;
        }

        public String Tables
        {
            get { return tables; }
            set { tables = value; }
        }
        public String PukeyId
        {
            get { return pukeyId; }
            set { pukeyId = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        public int PaginationScheme
        {
            get { return paginationScheme; }
            set { paginationScheme = value; }
        }
        public int OrderType
        {
            get { return orderType; }
            set { orderType = value; }
        }
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        public String FldOrder
        {
            get { return fldOrder; }
            set { fldOrder = value; }
        }
        public String ShowColumn
        {
            get { return showColumn; }
            set { showColumn = value; }
        }
        public String Where
        {
            get { return where; }
            set { where = value; }
        }
        public String ClassName
        {
            get { return className; }
            set { className = value; }
        }
        public Object[] Obj
        {
            get { return obj; }
            set { obj = value; }
        }
    }
}
