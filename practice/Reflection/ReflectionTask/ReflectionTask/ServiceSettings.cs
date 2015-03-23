namespace NetMentoring.Epam.ReflectionTask
{
    public class ServiceSettings
    {
        public string Connection { get; set; }
        public string Service { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var service = obj as ServiceSettings;
            if (service == null) return false;
            return (Connection == service.Connection) && (Service == service.Service);
            
        }

        public bool Equals(ServiceSettings service)
        {
            return (object) service != null && ((Connection == service.Connection) && (Service == service.Service));
        }

        public override int GetHashCode()
        {
            return Connection.GetHashCode() ^ Service.GetHashCode();
        }
    }
}
