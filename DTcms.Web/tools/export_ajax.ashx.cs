using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

using DTcms.Common;
using System.Data;

namespace DTcms.Web.tools
{
    /// <summary>
    /// export_ajax 的摘要说明
    /// </summary>
    public class export_ajax : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            int page = DTRequest.GetQueryInt("page");
            int pagesize = DTRequest.GetQueryInt("pagesize");
            string where = DTRequest.GetQueryString("where");
            string order = DTRequest.GetQueryString("order");

            BLL.orders bll = new BLL.orders();
            int totalCount;
            DataTable dt = bll.GetList(pagesize, page, where, order, out totalCount).Tables[0];

            //DataTable new_dt = new DataTable();
            //new_dt.Columns.Add("网店订单编号");
            //new_dt.Columns.Add("商品名称");
            //new_dt.Columns.Add("商品编码");
            //new_dt.Columns.Add("数量");
            //new_dt.Columns.Add("单价");
            //new_dt.Columns.Add("订单日期");
            //new_dt.Columns.Add("收货人名称");
            //new_dt.Columns.Add("收货人电话");
            //new_dt.Columns.Add("收货人手机");
            //new_dt.Columns.Add("省份");
            //new_dt.Columns.Add("市");
            //new_dt.Columns.Add("区");
            //new_dt.Columns.Add("收货地址");
            //new_dt.Columns.Add("买家帐号");
            //new_dt.Columns.Add("物流公司");
            //new_dt.Columns.Add("物流单号");
            //new_dt.Columns.Add("买家运费");
            //new_dt.Columns.Add("买家留言");
            //new_dt.Columns.Add("卖家备注");
            //new_dt.Columns.Add("发票抬头");

            string str_table = "<table border=\"1\"><tr>"
                + "<td>网店订单编号</td>"
                + "<td>商品名称</td>"
                + "<td>商品编码</td>"
                + "<td>数量</td>"
                + "<td>单价</td>"
                + "<td>订单日期</td>"
                + "<td>收货人名称</td>"
                + "<td>收货人电话</td>"
                + "<td>收货人手机</td>"
                + "<td>省份</td>"
                + "<td>市</td>"
                + "<td>区</td>"
                + "<td>收货地址</td>"
                + "<td>买家帐号</td>"
                + "<td>物流公司</td>"
                + "<td>物流单号</td>"
                + "<td>买家运费</td>"
                + "<td>买家留言</td>"
                + "<td>卖家备注</td>"
                + "<td>发票抬头</td>"
                + "</tr>";

            foreach (DataRow dr in dt.Rows)
            {
                Model.orders model = bll.GetModel(Convert.ToInt32(dr["id"]));
                if (model != null)
                {
                    int good_count = 1;
                    if (model.order_goods != null)
                    {
                        good_count = model.order_goods.Count;
                    }
                    string[] address = model.address.Split('|');
                    int flg = 0;
                    if (model.order_goods != null)
                    {
                        foreach (Model.order_goods item in model.order_goods)
                        {
                            str_table += "<tr>";
                            if (flg < 1)
                            {
                                str_table += "<td rowspan=\"" + good_count + "\">" + model.order_no + "</td>";
                            }
                            string unit = "";
                            if (!string.IsNullOrEmpty(item.unit))
                            {
                                unit = "单位:" + item.unit;
                            }

                            str_table += "<td>" + item.goods_title + "(" + new DTcms.BLL.standard_value().get_standrad(item.standard) + unit + ")" + "</td>";
                            str_table += "<td>" + item.good_no + "</td>";
                            str_table += "<td>" + item.quantity + "</td>";
                            str_table += "<td>" + item.real_price + "</td>";

                            if (flg < 1)
                            {
                                str_table += "<td rowspan=\"" + good_count + "\">" + model.add_time + "</td>";
                                str_table += "<td rowspan=\"" + good_count + "\">" + model.accept_name + "</td>";
                                str_table += "<td rowspan=\"" + good_count + "\">" + model.telphone + "</td>";
                                str_table += "<td rowspan=\"" + good_count + "\">" + model.mobile + "</td>";
                                if (address.Length >= 1)
                                {
                                    str_table += "<td rowspan=\"" + good_count + "\">" + address[0] + "</td>";
                                }
                                else
                                {
                                    str_table += "<td rowspan=\"" + good_count + "\"></td>";
                                }
                                if (address.Length >= 2)
                                {
                                    str_table += "<td rowspan=\"" + good_count + "\">" + address[1] + "</td>";
                                }
                                else
                                {
                                    str_table += "<td rowspan=\"" + good_count + "\"></td>";
                                }
                                if (address.Length >= 3)
                                {
                                    str_table += "<td rowspan=\"" + good_count + "\">" + address[2] + "</td>";
                                }
                                else
                                {
                                    str_table += "<td rowspan=\"" + good_count + "\"></td>";
                                }
                                if (address.Length >= 4)
                                {
                                    str_table += "<td rowspan=\"" + good_count + "\">" + address[3] + "</td>";
                                }
                                else
                                {
                                    str_table += "<td rowspan=\"" + good_count + "\"></td>";
                                }
                                str_table += "<td rowspan=\"" + good_count + "\">" + model.user_name + "</td>";
                                str_table += "<td rowspan=\"" + good_count + "\">" + (new BLL.express().GetModel(model.express_id) == null ? "" : new BLL.express().GetModel(model.express_id).title) + "</td>";
                                str_table += "<td rowspan=\"" + good_count + "\">" + model.express_no + "</td>";
                                str_table += "<td rowspan=\"" + good_count + "\">" + model.express_fee + "</td>";
                                str_table += "<td rowspan=\"" + good_count + "\">" + model.message + "</td>";
                                str_table += "<td rowspan=\"" + good_count + "\">" + model.remark + "</td>";
                                str_table += "<td rowspan=\"" + good_count + "\">" + "" + "</td>"; 
                            }

                            str_table += "</tr>";
                            flg++;
                        }
                    }

                    
                }
            }

            str_table += "</table>";

            context.Response.Clear();
            context.Response.Buffer = true;
            context.Response.AppendHeader("Content-Disposition", "attachment;filename=订单" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.ContentType = "application/vnd.ms-excel";
            context.Response.Write(str_table);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
