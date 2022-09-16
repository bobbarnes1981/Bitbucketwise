using Bitbucketwise.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Bitbucketwise
{
    public class BitbucketClient
    {
        private string _protocol;
        private string _host;
        private int _port;

        private string _username;
        private string _password;

        private string _apiName = "api";
        private string _apiVersion = "latest";

        public BitbucketClient(string protocol, string host, int port, string username, string password)
        {
            _protocol = protocol;
            _host = host;
            _port = port;

            _username = username;
            _password = password;
        }

        public async Task<Page<Project>> GetProjectsAsync(string name, string permission, int start, int limit = 25)
        {
            var query = string.Empty;
            query += getQueryArg(nameof(name), name);
            query += getQueryArg(nameof(permission), permission);
            query += getQueryArg(nameof(start), start);
            query += getQueryArg(nameof(limit), limit);

            var url = $"{_protocol}://{_host}:{_port}/rest/{_apiName}/{_apiVersion}/projects?{query}";

            return await getObjectAsync<Page<Project>>(url);
        }

        public async Task<Page<Repository>> GetRepositoriesAsync(string projectKey, int start, int limit = 25)
        {
            if (projectKey == null)
            {
                throw new NullReferenceException(nameof(projectKey));
            }

            var query = string.Empty;
            query += getQueryArg(nameof(start), start);
            query += getQueryArg(nameof(limit), limit);

            var url = $"http://{_host}:{_port}/rest/{_apiName}/{_apiVersion}/projects/{projectKey}/repos?{query}";

            return await getObjectAsync<Page<Repository>>(url);
        }

        private async Task<T> getObjectAsync<T>(string url)
        {
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_username}:{_password}")));
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return await http.GetFromJsonAsync<T>(url);
            }
        }

        private string getQueryArg<T>(string name, T value)
        {
            if (name == null)
            {
                throw new NullReferenceException(nameof(name));
            }

            return value == null ? "" : $"{name}={value}&";
        }
    }
}