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
    public class DBTest
    {
        UPrintDataSet dataSet;
        PrinterDataAccessor printerDA;
        ModelDataAccessor modelDA;
        JobDataAccessor jobDA;
        PersonDataAccessor personDA;
        TaskDataAccessor taskDA;

        [SetUp]
        public void Setup()
        {
            DBUtil.Reset();
            dataSet = new UPrintDataSet();
            printerDA = new PrinterDataAccessor();
            modelDA = new ModelDataAccessor();
            jobDA = new JobDataAccessor();
            personDA = new PersonDataAccessor();
            taskDA = new TaskDataAccessor();
        }

        [Test]
        public void TestPrinter()
        {
            read();
            Assert.AreEqual(0, dataSet.printer.Rows.Count, "Table is empty");
            DataRow newRow = dataSet.printer.NewRow();
            PrinterConverter.toDataRow(newRow, new Printer("TestPrinter"));
            dataSet.printer.Rows.Add(newRow);
            write();
            Assert.AreEqual(1, dataSet.printer.Rows.Count, "Added one printer");
            DataRow firstRow = dataSet.printer.Rows[0];
            Assert.AreEqual("TestPrinter", firstRow["name"], "Names are equals");
            firstRow["name"] = "RenameTest";
            write();
            List<DataRow> findList = dataSet.printer.Select("name = 'RenameTest'").OfType<DataRow>().ToList();
            Assert.AreEqual("RenameTest", findList[0]["name"], "Names are equals");
            firstRow.Delete();
            write();
            dataSet = new UPrintDataSet();
            read();
            int count = dataSet.printer.Rows.Count;
            Assert.AreEqual(0, count);
        }

        private void read()
        {
            bool exx = false;
            AbstractConnection connection = null;
            AbstractTransaction transaction = null;
            try
            {
                connection = DBFactory.CreateConnection();
                connection.Open();
                transaction = connection.BeginTransaction();
                printerDA.Read(connection, transaction, dataSet);
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

        private void write()
        {
            bool exx = false;
            AbstractConnection connection = null;
            AbstractTransaction transaction = null;
            try
            {
                connection = DBFactory.CreateConnection();
                connection.Open();
                transaction = connection.BeginTransaction();
                printerDA.Update(connection, transaction, dataSet);
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
    }
}