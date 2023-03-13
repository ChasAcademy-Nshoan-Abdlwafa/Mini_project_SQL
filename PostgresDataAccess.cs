using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using Dapper;
using Microsoft.VisualBasic;
using Npgsql;
using NpgsqlTypes;

namespace Mini_project_SQL
{
    public class PostgresDataAccess
    {
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        internal static List<PersonModel> LoadPerson() //Retrieves data regarding persons
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                try
                {
                    var output = cnn.Query<PersonModel>("SElECT * FROM nab_person", new DynamicParameters());
                    return output.ToList();
                }
                catch (PostgresException e)
                {
                    throw new InvalidOperationException(e.Message);
                }
            }
        }

        internal static List<ProjectModel> LoadProject() //Retrieves data regarding projects
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                try
                {
                    var output = cnn.Query<ProjectModel>("SElECT * FROM nab_project", new DynamicParameters());
                    return output.ToList();
                }
                catch (PostgresException e)
                {
                    throw new InvalidOperationException(e.Message);
                }
            }
        }
    }
}