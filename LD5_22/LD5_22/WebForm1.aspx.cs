using System;
using System.Collections.Generic;
using System.IO;

namespace LD5_22
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label3.Text = string.Empty;
            List<Publication> publications = new List<Publication>();
            List<Subscriber> subscribers = new List<Subscriber>();
            int index;
            try
            {
                string pathResults = Server.MapPath("App_Data/Results.txt");

                publications = InOutUtils.ReadPublication(TextBox2.Text);

                subscribers = InOutUtils.ReadData(TextBox1.Text);
                
                if(File.Exists(pathResults))
                    File.Delete(pathResults);

                TaskUtils.AddLabel(PlaceHolder1, "Pradiniai duomenys" +
                                                " prenumeratorių: ");

                TaskUtils.Seperate(subscribers, PlaceHolder1, out index);

                InOutUtils.PrintData(pathResults, subscribers, "Pradiniai duome" +
                                                               "nys prenumera" +
                                                               "torių: ");

                TaskUtils.AddLabel(PlaceHolder1, "Pradiniai duomenys leidinių: ");

                PlaceHolder1.Controls.Add(TaskUtils.CreateTable(publications,
                                          index++));

                InOutUtils.PrintData(pathResults, publications, "Pradiniai du" +
                                                                "omenys leidi" +
                                                                "nių: ");

                TaskUtils.AddLabel(PlaceHolder1, "Prenumeratuoriams reikia" +
                                                 " sumokėti: ");

                var answer = TaskUtils.TotalPrice(publications, subscribers);

                PlaceHolder1.Controls.Add(TaskUtils.CreateTable(answer, index++));

                InOutUtils.PrintData(pathResults, answer, "Prenumeratuoriams " +
                                                          "reikia sumokėti: ");

                Label3.Visible = false;
            }
            catch (Exception ex)
            {
                Label3.Visible = true;
                Label3.Text = ex.Message;
            }
            Session["publications"] = publications;
            Session["subscribers"] = subscribers;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<Publication> publications = new List<Publication>();
            List<Subscriber> subscribers = new List<Subscriber>();
            int index = 1;

            publications = (List<Publication>)Session["publications"];
            subscribers = (List<Subscriber>)Session["subscribers"];
            try
            {
                string pathResults = Server.MapPath("App_Data/Results.txt");

                var answer = TaskUtils.CertainMonth(int.Parse(TextBox3.Text),
                                                    TextBox4.Text, TextBox5.Text,
                                                    subscribers);

                TaskUtils.AddLabel(PlaceHolder1, $"Nuo {TextBox4.Text} iki" +
                                                 $" {TextBox5.Text} įvesti " +
                                                 $"duomenys {TextBox3.Text} mė" +
                                                 $"nesį narystės statusas");

                PlaceHolder1.Controls.Add(TaskUtils.CreateTable(answer, index++));

                InOutUtils.PrintData(pathResults, answer, $"Nuo {TextBox4.Text} iki" +
                                                          $" {TextBox5.Text} įvesti " +
                                                          $"duomenys {TextBox3.Text} mė" +
                                                          $"nesį narystės statusas");

                var answer2 = TaskUtils.CertainPublication(int.Parse(TextBox3.Text),
                                                           TextBox4.Text,
                                                           TextBox5.Text,
                                                           subscribers,
                                                           publications);

                TaskUtils.AddLabel(PlaceHolder1, $"Pagal nuo {TextBox4.Text} " +
                                                 $"iki {TextBox5.Text} įvesti" +
                                                 $" duomenys {TextBox3.Text} " +
                                                 $"mėnesį leidinių kiekis " +
                                                 $"prenumeruotu");

                InOutUtils.PrintData(pathResults, answer, $"Pagal nuo {TextBox4.Text} " +
                                                 $"iki {TextBox5.Text} įvesti" +
                                                 $" duomenys {TextBox3.Text} " +
                                                 $"mėnesį leidinių kiekis " +
                                                 $"prenumeruotu");

                PlaceHolder1.Controls.Add(TaskUtils.CreateTable(answer2, index++));
            }
            catch (Exception ex)
            {
                TaskUtils.AddLabel(PlaceHolder1, ex.Message);
            }
        }
    }
}