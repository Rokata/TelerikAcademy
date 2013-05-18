using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem04_Free_Content;

namespace CatalogTests
{
    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void UpdateContent_Returns0OnNonExistingKeyEntry()
        {
            Catalog catalog = new Catalog();
            int updated = catalog.UpdateContent("non-existing", "another");

            Assert.AreEqual(0, updated);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "No null values")]
        public void UpdateContent_ThrowsExceptionOnNullParameter()
        {
            Catalog catalog = new Catalog();
            catalog.UpdateContent(null, "new url");
        }

        [TestMethod]
        public void UpdateContent_Returns0OnEqualUrlParams()
        {
            Catalog catalog = new Catalog();

            string commandStr = "Add movie: One; James Wong (2001); 969763002; http://www.imdb.com/title/tt0267804/";
            ICommand command = new Command(commandStr);

            ICommandExecutor executor = new CommandExecutor();
            executor.ExecuteCommand(catalog, command, new System.Text.StringBuilder());

            int updated = catalog.UpdateContent("http://www.imdb.com/title/tt0267804/", "http://www.imdb.com/title/tt0267804/");
            Assert.AreEqual(0, updated);
        }

        [TestMethod]
        public void UpdateContent_OnSingleMatchingElement()
        {
            string[] commandStrings = { "Add movie: One; James Wong (2001); 969763002; http://www.imdb.com/title/tt0267804/",
                                       "Add song: One; Metallica (2000); 734837437; http://sample.net",
                                       "Add application: Google Chrome; Chrome; 374837837; http://google.com"};

            Catalog catalog = new Catalog();
            ICommandExecutor executor = new CommandExecutor();

            foreach (string commandString in commandStrings)
            {
                ICommand command = new Command(commandString);
                executor.ExecuteCommand(catalog, command, new System.Text.StringBuilder());
            }

            int updated = catalog.UpdateContent("http://google.com", "http://google.bg");
            Assert.AreEqual(1, updated);
        }

        [TestMethod]
        public void UpdateContent_DoubleUpdatingElement()
        {
            string[] commandStrings = { "Add movie: One; James Wong (2001); 969763002; http://www.imdb.com/title/tt0267804/",
                                       "Add song: One; Metallica (2000); 734837437; http://sample.net",
                                       "Add application: Google Chrome; Chrome; 374837837; http://google.com"};

            Catalog catalog = new Catalog();
            ICommandExecutor executor = new CommandExecutor();

            foreach (string commandString in commandStrings)
            {
                ICommand command = new Command(commandString);
                executor.ExecuteCommand(catalog, command, new System.Text.StringBuilder());
            }

            catalog.UpdateContent("http://sample.net", "http://sample.com");
            int updated = catalog.UpdateContent("http://sample.com", "http://sample.net");
            Assert.AreEqual(1, updated);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "No null values allowed")]
        public void Add_ThrowsExceptionOnNullParameter()
        {
            Catalog catalog = new Catalog();
            catalog.Add(null);
        }

        [TestMethod]
        public void Add_ExecutesOKOnDuplicates()
        {
            Catalog catalog = new Catalog();

            string commandStr = "Add movie: One; James Wong (2001); 969763002; http://www.imdb.com/title/tt0267804/";
            ICommand command = new Command(commandStr); 
            ICommandExecutor executor = new CommandExecutor();

            for (int i = 0; i < 3; i++)
            {                
                executor.ExecuteCommand(catalog, command, new System.Text.StringBuilder());
            }
        }

        [TestMethod]
        public void GetListContent_MatchedEqualToRequested()
        {
            Catalog catalog = new Catalog();

            string commandStr = "Add movie: One; James Wong (2001); 969763002; http://www.imdb.com/title/tt0267804/";
            ICommand command = new Command(commandStr);
            ICommandExecutor executor = new CommandExecutor();

            for (int i = 0; i < 3; i++)
            {
                executor.ExecuteCommand(catalog, command, new System.Text.StringBuilder());
            }

            IEnumerable<IContent> result = catalog.GetListContent("One", 3);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void GetListContent_MatchedLessThanTheRequested()
        {
            string[] commandStrings = { "Add movie: One; James Wong (2001); 969763002; http://www.imdb.com/title/tt0267804/",
                                       "Add song: One; Metallica (2000); 734837437; http://sample.net",
                                       "Add application: Google Chrome; Chrome; 374837837; http://google.com"};

            Catalog catalog = new Catalog();
            ICommandExecutor executor = new CommandExecutor();

            foreach (string commandString in commandStrings)
            {
                ICommand command = new Command(commandString);
                executor.ExecuteCommand(catalog, command, new System.Text.StringBuilder());
            }

            IEnumerable<IContent> result = catalog.GetListContent("One", 6);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void GetListContent_MatchedMoreThanTheRequestedAndSingleTest()
        {
            string[] commandStrings = { "Add movie: One; James Wong (2001); 969763002; http://www.imdb.com/title/tt0267804/",
                                       "Add song: One; Metallica (2000); 734837437; http://sample.net",
                                       "Add application: Google Chrome; Chrome; 374837837; http://google.com", 
                                       "Add song: One; Metallica (2000); 37483743; http://test.net"};

            Catalog catalog = new Catalog();
            ICommandExecutor executor = new CommandExecutor();

            foreach (string commandString in commandStrings)
            {
                ICommand command = new Command(commandString);
                executor.ExecuteCommand(catalog, command, new System.Text.StringBuilder());
            }

            IEnumerable<IContent> result = catalog.GetListContent("One", 1);
            IEnumerable<IContent> secondResult = catalog.GetListContent("Google Chrome", 2);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(1, secondResult.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "No negative value")]
        public void GetListContent_ThrowsExceptionOnNegativeElementsValue()
        {
            Catalog catalog = new Catalog();
            catalog.GetListContent("Some title", -23);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "No negative value")]
        public void GetListContent_ThrowsExceptionOnEmptyTitle()
        {
            Catalog catalog = new Catalog();
            catalog.GetListContent("", 2);
        }

        [TestMethod]
        public void GetListContent_ReturnsEmptyListOnNonExisting()
        {
            Catalog catalog = new Catalog();
            IEnumerable<IContent> result = catalog.GetListContent("some title", 5);
            Assert.AreEqual(0, result.Count());
        }
    }
}
