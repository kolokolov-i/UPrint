using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UPrint.accessor;
using UPrint.converter;
using UPrint.database;
using UPrint.entity;

namespace UPrint.logic
{
    public class BusinessLogic
    {
        public UPrintDataSet dataSet;
        PrinterDataAccessor printerDA;
        ModelDataAccessor modelDA;
        JobDataAccessor jobDA;
        PersonDataAccessor personDA;
        TaskDataAccessor taskDA;

        public void init()
        {
            printerDA = new PrinterDataAccessor();
            modelDA = new ModelDataAccessor();
            jobDA = new JobDataAccessor();
            personDA = new PersonDataAccessor();
            taskDA = new TaskDataAccessor();
        }

        public List<Printer> GetEmptyPrinters()
        {
            read(printerDA);
            return dataSet.printer.AsEnumerable()
                .Select(t => new Printer(
                    t.Field<short>(0), t.Field<string>(1), t.Field<string>(2), t.Field<bool>(3)))
                .Where(t => t.Status.Equals(Printer.PrinterStatus.EMPTY)).ToList();
        }

        public List<Model> GetModelByName(string term)
        {
            read(modelDA);
            return dataSet.model.AsEnumerable()
                .Select(t => new Model(t.Field<int>(0), t.Field<string>(1), t.Field<string>(2)))
                .Where(t => t.Name.ToLower().StartsWith(term.ToLower())).ToList();
        }

        public List<Task> GetTaskForJob(Job job)
        {
            return null;
        }

        public void readAllJob()
        {

        }

        private void read(IDataAccessor da)
        {
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
        }
    }
}
