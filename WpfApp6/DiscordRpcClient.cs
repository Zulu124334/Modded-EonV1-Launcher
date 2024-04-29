using static NetDiscordRpc.DiscordRPC;
using System;

namespace Frost
{
    internal class DiscordRpcClient
    {
        private string v;

        public DiscordRpcClient(string v)
        {
            this.v = v;
        }

        public Action<object, object> OnReady { get; internal set; }
        public Action<object, object> OnError { get; internal set; }

        internal void ClearPresence()
        {
            throw new NotImplementedException();
        }

        internal void Dispose()
        {
            throw new NotImplementedException();
        }

        internal void Initialize()
        {
            throw new NotImplementedException();
        }

        internal void SetPresence(RichPresence activity)
        {
            throw new NotImplementedException();
        }

        internal void SetPresence(WpfApp6.RichPresenceDetails presenceDetails)
        {
            throw new NotImplementedException();
        }
    }
}