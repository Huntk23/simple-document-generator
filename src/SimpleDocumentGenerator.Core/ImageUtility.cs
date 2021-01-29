using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleDocumentGenerator.Core
{
    public class ImageUtility
    {
        private readonly GoogleSettings _googleSettings;

        private readonly HttpClient _client;

        /// <summary>
        /// </summary>
        /// <param name="googleSettings"></param>
        public ImageUtility(GoogleSettings googleSettings)
        {
            _googleSettings = googleSettings;

            _client = new HttpClient();
        }

        /// <summary>
        /// </summary>
        /// <param name="searchWords"></param>
        /// <returns></returns>
        public async Task<List<string>> SearchForImages(List<string> searchWords)
        {
            GoogleResponse googleResponse;
            var startIndex = 1;
            var listOfImageLinks = new List<string>();

            do
            {
                var url = string.Format(_googleSettings.UrlFormat, _googleSettings.ApiKey, _googleSettings.SearchEngineId, startIndex,
                    string.Join("+", searchWords));

                var response = await _client.GetStringAsync(url);

                googleResponse = JsonConvert.DeserializeObject<GoogleResponse>(response);

                listOfImageLinks.AddRange(googleResponse.Items.Select(x => x.Link));

                var nextPage = googleResponse.Queries.NextPage?.FirstOrDefault();

                startIndex = nextPage?.StartIndex ?? -1;

                if (startIndex >= 51) break; // Stop getting image links to not overflow memory or slow loading - TODO make this a setting and can be way more advanced

            } while (googleResponse.Queries.NextPage != null && startIndex != -1);

            return listOfImageLinks;
        }
    }
}
