namespace Data.Context
{
    public class ContextConfig
    {
        public const string SchemeName = "DEVELOPER";
        public const string DatabaseName = "LOCAL";
        public const string Pass = "developer";
        public const string User_Id = "DEVELOPER";

        public void EditSchemaOnBuilding()
        {
            System.Configuration.Configuration objConfig =  System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            System.Configuration.ConnectionStringsSection objSectionSettings =
                (System.Configuration.ConnectionStringsSection)objConfig.GetSection("connectionStrings");
            var conn = string.Format("DATA SOURCE = {0}; PASSWORD= {1}; USER ID={2};", DatabaseName, Pass, User_Id);
            //Edit
            if (objSectionSettings != null && !(objSectionSettings.ConnectionStrings["DbContext"].ConnectionString == conn))
            {
                objSectionSettings.ConnectionStrings["DbContext"].ConnectionString = conn;
                objSectionSettings.ConnectionStrings["DbLogErrorContext"].ConnectionString = conn;
                objConfig.Save();
            }
        }
    }
}
