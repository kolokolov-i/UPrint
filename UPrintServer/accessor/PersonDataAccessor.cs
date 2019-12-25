using System;
using UPrint.database;
using Npgsql;

namespace UPrint.accessor
{
    public class PersonDataAccessor : IDataAccessor
    {

        private static String selection = "SELECT * FROM person";
        private static String insertion = "INSERT INTO person (id, login, password, name, type, active) VALUES (@id, @login, @password, @name, @type, @active)";
        private static String updation = "UPDATE person SET login = @login, password = @password, name = @name, type = @type, active = @active WHERE id = @id";
        private static String deletion = "DELETE FROM person WHERE id = @id";

        NpgsqlDataAdapter adapter;

        //private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void Read(AbstractConnection connection, AbstractTransaction transaction, UPrintDataSet dataSet)
        {
            adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand(selection, connection.GetConnection(), transaction.GetTransaction());
            adapter.Fill(dataSet, "person");
        }

        public void Update(AbstractConnection connection, AbstractTransaction transaction, UPrintDataSet dataSet)
        {
            adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand(selection, connection.GetConnection(), transaction.GetTransaction());
            adapter.Fill(dataSet, "person");
            adapter.InsertCommand = new NpgsqlCommand(insertion, connection.GetConnection(), transaction.GetTransaction());
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "id", ParameterName = "@id" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "login", ParameterName = "@login" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "password", ParameterName = "@password" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "name", ParameterName = "@name" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "type", ParameterName = "@type" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "active", ParameterName = "@active" });
            adapter.UpdateCommand = new NpgsqlCommand(updation, connection.GetConnection(), transaction.GetTransaction());
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "id", ParameterName = "@id" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "login", ParameterName = "@login" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "password", ParameterName = "@password" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "name", ParameterName = "@name" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "type", ParameterName = "@type" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "active", ParameterName = "@active" });
            adapter.DeleteCommand = new NpgsqlCommand(deletion, connection.GetConnection(), transaction.GetTransaction());
            adapter.DeleteCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "id", ParameterName = "@id" });
            NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(adapter);
            adapter.Update(dataSet, "person");
        }
    }
}
