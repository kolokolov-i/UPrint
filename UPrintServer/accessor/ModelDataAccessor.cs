using System;
using UPrint.database;
using Npgsql;

namespace UPrint.accessor
{
    public class ModelDataAccessor : IDataAccessor
    {

        private static String selection = "SELECT * FROM model";
        private static String insertion = "INSERT INTO model (id, name, path) VALUES (@id, @name, @path)";
        private static String updation = "UPDATE model SET name = @name, path = @path WHERE id = @id";
        private static String deletion = "DELETE FROM model WHERE id = @id";

        NpgsqlDataAdapter adapter;

        //private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void Read(AbstractConnection connection, AbstractTransaction transaction, UPrintDataSet dataSet)
        {
            adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand(selection, connection.GetConnection(), transaction.GetTransaction());
            adapter.Fill(dataSet, "model");
        }

        public void Update(AbstractConnection connection, AbstractTransaction transaction, UPrintDataSet dataSet)
        {
            adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand(selection, connection.GetConnection(), transaction.GetTransaction());
            adapter.Fill(dataSet, "model");
            adapter.InsertCommand = new NpgsqlCommand(insertion, connection.GetConnection(), transaction.GetTransaction());
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "id", ParameterName = "@id" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "name", ParameterName = "@name" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "path", ParameterName = "@path" });
            adapter.UpdateCommand = new NpgsqlCommand(updation, connection.GetConnection(), transaction.GetTransaction());
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "id", ParameterName = "@id" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "name", ParameterName = "@name" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "path", ParameterName = "@path" });
            adapter.DeleteCommand = new NpgsqlCommand(deletion, connection.GetConnection(), transaction.GetTransaction());
            adapter.DeleteCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "id", ParameterName = "@id" });
            NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(adapter);
            adapter.Update(dataSet, "model");
        }
    }
}
