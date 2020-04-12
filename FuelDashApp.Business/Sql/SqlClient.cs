using System.Data;
using System.Data.SqlClient;

namespace FuelDashApp.Business.Sql
{
    public class SqlClient
    {
       // protected SqlClient(string ConnectionString);

        public int CommandTimeout { get; set; }

     //   public static string CreateErrorMessage(string SpName, SqlParameter[] SqlParams);
        public static SqlClient GetInstance(string ConnectionString) ;
        public DataTable ExecuteDataTable(string StoredProcName);
        public DataTable ExecuteDataTable(string StoredProcName, SqlParameter[] StoredProcParameters);
       // public DataTable ExecuteDataTableTopRecords(string StoredProcName, int NumberOfTopRecords, SqlParameter[] StoredProcParameters);
        //public object ExecuteInfoMessage(string StoredProcName);
      //  public object ExecuteInfoMessage(string StoredProcName, SqlParameter[] StoredProcParameters);
     //   public int ExecuteNonQuery(string StoredProcName);
    //    public int ExecuteNonQuery(string StoredProcName, SqlParameter[] StoredProcParameters);
        public object ExecuteScalar(string StoredProcName);
        public object ExecuteScalar(string StoredProcName, SqlParameter[] StoredProcParameters);
      //  public DataTable ExecuteScript(string sqlscript);
      //  public DataTable GetTableSchema(string TableName);
      //  public int SqlBulkCopy(string DestinationTableName, DataTable ImportDataTable);
      //  public int SqlBulkCopy(string DestinationTableName, DataTable ImportDataTable, string FollowupProcedure);

    }
}