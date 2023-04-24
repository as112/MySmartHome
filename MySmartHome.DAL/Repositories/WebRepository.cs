using MySmartHome.DAL.Entities;
using MySmartHome.DAL.Repositories.Interfaces;
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

        public void SetDefaultRequestHeaders(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
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
            var response = await _client.PutAsJsonAsync("", item, Cancel).ConfigureAwait(false);
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
            try
            {
                return await _client.GetFromJsonAsync<IEnumerable<T>>("", Cancel).ConfigureAwait(false) ?? Enumerable.Empty<T>();
            }
            catch (Exception ex) 
            {
                return Enumerable.Empty<T>();
            }
            
        }

        public async Task<T?> GetById(Guid Id, CancellationToken Cancel = default)
        {
            try
            {
                return await _client.GetFromJsonAsync<T>($"{Id}", Cancel).ConfigureAwait(false);
            }
            catch(Exception ex)
            {
                return null;
            }
            
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

        public Task<IEnumerable<T>> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[]? includeProperties)
        {
            throw new NotImplementedException();
        }
    }
}
