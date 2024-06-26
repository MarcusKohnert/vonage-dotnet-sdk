using System.Threading.Tasks;
using Vonage.Common.Client;
using Vonage.Common.Monads;
using Vonage.Serialization;
using Vonage.VerifyV2.Cancel;
using Vonage.VerifyV2.NextWorkflow;
using Vonage.VerifyV2.StartVerification;
using Vonage.VerifyV2.VerifyCode;

namespace Vonage.VerifyV2;

internal class VerifyV2Client : IVerifyV2Client
{
    private readonly VonageHttpClient vonageClient;

    /// <summary>
    ///     Creates a new client.
    /// </summary>
    /// <param name="configuration">The client configuration.</param>
    internal VerifyV2Client(VonageHttpClientConfiguration configuration) =>
        this.vonageClient = new VonageHttpClient(configuration, JsonSerializerBuilder.BuildWithSnakeCase());

    /// <inheritdoc />
    public Task<Result<Unit>> CancelAsync(Result<CancelRequest> request) =>
        this.vonageClient.SendAsync(request);

    /// <inheritdoc />
    public Task<Result<Unit>> NextWorkflowAsync(Result<NextWorkflowRequest> request) =>
        this.vonageClient.SendAsync(request);

    /// <inheritdoc />
    public Task<Result<StartVerificationResponse>> StartVerificationAsync(Result<StartVerificationRequest> request) =>
        this.vonageClient.SendWithResponseAsync<StartVerificationRequest, StartVerificationResponse>(request);

    /// <inheritdoc />
    public Task<Result<Unit>> VerifyCodeAsync(Result<VerifyCodeRequest> request) =>
        this.vonageClient.SendAsync(request);
}