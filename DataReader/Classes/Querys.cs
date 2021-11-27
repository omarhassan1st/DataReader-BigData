using System;
using System.Data;
using System.Data.SqlClient;

namespace DataReader
{
    class Querys
    {
        private readonly static string connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Reader;User ID=sa;Password=123456";
        public static void Excuter(string Qury)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand(Qury, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                COMMANDS.Error(ex.Message);
                return;
            }
        }
        public static string Reader_SingleValue(string ReaderQury)
        {
            try
            {
                DataTable table2 = new DataTable();
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand(ReaderQury, conn))
                    {
                        conn.Open();
                        object Value = cmd.ExecuteScalar();
                        conn.Close();

                        if (Value == null)
                            return string.Empty;
                        else
                            return Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                COMMANDS.Error(ex.Message);
                return string.Empty;
            }
        }
        public static DataTable Reader_Table(string ReaderQury)
        {
            try
            {
                DataTable TableName = new DataTable();
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand(ReaderQury, conn))
                    {
                        conn.Open();
                        cmd.CommandTimeout = 60;
                        TableName.Load(cmd.ExecuteReader());
                        conn.Close();
                    }
                }
                return TableName;
            }
            catch (Exception ex)
            {
                COMMANDS.Error(ex.Message);
                return null;
            }
        }
    }
}
