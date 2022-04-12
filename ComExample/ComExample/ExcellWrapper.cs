using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComExample
{
    public class ExcellWrapper : IDisposable
    {
        object excelApp;
        static readonly Type excellType = Type.GetTypeFromProgID("Excel.Application");
        static dynamic sheet;
        public void Open()
        {
            
            if (excelApp == null)
                excelApp = Activator.CreateInstance(excellType);
            dynamic e = excelApp;
            e.Visible = true;
            var w = e.Workbooks.Add();
            sheet = w.Worksheets[1];
        }

        public object this[string cell]
        {
            get{ return sheet.Range[cell].Value; }
            set { sheet.Range[cell].Value = value; }
        }
        public void Close()
        {
            try
            {
                if (excelApp != null)
                {
                    excellType.GetMethod("Quit").Invoke(excelApp, null);
                    excelApp = null;
                }
            }
            catch { }
        }
        public void Save(string path) {
            dynamic e = excelApp;
            e.Workbooks[1].SaveAs(path, 51);
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            Close();
            GC.SuppressFinalize(this);
        }
        ~ExcellWrapper()
        {
            Dispose(false);
        }

    }
}
