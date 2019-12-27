using NUnit.Framework;
using System;
using UPrint.accessor;
using UPrint.converter;
using UPrint.database;
using UPrint.entity;
using UPrint.logic;
using UPrint.util;

namespace UPrint.test
{
    [TestFixture]
    class BusinessLogicTest
    {
        UPrintDataSet dataSet;
        PrinterDataAccessor printerDA;
        ModelDataAccessor modelDA;
        JobDataAccessor jobDA;
        PersonDataAccessor personDA;
        TaskDataAccessor taskDA;

        BusinessLogic logic;

        [OneTimeSetUp]
        public void Init()
        {
            DBUtil.Clean();
            printerDA = new PrinterDataAccessor();
            modelDA = new ModelDataAccessor();
            jobDA = new JobDataAccessor();
            personDA = new PersonDataAccessor();
            taskDA = new TaskDataAccessor();
            logic = new BusinessLogic();
        }
        [Test]
        public void TestGetEmptyPrinters()
        {
            read(printerDA);
            System.Data.DataRow newRow;
            newRow = dataSet.printer.NewRow();
            PrinterConverter.toDataRow(newRow, new Printer(1, "P1_e", Printer.PrinterStatus.EMPTY, true));
            dataSet.printer.Rows.Add(newRow);
            newRow = dataSet.printer.NewRow();
            PrinterConverter.toDataRow(newRow, new Printer(2, "P2_r", Printer.PrinterStatus.READY, true));
            dataSet.printer.Rows.Add(newRow);
            newRow = dataSet.printer.NewRow();
            PrinterConverter.toDataRow(newRow, new Printer(3, "P3_e", Printer.PrinterStatus.EMPTY, true));
            dataSet.printer.Rows.Add(newRow);
            write(printerDA);

            logic.init();
            System.Collections.Generic.List<Printer> list = logic.GetEmptyPrinters();
            Assert.AreEqual(2, list.Count);
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
    }
}
