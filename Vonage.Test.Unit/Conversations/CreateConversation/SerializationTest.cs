﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using Vonage.Common;
using Vonage.Common.Monads;
using Vonage.Common.Test;
using Vonage.Common.Test.Extensions;
using Vonage.Conversations.CreateConversation;
using Xunit;

namespace Vonage.Test.Unit.Conversations.CreateConversation
{
    public class SerializationTest
    {
        private readonly SerializationTestHelper helper = new SerializationTestHelper(
            typeof(SerializationTest).Namespace,
            JsonSerializer.BuildWithSnakeCase());

        [Fact]
        public void ShouldDeserialize200() => this.helper.Serializer
            .DeserializeObject<CreateConversationResponse>(this.helper.GetResponseJson())
            .Should()
            .BeSuccess(response =>
            {
                response.Id.Should().Be("CON-d66d47de-5bcb-4300-94f0-0c9d4b948e9a");
                response.Name.Should().Be("customer_chat");
                response.DisplayName.Should().Be("Customer Chat");
                response.ImageUrl.Should().Be(new Uri("https://example.com/image.png"));
                response.State.Should().Be("ACTIVE");
                response.SequenceNumber.Should().Be(0);
                response.Timestamp.Should().Be(new Timestamp(
                    DateTimeOffset.Parse("2019-09-03T18:40:24.324Z"),
                    DateTimeOffset.Parse("2019-09-03T18:40:24.324Z"),
                    DateTimeOffset.Parse("2019-09-03T18:40:24.324Z")));
                response.Properties.Should().BeEquivalentTo(new Properties(60, "string",
                    "string", new Dictionary<string, string>
                    {
                        {"property1", "string"},
                        {"property2", "string"},
                    }));
                response.Links.Should()
                    .Be(new Links(new HalLink(
                        new Uri("https://api.nexmo.com/v1/conversations/CON-d66d47de-5bcb-4300-94f0-0c9d4b948e9a"))));
            });

        [Fact]
        public void ShouldDeserialize200Minimal() => this.helper.Serializer
            .DeserializeObject<CreateConversationResponse>(this.helper.GetResponseJson())
            .Should()
            .BeSuccess(response =>
            {
                response.Id.Should().Be("CON-dd7ca47d-0e2f-4118-adc4-905e96431459");
                response.Name.Should().Be("NAM-ba3a9bc0-9f7c-4d12-9dca-129cec0fad30");
                response.DisplayName.Should().BeNone();
                response.ImageUrl.Should().BeNone();
                response.State.Should().Be("ACTIVE");
                response.SequenceNumber.Should().Be(0);
                response.Timestamp.Should().Be(new Timestamp(DateTimeOffset.Parse("2023-12-06T06:45:10.390Z"),
                    Maybe<DateTimeOffset>.None, Maybe<DateTimeOffset>.None));
                response.Properties.Should().BeNone();
                response.Links.Should()
                    .Be(new Links(new HalLink(new Uri(
                        "https://api-us-3.vonage.com/v1/conversations/CON-dd7ca47d-0e2f-4118-adc4-905e96431459"))));
            });
    }
}