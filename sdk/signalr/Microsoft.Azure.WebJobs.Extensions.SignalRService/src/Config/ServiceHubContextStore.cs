// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class ServiceHubContextStore : IInternalServiceHubContextStore
    {
        private readonly ConcurrentDictionary<string, (Lazy<Task<IServiceHubContext>> Lazy, IServiceHubContext Value)> _store = new(StringComparer.OrdinalIgnoreCase);
        private readonly ConcurrentDictionary<string, Lazy<Task<object>>> _stronglyTypedStore = new(StringComparer.OrdinalIgnoreCase);
        private readonly IServiceEndpointManager _endpointManager;
        private readonly ServiceManager _serviceManager;

        public AccessKey[] AccessKeys => _endpointManager.Endpoints.Keys.Select(endpoint => endpoint.AccessKey).ToArray();

        public IServiceManager ServiceManager => _serviceManager as IServiceManager;

        public ServiceHubContextStore(IServiceEndpointManager endpointManager, ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            _endpointManager = endpointManager;
        }

        public async ValueTask<ServiceHubContext<T>> GetAsync<T>(string hubName) where T : class
        {
            // The GetAsync for strongly typed hub is more simple than that for weak typed hub, as it removes codes to handle transient errors. The creation of service hub context should not contain transient errors.
            var lazy = _stronglyTypedStore.GetOrAdd(hubName, new Lazy<Task<object>>(async () => await _serviceManager.CreateHubContextAsync<T>(hubName, default).ConfigureAwait(false)));
            var hubContext = await lazy.Value.ConfigureAwait(false);
            return (ServiceHubContext<T>)hubContext;
        }

        public ValueTask<IServiceHubContext> GetAsync(string hubName)
        {
            var pair = _store.GetOrAdd(hubName,
                (new Lazy<Task<IServiceHubContext>>(
                    () => ServiceManager.CreateHubContextAsync(hubName)), default));
            return GetAsyncCore(hubName, pair);
        }

        private ValueTask<IServiceHubContext> GetAsyncCore(string hubName, (Lazy<Task<IServiceHubContext>> Lazy, IServiceHubContext Value) pair)
        {
            if (pair.Lazy == null)
            {
                return new ValueTask<IServiceHubContext>(pair.Value);
            }
            else
            {
                return new ValueTask<IServiceHubContext>(GetFromLazyAsync(hubName, pair));
            }
        }

        private async Task<IServiceHubContext> GetFromLazyAsync(string hubName, (Lazy<Task<IServiceHubContext>> Lazy, IServiceHubContext Value) pair)
        {
            try
            {
                var value = await pair.Lazy.Value.ConfigureAwait(false);
                _store.TryUpdate(hubName, (null, value), pair);
                return value;
            }
            catch (Exception)
            {
                // Allow to retry for transient errors.
                _store.TryRemove(hubName, out _);
                throw;
            }
        }
    }
}