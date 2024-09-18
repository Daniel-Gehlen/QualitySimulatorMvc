using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace QualitySimulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private static readonly string FilePath = "data.json";
        private static Data _data = LoadData();

        [HttpGet("components")]
        public ActionResult<IEnumerable<string>> GetComponents()
        {
            return Ok(_data.ElectronicComponents);
        }

        [HttpPost("components")]
        public ActionResult AddComponent([FromBody] string component)
        {
            if (!string.IsNullOrEmpty(component))
            {
                _data.ElectronicComponents.Add(component);
                SaveData();
                return Ok($"Component '{component}' added successfully.");
            }
            return BadRequest("Invalid component.");
        }

        [HttpDelete("components/{component}")]
        public ActionResult RemoveComponent(string component)
        {
            if (_data.ElectronicComponents.Remove(component))
            {
                _data.ComponentQuality.Remove(component);
                SaveData();
                return Ok($"Component '{component}' removed successfully.");
            }
            return NotFound("Component not found.");
        }

        [HttpGet("standards")]
        public ActionResult<IEnumerable<string>> GetStandards()
        {
            return Ok(_data.QualityStandards);
        }

        [HttpPost("standards")]
        public ActionResult AddStandard([FromBody] string standard)
        {
            if (!string.IsNullOrEmpty(standard))
            {
                _data.QualityStandards.Add(standard);
                SaveData();
                return Ok($"Quality standard '{standard}' added successfully.");
            }
            return BadRequest("Invalid quality standard.");
        }

        [HttpDelete("standards/{standard}")]
        public ActionResult RemoveStandard(string standard)
        {
            if (_data.QualityStandards.Remove(standard))
            {
                SaveData();
                return Ok($"Quality standard '{standard}' removed successfully.");
            }
            return NotFound("Quality standard not found.");
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
