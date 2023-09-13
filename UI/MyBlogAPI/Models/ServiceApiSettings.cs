namespace MyBlogAPI.Models;

 public class ServiceApiSettings
    {
        public string IdentityBaseUri { get; set; }
        public string GatewayBaseUri { get; set; }

        public ServiceApi Content { get; set; }
    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
