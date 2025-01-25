using LD4_22;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Xml.Linq;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Tests if it creates fridge class corectly
        /// </summary>
        [TestMethod]
        public void FridgeConstructorInitializesCorrectly()
        {
            var manufacturer = "Whirlpool";
            var model = "WRX735SDHZ";
            var energyClass = "A+";
            var color = "Silver";
            var price = 1299.99;
            var capacity = 500;
            var installType = "Freestanding";
            var hasFreezer = true;
            var height = 180;
            var width = 70;
            var depth = 75;

            var fridge = new Fridge(
                manufacturer, model, energyClass, color, price,
                capacity, installType, hasFreezer, height, width, depth);

            Assert.AreEqual(manufacturer, fridge.manufacturer);
            Assert.AreEqual(model, fridge.model);
            Assert.AreEqual(energyClass, fridge.energyClass);
            Assert.AreEqual(color, fridge.color);
            Assert.AreEqual(price, fridge.price);
            Assert.AreEqual(capacity, fridge.capacity);
            Assert.AreEqual(installType, fridge.installType);
            Assert.AreEqual(hasFreezer, fridge.hasFreezer);
            Assert.AreEqual(height, fridge.height);
            Assert.AreEqual(width, fridge.width);
            Assert.AreEqual(depth, fridge.depth);
        }
        /// <summary>
        /// Checks if compareto method is correct
        /// </summary>
        [TestMethod]
        public void FridgeCompareToHeightComparison()
        {
            var tallerFridge = new Fridge("A", "B", "C", "D", 1000, 500,
                                          "Freestanding", true, 190, 70, 75);
            var shorterFridge = new Fridge("A", "B", "C", "D", 1000, 500,
                                           "Freestanding", true, 170, 70, 75);

            Assert.AreEqual(-1, shorterFridge.CompareTo(tallerFridge));
            Assert.AreEqual(1, tallerFridge.CompareTo(shorterFridge));
        }
        /// <summary>
        /// Checks if it creates correct store class
        /// </summary>
        [TestMethod]
        public void StoreConstructorInitializesCorrectly()
        {
            var name = "ElectroMart";
            var address = "123 Elm Street";
            var phone = "123-456-7890";

            var store = new Store(name, address, phone);

            Assert.AreEqual(name, store.name);
            Assert.AreEqual(address, store.adress);
            Assert.AreEqual(phone, store.phone);
        }
        /// <summary>
        /// Checks if adds devices to store class
        /// </summary>
        [TestMethod]
        public void StoreAddDevicesStoresDevicesCorrectly()
        {
            var store = new Store("ElectroMart", "123 Elm Street",
                                  "123-456-7890");
            var device = new Fridge("Whirlpool", "WRX735SDHZ", "A+", "Silver",
                                    1299.99, 500, "Freestanding", true, 180, 70,
                                    75);

            store.AddDevices(device);

            Assert.AreEqual(1, store.DeviceCount());
            Assert.AreEqual(device, store.GetDevice(0));
        }
        /// <summary>
        /// Checks if fridge equal works
        /// </summary>
        [TestMethod]
        public void FridgeEqualsTypeComparison()
        {
            var fridge = new Fridge("Whirlpool", "WRX735SDHZ", "A+", "Silver",
                                    1299.99, 500, "Freestanding", true, 180, 70,
                                    75);

            Assert.IsTrue(fridge.Equals('F'));
            Assert.IsFalse(fridge.Equals('O'));
        }
        /// <summary>
        /// Checks if color comparision works
        /// </summary>
        [TestMethod]
        public void FridgeEqualsColorComparison()
        {
            var fridge = new Fridge("Whirlpool", "WRX735SDHZ", "A+", "Silver",
                                    1299.99, 500, "Freestanding", true, 180, 70,
                                    75);

            Assert.IsTrue(fridge.Equals("Silver"));
            Assert.IsFalse(fridge.Equals("Black"));
            Assert.IsFalse(fridge.Equals(""));
        }
        /// <summary>
        /// Checks if adds only unique colors
        /// </summary>
        [TestMethod]
        public void ColorReturnsUniqueColors()
        {
            var store = new Store("Store1", "Address1", "123-456");
            var fridge1 = new Fridge("Brand1", "Model1", "A+", "White", 500, 300,
                                     "Freestanding", true, 180, 70, 75);
            var fridge2 = new Fridge("Brand2", "Model2", "A+", "White", 500, 300,
                                     "Freestanding", true, 180, 70, 75);
            var fridge3 = new Fridge("Brand3", "Model3", "A+", "Silver", 500, 300,
                                     "Freestanding", true, 180, 70, 75);

            store.AddDevices(fridge1);
            store.AddDevices(fridge2);
            store.AddDevices(fridge3);

            var stores = new List<Store> { store };

            var colors = TaskUtils.Color(stores, 'F');

            Assert.AreEqual(2, colors.Count);
            Assert.IsTrue(colors.Contains("White"));
            Assert.IsTrue(colors.Contains("Silver"));
        }
        /// <summary>
        /// Checks if it returns cheapest device
        /// </summary>
        [TestMethod]
        public void CheapestReturnsCheapestDevice()
        {
            var store = new Store("Store1", "Address1", "123-456");
            var fridge1 = new Fridge("Brand1", "Model1", "A+", "White", 400, 300,
                                     "Freestanding", true, 180, 70, 75);
            var fridge2 = new Fridge("Brand2", "Model2", "A+", "Silver", 300, 300,
                                     "Freestanding", true, 180, 70, 75);

            store.AddDevices(fridge1);
            store.AddDevices(fridge2);

            var stores = new List<Store> { store };

            var cheapestFridge = TaskUtils.Cheapest(stores, 'F');

            Assert.AreEqual(fridge2, cheapestFridge);
        }
        /// <summary>
        /// Checks if it sorts correctly
        /// </summary>
        [TestMethod]
        public void SortsDevicesCorrectly()
        {
            var devices = new List<Device>
            {   new Fridge("Brand1", "Model1", "A+", "White", 500, 300,
                           "Freestanding", true, 180, 70, 75),
                new Fridge("Brand2", "Model2", "A+", "Silver", 300, 300,
                           "Freestanding", true, 150, 70, 75),
                new Fridge("Brand3", "Model3", "A+", "Black", 400, 300,
                           "Freestanding", true, 170, 70, 75)   };

            var expectedSorted = new List<Device>
            {   devices[0], devices[2], devices[1]  };

            TaskUtils.Sort(devices);

            CollectionAssert.AreEqual(expectedSorted, devices);
        }
    }
}