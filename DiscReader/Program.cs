using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DiscReader
{   
    class DirReader
    {
        long fileSize;
        long fileCount;
        long dirCount;
        void ReadDirectory(TextWriter tw, string path, int level)
        {
            var tabs = new string(' ', level);
            try
            {
                var files = Directory.GetFiles(path);
                fileCount += files.Length;
                foreach (var file in files)
                {
                    try
                    {
                        var f = new FileInfo(file);
                        tw.WriteLine($"{tabs}{f.Name} Size={f.Length}");
                        fileSize += f.Length;
                    }
                    catch (Exception ex)
                    {
                        tw.WriteLine($"{tabs}{Path.GetFileName(file)}-{ex.Message}");
                    }
                }

                files = Directory.GetDirectories(path);
                dirCount += files.Length;
                foreach (var dir in files)
                {
                    tw.WriteLine($"{tabs}{Path.GetFileName(dir)}");
                    ReadDirectory(tw, dir, level + 1);
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
            };
        }
        public void ReadDirectory(TextWriter tw, string path)
        {
            fileSize = fileCount = dirCount = 0;
            tw.WriteLine(path);
            
            ReadDirectory(tw, path, 1);
            tw.WriteLine($"Dir count={dirCount} File count={fileCount} Size={fileSize}");
        }
    }
    class Program
    {
        private static void ReadDir(string path,string outFile)
        {
            var dirReader = new DirReader();
            using (var f = File.CreateText(outFile))
            {
                dirReader.ReadDirectory(f, path);
            }
        }
        private static void Read1()
        {
            Console.WriteLine("Read1 start");
            ReadDir( @"C:\Users\Administrator\source", @"C:\temp\fileList.txt");
            Console.WriteLine("Read1 finished");
        }
        private static void Read2()
        {
            Console.WriteLine("Read2 start");
            ReadDir(@"C:\install", @"C:\temp\fileList2.txt");
            Console.WriteLine("Read2 finished");
        }
        private async static Task  Read3()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Read3 start");
                ReadDir(@"C:\Intel", @"C:\temp\fileList3.txt");
                Console.WriteLine("Read3 finished");
            });
              
        }
        private async static Task Read4()
        {
            await Read3();
        }
        static void Main(string[] args)
        {
            try
            {
                //Parallel.Invoke(Read1, Read2);
                var t1 = new Task(Read1);
                var t2 = new Task(Read2);
                t1.Start();
                t2.Start();

                Task.WaitAll(t1, t2, Read4());
                

               //var t1 = new Thread(Read1);
               //var t2 = new Thread(Read2);
               // Console.WriteLine("Before");
               // t1.Start();
               // t2.Start();
               // while (t1.ThreadState == System.Threading.ThreadState.Running ||
               //     t2.ThreadState == System.Threading.ThreadState.Running)
               // {
               //     Console.WriteLine("Waiting");
               //     Thread.Sleep(1000); 
                    
               // }



                Console.WriteLine("after");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }      
        }
    }
}
