using System.Collections.Generic;

namespace Nexmo.Api.Applications.Capabilities
{
    public class Voice : Capability
    {
        public Voice(IDictionary<Common.Webhook.Type, Common.Webhook> webhooks)
        {
            this.Webhooks = webhooks;
            this.Type = Capability.CapabilityType.Voice;
        }
    }
}