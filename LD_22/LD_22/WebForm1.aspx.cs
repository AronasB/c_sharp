using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace LD_22
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Container container = new Container();
        }
        private void ReadFile(string textFile, Container container)
        {
            using (StreamReader reader = new StreamReader(textFile))
            {
                string temp;
                temp = reader.ReadLine();

                string[] parts = temp.Split(' ');
                container.n = int.Parse(parts[0].Trim());
                container.m = int.Parse(parts[1].Trim());

                Locations Location1 = new Locations();
                for (int i = 0; i < container.n; i++)
                {
                    temp = reader.ReadLine();
                    Location1.Place(temp, i);
                }
                container.Place(Location1);

                
            }
        }
    }
}