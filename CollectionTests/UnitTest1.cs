using Collection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CollectionTests
{
    [TestClass]
    public class CustomDictionaryTest
    {

        // testing add method
        [TestMethod]
        public void AddValues()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.Add("Spain", "Madrid");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Key already exists")]
        public void AddValueWhenKeyIsAlreadyExists()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.Add("Spain", "Madrid");
            dict.Add("Spain", "Madrid");
        }
        [TestMethod]
        public void AddValueWhenKeyIsAlreadyExistsButWasDeleted()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.Add("Spain", "Madrid");
            dict.Remove("Spain");
            dict.Add("Spain", "Madrid");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Keys couldn't be null")]
        public void AddNulls()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.Add(null, null);
        }


        //Test Clear method
        [TestMethod]
        public void AlearingDictionary_checkUsingCountMethod()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.Add("Spain", "Madrid");
            dict.Add("Georgia", "Tbilisi");
            Assert.AreEqual(dict.Count, 2);
            dict.Clear();
            Assert.AreEqual(dict.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Key not found")]
        public void ClearingDictionary_checkUsingTryGetValue()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.Add("Spain", "Madrid");
            dict.Add("Georgia", "Tbilisi");
            dict.Clear();
            dict.TryGetValue("Spain", out string value);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Key not found")]
        public void ClearingDictionary_checkUsingGetValueByKey()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.Add("Spain", "Madrid");
            dict.Add("Georgia", "Tbilisi");
            dict.Clear();
            string val = dict["Spain"];
        }


        // test ContainsKey method
        [TestMethod]
        [ExpectedException(typeof(Exception), "Key is null")]
        public void ContainsNullKey()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.ContainsKey(null);
        }

        [TestMethod]
        public void CheckContainsExistingKey()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.Add("Spain", "Madrid");
            dict.Add("Georgia", "Tbilisi");
            Assert.AreEqual(dict.ContainsKey("Spain"), true);
            Assert.AreEqual(dict.ContainsKey("Georgia"), true);
        }
        [TestMethod]
        public void CheckContainsNotExistingKey()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            Assert.AreEqual(dict.ContainsKey("Georgia"), false);
            Assert.AreEqual(dict.ContainsKey("France"), false);
        }

        // test Remove method
        [TestMethod]
        public void RemovingExistingKey()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.Add("Spain", "Madrid");
            dict.Remove("Spain");
            Assert.AreEqual(dict.ContainsKey("Spain"), false);

        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Key not found")]
        public void RemovingNotExistingKey()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.Remove("Spain");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Key is null")]
        public void RemovingNull()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.Remove(null);
        }


        // testing get and set by index
        //get

        [TestMethod]
        public void GetValueByExistingKey()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.Add("Spain", "Madrid");
            dict.Add("Georgia", "Tbilisi");
            Assert.AreEqual(dict["Spain"], "Madrid");
            Assert.AreEqual(dict["Georgia"], "Tbilisi");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Key not found")]
        public void GetValueByNotExistingKey()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            string val = dict["Spain"];
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Key is null")]
        public void GetValueByNullKey()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            string val = dict[null];
        }

        //set

        [TestMethod]
        public void SetValueBySomeKey()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict["Spain"] = "Madrid";
            dict["Georgia"] = "Tbilisi";
            Assert.AreEqual(dict["Spain"], "Madrid");
            Assert.AreEqual(dict["Georgia"], "Tbilisi");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Key is null")]
        public void SetValueByNullKey()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict[null] = "Madrid";
        }
        [TestMethod]
        public void SetNullValueBySomeKey()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict["Spain"] = null;
            Assert.AreEqual(dict["Spain"], null);

        }

        [TestMethod]
        public void SetValueWhenKeyIsAlreadyExists()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.Add("Spain", "Madrid");
            dict["Spain"] = "Madrid2";
            Assert.AreEqual(dict["Spain"], "Madrid2");
        }


        // testing getting keys
        [TestMethod]
        public void GetAllKeys_checkingByKeysCount()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            Assert.AreEqual(dict.Keys.Count, 0);
            dict.Add("Spain", "Madrid");
            dict["Georgia"] = "Tbilisi";
            Assert.AreEqual(dict.Keys.Count, 2);
            dict["Georgia"] = "Tbilisi2";
            Assert.AreEqual(dict.Keys.Count, 2);
            dict["France"] = "Paris";
            Assert.AreEqual(dict.Keys.Count, 3);
            dict.Remove("Georgia");
            Assert.AreEqual(dict.Keys.Count, 2);
            dict.Clear();
            Assert.AreEqual(dict.Keys.Count, 0);
            dict.Add("Spain", "Madrid");
            Assert.AreEqual(dict.Keys.Count, 1);
        }


        [TestMethod]
        public void GetAllKeys_checkingByKeysNames()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.Add("Spain", "Madrid");
            Assert.AreEqual(dict.Keys.OfType<string>().FirstOrDefault(), "Spain");
            dict.Clear();
            dict["France"] = "Paris";
            Assert.AreEqual(dict.Keys.OfType<string>().FirstOrDefault(), "France");

        }

        // testing getting values
        [TestMethod]
        public void GetAllValues_checkingByValuesCount()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            Assert.AreEqual(dict.Values.Count, 0);
            dict.Add("Spain", "Madrid");
            dict["Georgia"] = "Tbilisi";
            Assert.AreEqual(dict.Values.Count, 2);
            dict["Georgia"] = "Tbilisi2";
            Assert.AreEqual(dict.Values.Count, 2);
            dict["France"] = "Paris";
            Assert.AreEqual(dict.Values.Count, 3);
            dict.Remove("Georgia");
            Assert.AreEqual(dict.Values.Count, 2);
            dict.Clear();
            Assert.AreEqual(dict.Values.Count, 0);
            dict.Add("Spain", "Madrid");
            Assert.AreEqual(dict.Values.Count, 1);
            Assert.AreEqual(dict.Values.OfType<string>().FirstOrDefault(), "Madrid");

        }

        [TestMethod]
        public void GetAllValues_checkingByValuesNames()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.Add("Spain", "Madrid");
            Assert.AreEqual(dict.Values.OfType<string>().FirstOrDefault(), "Madrid");
            dict.Clear();
            dict["France"] = "Paris";
            Assert.AreEqual(dict.Values.OfType<string>().FirstOrDefault(), "Paris");

        }

        //testing getting count
        [TestMethod]
        public void GetCount()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            Assert.AreEqual(dict.Values.Count, 0);
            dict.Add("Spain", "Madrid");
            dict["Georgia"] = "Tbilisi";
            Assert.AreEqual(dict.Count, 2);
            dict["Georgia"] = "Tbilisi2";
            Assert.AreEqual(dict.Count, 2);
            dict["France"] = "Paris";
            Assert.AreEqual(dict.Count, 3);
            dict.Remove("Georgia");
            Assert.AreEqual(dict.Count, 2);
            dict.Clear();
            Assert.AreEqual(dict.Count, 0);
            dict.Add("Spain", "Madrid");
            Assert.AreEqual(dict.Count, 1);
        }


        //testing TryGetValue method
        [TestMethod]
        public void TryGetExistingValue()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.Add("Spain", "Madrid");
            dict.Add("Georgia", "Tbilisi");
            dict.TryGetValue("Spain", out string value);
            Assert.AreEqual(value, "Madrid");
            dict.TryGetValue("Georgia", out string value2);
            Assert.AreEqual(value2, "Tbilisi");

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Key not found")]
        public void TryGetNotExistingValue()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.TryGetValue("Spain", out string value);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Key is null")]
        public void TryGetNullValue()
        {
            CustomDictionary<string, string> dict = new CustomDictionary<string, string>();
            dict.TryGetValue(null, out string value);
        }
    }
}
