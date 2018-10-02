namespace Model
{
    public static class CommonInfo
    {
        public enum ConfigStyle
        {
            职称类别 = 1,
            计量单位 = 2,
            药品类别 = 3,
            收费类型 = 4,
            用户权限 = 5,
            生产厂商,
            用法 = 41,
            频率 = 37,
            方案类别 = 56,
            辅助检查 = 84
        }
        public enum UserPowers
        {
            一般权限 = 31,
            人员管理 = 29,
            门诊量管理 = 30
        }
    }
}