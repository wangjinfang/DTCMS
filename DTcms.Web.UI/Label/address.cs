using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.UI
{
    public partial class BasePage : System.Web.UI.Page
    {
        
        protected DataTable get_address_list(int top,string strwhere,string strorder)
        {
            BLL.address bll = new BLL.address();
            return bll.GetList(top, strwhere, strorder).Tables[0];
        }

        protected DataTable get_address_list(int pageSize, int pageIndex, string strWhere, string strorder, out int totalcount)
        {
            BLL.address bll = new BLL.address();
            return bll.GetList(pageSize, pageIndex, strWhere, strorder, out totalcount).Tables[0];
        }
    }
}
