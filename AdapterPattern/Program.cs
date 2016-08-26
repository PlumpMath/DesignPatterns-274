using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("--------------------------------Simple Stub----------------------------------------------");
            DataRenderer dr = new DataRenderer(new StubAdapter());
            dr.Render(Console.Out);


            Console.WriteLine("--------------------------------Adapter Stub----------------------------------------------");

            List<Pattern> lstPatterns = new List<Pattern>();
            lstPatterns.Add(new Pattern() { Id = "1", Description = "This is adapter pattern.", Name = "Adapter Patttern" });
            PatternRender pt = new PatternRender(new DataPatternRenderAdapter());
            string result  = pt.ListPatterns(lstPatterns);
            Console.WriteLine(result);


            Console.ReadLine();
            

        }
    }

    public class DataRenderer
    {

        IDataFill _dataFill;

        public DataRenderer(IDataFill dataAdapter)
        {
            _dataFill = dataAdapter;
        }

        public void Render(TextWriter writer)
        {
          
            DataSet myDataset = new DataSet();
            _dataFill.Fill(myDataset);
            foreach (DataTable table in myDataset.Tables)
            {
                foreach (DataColumn col in table.Columns)
                {
                    writer.Write(col.ColumnName.PadRight(20) + " ");
                }
                writer.WriteLine();
                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                        writer.Write(row[i].ToString().PadRight(20) + " ");
                }

            }


        }

    }

  public  interface IDataFill
    {
        int Fill(DataSet dataSet);
    }
    public class StubAdapter : IDataFill
    {
        public int Fill(DataSet dataSet)
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("Id");
            DataColumn dc2 = new DataColumn("Name");
            DataColumn dc3 = new DataColumn("Description");
            dt.Columns.Add(dc1); dt.Columns.Add(dc2); dt.Columns.Add(dc3);
           DataRow dr = dt.NewRow();
                dr[0] = "01";
                dr[1] = "Adapter Pattern";
                dr[2] = "This is adapter Patern";
                dt.Rows.Add(dr);
           
            dataSet.Tables.Add(dt);
            dataSet.AcceptChanges();
            return 1;
        }

      
    }
    public class Pattern
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }

    public class PatternRender
    {
        private IDataPatternRenderAdapter _dataPaternRender;

        public PatternRender(IDataPatternRenderAdapter dataPaternRender)
        {
            _dataPaternRender = dataPaternRender;

        }

        public string ListPatterns(IEnumerable<Pattern> patterns)
        {
            return _dataPaternRender.ListPatterns(patterns);
        }
    }
    public interface IDataPatternRenderAdapter
    {
        string ListPatterns(IEnumerable<Pattern> patterns);
    }
    public class DataPatternRenderAdapter : IDataPatternRenderAdapter
    {
        DataRenderer _dataRender;

        public string ListPatterns(IEnumerable<Pattern> patterns)
        {
            _dataRender = new DataRenderer(new PatternFill(patterns));
            var writer = new StringWriter();
            _dataRender.Render(writer);
            return writer.ToString();


        }
    }

    public class PatternFill : IDataFill
    {
        IEnumerable<Pattern> _patterns;
        public PatternFill(IEnumerable<Pattern> patterns)
        {
            _patterns = patterns;

        }

        public int Fill(DataSet dataSet)
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("Id");
            DataColumn dc2 = new DataColumn("Name");
            DataColumn dc3 = new DataColumn("Description");
            dt.Columns.Add(dc1); dt.Columns.Add(dc2); dt.Columns.Add(dc3);
            foreach (var item in _patterns)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item.Id;
                dr[1] = item.Name;
                dr[2] = item.Description;
                dt.Rows.Add(dr);
            }
            dataSet.Tables.Add(dt);
            dataSet.AcceptChanges();
            return _patterns.Count();
        }

       
    }









}
