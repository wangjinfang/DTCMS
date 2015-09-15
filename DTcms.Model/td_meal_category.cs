using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class meal_category
    {
        	
        private int _id;
        /// <summary>
        /// id
        /// </summary>	
        public int id
        {
            get{ return _id; }
            set{ _id = value; }
        }
        	
        private string _title;
        /// <summary>
        /// title
        /// </summary>	
        public string title
        {
            get{ return _title; }
            set{ _title = value; }
        }
        	
        private string _call_index;
        /// <summary>
        /// call_index
        /// </summary>	
        public string call_index
        {
            get{ return _call_index; }
            set{ _call_index = value; }
        }
        	
        private int _parent_id;
        /// <summary>
        /// parent_id
        /// </summary>	
        public int parent_id
        {
            get{ return _parent_id; }
            set{ _parent_id = value; }
        }
        	
        private string _class_list;
        /// <summary>
        /// class_list
        /// </summary>	
        public string class_list
        {
            get{ return _class_list; }
            set{ _class_list = value; }
        }
        	
        private int _class_layer;
        /// <summary>
        /// class_layer
        /// </summary>	
        public int class_layer
        {
            get{ return _class_layer; }
            set{ _class_layer = value; }
        }
        	
        private int _sort_id;
        /// <summary>
        /// sort_id
        /// </summary>	
        public int sort_id
        {
            get{ return _sort_id; }
            set{ _sort_id = value; }
        }
        	
        private string _link_url;
        /// <summary>
        /// link_url
        /// </summary>	
        public string link_url
        {
            get{ return _link_url; }
            set{ _link_url = value; }
        }
        	
        private string _img_url;
        /// <summary>
        /// img_url
        /// </summary>	
        public string img_url
        {
            get{ return _img_url; }
            set{ _img_url = value; }
        }
        	
        private string _content;
        /// <summary>
        /// content
        /// </summary>	
        public string content
        {
            get{ return _content; }
            set{ _content = value; }
        }
        	
        private string _seo_title;
        /// <summary>
        /// seo_title
        /// </summary>	
        public string seo_title
        {
            get{ return _seo_title; }
            set{ _seo_title = value; }
        }
        	
        private string _seo_keywords;
        /// <summary>
        /// seo_keywords
        /// </summary>	
        public string seo_keywords
        {
            get{ return _seo_keywords; }
            set{ _seo_keywords = value; }
        }
        	
        private string _seo_description;
        /// <summary>
        /// seo_description
        /// </summary>	
        public string seo_description
        {
            get{ return _seo_description; }
            set{ _seo_description = value; }
        }
            }
}