using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace FileApp
{
    class DirProcessor
    {
        SqlConnection cn;
        SqlCommand cmd;
        TextWriter tw;
        public  async Task ProcessDir(string root, string logFile)
        {
            using (cn = new SqlConnection(ConfigurationManager.ConnectionStrings["FileLog"].ConnectionString))
            {
                await cn.OpenAsync();
                //cn.Open();
                cmd = cn.CreateCommand();
                cmd.CommandText = "insert Files(FullPath,FileName, FileDate,Size) values(@FullPath,@FileName,@FileDate,@Size)";
                cmd.Parameters.Add("@FullPath", System.Data.SqlDbType.NVarChar);
                cmd.Parameters.Add("@FileName", System.Data.SqlDbType.NVarChar);
                cmd.Parameters.Add("@FileDate", System.Data.SqlDbType.DateTime);
                cmd.Parameters.Add("@Size", System.Data.SqlDbType.BigInt);
                string dirName = @"c:\temp";

                using ( tw = File.CreateText(Path.Combine(dirName, logFile)))
                {
                    ReadDir(root, 0);
                }
            }
        }
        static string RepeatString(string s, int count)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }

        void ReadDir(string root, int level)
        {
            var dirList = Directory.GetDirectories(root);
            var startString = RepeatString("\t", level + 1);
            foreach (var dir in dirList)
            {
                long dirSize = 0;
                Console.WriteLine(dir);
                tw.WriteLine(dir);
                try
                {

                    var fileList = Directory.GetFiles(dir);
                    foreach (var file in fileList)
                    {
                        var fileInfo = new FileInfo(file);
                        tw.WriteLine(startString + fileInfo.Name + " Size=" + fileInfo.Length);
                        dirSize += fileInfo.Length;
                        cmd.Parameters["@FullPath"].Value = Path.GetDirectoryName(file);
                        cmd.Parameters["@FileName"].Value = fileInfo.Name;
                        cmd.Parameters["@FileDate"].Value = fileInfo.CreationTime;
                        cmd.Parameters["@Size"].Value = fileInfo.Length;
                        cmd.ExecuteNonQuery();
                    }
                    ReadDir(dir, level + 1);
                    tw.Flush();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(startString + ex.Message);
                }
                finally
                {
                    Console.WriteLine(startString + "Dirsize =" + dirSize);
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //DirectoryInfo dir = new DirectoryInfo(dirName);
            //FileInfo file = new FileInfo(Path.Combine(dirName, "test.txt"));

            //using (var f = File.AppendText (Path.Combine(dirName, "test.txt")))
            //{

            //    f.WriteLine("ala ma kota");
            //    f.WriteLine();

            //}

            //using (var log = File.AppendText(Path.Combine(dirName, "log.txt")))
            //{
            //    var oldOut = Console.Out;
            //    Console.WriteLine("Redirect start");
            //    //Console.SetOut(log);

            //    string root = @"c:\";
            //    ReadDir(root, 0);
            //    //Console.SetOut(oldOut);
            //    Console.WriteLine("Redirect end");
            //}
            //var t = new Task(() => new DirProcessor().ProcessDir(@"c:\windows", "log2.txt"));
            //var t1 = new Task(() =>new DirProcessor().ProcessDir(@"c:\Program Files\", "log3.txt"));
            var t =  new DirProcessor().ProcessDir(@"c:\windows", "log2.txt");
            var t1 =  new DirProcessor().ProcessDir(@"c:\Program Files\", "log3.txt");

            //t.Start();
            //t1.Start();
            Task.WaitAll(t, t1);
                Console.ReadLine();
        }
    
    }
}
