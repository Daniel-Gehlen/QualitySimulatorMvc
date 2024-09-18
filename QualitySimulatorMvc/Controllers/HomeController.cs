using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebFrontend.Controllers
{
    public class HomeController : Controller
    {
        private static readonly string FilePath = "data.json";
        private static Data _data = LoadData();

        public IActionResult Index()
        {
            return View(_data);
        }

        [HttpPost]
        public IActionResult AddComponent(string componentName)
        {
            if (!string.IsNullOrEmpty(componentName))
            {
                _data.ElectronicComponents.Add(componentName);
                SaveData();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveComponent(string componentName)
        {
            if (_data.ElectronicComponents.Remove(componentName))
            {
                _data.ComponentQuality.Remove(componentName);
                SaveData();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddQualityStandard(string qualityStandard)
        {
            if (!string.IsNullOrEmpty(qualityStandard))
            {
                _data.QualityStandards.Add(qualityStandard);
                SaveData();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveQualityStandard(string qualityStandard)
        {
            if (_data.QualityStandards.Remove(qualityStandard))
            {
                SaveData();
            }
            return RedirectToAction("Index");
        }

        private static Data LoadData()
        {
            if (System.IO.File.Exists(FilePath))
            {
                string json = System.IO.File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<Data>(json) ?? new Data();
            }
            return new Data();
        }

        private static void SaveData()
        {
            string jsonData = JsonSerializer.Serialize(_data);
            System.IO.File.WriteAllText(FilePath, jsonData);
        }
    }

    public class Data
    {
        public List<string> QualityStandards { get; set; } = new List<string>();
        public List<string> ElectronicComponents { get; set; } = new List<string>();
        public Dictionary<string, string> ComponentQuality { get; set; } = new Dictionary<string, string>();
    }
}
