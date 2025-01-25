using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LD4_22
{
    public static class TaskUtils
    {
        /// <summary>
        /// Gets certain type of device
        /// </summary>
        /// <param name="stores">stores list</param>
        /// <param name="type">type of device</param>
        /// <returns>device list</returns>
        private static List<Device> GetDevice(List<Store> stores, char type)
        {
            List<Device> result = new List<Device>();
            
            foreach (Store st in stores)
            {
                for(int i = 0; i < st.DeviceCount(); i++)
                {
                    if (st.GetDevice(i).Equals(type))
                    {
                         result.Add(st.GetDevice(i));
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Finds color for certain device
        /// </summary>
        /// <param name="stores">stores data</param>
        /// <param name="type">type of device</param>
        /// <returns>colors</returns>
        public static List<string> Color(List<Store> stores, char type)
        {
            List<string> results = new List<string>();
            List<Device> devices = GetDevice(stores, type);

            foreach (Device device in devices)
            {
                if (results.Count == 0)
                    results.Add(device.color);
                else
                {
                    bool unique = true;
                    foreach (string res in results)
                    {
                        if (device.Equals(res))
                        {
                            unique = false;
                            break;
                        }
                    }
                    if(unique)
                        results.Add(device.color);
                }
            }
            return results;
        }
        /// <summary>
        /// Finds cheapest certain device
        /// </summary>
        /// <param name="stores">stores data</param>
        /// <param name="type">type of data</param>
        /// <returns>device data</returns>
        public static Device Cheapest(List<Store> stores, char type)
        {
            List<Device> devices = GetDevice(stores, type);
            double cheapValue = double.MaxValue;
            Device cheapDevice = null;

            foreach(Device device in devices)
            {
                if(string.Compare(device.energyClass, "A+") == 0)
                    if(device.CompareTo(cheapValue) == 1)
                    {
                        cheapValue = device.price;
                        cheapDevice = device;
                    }
            }

            return cheapDevice;
        }
        /// <summary>
        /// Finds fridges that fit requirements
        /// </summary>
        /// <param name="stores">stores data</param>
        /// <param name="from">minimum width</param>
        /// <param name="to">maximum width</param>
        /// <returns>fridge list</returns>
        public static List<Fridge> Fits(List<Store> stores, int from, int to)
        {
            List<Device> devices = GetDevice(stores, 'F');
            List<Fridge> fridgeFits = new List<Fridge>();

            foreach(Fridge device in devices) 
            {
                if(device.width >= from && device.width <= to)
                {
                    fridgeFits.Add(device);
                }
            }

            return fridgeFits;
        }
        /// <summary>
        /// Finds expensive devices given criteria
        /// </summary>
        /// <param name="stores">stores data</param>
        /// <param name="type">type of device</param>
        /// <param name="price">criteria</param>
        /// <returns>device list</returns>
        public static List<Device> Expensive(List<Store> stores, char type,
            double price)
        {
            List<Device> results = new List<Device>();
            List<Device> devices = GetDevice(stores, type);

            foreach(Device device in devices)
            {
                if(device.CompareTo(price) != 1)
                {
                    results.Add(device);
                }
            }
            return results;
        }
        /// <summary>
        /// Sorts list
        /// </summary>
        /// <param name="devices">devices list</param>
        public static void Sort(List<Device> devices)
        {
            int max;
            for(int i = 0 ; i < devices.Count; i++)
            {
                max = i;
                for(int j = i  ; j < devices.Count; j++)
                {
                    if (devices[max].CompareTo(devices[j]) < 0)
                    {
                        max = j;
                    }
                }
                Device device1 = devices[i];
                devices[i] = devices[max];
                devices[max] = device1;
            }
        }
        /// <summary>
        /// Puts data in table
        /// </summary>
        /// <typeparam name="T">type of list</typeparam>
        /// <param name="values">list values</param>
        /// <param name="table">table name</param>
        public static void CreateTable<T>(List<T> values, Table
                                          table)
        {
            foreach(T value in values)
            {
                TableRow row = new TableRow();
                string[] parts = value.ToString().Split(',');
                foreach(string part in parts)
                {
                    TableCell cell = new TableCell();
                    cell.Text = part;
                    row.Cells.Add(cell);
                }
                table.Rows.Add(row);
            }
        }
        /// <summary>
        /// Creates a header for table
        /// </summary>
        /// <param name="header">headers information</param>
        /// <param name="table">tables name</param>
        public static void CreateHeader(string header, Table table)
        {
            TableRow row = new TableRow();
            
            string[] parts = header.Split(',');

            foreach(string part in parts)
            {
                TableCell cell = new TableCell();
                cell.Text = part;
                row.Cells.Add(cell);
            }
            table.Rows.Add(row);
        }
    }
}