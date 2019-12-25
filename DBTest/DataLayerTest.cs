using NUnit.Framework;
using UPrint.database;
using UPrint.database.entity;
using UPrint.accessor;
using System.Collections.Generic;
using System;
using UPrint;
using System.Data;
using UPrint.converter;
using UPrint.util;
using System.Diagnostics;
using System.Linq;

namespace UPrint.test
{

    [TestFixture]
    public class DBTest
    {
        UPrintDataSet dataSet;
        PrinterDataAccessor printerDA;
        ModelDataAccessor modelDA;
        JobDataAccessor jobDA;
        PersonDataAccessor personDA;
        TaskDataAccessor taskDA;

        [OneTimeSetUp]
        public void Init()
        { 
            DBUtil.Reset();
            printerDA = new PrinterDataAccessor();
            modelDA = new ModelDataAccessor();
            jobDA = new JobDataAccessor();
            personDA = new PersonDataAccessor();
            taskDA = new TaskDataAccessor();
        }

        [SetUp]
        public void Setup()
        {
            DBUtil.Clean();
            dataSet = new UPrintDataSet();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            DBUtil.Clean();
        }

        [Test]
        public void TestPrinter()
        {
            IDataAccessor da = printerDA;
            read(da);
            Assert.AreEqual(0, dataSet.printer.Rows.Count, "Table is empty");
            DataRow newRow = dataSet.printer.NewRow();
            PrinterConverter.toDataRow(newRow, new Printer("TestPrinter"));
            dataSet.printer.Rows.Add(newRow);
            write(da);
            read(da);
            Assert.AreEqual(1, dataSet.printer.Rows.Count, "Added one record");
            DataRow firstRow = dataSet.printer.Rows[0];
            Assert.AreEqual("TestPrinter", firstRow["name"], "Names are equals");
            firstRow["name"] = "RenameTest";
            write(da);
            List<DataRow> findList = dataSet.printer.Select("name = 'RenameTest'").OfType<DataRow>().ToList();
            Assert.AreEqual("RenameTest", findList[0]["name"], "Names are equals");
            firstRow.Delete();
            write(da);
            read(da);
            int count = dataSet.printer.Rows.Count;
            Assert.AreEqual(0, count);
        }

        [Test]
        public void TestModel()
        {
            IDataAccessor da = modelDA;
            read(da);
            //DataTable table = dataSet.model;
            Assert.AreEqual(0, dataSet.model.Rows.Count, "Table is empty");
            DataRow newRow = dataSet.model.NewRow();
            ModelConverter.toDataRow(newRow, new Model("TestModel"));
            dataSet.model.Rows.Add(newRow);
            write(da);
            Assert.AreEqual(1, dataSet.model.Rows.Count, "Added one record");
            DataRow firstRow = dataSet.model.Rows[0];
            Assert.AreEqual("TestModel", firstRow["name"], "Names are equals");
            firstRow["name"] = "RenameTest";
            write(da);
            List<DataRow> findList = dataSet.model.Select("name = 'RenameTest'").OfType<DataRow>().ToList();
            Assert.AreEqual("RenameTest", findList[0]["name"], "Names are equals");
            firstRow.Delete();
            write(da);
            read(da);
            int count = dataSet.model.Rows.Count;
            Assert.AreEqual(0, count);
        }

        [Test]
        public void TestPerson()
        {
            IDataAccessor da = personDA;
            read(da);
            DataTable table = dataSet.person;
            Assert.AreEqual(0, table.Rows.Count, "Table is empty");
            DataRow newRow = table.NewRow();
            PersonConverter.toDataRow(newRow, new Person("TestPerson", "password", Person.PersonType.REGULAR));
            table.Rows.Add(newRow);
            write(da);
            Assert.AreEqual(1, table.Rows.Count, "Added one record");
            DataRow firstRow = table.Rows[0];
            Assert.AreEqual("TestPerson", firstRow["name"], "Names are equals");
            firstRow["name"] = "RenameTest";
            write(da);
            List<DataRow> findList = table.Select("name = 'RenameTest'").OfType<DataRow>().ToList();
            Assert.AreEqual("RenameTest", findList[0]["name"], "Names are equals");
            firstRow.Delete();
            write(da);
            dataSet = new UPrintDataSet();
            read(da);
            int count = dataSet.person.Rows.Count;
            Assert.AreEqual(0, count);
        }

        [Test]
        public void TestJob()
        {
            IDataAccessor da = jobDA;
            read(da);
            DataTable table = dataSet.job;
            Assert.AreEqual(0, table.Rows.Count, "Table is empty");
            DataRow personRow = dataSet.person.NewRow();
            Person person = new Person("person", "", Person.PersonType.ADMIN);
            PersonConverter.toDataRow(personRow, person);
            dataSet.person.Rows.Add(personRow);
            write(personDA);
            DataRow modelRow = dataSet.model.NewRow();
            Model model = new Model("model");
            ModelConverter.toDataRow(modelRow, model);
            dataSet.model.Rows.Add(modelRow);
            write(modelDA);
            DataRow newRow = table.NewRow();
            JobConverter.toDataRow(newRow, new Job(0, "TestJob", DateTime.Now, "test", 0, 0));
            table.Rows.Add(newRow);
            write(da);
            Assert.AreEqual(1, table.Rows.Count, "Added one record");
            DataRow firstRow = table.Rows[0];
            Assert.AreEqual("TestJob", firstRow["name"], "Names are equals");
            firstRow["name"] = "RenameTest";
            write(da);
            List<DataRow> findList = table.Select("name = 'RenameTest'").OfType<DataRow>().ToList();
            Assert.AreEqual("RenameTest", findList[0]["name"], "Names are equals");
            firstRow.Delete();
            write(da);
            read(da);
            int count = dataSet.job.Rows.Count;
            Assert.AreEqual(0, count);
        }

        [Test]
        public void TestTask()
        {
            IDataAccessor da = taskDA;
            read(da);
            DataTable table = dataSet.task;
            Assert.AreEqual(0, table.Rows.Count, "Table is empty");
            DataRow personRow = dataSet.person.NewRow();
            Person person = new Person("person", "", Person.PersonType.ADMIN);
            PersonConverter.toDataRow(personRow, person);
            dataSet.person.Rows.Add(personRow);
            write(personDA);
            DataRow modelRow = dataSet.model.NewRow();
            Model model = new Model("model");
            ModelConverter.toDataRow(modelRow, model);
            dataSet.model.Rows.Add(modelRow);
            write(modelDA);
            DataRow jobRow = dataSet.job.NewRow();
            Job job = new Job(0, "job", DateTime.Now, "test", 0, 0);
            JobConverter.toDataRow(jobRow, job);
            dataSet.job.Rows.Add(jobRow);
            write(jobDA);
            DataRow printerRow = dataSet.printer.NewRow();
            Printer printer = new Printer("printer");
            PrinterConverter.toDataRow(printerRow, printer);
            dataSet.printer.Rows.Add(printerRow);
            write(printerDA);
            DataRow newRow = table.NewRow();
            TaskConverter.toDataRow(newRow, new Task(0, "TestTask", 0, 0, DateTime.Now, DateTime.Now, DateTime.Now, Task.TaskStatus.NEW, 0));
            table.Rows.Add(newRow);
            write(da);
            Assert.AreEqual(1, table.Rows.Count, "Added one record");
            DataRow firstRow = table.Rows[0];
            Assert.AreEqual("TestTask", firstRow["name"], "Names are equals");
            firstRow["name"] = "RenameTest";
            write(da);
            List<DataRow> findList = table.Select("name = 'RenameTest'").OfType<DataRow>().ToList();
            Assert.AreEqual("RenameTest", findList[0]["name"], "Names are equals");
            firstRow.Delete();
            write(da);
            read(da);
            int count = dataSet.task.Rows.Count;
            Assert.AreEqual(0, count);
        }


        private void read(IDataAccessor da)
        {
            bool exx = false;
            AbstractConnection connection = null;
            AbstractTransaction transaction = null;
            dataSet = new UPrintDataSet();
            try
            {
                connection = DBFactory.CreateConnection();
                connection.Open();
                transaction = connection.BeginTransaction();
                da.Read(connection, transaction, dataSet);
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
            Assert.IsFalse(exx, "Exceptions not throwed");
        }

        private void write(IDataAccessor da)
        {
            bool exx = false;
            AbstractConnection connection = null;
            AbstractTransaction transaction = null;
            try
            {
                connection = DBFactory.CreateConnection();
                connection.Open();
                transaction = connection.BeginTransaction();
                da.Update(connection, transaction, dataSet);
                transaction.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                exx = true;
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
            Assert.IsFalse(exx, "Exceptions not throwed");
        }

        [Test]
        public void TestClean()
        {
            IDataAccessor da = printerDA;
            read(da);
            DataTable table = dataSet.printer;
            DataRow newRow = table.NewRow();
            PrinterConverter.toDataRow(newRow, new Printer("printerForClean"));
            table.Rows.Add(newRow);
            write(da);
            DBUtil.Clean();
            read(da);
            Assert.AreEqual(0, dataSet.printer.Rows.Count);
        }
    }
}