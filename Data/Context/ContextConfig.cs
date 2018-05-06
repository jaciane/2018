namespace Data.Context
{
    public class ContextConfig
    {
        public const string SchemeName = "earth";
        public const string DatabaseName = "localhost";
        public const string Pass = "Earthconsultoria2018!";
        public const string User_Id = "earthconsultoria";

        public void EditSchemaOnBuilding()
        {
            System.Configuration.Configuration objConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            System.Configuration.ConnectionStringsSection objSectionSettings =
                (System.Configuration.ConnectionStringsSection)objConfig.GetSection("connectionStrings");
            var conn = string.Format("DATA SOURCE = {0}; PASSWORD= {1}; USER ID={2};", DatabaseName, Pass, User_Id);
            //Edit
            if (objSectionSettings != null && !(objSectionSettings.ConnectionStrings["mysqlconnection"].ConnectionString == conn))
            {
                objSectionSettings.ConnectionStrings["mysqlconnection"].ConnectionString = conn;
                objSectionSettings.ConnectionStrings["DbLogErrorContext"].ConnectionString = conn;
                objConfig.Save();
            }
        }
    }
}
