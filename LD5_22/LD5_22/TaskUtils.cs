using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;

namespace LD5_22
{
    public static class TaskUtils
    {
        /// <summary>
        /// Finds each subscriber total prcie for his subscribtions
        /// </summary>
        /// <param name="publications">publication data</param>
        /// <param name="subscribers">subscriber data</param>
        /// <returns>subscriber surname and total price</returns>
        public static IEnumerable<string> TotalPrice(List<Publication>
            publications, List<Subscriber> subscribers)
        {
            var answer =
                from subscriberGroup in subscribers
                    .GroupBy(subscriber => subscriber.surname)
                select (
                    subscriberGroup.Key + " " +
                    subscriberGroup.Sum(subscriber => publications
                                       .Where(publisher => subscriber.code
                                              == publisher.code)
                                        .Sum(publisher => publisher.price *
                                             subscriber.dateLength *
                                             subscriber.amount)
                    )
                );

            return answer;
        }
        /// <summary>
        /// Returns from certain given information certain month subscriber
        /// subscribtion status
        /// </summary>
        /// <param name="month">which month we are checking</param>
        /// <param name="startDate">inserted data start</param>
        /// <param name="endDate">inserted data end</param>
        /// <param name="subscribers">subscriber data</param>
        /// <returns>subscribers surname, adress and * or .</returns>
        public static IEnumerable<string> CertainMonth(int month, string startDate
            , string endDate, List<Subscriber> subscribers)
        {
            var answer = subscribers.Where(sub => string.Compare(sub.dateInserted,
                                                                 startDate) >= 0
                                                                 &&
                                                  string.Compare(sub.dateInserted,
                                                  endDate) <= 0)
                                    .OrderBy(sub => sub.adress)
                                    .ThenBy(sub => sub.surname)
                                    .Select(sub => sub.surname + " " + sub.adress
                                            + " " + sub.code + " " + 
                                            ((sub.dateStart == month) || 
                                            (sub.dateStart < month && 
                                            sub.dateLength >= month -
                                            sub.dateStart) || 
                                            (sub.dateLength >= 12 - 
                                            Math.Abs((month - sub.dateStart)))
                                            ? "*" : "-"));

            return answer;
        }
        /// <summary>
        /// Returns from certain given information certain month publication
        /// name and how much of ammount was purchased
        /// </summary>
        /// <param name="month">which month we are checking</param>
        /// <param name="startDate">inserted data start</param>
        /// <param name="endDate">inserted data end</param>
        /// <param name="subscribers">subscriber data</param>
        /// <param name="publications">publication data</param>
        /// <returns>publication name and ammount</returns>
        public static IEnumerable<string> CertainPublication(int month,
                                                             string startDate,
                                                             string endDate,
                                                             List<Subscriber>
                                                             subscribers,
                                                             List<Publication>
                                                             publications)
        {
            var answer = subscribers.Where(sub =>
                                           string.Compare(sub.dateInserted,
                                           startDate) >= 0 &&
                                           string.Compare(sub.dateInserted,
                                           endDate) <= 0 &&
                                           ((sub.dateStart == month) ||
                                           (sub.dateStart < month &&
                                           sub.dateLength >= month - sub.dateStart
                                           ) || (sub.dateLength >= 12 - 
                                           Math.Abs((month - sub.dateStart)))));

            var answer2 = answer.Join(publications, sub => sub.code,
                                      pub => pub.code, (sub, pub) =>
                                      new { PublicationName = pub.name,
                                      Amount = sub.amount })
                                .GroupBy(item => item.PublicationName)
                                .Select(group => group.Key + " " + 
                                        group.Sum(item => item.Amount));

            return answer2;
        }
        /// <summary>
        /// Creates dynamic table
        /// </summary>
        /// <typeparam name="T">list type</typeparam>
        /// <param name="list">list data</param>
        /// <param name="index">index</param>
        /// <returns>table</returns>
        public static Table CreateTable<T>(IEnumerable<T> list, int index)
        {
            Table table = new Table();
            table.ID = "Table" + index;
            foreach (T item in list)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                cell.Text = item.ToString();
                row.Cells.Add(cell);
                table.Rows.Add(row);
            }
            return table;
        }
        /// <summary>
        /// Seperates subscribers and creates tables for each of one
        /// </summary>
        /// <param name="subscribers">subscribers</param>
        /// <param name="placeholder">location where table is created</param>
        /// <param name="index">index</param>
        public static void Seperate(List<Subscriber> subscribers,
            PlaceHolder placeholder, out int index)
        {
            var groupedSubscribers = subscribers.GroupBy(subscriber =>
                                                         subscriber.dateInserted);
            index = 1;

            foreach (var group in groupedSubscribers)
            {
                AddLabel(placeholder, group.Key);
                placeholder.Controls.Add(CreateTable(group.ToList(), index));
                index++;
            }
        }
        /// <summary>
        /// Adds label
        /// </summary>
        /// <param name="placeholder">place for adding</param>
        /// <param name="text">given text</param>
        public static void AddLabel(PlaceHolder placeholder, string text)
        {
            Label label = new Label();
            label.Text = text;
            label.ForeColor = Color.FloralWhite;
            placeholder.Controls.Add(label);
        }
    }
}