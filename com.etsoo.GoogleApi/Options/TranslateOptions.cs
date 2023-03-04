namespace com.etsoo.GoogleApi.Options
{
    /// <summary>
    /// Translate API options
    /// 翻译接口参数
    /// </summary>
    public record TranslateOptions : CloudOptions
    {
        /// <summary>
        /// Translate project id
        /// 翻译项目编号
        /// https://cloud.google.com/translate/docs/setup
        /// </summary>
        public required string TranslateProjectId { get; init; }
    }
}
