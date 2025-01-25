using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Web.Services.Description;
using System.Web.UI.HtmlControls;

namespace LD4_22
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = TextBox1.Text;
            string pathTilps = $"{path}\\Tilps.csv";
            string pathBrangus = $"{path}\\Brangus.csv";

            Session["path"] = path;
            Session["pathTilps"] = pathTilps;
            Session["pathBrangus"] = pathBrangus;

            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;
            Label11.Visible = false;

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                Label2.Visible = false;
                Label3.Visible = true;
                Label4.Visible = true;
                Label5.Visible = true;
                Label6.Visible = true;
                Label7.Visible = true;
                Label8.Visible = true;
                Label9.Visible = true;
                Label10.Visible = true;
                Label11.Visible = true;

                List<Store> stores = new List<Store>();

                string path = (string)Session["path"];
                string pathTilps = (string)Session["pathTilps"];
                string pathBrangus = (string)Session["pathBrangus"];

                string header;
                header = "gamintojas,modelis,energijos klasė,spalva,kaina,";
                string headerF = "talpa,montavimo tipas,turi šaldiklį,aukštis," +
                                 "plotis,gylis";
                string headerO = "galingumas,programų skaičius";
                string headerK = "galia,tūris";

                InOutUtils.ReadData(path, stores);

                List<string> colorsF = TaskUtils.Color(stores, 'F');
                List<string> colorsK = TaskUtils.Color(stores, 'K');

                TaskUtils.CreateTable(colorsF, Table1);
                TaskUtils.CreateTable(colorsK, Table2);

                Fridge cheapFridge = (Fridge)TaskUtils.Cheapest(stores, 'F');
                Oven cheapOven = (Oven)TaskUtils.Cheapest(stores, 'O');
                Kettle cheapKettle = (Kettle)TaskUtils.Cheapest(stores, 'K');
                
                List<Fridge> cheapFridg = new List<Fridge> { cheapFridge };
                List<Oven> cheapOve = new List<Oven> { cheapOven};
                List<Kettle> cheapKettl = new List<Kettle> { cheapKettle };

                TaskUtils.CreateHeader(header + headerF, Table3);
                TaskUtils.CreateTable(cheapFridg, Table3);

                TaskUtils.CreateHeader(header + headerO, Table4);
                TaskUtils.CreateTable(cheapOve, Table4);

                TaskUtils.CreateHeader(header + headerK, Table5);
                TaskUtils.CreateTable(cheapKettl, Table5);

                List<Fridge> fridgeFits = TaskUtils.Fits(stores, 52, 56);

                TaskUtils.CreateHeader(header + headerF, Table6);
                TaskUtils.CreateTable(fridgeFits, Table6);

                if (File.Exists(pathTilps))
                    File.Delete(pathTilps);

                InOutUtils.PrintData(pathTilps, fridgeFits, header + headerF);

                List<Device> expenFridge = TaskUtils.Expensive(stores, 'F', 1000.00);
                List<Device> expenOven = TaskUtils.Expensive(stores, 'O', 500.00);
                List<Device> expenKettle = TaskUtils.Expensive(stores, 'K', 50.00);

                if (File.Exists(pathBrangus))
                    File.Delete(pathBrangus);

                TaskUtils.Sort(expenFridge);
                TaskUtils.Sort(expenOven);
                TaskUtils.Sort(expenKettle);

                TaskUtils.CreateHeader(header + headerF, Table7);
                TaskUtils.CreateTable(expenFridge, Table7);

                TaskUtils.CreateHeader(header + headerO, Table8);
                TaskUtils.CreateTable(expenOven, Table8);

                TaskUtils.CreateHeader(header + headerK, Table9);
                TaskUtils.CreateTable(expenKettle, Table9);

                InOutUtils.PrintData(pathBrangus, expenFridge, header + headerF);
                InOutUtils.PrintData(pathBrangus, expenOven, header + headerO);
                InOutUtils.PrintData(pathBrangus, expenKettle, header + headerK);
            }
            catch (Exception ex)
            {
                Label2.Visible = true;
                Label3.Visible = false;
                Label4.Visible = false;
                Label5.Visible = false;
                Label6.Visible = false;
                Label7.Visible = false;
                Label8.Visible = false;
                Label9.Visible = false;
                Label10.Visible = false;
                Label11.Visible = false;
                Label2.Text = ex.Message;
            }
        }
    }
}