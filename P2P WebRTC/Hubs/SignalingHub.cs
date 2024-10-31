using Microsoft.AspNetCore.SignalR;

namespace P2P_WebRTC.Hubs
{
    public class SignalingHub : Hub
    {
        public async Task SendOffer(string receiverConnectionId, string sdp)
        {
            if (string.IsNullOrEmpty(receiverConnectionId))
            {
                await Clients.Others
                    .SendAsync("ReceiveOffer", Context.ConnectionId, sdp);
            }
            else
            {
                await Clients.Client(receiverConnectionId)
                  .SendAsync("ReceiveOffer", Context.ConnectionId, sdp);
            }
        }

        public async Task SendAnswer(string receiverConnectionId, string sdp)
        {
            if (string.IsNullOrEmpty(receiverConnectionId))
            {
                await Clients.Others
                    .SendAsync("ReceiveAnswer", Context.ConnectionId, sdp);
            }
            else
            {
                await Clients.Client(receiverConnectionId)
                    .SendAsync("ReceiveAnswer", Context.ConnectionId, sdp);
            }
        }

        public async Task SendIceCandidate(string receiverConnectionId, string candidate)
        {
            if (string.IsNullOrEmpty(receiverConnectionId))
            {
                await Clients.Others
                    .SendAsync("ReceiveIceCandidate", Context.ConnectionId, candidate);
            }
            else
            {
                await Clients.Client(receiverConnectionId)
                  .SendAsync("ReceiveIceCandidate", Context.ConnectionId, candidate);
            }
        }
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}
