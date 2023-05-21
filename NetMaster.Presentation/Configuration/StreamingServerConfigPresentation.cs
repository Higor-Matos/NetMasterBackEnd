namespace NetMaster.Presentation.Configuration
{
    public class StreamingServerConfigPresentation
    {
        public string? FileName { get; set; }
        public bool UseShellExecute { get; set; }
        public bool RedirectStandardOutput { get; set; }
        public bool CreateNoWindow { get; set; }
    }
}