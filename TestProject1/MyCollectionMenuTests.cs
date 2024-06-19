using ClassLibrary1;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace laba14.Tests
{
    [TestClass]
    public class MyCollectionMenuTests
    {
        private MyCollection<Auto> _testCollection;

        [TestInitialize]
        public void Setup()
        {
            _testCollection = new MyCollection<Auto>();
            for (int i = 0; i < 10; i++)
            {
                var auto = new Auto();
                auto.RandomInit();
                _testCollection.Add(auto);
            }
        }

        [TestMethod]
        public void TestQueryWhere()
        {
            // Arrange & Act
            using (var consoleOutput = new ConsoleOutput())
            {
                MyCollectionMenu.QueryWhere(_testCollection);

                // Assert
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Результаты запроса (Where (LINQ)):"));
            }
        }

        [TestMethod]
        public void TestQueryUnionExceptIntersect()
        {
            // Arrange & Act
            using (var consoleOutput = new ConsoleOutput())
            {
                MyCollectionMenu.QueryUnionExceptIntersect(_testCollection);

                // Assert
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Результаты запроса (Union):"));
            }
        }

        [TestMethod]
        public void TestQueryAggregation()
        {
            // Arrange & Act
            using (var consoleOutput = new ConsoleOutput())
            {
                MyCollectionMenu.QueryAggregation(_testCollection);

                // Assert
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Sum:"));
            }
        }

        [TestMethod]
        public void TestQueryGroupBy()
        {
            // Arrange & Act
            using (var consoleOutput = new ConsoleOutput())
            {
                MyCollectionMenu.QueryGroupBy(_testCollection);

                // Assert
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Результаты группировки (Группировка (LINQ)):"));
            }
        }

        [TestMethod]
        public void TestQueryJoin()
        {
            // Arrange & Act
            using (var consoleOutput = new ConsoleOutput())
            {
                MyCollectionMenu.QueryJoin(_testCollection);

                // Assert
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Результаты запроса на соединение (Соединение):"));
            }
        }

        private class ConsoleInput : IDisposable
        {
            private readonly StringReader _reader;
            private readonly TextReader _originalInput;

            public ConsoleInput(string simulatedInput)
            {
                _reader = new StringReader(simulatedInput);
                _originalInput = Console.In;
                Console.SetIn(_reader);
            }

            public ConsoleInput(string[] simulatedInputs) : this(string.Join(Environment.NewLine, simulatedInputs)) { }

            public void Dispose()
            {
                Console.SetIn(_originalInput);
                _reader.Dispose();
            }
        }

        private class ConsoleOutput : IDisposable
        {
            private readonly StringWriter _writer;
            private readonly TextWriter _originalOutput;

            public ConsoleOutput()
            {
                _writer = new StringWriter();
                _originalOutput = Console.Out;
                Console.SetOut(_writer);
            }

            public string GetOutput()
            {
                return _writer.ToString();
            }

            public void Dispose()
            {
                Console.SetOut(_originalOutput);
                _writer.Dispose();
            }
        }
    }
}
