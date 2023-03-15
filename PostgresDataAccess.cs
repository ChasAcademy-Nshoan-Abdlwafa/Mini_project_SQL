using Dapper;
using Npgsql;
using System.Configuration;
using System.Data;

namespace Mini_project_SQL;

public class PostgresDataAccess //Connections are made to the database through the methods shown below
{
    private static string LoadConnectionString(string id = "Default")
    {
        return ConfigurationManager.ConnectionStrings[id].ConnectionString;
    }

    internal static List<ProjectModel> LoadProject() //Fetches data regarding projects
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

    internal static List<PersonModel> LoadPerson() //Fetches data regarding persons
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

    internal static List<ProjectPersonModel> LoadProjectPerson() //Fetches data regarding inner joins
    {
        using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
        {
            try
            {
                var output = cnn.Query<ProjectPersonModel>("SELECT nab_project_person.*, nab_project.project_name FROM nab_project_person INNER JOIN nab_project ON nab_project_person.project_id = nab_project.id", new DynamicParameters());
                return output.ToList();
            }
            catch (PostgresException e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }

    internal static void AddProject(string project_name) //Inserts a project into the table
    {
        using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
        {
            try
            {
                cnn.Query<ProjectModel>($"INSERT INTO nab_project (project_name) VALUES ('{project_name}')", new DynamicParameters());
            }
            catch (PostgresException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    internal static void AddPerson(string person_name) //Inserts a person into the table
    {
        using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
        {
            try
            {
                cnn.Query<PersonModel>($"INSERT INTO nab_person (person_name) VALUES ('{person_name}')", new DynamicParameters());
            }
            catch (PostgresException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    internal static void AddHours(ProjectPersonModel ProjectPerson) //Inserts hours worked into the table
    {
        using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
        {
            try
            {
                cnn.Query<PersonModel>("INSERT INTO nab_project_person (project_id, person_id, hours) VALUES (@project_id, @person_id, @hours)", ProjectPerson);
            }
            catch (PostgresException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
