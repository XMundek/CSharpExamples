using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace CSVExport
{

    static class Program
    {
        static void Main(string[] args)
        {
            SqlConnection cn;
            SqlCommand cmd;
            using (cn = new SqlConnection(ConfigurationManager.ConnectionStrings["FileLog"].ConnectionString))
            {
                cn.Open();
                cmd = cn.CreateCommand();
                cmd.CommandText = "select * from Files";

                using (var dr = cmd.ExecuteReader())
                {
                    using (var file = File.CreateText(@"c:\temp\filelist.log"))
                    {
                        for (var i = 0; i < dr.FieldCount; i++)
                        {
                            file.Write(dr.GetName(i));
                            file.Write("\t");
                        }
                        file.WriteLine();
                        while (dr.Read())
                        {
                            for (var i = 0; i < dr.FieldCount; i++)
                            {
                                file.Write(dr[i]);
                                file.Write("\t");
                            }
                            file.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
