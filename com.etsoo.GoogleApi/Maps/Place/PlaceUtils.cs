using com.etsoo.GoogleApi.Maps.Place.RQ;
using com.etsoo.Utils;

namespace com.etsoo.GoogleApi.Maps.Place
{
    /// <summary>
    /// Place utils
    /// 地点工具
    /// </summary>
    public static class PlaceUtils
    {
        /// <summary>
        /// Format place fields
        /// 格式化地点字段
        /// </summary>
        /// <param name="fields">Fields</param>
        /// <returns>Result</returns>
        public static string FormatFields(PlaceField fields)
        {
            var keys = fields.GetKeys().Where(field => field != "Basic");
            return string.Join(",", keys).ToLower();
        }
    }
}
