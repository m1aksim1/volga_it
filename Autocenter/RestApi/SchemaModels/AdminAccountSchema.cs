namespace RestApi.SchemaModels
{
    public class AdminAccountSchema
    {
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public bool isAdmin { get; set; }
        public double balance { get; set; }
    }
}
