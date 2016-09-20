namespace PentiaExcercise.ViewModels
{
    /// <summary>
    /// View model created to enable dynamic generation of search fields in views
    /// </summary>
    public class SearchFieldViewModel
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Placeholder { get; set; }
    }
}