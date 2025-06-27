using System.Data.SqlClient;

namespace LibraryDBM
{
    class DBConnect
    {
        SqlConnection sc;

        // 1. 连接数据库的方法
        public SqlConnection connect()
        {
            string str = @"Data Source=192.168.137.1;Initial Catalog=BookDB;User ID=remote_user;Password=123";
            sc = new SqlConnection(str);
            sc.Open();
            return sc;
        }


        // 2. 创建 SQL 命令对象的方法
        public SqlCommand command(string sql)
        {
            // 创建 SQL 命令对象，并与数据库连接绑定
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        }

        // 3. 执行更新类操作的方法（增删改）
        public int Execute(string sql)
        {
            return command(sql).ExecuteNonQuery();
        }

        // 4. 执行查询操作的方法
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
