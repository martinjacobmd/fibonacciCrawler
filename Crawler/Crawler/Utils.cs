using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    static class Utils
    {
        /// <summary>
        /// Method that triggers a GET call to the desired website and loads the content
        /// </summary>
        /// <param name="url">the url of the website</param>
        /// <returns></returns>
        public static async Task<string> GetWebsite(string url)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Method to extract the phone number from the content; trims out unnecessary chars
        /// </summary>
        /// <param name="content">The content</param>
        /// <returns>A string only containing the 4 digits from the number</returns>
        public static string ExtractPhoneNumber(string content)
        {
            string regEx = @"(?:\bTelefon\b)+([0-9\s:]+)";
            Regex r = new Regex(regEx, RegexOptions.IgnoreCase);
            Match m = r.Match(content);

            return m.Groups[1].Value.Replace(":", "").Replace(" ", "");
        }

        /// <summary>
        /// Method calculated the x-th fibonacci number
        /// </summary>
        /// <param name="number">The x-th number</param>
        /// <returns>The fibonacci number</returns>
        public static int CalculateFibonacci(int number)
        {
            int a = 0, b = 1, temp;

            for (int i = 0; i < number; i++)
            {
                temp = a;
                a = b;
                b = temp + b;
            }

            return a;
        }
    }
}
