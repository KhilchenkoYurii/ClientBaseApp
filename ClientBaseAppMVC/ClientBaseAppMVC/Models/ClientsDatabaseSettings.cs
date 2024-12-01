namespace ClientBaseAppMVC.Models
{
    public class ClientsDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ClientsCollectionName { get; set; } = null!;
    }
}
