using System.Data.SqlClient;

namespace LibraryDBM
{
    class DBConnect
    {
        SqlConnection sc;

        // 1. 连接数据库的方法
        public SqlConnection connect()
        {
            string str = @"Data Source=UTAPIA; Initial Catalog=BookDB; Integrated Security=True";
            //string str = @"Data Source= 10.129.87.20,1433; Initial Catalog=BookDB; User Id=sa; Password=2004113921mpx ; Encrypt=True; TrustServerCertificate=True;";
            
            sc = new SqlConnection(str); // 创建连接对象
                sc.Open(); // 打开数据库连接
                return sc; // 返回连接对象
        }


        // 2. 创建 SQL 命令对象的方法
        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        }

        // 3. 执行更新类操作的方法（增删改）
        public int Execute(string sql)
        {
            return command(sql).ExecuteNonQuery();
        }

        // 4. 执行读取操作的方法
        public SqlDataReader read(string sql)
        {
            return command(sql).ExecuteReader();
        }

        // 5. 关闭数据库连接的方法
        public void DaoClose()
        {
            sc.Close();
        }
    }
}
