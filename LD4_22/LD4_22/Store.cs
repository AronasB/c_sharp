using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD4_22
{
    public class Store
    {
        public string name {  get; private set; }
        public string adress { get; private set; }
        public string phone { get; private set; }
        private List<Device> devices;
        /// <summary>
        /// Store constructor with parameters
        /// </summary>
        /// <param name="name">store name</param>
        /// <param name="adress">adress</param>
        /// <param name="phone">phone number</param>
        public Store(string name, string adress, string phone)
        {
            this.name = name;
            this.adress = adress;
            this.phone = phone;
            devices = new List<Device>();
        }
        /// <summary>
        /// Adds device
        /// </summary>
        /// <param name="device">device class</param>
        public void AddDevices(Device device)
        {
            devices.Add(device);
        }
        /// <summary>
        /// Gets certain device data
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>device data</returns>
        public Device GetDevice(int index)
        {
            return devices[index];
        }
        /// <summary>
        /// Counts devices in store
        /// </summary>
        /// <returns>int</returns>
        public int DeviceCount()
        {
            return devices.Count;
        }
    }
}