using System;
namespace DTcms.Model
{
    [Serializable]
    public partial class standard_price
    {

        private decimal _id;
        /// <summary>
        /// id
        /// </summary>	
        public decimal id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _good_id;
        /// <summary>
        /// 商品ID
        /// </summary>	
        public int good_id
        {
            get { return _good_id; }
            set { _good_id = value; }
        }

        private string _standard_ids;
        /// <summary>
        /// 规格名称ID   1,2
        /// </summary>	
        public string standard_ids
        {
            get { return _standard_ids; }
            set { _standard_ids = value; }
        }

        private string _standards;
        /// <summary>
        /// 规格名称   颜色，大小
        /// </summary>	
        public string standards
        {
            get { return _standards; }
            set { _standards = value; }
        }

        private string _standard_value_ids;
        /// <summary>
        /// 规格值ID   1,2
        /// </summary>	
        public string standard_value_ids
        {
            get { return _standard_value_ids; }
            set { _standard_value_ids = value; }
        }

        private string _standard_values;
        /// <summary>
        /// 规格值：红色,大
        /// </summary>	
        public string standard_values
        {
            get { return _standard_values; }
            set { _standard_values = value; }
        }

        private decimal _market_price;
        /// <summary>
        /// 市场价
        /// </summary>	
        public decimal market_price
        {
            get { return _market_price; }
            set { _market_price = value; }
        }

        private decimal _sell_price;
        /// <summary>
        /// 销售价
        /// </summary>	
        public decimal sell_price
        {
            get { return _sell_price; }
            set { _sell_price = value; }
        }

        private int _stock_quantity;
        /// <summary>
        /// 库存
        /// </summary>	
        public int stock_quantity
        {
            get { return _stock_quantity; }
            set { _stock_quantity = value; }
        }

        private DateTime _add_time;
        /// <summary>
        /// add_time
        /// </summary>	
        public DateTime add_time
        {
            get { return _add_time; }
            set { _add_time = value; }
        }

        private decimal _action_price;
        /// <summary>
        /// 活动价
        /// </summary>	
        public decimal action_price
        {
            get { return _action_price; }
            set { _action_price = value; }
        }

        private decimal _user_price;
        /// <summary>
        /// 会员价
        /// </summary>	
        public decimal user_price
        {
            get { return _user_price; }
            set { _user_price = value; }
        }

        private string _good_no;
        /// <summary>
        /// 规格商品编号
        /// </summary>
        public string good_no
        {
            get { return _good_no; }
            set { _good_no = value; }
        }
    }
}