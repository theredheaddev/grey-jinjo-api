using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Banjo_kazooie_api.Helpers
{
    public static class RepositoryParser
    {
        public static async Task<T> ParseRepository<T>(string name)
        {
            var contentsArray = await File.ReadAllLinesAsync(name);

            var stringContent = string.Join("", contentsArray);

            return JsonConvert.DeserializeObject<T>(stringContent);
        }
    }
}