using System;
using Vonage.Common.Exceptions;

namespace Vonage.Common.Failures;

/// <inheritdoc />
public struct AuthenticationFailure : IResultFailure
{
    /// <inheritdoc />
    public string GetFailureMessage() => VonageAuthenticationException.FromMissingApplicationIdOrPrivateKey().Message;

    /// <inheritdoc />
    public Exception ToException() => VonageAuthenticationException.FromMissingApplicationIdOrPrivateKey();
}