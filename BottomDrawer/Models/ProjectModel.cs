using Newtonsoft.Json;

namespace BottomDrawer.Models
{
    public class ProjectModel
    {
        public string ShortDesc { get; set; }
        public string Desc { get; set; }
        public string Category { get; set; }
        public int Difficulty { get; set; }

        public ProjectModel(string _shortDesc, string _Desc, string _Category, int _difficulty)
        {
            ShortDesc = _shortDesc;
            Desc = _Desc;
            Category = _Category;
            Difficulty = _difficulty;
        }

        public void Save()
        {
            using StreamReader reader = new("ProductModels.json");
            string json = reader.ReadToEnd();

            List<ProjectModel> projects = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projects.Add(this);

            using StreamWriter writer = new("ProductModels.json");
            writer.Write(JsonConvert.SerializeObject(projects));
        }

        public static List<ProjectModel> GetAll()
        {
            using StreamReader reader = new("ProductModels.json");

            string json = reader.ReadToEnd();

            return JsonConvert.DeserializeObject<List<ProjectModel>>(json);
        }

        public static ProjectModel GetByShortDesc(string _shortDisc)
        {
            using StreamReader reader = new("ProductModels.json");
            string json = reader.ReadToEnd();

            return JsonConvert.DeserializeObject<List<ProjectModel>>(json).Find(x => x.ShortDesc == _shortDisc);
        }

        public static void Delete(string _shortDisc)
        {
            using StreamReader reader = new("ProductModels.json");
            string json = reader.ReadToEnd();

            List<ProjectModel> projects = JsonConvert.DeserializeObject<List<ProjectModel>>(json);

            ProjectModel project = projects.Find(x => x.ShortDesc == _shortDisc);
            projects.Remove(project);

            using StreamWriter writer = new("ProductModels.json");
            writer.Write(JsonConvert.SerializeObject(projects));

        }
    }
}
