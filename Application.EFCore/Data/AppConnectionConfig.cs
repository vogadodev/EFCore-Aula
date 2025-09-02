namespace Application.EFCore.Data
{
    public static class AppConnectionConfig
    {
        public static string GetConnectionString()
        {
            return "Data Source =MARCUS-PC; Initial Catalog= EFCore.DB; Trusted_Connection=True; TrustServerCertificate=True;";
        }
    }
}
