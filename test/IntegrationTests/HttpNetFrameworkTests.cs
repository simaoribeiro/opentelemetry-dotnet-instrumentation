// <copyright file="HttpNetFrameworkTests.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

#if NETFRAMEWORK
using IntegrationTests.Helpers;
using Xunit.Abstractions;

namespace IntegrationTests;

public class HttpNetFrameworkTests : TestHelper
{
    public HttpNetFrameworkTests(ITestOutputHelper output)
        : base("Http.NetFramework", output)
    {
    }

    [Fact]
    [Trait("Category", "EndToEnd")]
    public void SubmitTraces()
    {
        using var collector = new MockSpansCollector(Output);
        SetExporter(collector);

        collector.Expect("OpenTelemetry.Instrumentation.Http.HttpWebRequest");

        RunTestApplication();

        collector.AssertExpectations();
    }
}
#endif
