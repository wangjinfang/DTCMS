using System;
namespace DTcms.Model
{
    [Serializable]
    public partial class meal_good
    {

        private int _meal_id;
        /// <summary>
        /// 套餐ID
        /// </summary>	
        public int meal_id
        {
            get { return _meal_id; }
            set { _meal_id = value; }
        }

        private int _group_id;
        /// <summary>
        /// 会员组别ID
        /// </summary>	
        public int group_id
        {
            get { return _group_id; }
            set { _group_id = value; }
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

        private decimal _standard_price_id;
        /// <summary>
        /// 规格价格ID
        /// </summary>	
        public decimal standard_price_id
        {
            get { return _standard_price_id; }
            set { _standard_price_id = value; }
        }

        private int _unit_id;
        /// <summary>
        /// 单位ID
        /// </summary>	
        public int unit_id
        {
            get { return _unit_id; }
            set { _unit_id = value; }
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

        private decimal _standard_price;
        /// <summary>
        /// 规格价格
        /// </summary>	
        public decimal standard_price
        {
            get { return _standard_price; }
            set { _standard_price = value; }
        }

        private decimal _standard_group_price;
        /// <summary>
        /// 规格会员价格
        /// </summary>	
        public decimal standard_group_price
        {
            get { return _standard_group_price; }
            set { _standard_group_price = value; }
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
        /// 活动价格
        /// </summary>
        public decimal action_price
        {
            get { return _action_price; }
            set { _action_price = value; }
        }

        private int _quantity = 0;
        /// <summary>
        /// 数量
        /// </summary>
        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
    }
}