using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
  public class BoxMessageCount
    {
        private int inboxTotal;//收件箱

        public int InboxTotal
        {
            get { return inboxTotal; }
            set { inboxTotal = value; }
        }
        private int itNotRead;//未读

        public int ItNotRead
        {
            get { return itNotRead; }
            set { itNotRead = value; }
        }
        private int draftTotal;//草稿箱

        public int DraftTotal
        {
            get { return draftTotal; }
            set { draftTotal = value; }
        }
        private int dtNotRead;

        public int DtNotRead
        {
            get { return dtNotRead; }
            set { dtNotRead = value; }
        }
        private int sendedTotal;//发件箱

        public int SendedTotal
        {
            get { return sendedTotal; }
            set { sendedTotal = value; }
        }
        private int stNotRead;

        public int StNotRead
        {
            get { return stNotRead; }
            set { stNotRead = value; }
        }
        private int garbageTotal;//已删除

        public int GarbageTotal
        {
            get { return garbageTotal; }
            set { garbageTotal = value; }
        }
        private int gtNotRead;

        public int GtNotRead
        {
            get { return gtNotRead; }
            set { gtNotRead = value; }
        }
    }
}
