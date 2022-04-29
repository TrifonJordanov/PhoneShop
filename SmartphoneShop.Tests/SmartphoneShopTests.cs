using System;
using NUnit.Framework;

namespace SmartphoneShop.Tests
{

    public class SmartphoneShopTests
    {
        [Test]
        public void ValidateConstructor()
        {
            Shop shop = new Shop(2);
            Assert.AreEqual(2, shop.Capacity);
        }

        [Test]
        public void ValidateConstructor_CreateCollectionOfPhones()
        {
            Shop shop = new Shop(2);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void ValidateCapacityProperty_ThrowsExceptionWithNegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Shop(-1), "Invalid capacity.");
        }

        [Test]
        public void ValidateAddMethod_AddingCorrectlyPhone()
        {
            Smartphone phone = new Smartphone("Sony", 12);
            Shop shop = new Shop(12);
            shop.Add(phone);
            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void ValidateAddMethod_ThrowExceptionWithExistingPhone()
        {
            Smartphone phone = new Smartphone("Sony", 12);
            Shop shop = new Shop(12);
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(phone), "The phone model Sony already exist.");
        }

        [Test]
        public void ValidateAddMethod_ThrowExceptionWithNotEnoughCapacity()
        {
            Smartphone phone = new Smartphone("Sony", 12);
            Shop shop = new Shop(0);
            Assert.Throws<InvalidOperationException>(()=> shop.Add(phone), "The shop is full.");
        }

        [Test]
        public void ValidateRemoveMethod_RemoveCorrectlyExistingPhone()
        {
            Smartphone phone = new Smartphone("Sony", 12);
            Shop shop = new Shop(4);
            shop.Add(phone);
            shop.Remove("Sony");
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void ValidateRemoveMethod_ThrowExceptionWithNonExistingPhone()
        {
            Smartphone phone = new Smartphone("Sony", 12);
            Shop shop = new Shop(4);
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(()=> shop.Remove("Panasonic"), "The phone model Panasonic doesn't exist.");
        }

        [Test]
        public void ValidateTestPhoneMethod_ReduceCorrectlyPhoneBatteryCharge()
        {
            Smartphone phone = new Smartphone("Sony", 12);
            Shop shop = new Shop(4);
            shop.Add(phone);
            shop.TestPhone("Sony", 6);
            Assert.AreEqual(6, phone.CurrentBateryCharge);
        }

        [Test]
        public void ValidateTestPhoneMethod_ThrowExceptionWithUnExistingPhone()
        {
            Shop shop = new Shop(4);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Sony", 12),
                "The phone model Sony doesn't exist.");
        }

        [Test]
        public void ValidateTestPhoneMethod_ThrowExceptionWithNotEnoughBatteryOfPhone()
        {
            Smartphone phone = new Smartphone("Sony", 12);
            Shop shop = new Shop(4);
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Sony", 13), "The phone model Sony is low on batery.");
        }

        [Test]
        public void ValidatePhoneChargeMethod_CorrectlyChargePhoneBattery()
        {
            Smartphone phone = new Smartphone("Sony", 12);
            Shop shop = new Shop(4);
            shop.Add(phone);
            shop.TestPhone("Sony", 6);
            shop.ChargePhone("Sony");
            Assert.AreEqual(phone.MaximumBatteryCharge, phone.CurrentBateryCharge);
        }

        [Test]
        public void ValidatePhoneChargeMethod_ThrowExceptionWithUnExistingPhone()
        {
            Shop shop = new Shop(4);
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Sony"), "The phone model Sony doesn't exist.");
        }
    }
}