namespace com.etsoo.GoogleApi.Maps.Place.RQ
{
    /// <summary>
    /// Place field enum
    /// 地址字段枚举
    /// </summary>
    [Flags]
    public enum PlaceField
    {
        /// <summary>
        /// Formatted Address
        /// 格式化地址
        /// </summary>
        Formatted_Address = 1 << 1,

        /// <summary>
        /// Geometry
        /// 地理
        /// </summary>
        Geometry = 1 << 2,

        /// <summary>
        /// Icon
        /// 图标
        /// </summary>
        Icon = 1 << 3,

        /// <summary>
        /// Name
        /// 名称
        /// </summary>
        Name = 1 << 4,

        /// <summary>
        /// Photos
        /// 照片
        /// </summary>
        Photos = 1 << 5,

        /// <summary>
        /// Place_Id
        /// 地址编号
        /// </summary>
        Place_Id = 1 << 6,

        /// <summary>
        /// Plus_Code
        /// https://maps.google.com/pluscodes/
        /// </summary>
        Plus_Code = 1 << 7,

        /// <summary>
        /// Types
        /// 类型
        /// </summary>
        Types = 1 << 8,

        /// <summary>
        /// Opening Hours
        /// 开放时间
        /// </summary>
        Opening_Hours = 1 << 9,

        /// <summary>
        /// Price Level
        /// 价格水平
        /// </summary>
        Price_Level = 1 << 10,

        /// <summary>
        /// Rating
        /// 评分
        /// </summary>
        Rating = 1 << 11,

        /// <summary>
        /// User Ratings Total
        /// 总评分
        /// </summary>
        User_Ratings_Total = 1 << 12,

        /// <summary>
        /// Business Status
        /// 业务状况
        /// </summary>
        Business_Status = 1 << 13,

        /// <summary>
        /// Basic
        /// 基础信息
        /// </summary>
        Basic = Formatted_Address | Geometry | Icon | Name | Photos | Place_Id | Plus_Code | Types | Business_Status
    }
}
