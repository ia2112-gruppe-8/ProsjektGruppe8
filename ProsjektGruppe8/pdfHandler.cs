using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace ProsjektGruppe8
{
    class pdfHandler
    {
        public string filename { get;private set; }
        DataTable dt;
        public pdfHandler(DataTable dataTable)
        {
            dt = dataTable;

        }
        public void CreateDocument(bool openDoc)
        {
            Document doc = new Document();
            Section section = doc.AddSection();
            Table table = section.AddTable();
            table.Borders.Width = 0.25;
            table.Rows.LeftIndent = 0;
            Column columnA = table.AddColumn("3cm");
            Column columnB = table.AddColumn("7cm");
            Column columnC = table.AddColumn("3cm");
            columnA.Format.Alignment = ParagraphAlignment.Center;
            columnB.Format.Alignment = ParagraphAlignment.Center;
            columnC.Format.Alignment = ParagraphAlignment.Center;
            Row row = table.AddRow();
            row.Cells[0].AddParagraph("Alarmtype");
            row.Cells[1].AddParagraph("Dato");
            row.Cells[2].AddParagraph("Verdi");
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                row = table.AddRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j == 0)
                    {
                        AlarmType at = (AlarmType)Convert.ToInt32(dt.Rows[i][j]);
                        row.Cells[j].AddParagraph(at.ToString());
                    }
                    else
                    {
                    row.Cells[j].AddParagraph(dt.Rows[i][j].ToString());
                    }
                    
                }
            }

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(false);
            renderer.Document = doc;
            renderer.RenderDocument();
            filename = $"Alarmer{DateTime.Today.Day}_{DateTime.Today.TimeOfDay.Hours}.pdf";
            
            renderer.PdfDocument.Save(filename);
            if (openDoc)
            {
            Process.Start(filename);

            }
        }
        
    }
}
