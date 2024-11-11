using Aria2.NET.Results;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Aria2.NET;

internal sealed class Aria2Client(HttpClient http, Aria2Settings settings) : IDisposable
{
    private readonly HttpClient _http = http;
    private readonly Aria2Settings _settings = settings;

    private bool disposed;

    #region Public Methods

    public async Task<Aria2Response> AddUriAsync(string[] links, Dictionary<string, string>? options = default, CancellationToken cancellationToken = default)
    {
        Aria2Request request = CreateRequest("aria2.addUri");
        request.Params.Add(links);

        if (options != null)
        {
            request.Params.Add(options);
        }

        return await SendAsync<Aria2GidResult>(request, cancellationToken);
    }

    public async Task<Aria2Response> ChangeGlobalOptionAsync(Dictionary<string, string> options, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.changeGlobalOption");
        request.Params.Add(options);
        return await SendAsync<string>(request, cancellationToken);
    }

    public async Task<Aria2Response> ChangeOptionAsync(string gid, Dictionary<string, string> options, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.changeOption");
        request.Params.Add(gid);
        request.Params.Add(options);
        return await SendAsync<string>(request, cancellationToken);
    }

    public async Task<Aria2Response> ChangePositionAsync(string gid, int pos, string how, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.changePosition");
        request.Params.Add(gid);
        request.Params.Add(pos);
        request.Params.Add(how);
        return await SendAsync<int>(request, cancellationToken);
    }

    public async Task<Aria2Response> ChangeUriAsync(string gid, int fileIndex, string delUris, string addUris, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.changeUrl");
        request.Params.Add(gid);
        request.Params.Add(fileIndex);
        request.Params.Add(delUris);
        request.Params.Add(addUris);
        return await SendAsync<int[]>(request, cancellationToken);
    }

    public async Task<Aria2Response> ForcePauseAsync(string gid, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.forcePause");
        request.Params.Add(gid);
        return await SendAsync<Aria2GidResult>(request, cancellationToken);
    }

    public async Task<Aria2Response> ForceRemoveAsync(string gid, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.forceRemove");
        request.Params.Add(gid);
        return await SendAsync<Aria2GidResult>(request, cancellationToken);
    }

    public async Task<Aria2Response> ForceShutdownAsync(CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.forceShutdown");
        return await SendAsync<string>(request, cancellationToken);
    }

    public async Task<Aria2Response> GetFilesAsync(string gid, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.getFiles");
        request.Params.Add(gid);
        return await SendAsync<Aria2GetFilesResult>(request, cancellationToken);
    }

    public async Task<Aria2Response> GetGlobalOptionAsync(CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.getGlobalOption");
        return await SendAsync<Dictionary<string, string>>(request, cancellationToken);
    }

    public async Task<Aria2Response> GetGlobalStatAsync(CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.getGlobalStat");
        return await SendAsync<Aria2GetGlobalStatResult>(request, cancellationToken);
    }

    public async Task<Aria2Response> GetOptionAsync(string gid, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.getOption");
        request.Params.Add(gid);
        return await SendAsync<Dictionary<string, string>>(request, cancellationToken);
    }

    public async Task<Aria2Response> GetPeersAsync(string gid, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.getPeers");
        request.Params.Add(gid);
        return await SendAsync<Aria2GetPeersResult>(request, cancellationToken);
    }

    public async Task<Aria2Response> GetServersAsync(string gid, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.getServers");
        request.Params.Add(gid);
        return await SendAsync<Aria2GetServersResult>(request, cancellationToken);
    }

    public async Task<Aria2Response> GetSessionInfoAsync(CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.getSessionInfo");
        return await SendAsync<Aria2GidResult>(request, cancellationToken);
    }

    public async Task<Aria2Response> GetUrisAsync(string gid, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.getUris");
        request.Params.Add(gid);
        return await SendAsync<Aria2GetUrisResult>(request, cancellationToken);
    }

    public async Task<Aria2Response> GetVersionAsync(CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.getVersion");
        return await SendAsync<Aria2GetVersionResult>(request, cancellationToken);
    }

    public async Task<Aria2Response> ListMethodsAsync(CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("system.listMethods");
        return await SendAsync<string[]>(request, cancellationToken);
    }

    public async Task<Aria2Response> ListNotificationsAsync(CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("system.listNotifications");
        return await SendAsync<string[]>(request, cancellationToken);
    }

    public async Task<Aria2Response> PauseAsync(string gid, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.pause");
        request.Params.Add(gid);
        return await SendAsync<Aria2GidResult>(request, cancellationToken);
    }

    public async Task<Aria2Response> PurgeDownloadResultAsync(string gid, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.purgeDownloadResult");
        request.Params.Add(gid);
        return await SendAsync<string>(request, cancellationToken);
    }

    public async Task<Aria2Response> RemoveAsync(string gid, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.remove");
        request.Params.Add(gid);
        return await SendAsync<Aria2GidResult>(request, cancellationToken);
    }

    public async Task<Aria2Response> SaveSessionAsync(CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.saveSession");
        return await SendAsync<string>(request, cancellationToken);
    }

    public async Task<Aria2Response> ShutdownAsync(CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.shutdown");
        return await SendAsync<string>(request, cancellationToken);
    }

    public async Task<Aria2Response> TellActiveAsync(string gid, string[]? keys, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.tellActive");
        request.Params.Add(gid);

        if (keys != null)
        {
            request.Params.Add(keys);
        }

        return await SendAsync<Aria2TellActiveResult>(request, cancellationToken);
    }

    public async Task<Aria2Response> TellStatusAsync(string gid, string[]? keys = default, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.tellStatus");
        request.Params.Add(gid);

        if (keys != null)
        {
            request.Params.Add(keys);
        }

        return await SendAsync<Aria2TellStatusResult>(request, cancellationToken);
    }

    public async Task<Aria2Response> TellStoppedAsync(string gid, int offset, int num, string[]? keys, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.tellStopped");
        request.Params.Add(gid);
        request.Params.Add(offset);
        request.Params.Add(num);

        if (keys != null)
        {
            request.Params.Add(keys);
        }

        return await SendAsync<Aria2TellStoppedResult>(request, cancellationToken);
    }

    public async Task<Aria2Response> TellWaitingAsync(string gid, int offset, int num, string[]? keys, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.tellWaiting");
        request.Params.Add(gid);
        request.Params.Add(offset);
        request.Params.Add(num);

        if (keys != null)
        {
            request.Params.Add(keys);
        }

        return await SendAsync<Aria2TellWaitingResult>(request, cancellationToken);
    }

    public async Task<Aria2Response> UnpauseAsync(string gid, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest("aria2.unpause");
        request.Params.Add(gid);
        return await SendAsync<Aria2GidResult>(request, cancellationToken);
    }

    #endregion Public Methods

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    private Aria2Request CreateRequest(string method)
    {
        var request = new Aria2Request { Method = method };

        if (!string.IsNullOrEmpty(_settings.Secret))
        {
            request.Params.Insert(0, $"token:{_settings.Secret}");
        }

        return request;
    }

    private void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _http.Dispose();
            }

            disposed = true;
        }
    }

    private async Task<Aria2Response> SendAsync<T>(Aria2Request request, CancellationToken cancellationToken = default)
    {
        var content = JsonSerializer.Serialize(request);

        using var response = await _http.SendAsync(new HttpRequestMessage(HttpMethod.Post, "/jsonrpc")
        {
            Content = new StringContent(content, Encoding.UTF8, "application/json")
        },
        cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<Aria2ResponseError>(cancellationToken))
                ?? throw new InvalidOperationException("Failed to deserialize response content.");
        }

        return (await response.Content.ReadFromJsonAsync<Aria2ResponseSuccess<T>>(cancellationToken))
            ?? throw new InvalidOperationException("Failed to deserialize response content.");
    }
}

internal static partial class ServiceCollectionExtensions
{
    internal static IHttpClientBuilder AddAria2Client(this IServiceCollection services, Aria2Settings? settings = null)
    {
        services.AddSingleton(settings ?? new());
        return services.AddHttpClient<Aria2Client>();
    }
}