using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace laba14.Tests
{
    [TestClass]
    public class FactoryMenuTests
    {
        private Factory _testFactory;

        [TestInitialize]
        public void Setup()
        {
            _testFactory = Program.InitializeFactory();
        }

        [TestMethod]
        public void TestQueryWhere()
        {
            // Arrange & Act
            using (var consoleOutput = new ConsoleOutput())
            {
                FactoryMenu.QueryWhere(_testFactory);

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
                FactoryMenu.QueryUnionExceptIntersect(_testFactory);

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
                FactoryMenu.QueryAggregation(_testFactory);

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
                FactoryMenu.QueryGroupBy(_testFactory);

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
                FactoryMenu.QueryJoin(_testFactory);

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
