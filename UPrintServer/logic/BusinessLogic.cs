using System;
using System.Collections.Generic;
using System.Data;
using UPrint.accessor;
using UPrint.converter;
using UPrint.entity;

namespace UPrint.logic
{
    class BusinessLogic
    {
        UPrintDataSet dataSet;
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

        public Job CreateJob(Person person, string modelName)
        {
            //readModel();
            Model model = new Model(0, modelName, "model/" + modelName);
            DataRow newRowModel = dataSet.model.NewRow();
            ModelConverter.toDataRow(newRowModel, model);
            dataSet.model.Rows.Add(newRowModel);
            //writeModel();
            DataRow dataRow = dataSet.model.Select("name = " + modelName)[0];
            //dataRow["Id"];
            readJob();
            DataRow newRowJob = dataSet.job.NewRow();
            Job newJob = new Job(0, "Print" + modelName, DateTime.Now, "", person.Id, 0);
            JobConverter.toDataRow(newRowJob, newJob);
            dataSet.job.Rows.Add(newRowJob);
            writeJob();
            readJob();
            return null;
        }

        public Task LaunchJob(Person person, Printer printer)
        {
            return null;
        }

        public List<Printer> GetEmptyPrinters()
        {
            return null;
        }

        public List<Task> GetWorkingTasks()
        {
            return null;
        }

        public List<Task> GetTaskForJob(Job job)
        {
            return null;
        }

        private void readJob()
        {

        }

        private void writeJob()
        {

        }
    }
}
