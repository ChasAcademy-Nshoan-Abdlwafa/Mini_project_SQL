namespace Mini_project_SQL;

internal class ProjectPersonModel
{
    public int id { get; set; }
    public int project_id { get; set; }
    public int person_id { get; set; }
    public string? project_name { get; set; }
    public int hours { get; set; }
}
