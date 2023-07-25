﻿using System;
using System.Net;
using System.Threading.Tasks;
using Vonage.Common.Test.Extensions;
using Vonage.VerifyV2.VerifyCode;
using WireMock.ResponseBuilders;
using Xunit;

namespace Vonage.Test.Unit.VerifyV2.VerifyCode
{
    [Trait("Category", "E2E")]
    public class E2ETest : E2EBase
    {
        public E2ETest() : base(typeof(SerializationTest).Namespace)
        {
        }

        [Fact]
        public async Task VerifyCode()
        {
            this.Helper.Server.Given(WireMock.RequestBuilders.Request.Create()
                    .WithPath("/v2/verify/68c2b32e-55ba-4a8e-b3fa-43b3ae6cd1fb")
                    .WithHeader("Authorization", "Bearer *")
                    .WithBody(this.Serialization.GetRequestJson(nameof(SerializationTest.ShouldSerialize)))
                    .UsingPost())
                .RespondWith(Response.Create().WithStatusCode(HttpStatusCode.OK));
            var result = await this.Helper.VonageClient.VerifyV2Client.VerifyCodeAsync(VerifyCodeRequest.Build()
                .WithRequestId(Guid.Parse("68c2b32e-55ba-4a8e-b3fa-43b3ae6cd1fb"))
                .WithCode("123456789")
                .Create());
            result.Should().BeSuccess();
        }
    }
}