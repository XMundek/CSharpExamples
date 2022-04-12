using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace EF.Query
{

    class Program
    {
        static async Task<List<Product>> LoadProductsAsync()
        {
            Console.WriteLine("start" + nameof(LoadProductsAsync));
            using (var context = new ProductDbContext())
            {
                return await context.Products.ToListAsync();
            }
        }
        static async Task<List<Category>> LoadCategoriesAsync()
        {
            Console.WriteLine("start" + nameof(LoadCategoriesAsync));
            using (var context = new ProductDbContext())
            {
                return await context.Categories.ToListAsync();
            }
        }
        static async Task<int> LoadInt(){
            Console.WriteLine("start" + nameof(LoadInt));
            var task = Task<int>.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("end" + nameof(LoadInt));
                return 101;
            });
            return await task;
        }
        static void Main(string[] args)
        {
            var t1 = LoadInt();
            var t2 = LoadCategoriesAsync();
            var t3 = LoadProductsAsync();
            Task.WaitAll(t1, t2, t3);
            Console.WriteLine(t1.Result);
            Console.WriteLine(t2.Result.Count());
            Console.WriteLine(t3.Result.Count());
            Console.ReadLine();
            //Product[] l;
            using (var context = new ProductDbContext())
            {
               
                

                //var prod = context.Products.First();
                //prod.Name = "A";
                //prod = context.Products.Last();
                ////prod.SubCategoryId = 10;

                //context.SaveChanges();

                //using (var tr = context.Database.BeginTransaction())
                {


                    //foreach (var e in context.Model.GetEntityTypes())
                    //{
                    //    Console.WriteLine(e.Relational().TableName);
                    //    foreach (var p in e.GetProperties())
                    //    {
                    //        Console.WriteLine(p.Relational().ColumnName);
                    //    }                      
                    //}
                    //context.Database.GetDbConnection().Open();
                    var prod = context.Products.First();
                    prod.Name = "Y";
                    prod = context.Products.Last();
                    //prod.SubCategoryId = 10;

                    context.SaveChanges();
                    var con = context.Database.GetDbConnection();
                    con.Open();
                    var dbTran = con.BeginTransaction();
                    var cm = con.CreateCommand();
                    cm.Transaction = dbTran;
                    cm.CommandText = "BEGIN TRAN UPDATE Products SET SubCategoryId=2 where subcategoryid=4 COMMIT";
                    cm.ExecuteNonQuery();
                    //context.Database.ExecuteSqlCommand("UPDATE Products SET SubCategoryId=1 where subcategoryid=10");
                    dbTran.Commit();


                    //context.SaveChanges();
                    //tr.Commit();                   
                }
                using (var tr = new System.Transactions.TransactionScope())
                {
                    //using (var trx = context.Database.BeginTransaction())
                    //{
                        var prod = context.Products.First();
                        prod.Name = "X";
                        prod = context.Products.Last();
                        //prod.SubCategoryId = 10;

                        context.SaveChanges();
                        context.Database.ExecuteSqlCommand("UPDATE Products SET SubCategoryId=2 where subcategoryid=4");
                        context.Database.ExecuteSqlCommand("UPDATE Products SET SubCategoryId=4 where subcategoryid=1");

                        var con = context.Database.GetDbConnection();
                        //con.Open();
                        var dbTran = con.BeginTransaction();
                        var cm = con.CreateCommand();
                        cm.Transaction = dbTran;
                        cm.CommandText = "BEGIN TRAN UPDATE Products SET SubCategoryId=1 where subcategoryid=3 COMMIT";
                        cm.ExecuteNonQuery();
                      //  trx.Commit();
                        tr.Complete();
                    //}
                }
                    var name = "P%";
                var pr = context.Products
                        .FromSql($"select * from Products where Name like {name}")
                        .OrderBy(a=>a.Name).ToArray();

                var pr2 = context.Products.FromSql($"EXEC GetProducts {name}").OrderBy(a => a.Name).ToArray();

                var newVal = "A"; var oldVal = "B";
                var cnt = context.Database.ExecuteSqlCommand($"UPDATE Products SET Name={newVal} WHERE Name={oldVal}");

                var cn = context.Database.GetDbConnection();
                //cn.Open();
                var cmd= cn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetProducts";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@name",name));
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(dr.GetInt32(0));
                }
                
                    var pl = pr.ToArray();

                //var data = context.Categories.Include(z => z.SubCategories).ToArray();

                ////var data = context.Categories.ToArray();
                //var serializer = new XmlSerializer(typeof(Category[]));
                //var sb = new StringBuilder();
                //var stream = new StringWriter(sb);
                //serializer.Serialize(stream, data);
                //stream.Close();
                //Console.WriteLine(sb.ToString());


                //MemoryStream str = new MemoryStream();
                //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Category[]));
                //ser.WriteObject(str, data);
                //str.Position = 0;
                //StreamReader sr = new StreamReader(str);
                //Console.WriteLine(sr.ReadToEnd());

                ////var l = context.Products.Include(p=>p.SubCategory).ThenInclude(p=>p.Category).ToArray();
                ////context.Products.Load();
                //l = context.Products.ToArray();
                ////foreach (var p in context.Products)
                ////{
                ////   Console.WriteLine(p.SubCategory.Name);
                ////}

                ////foreach (var p in l)
                ////{
                ////    Console.WriteLine(p.SubCategory.Name);
                ////}
                ////foreach (var c in context.SubCategories)
                ////{
                ////    foreach (var p in c.Products)
                ////    {
                ////        Console.WriteLine(p.Name + " " + c.Name);
                ////    }
                ////}
                //var p = context.Products.Find(1);
                //Console.WriteLine(context.Entry(p).State);
                //p.Name += "changed";
                //Console.WriteLine(context.Entry(p).State);

                //p = context.Products.Find(4);
                //context.Products.Remove(p);
                //Console.WriteLine(context.Entry(p).State);

                //p = new Product { Name = "NewProduct", SubCategoryId = 1 };
                //Console.WriteLine(context.Entry(p).State);
                //context.Products.Add(p);
                //Console.WriteLine(context.Entry(p).State);

                ////context.ChangeTracker.AcceptAllChanges();
                //p = new Product() { Id = 100, Name = "Detached", SubCategoryId = 1 };
                //Console.WriteLine(context.Entry(p).State);

                //context.Attach(p);
                //Console.WriteLine(context.Entry(p).State);

                //context.Update(p);
                //Console.WriteLine(context.Entry(p).State);

                //context.SaveChanges();

                ////context.ChangeTracker.AcceptAllChanges();
                ////p = new Product() {Id=100, Name = "Detached", SubCategoryId = 1 };
                //Console.WriteLine(context.Entry(p).State);


                //var subCat = new SubCategory
                //{
                //    Id = 1, Name = "Test",
                //    Products = new List<Product>
                //    {
                //        new Product{Id = 1, Name="P1"},
                //        new Product{Id = 2, Name="P2"},
                //        new Product{Id = -1, Name="P2"}
                //    }
                //};
                //context.ChangeTracker.TrackGraph(subCat, e => {
                //    var entity = e.Entry.Entity as Product;
                //   e.Entry.State = (entity == null || entity.Id < 0) 
                //    ? EntityState.Added 
                //    : EntityState.Unchanged;
                //});
                //foreach (var entry in context.ChangeTracker.Entries())
                //{
                //    Console.WriteLine($"Type:{entry.Entity.GetType()}; State:{entry.State}");
                //}
                

var q1 = from p in context.SubCategories
            where p.Name.StartsWith(GetName())
            orderby p.Name, p.Id descending
            select p;

var list = q1.ToList();

var uq = (from s in context.SubCategories
            select new { s.Name }).Union(
            from c in context.Categories
            select new { c.Name });
var ulist = uq.ToList();

var q2 = from p in context.Products
            group p by p.SubCategory into g
            select new { Id = g.Key.Id, Name = g.Key.Name, Count = g.Count() };
var list2 = q2.ToList();
var q3 = from p in context.Products
            group p by p.SubCategoryId into g
            select new { Id = g.Key, Name = g.First().SubCategory.Name, Count = g.Count() };
var list3 = q3.ToList();
var q4 = from p in context.Products
            group p by p.SubCategoryId into g
            select new { Id = g.Key, Count = g.Count() };
var list4 = q4.ToList();
var q5 = from p in context.SubCategories
            select new { Id = p.Id, Name = p.Name, Count = p.Products.Count() };
var list5 = q5.ToList();


            }

            //foreach (var p in l)
            //{
            //    Console.WriteLine(p.SubCategory.Name);
            //}
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
        public static string GetName()
        {
            return "S";
        }
    }
}
