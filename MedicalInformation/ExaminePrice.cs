namespace Model
{
    /// <summary>
    /// 检查费
    /// </summary>
    public class ExaminePrice
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string CheckID { set; get; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string CheckName { set; get; }
        /// <summary>
        /// 检查费用
        /// </summary>
        public decimal CheckPrice { set; get; }
    }
}
