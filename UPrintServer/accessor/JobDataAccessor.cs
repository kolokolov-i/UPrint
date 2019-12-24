using System;
using UPrint.database;
using Npgsql;
using UPrint;
using UPrint.accessor;

namespace UPrint.accessor
{
    public class JobDataAccessor : IDataAccessor
    {
        private static String selection = "SELECT * FROM job";
        private static String insertion = "INSERT INTO job (id, name, date_add, description, person, model) VALUES (@id, @name, @date_add, @description, @person, @model)";
        private static String updation = "UPDATE job SET name = @name, date_add = @date_add, description = @description, person = @person, model = @model WHERE id = @id";
        private static String deletion = "DELETE FROM job WHERE id = @id";

        NpgsqlDataAdapter adapter;

        //private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void Read(AbstractConnection connection, AbstractTransaction transaction, UPrintDataSet dataSet)
        {
            adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand(selection, connection.GetConnection(), transaction.GetTransaction());
            adapter.Fill(dataSet, "job");
        }

        public void Update(AbstractConnection connection, AbstractTransaction transaction, UPrintDataSet dataSet)
        {
            adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand(selection, connection.GetConnection(), transaction.GetTransaction());
            adapter.Fill(dataSet, "job");
            adapter.InsertCommand = new NpgsqlCommand(insertion, connection.GetConnection(), transaction.GetTransaction());
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "id", ParameterName = "@id" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "name", ParameterName = "@name" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "date_add", ParameterName = "@date_add" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "description", ParameterName = "@description" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "person", ParameterName = "@person" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "model", ParameterName = "@model" });
            adapter.UpdateCommand = new NpgsqlCommand(updation, connection.GetConnection(), transaction.GetTransaction());
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "id", ParameterName = "@id" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "name", ParameterName = "@name" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "date_add", ParameterName = "@date_add" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "description", ParameterName = "@description" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "person", ParameterName = "@person" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "model", ParameterName = "@model" });
            adapter.DeleteCommand = new NpgsqlCommand(deletion, connection.GetConnection(), transaction.GetTransaction());
            adapter.DeleteCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "id", ParameterName = "@id" });
            NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(adapter);
            adapter.Update(dataSet, "job");

        }
    }
}
