using MySmartHomeWebApi.Data.Interfaces;
using MySmartHomeWebApi.Entities;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Json;

namespace WebApiClients.Repositories
{
    public class WebRepository<T> : IEntityRepository<T> where T : Entity, new()
    {
        private readonly HttpClient _client;

        public WebRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> Add(T item, CancellationToken Cancel = default)
        {
            var response = await _client.PostAsJsonAsync("", item, Cancel).ConfigureAwait(false);
            var result = await response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<T>(cancellationToken: Cancel)
               .ConfigureAwait(false);
            return result!;
        }

        public async Task<T?> Delete(T item, CancellationToken Cancel = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "")
            {
                Content = JsonContent.Create(item)
            };
            var response = await _client.SendAsync(request, Cancel).ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return default;
            var result = await response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<T>(cancellationToken: Cancel)
               .ConfigureAwait(false);
            return result;
        }

        public async Task<T?> DeleteById(Guid Id, CancellationToken Cancel = default)
        {
            var response = await _client.DeleteAsync($"{Id}", Cancel).ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return default;
            var result = await response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<T>(cancellationToken: Cancel)
               .ConfigureAwait(false);
            return result;
        }
        public async Task<T?> Update(T item, CancellationToken Cancel = default)
        {
            var response = await _client.PutAsJsonAsync($"{item.Id}", item, Cancel).ConfigureAwait(false);
            var result = await response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<T>(cancellationToken: Cancel)
               .ConfigureAwait(false);
            return result;
        }
        public async Task<bool> Exist(T item, CancellationToken Cancel = default)
        {
            var response = await _client.PostAsJsonAsync("exist", item, Cancel).ConfigureAwait(false);
            return response.StatusCode != HttpStatusCode.NotFound && response.IsSuccessStatusCode;
        }

        public async Task<bool> ExistId(Guid Id, CancellationToken Cancel = default)
        {
            var response = await _client.GetAsync($"exist/id/{Id}", Cancel).ConfigureAwait(false);
            return response.StatusCode != HttpStatusCode.NotFound && response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken Cancel = default)
        {
            //_client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers
            //    .AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJleHAiOjE2NjY4NzkzNjgsImlzcyI6Ik15U21hcnRIb21lIiwiYXVkIjoiTXlBdXRoQ2xpZW50In0.ibZO-brImzSzbaz4j3P4nEPyCnMa92K-g2YZuqKY2dE");
            return await _client.GetFromJsonAsync<IEnumerable<T>>("", Cancel).ConfigureAwait(false) ?? Enumerable.Empty<T>();
        }

        public async Task<T?> GetById(Guid Id, CancellationToken Cancel = default)
        {
            return await _client.GetFromJsonAsync<T>($"{Id}", Cancel).ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetByName(string name, params Expression<Func<T, object>>[]? includeProperties)
        {
            var response = await _client.PostAsJsonAsync($"filter/name", name).ConfigureAwait(false);
            var result = await response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<IEnumerable<T>>()
               .ConfigureAwait(false);
            return result ?? Enumerable.Empty<T>();
        }
    }
}
