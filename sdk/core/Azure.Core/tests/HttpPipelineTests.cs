﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpPipelineTests
    {
        [Test]
        public async Task DoesntDisposeRequestInSendRequestAsync()
        {
            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(new TestOptions()
            {
                Transport = new MockTransport(new MockResponse(200))
            });

            using MockRequest request = (MockRequest)httpPipeline.CreateRequest();

            MockResponse response = (MockResponse)await httpPipeline.SendRequestAsync(request, default);

            Assert.False(request.IsDisposed);
            Assert.False(response.IsDisposed);
        }

        private class TestOptions : ClientOptions
        {
        }

        [Test]
        public async Task CanAddPolicy_PerCall()
        {
            var mockTransport = new MockTransport(new MockResponse(200));
            var options = new TestOptions()
            {
                Transport = mockTransport,
            };
            var pipeline = HttpPipelineBuilder.Build(options);

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerCallHeader", "Value"), HttpPipelinePosition.PerCall);

            var message = pipeline.CreateMessage(context);
            await pipeline.SendAsync(message, message.CancellationToken);

            Request request = mockTransport.Requests[0];
            Assert.IsTrue(request.Headers.TryGetValues("PerCallHeader", out var values));
            Assert.AreEqual(1, values.Count());
            Assert.AreEqual("Value", values.ElementAt(0));
        }

        [Test]
        public async Task CanAddPolicy_PerRetry()
        {
            var retryResponse = new MockResponse(408); // Request Timeout
            var mockTransport = new MockTransport(retryResponse, retryResponse, new MockResponse(200));
            var options = new TestOptions()
            {
                Transport = mockTransport,
            };

            var pipeline = HttpPipelineBuilder.Build(options);

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerRetryHeader", "Value"), HttpPipelinePosition.PerRetry);

            var message = pipeline.CreateMessage(context);
            await pipeline.SendAsync(message, message.CancellationToken);

            Request request = mockTransport.Requests[0];
            Assert.IsTrue(request.Headers.TryGetValues("PerRetryHeader", out var values));
            Assert.AreEqual(3, values.Count());
            Assert.AreEqual("Value", values.ElementAt(0));
            Assert.AreEqual("Value", values.ElementAt(1));
            Assert.AreEqual("Value", values.ElementAt(2));
        }

        [Test]
        public async Task CanAddPolicy_BeforeTransport()
        {
            var retryResponse = new MockResponse(408); // Request Timeout

            // retry twice
            var mockTransport = new MockTransport(retryResponse, retryResponse, new MockResponse(200));
            var options = new TestOptions()
            {
                Transport = mockTransport,
            };

            var pipeline = HttpPipelineBuilder.Build(options);

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("BeforeTransportHeader", "Value"), HttpPipelinePosition.BeforeTransport);

            var message = pipeline.CreateMessage(context);
            await pipeline.SendAsync(message, message.CancellationToken);

            Request request = mockTransport.Requests[0];

            Assert.IsTrue(request.Headers.TryGetValues("BeforeTransportHeader", out var values));
            Assert.AreEqual(3, values.Count());
            Assert.AreEqual("Value", values.ElementAt(0));
            Assert.AreEqual("Value", values.ElementAt(1));
            Assert.AreEqual("Value", values.ElementAt(2));
        }

        [Test]
        public async Task CanAddRequestPolicies_AllPositions()
        {
            var retryResponse = new MockResponse(408); // Request Timeout

            // retry twice -- this will add the header three times.
            var mockTransport = new MockTransport(retryResponse, retryResponse, new MockResponse(200));
            var options = new TestOptions()
            {
                Transport = mockTransport,
            };

            var pipeline = HttpPipelineBuilder.Build(options);

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerCallHeader1", "PerCall1"), HttpPipelinePosition.PerCall);
            context.AddPolicy(new AddHeaderPolicy("PerCallHeader2", "PerCall2"), HttpPipelinePosition.PerCall);
            context.AddPolicy(new AddHeaderPolicy("PerRetryHeader", "PerRetry"), HttpPipelinePosition.PerRetry);
            context.AddPolicy(new AddHeaderPolicy("BeforeTransportHeader", "BeforeTransport"), HttpPipelinePosition.BeforeTransport);

            var message = pipeline.CreateMessage(context);
            await pipeline.SendAsync(message, message.CancellationToken);

            Request request = mockTransport.Requests[0];

            Assert.IsTrue(request.Headers.TryGetValues("PerCallHeader1", out var perCall1Values));
            Assert.AreEqual(1, perCall1Values.Count());
            Assert.AreEqual("PerCall1", perCall1Values.ElementAt(0));

            Assert.IsTrue(request.Headers.TryGetValues("PerCallHeader2", out var perCall2Values));
            Assert.AreEqual(1, perCall2Values.Count());
            Assert.AreEqual("PerCall2", perCall2Values.ElementAt(0));

            Assert.IsTrue(request.Headers.TryGetValues("PerRetryHeader", out var perRetryValues));
            Assert.AreEqual("PerRetry", perRetryValues.ElementAt(0));
            Assert.AreEqual("PerRetry", perRetryValues.ElementAt(1));
            Assert.AreEqual("PerRetry", perRetryValues.ElementAt(2));

            Assert.IsTrue(request.Headers.TryGetValues("BeforeTransportHeader", out var beforeTransportValues));
            Assert.AreEqual("BeforeTransport", beforeTransportValues.ElementAt(0));
            Assert.AreEqual("BeforeTransport", beforeTransportValues.ElementAt(1));
            Assert.AreEqual("BeforeTransport", beforeTransportValues.ElementAt(2));
        }

        [Test]
        public async Task CanAddPolicies_ThreeWays()
        {
            var mockTransport = new MockTransport(new MockResponse(200));
            var options = new TestOptions()
            {
                Transport = mockTransport,
            };

            var perCallPolicies = new HttpPipelinePolicy[] { new AddHeaderPolicy("PerCall", "Builder") };
            var perRetryPolicies = new HttpPipelinePolicy[] { new AddHeaderPolicy("PerRetry", "Builder") };

            options.AddPolicy(new AddHeaderPolicy("BeforeTransport", "ClientOptions"), HttpPipelinePosition.BeforeTransport);
            options.AddPolicy(new AddHeaderPolicy("PerRetry", "ClientOptions"), HttpPipelinePosition.PerRetry);
            options.AddPolicy(new AddHeaderPolicy("PerCall", "ClientOptions"), HttpPipelinePosition.PerCall);

            var pipeline = HttpPipelineBuilder.Build(options, perCallPolicies, perRetryPolicies, null);

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerRetry", "RequestContext"), HttpPipelinePosition.PerRetry);
            context.AddPolicy(new AddHeaderPolicy("PerCall", "RequestContext"), HttpPipelinePosition.PerCall);
            context.AddPolicy(new AddHeaderPolicy("BeforeTransport", "RequestContext"), HttpPipelinePosition.BeforeTransport);

            var message = pipeline.CreateMessage(context);
            await pipeline.SendAsync(message, message.CancellationToken);

            Request request = mockTransport.Requests[0];

            Assert.IsTrue(request.Headers.TryGetValues("PerCall", out var perCallValues));
            Assert.AreEqual(3, perCallValues.Count());
            Assert.AreEqual("Builder", perCallValues.ElementAt(0));
            Assert.AreEqual("ClientOptions", perCallValues.ElementAt(1));
            Assert.AreEqual("RequestContext", perCallValues.ElementAt(2));

            Assert.IsTrue(request.Headers.TryGetValues("PerRetry", out var perRetryValues));
            Assert.AreEqual(3, perRetryValues.Count());
            Assert.AreEqual("Builder", perRetryValues.ElementAt(0));
            Assert.AreEqual("ClientOptions", perRetryValues.ElementAt(1));
            Assert.AreEqual("RequestContext", perRetryValues.ElementAt(2));

            Assert.IsTrue(request.Headers.TryGetValues("BeforeTransport", out var beforeTransportValues));
            Assert.AreEqual(2, beforeTransportValues.Count());
            Assert.AreEqual("ClientOptions", beforeTransportValues.ElementAt(0));
            Assert.AreEqual("RequestContext", beforeTransportValues.ElementAt(1));
        }

        [Test]
        public async Task ThrowsIfUsePipelineConstructor()
        {
            HttpPipeline pipeline = new HttpPipeline(new MockTransport());

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerCallHeader", "Value"), HttpPipelinePosition.PerCall);

            var message = pipeline.CreateMessage(context);

            bool throws = false;
            try
            {
                await pipeline.SendAsync(message, context.CancellationToken);
            }
            catch (InvalidOperationException)
            {
                throws = true;
            }

            Assert.IsTrue(throws);
        }

        #region Helpers
        public class AddHeaderPolicy : HttpPipelineSynchronousPolicy
        {
            private string _headerName;
            private string _headerVaue;

            public AddHeaderPolicy(string headerName, string headerValue) : base()
            {
                _headerName = headerName;
                _headerVaue = headerValue;
            }

            public override void OnSendingRequest(HttpMessage message)
            {
                message.Request.Headers.Add(_headerName, _headerVaue);
            }
        }
        #endregion

    }
}
