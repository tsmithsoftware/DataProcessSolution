using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataProcessSolution.Tests.Utilities;
using DataProcessSolution.WorkerRole.Operations;
using NUnit.Framework;
using Rhino.Etl.Core;
using DataProcessSolution.WorkerRole.Entities;
using Microsoft.VisualBasic.FileIO;

namespace DataProcessSolution.Tests.WorkerRoleTests
{
    [TestFixture]
    public class UserFullWriteTests
    {
        private readonly string _baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        [Test]
        public void TestPassedRowsWrittenToFile()
        {
            //Setup
            string fileLocation = $"{_baseDirectory}\\ResultsFile.csv";
            FirstStageUserFullWrite sut = new FirstStageUserFullWrite(fileLocation);
            IEnumerable<Row> rows = new List<Row>()
            {
                Row.FromObject(new UserFullRecord()
                {
                    UserName = "John",
                    UserAddress = "23 Oligarch Avenue",
                    UserOrder = "Some Bananas"
                })
            };
            var results = sut.Execute(rows);
            results.ToList();
            Assert.IsTrue(File.Exists(fileLocation));
            Assert.IsTrue(FileContainsRows(fileLocation,rows));
        }

        private bool FileContainsRows(string fileLocation, IEnumerable<Row> rows)
        {
            bool doesFileContainsRows = true;
            //parse file into UserFullRecords
            List<UserFullRecord> savedRecords = new List<UserFullRecord>();
            using (TextFieldParser parser = new TextFieldParser(fileLocation))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                //skip headers
                parser.ReadLine();
                //process data
                while (!parser.EndOfData)
                {
                    UserFullRecord record = new UserFullRecord();
                    //Processing row
                    string[] fields = parser.ReadFields();
                    record.UserName = fields[0];
                    record.UserAddress = fields[1];
                    record.UserOrder = fields[2];
                    savedRecords.Add(record);
                }
            }

            List<UserFullRecord> passedRecords = new List<UserFullRecord>();

            foreach (var record in rows)
            {
                passedRecords.Add(record.ToObject<UserFullRecord>());
            }

            var comparator = new UserFullRecordComparator();
            foreach (var record in savedRecords)
            {
                if (!passedRecords.Contains(record, comparator)) doesFileContainsRows = false;
            }
            return doesFileContainsRows;
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists($"{_baseDirectory}\\ResultsFile.csv"))
            {
                File.Delete($"{_baseDirectory}\\ResultsFile.csv");
            }
        }
    }
}
