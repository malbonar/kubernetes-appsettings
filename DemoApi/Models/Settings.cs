namespace DemoApi.Models
{
    /// <summary>
    /// IOptions pattern used to read from appsettings
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// This value will be overridden in the kubernetes appsettings configMap
        /// </summary>
        public string? Message { get; set; }
    }
}
