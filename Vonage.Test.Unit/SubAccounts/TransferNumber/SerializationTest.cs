﻿using Vonage.Common;
using Vonage.Common.Test;
using Vonage.Common.Test.Extensions;
using Vonage.SubAccounts.TransferNumber;
using Xunit;

namespace Vonage.Test.Unit.SubAccounts.TransferNumber
{
    public class SerializationTest
    {
        private readonly SerializationTestHelper helper;

        public SerializationTest() =>
            this.helper = new SerializationTestHelper(
                typeof(SerializationTest).Namespace,
                JsonSerializer.BuildWithSnakeCase());

        [Fact]
        public void ShouldDeserialize200() =>
            this.helper.Serializer
                .DeserializeObject<TransferNumberResponse>(this.helper.GetResponseJson())
                .Should()
                .BeSuccess(new TransferNumberResponse("235077036", "GB", "7c9738e6", "ad6dc56f"));

        [Fact]
        public void ShouldSerialize() =>
            TransferNumberRequest.Build()
                .WithFrom("7c9738e6")
                .WithTo("ad6dc56f")
                .WithNumber("23507703696")
                .WithCountry("GB")
                .Create()
                .GetStringContent()
                .Should()
                .BeSuccess(this.helper.GetRequestJson());
    }
}