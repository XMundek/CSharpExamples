using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace EF.Query
{

    public class Product
    {
         private readonly ILazyLoader _loader;
        public Product() { }
        public Product(ILazyLoader loader)
        {
            _loader = loader;            
        }
        public byte[] RowVersion { get; set; }
        public int Id { get; set; }
       
        public string Name { get; set; }
        
        public int SubCategoryId { get; set; }
        private SubCategory _subCategory;
        public  SubCategory SubCategory {
            get => _loader.Load(this, ref _subCategory);
            set => _subCategory = value;
        }
    }
    [DataContract]
    public class Category
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<SubCategory> SubCategories {get;set;}
    }
    [DataContract]
    public class SubCategory
    {
        //private readonly ILazyLoader _loader;
        //public SubCategory() { }
        //public SubCategory(ILazyLoader loader)
        //{
        //    _loader = loader;
        //}
        [DataMember]
        public int Id { get; set; }
        //private List<Product> _products;
        public virtual List<Product> Products { get; set; }
        //    get =>_loader.Load(this,ref _products);
        //    set => _products=value;
        //}
        public int CategoryId { get; set; }
        [XmlIgnore]
        public  Category Category { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
