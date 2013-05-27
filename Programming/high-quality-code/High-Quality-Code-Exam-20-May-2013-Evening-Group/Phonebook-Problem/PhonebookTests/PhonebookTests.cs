using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhonebookApp;

namespace PhonebookTests
{
    [TestClass]
    public class PhonebookTests
    {
        [TestMethod]
        public void AddPhone_WorksWithDuplicatedNewNumber()
        {
            Phonebook book = new Phonebook();

            List<string> phones = new List<string>();
            phones.Add("+359222111");
            phones.Add("+3593484374");
            phones.Add("+35992738278");

            book.AddPhone("John", phones);

            phones.Clear();

            phones.Add("+359222111");

            book.AddPhone("John", phones);

            int phonesCount = book.NamesDictionary["john"].PhoneNumbers.Count;

            bool exists = book.AddPhone("JoHn", phones);

            Assert.AreEqual(true, exists);
            Assert.AreEqual(3, phonesCount);
        }

        [TestMethod]
        public void AddPhone_WorksWithDuplicatedNumbersInList()
        {
            Phonebook book = new Phonebook();

            List<string> phones = new List<string>();
            phones.Add("+359222111");
            phones.Add("+3593484374");
            phones.Add("+359222111");

            book.AddPhone("John", phones);

            int phonesCount = book.NamesDictionary["john"].PhoneNumbers.Count;

            Assert.AreEqual(2, phonesCount);
        }

        [TestMethod]
        public void ChangePhone_WorksOnEqualOldAndNewNumbers()
        {
            Phonebook book = new Phonebook();

            List<string> phones = new List<string>();
            phones.Add("+3592221431");
            phones.Add("+3593484374");
            phones.Add("+3598438748");

            book.AddPhone("John", phones);

            int phonesChanged = book.ChangePhone("+359222111", "+359222111");

            Assert.AreEqual(0, phonesChanged);
        }

        [TestMethod]
        public void ChangePhone_OldBeingReplacedWithExisting()
        {
            Phonebook book = new Phonebook();

            List<string> phones = new List<string>();
            phones.Add("+3592221431");
            phones.Add("+3593484374");
            phones.Add("+3598438748");

            book.AddPhone("John", phones);

            int oldPhonesCount = book.NamesDictionary["john"].PhoneNumbers.Count;

            book.ChangePhone("+3592221431", "+3593484374");

            int newPhonesCount = book.NamesDictionary["john"].PhoneNumbers.Count;

            Assert.AreEqual(3, oldPhonesCount);
            Assert.AreEqual(2, newPhonesCount); // instead of 3 with 2 being duplicated (+3593484374)
        }

        [TestMethod]
        public void ChangePhone_WorksOnMultipleChanges()
        {
            Phonebook book = new Phonebook();

            List<string> phones = new List<string>();

            phones.Add("+35988199283");
            phones.Add("+359848374");
            phones.Add("+3599033874");

            book.AddPhone("Test", phones);

            int changes = book.ChangePhone("+359848374", "+4839474387");
            Assert.AreEqual(1, changes);

            changes = book.ChangePhone("+4839474387", "+359848374");
            Assert.AreEqual(1, changes);
        }

        [TestMethod]
        public void ChangePhone_WorksOnReplaceingNonExistingWithNoExisting()
        {
            Phonebook book = new Phonebook();

            List<string> phones = new List<string>();

            int changes = book.ChangePhone("+83948384", "+48394839843");

            Assert.AreEqual(0, changes);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Index must be non-negative.")]
        public void ListEntries_ThrowsExceptionOnNegativeStartIndex()
        {
            Phonebook book = new Phonebook();

            book.ListEntries(-1, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Index must be non-negative.")]
        public void ListEntries_ThrowsExceptionOnBigIndex()
        {
            Phonebook book = new Phonebook();

            book.ListEntries(100, 4);
        }

        [TestMethod]
        public void ListEntries_ReturnsEmptyArrayOnZeroCount()
        {
            Phonebook book = new Phonebook();

            PhonebookEntry[] entries = book.ListEntries(0, 0);

            Assert.AreEqual(0, entries.Length);
        }

        [TestMethod]
        public void ListEntries_WorksOnCountEqualToCurrentPhonebookCount()
        {
            Phonebook book = new Phonebook();

            List<string> phones = new List<string>();
            phones.Add("+3592221431");
            phones.Add("+3593484374");
            phones.Add("+3598438748");

            book.AddPhone("John", phones);

            List<string> davePhones = new List<string>();

            davePhones.Add("+3593484374"); // equal to John's second
            davePhones.Add("+35932378439");
            davePhones.Add("+3590034884");

            book.AddPhone("Dave", davePhones);

            int entriesCount = book.ListEntries(0, 2).Length;

            Assert.AreEqual(2, entriesCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Less than the requested exist")]
        public void ListEntries_ThrowsExceptionOnCountBiggerThanActual()
        {
            Phonebook book = new Phonebook();

            List<string> phones = new List<string>();
            phones.Add("+3592221431");
            phones.Add("+3593484374");
            phones.Add("+3598438748");

            book.AddPhone("John", phones);

            List<string> davePhones = new List<string>();

            davePhones.Add("+3593484374"); // equal to John's second
            davePhones.Add("+35932378439");
            davePhones.Add("+3590034884");

            book.AddPhone("Dave", davePhones);

            int entriesCount = book.ListEntries(0, 10).Length;
        }

        [TestMethod]
        public void ListEntries_WorksOnCountLessThanActualAndIsSorted()
        {
            Phonebook book = new Phonebook();

            List<string> phones = new List<string>();
            phones.Add("+3592221431");
            phones.Add("+3593484374");
            phones.Add("+3598438748");

            book.AddPhone("John", phones);

            List<string> davePhones = new List<string>();

            davePhones.Add("+3593484374"); // equal to John's second
            davePhones.Add("+35932378439");
            davePhones.Add("+3590034884");

            List<string> adamPhones = new List<string>();

            adamPhones.Add("+3593484374"); // equal to John's second
            adamPhones.Add("+35932378439");
            adamPhones.Add("+3590034884");

            book.AddPhone("Adam", davePhones);

            PhonebookEntry[] entries = book.ListEntries(0, 1);

            string name = entries[0].Name;
            int count = entries.Length;

            Assert.AreEqual(1, count);
            Assert.AreEqual("Adam", name);
        }
    }
}
