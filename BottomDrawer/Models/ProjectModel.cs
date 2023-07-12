using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace BottomDrawer.Models
{
    public class ProjectModel
    {
        public string ShortDesc { get; set; }
        public string Desc { get; set; }
        public string Category { get; set; }

        public ProjectModel(string _shortDesc, string _Desc, string _Category)
        {
            ShortDesc = _shortDesc;
            Desc = _Desc;
            Category = _Category;
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
    }
}
