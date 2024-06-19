using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace laba14.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestInitializeFactory()
        {
            // Arrange & Act
            var factory = Program.InitializeFactory();

            // Assert
            Assert.IsNotNull(factory);
            Assert.AreEqual(2, factory.Workshops.Count());
            foreach (var workshop in factory.Workshops)
            {
                Assert.AreEqual(15, workshop.Cars.Count);
            }
        }

        [TestMethod]
        public void TestInitializeMyCollection()
        {
            // Arrange & Act
            var collection = Program.InitializeMyCollection();

            // Assert
            Assert.IsNotNull(collection);
            Assert.AreEqual(10, collection.Count());
        }


        // Helper classes for simulating console input and output
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
