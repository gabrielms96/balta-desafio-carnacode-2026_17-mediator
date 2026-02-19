using DesignPatternChallengeMediator.Colleague;
using DesignPatternChallengeMediator.Interface;

namespace DesignPatternChallengeMediator.ConcreteClass
{
    internal class ChatMediator : IChatMediator
    {
        private readonly List<User> _users = new();

        public void RegisterUser(User user)
        {
            if (!_users.Contains(user))
                _users.Add(user);
        }

        public void SendMessageToGroup(string message, User sender)
        {
            foreach (var user in _users)
            {
                if (user != sender && !user.IsMuted)
                    user.ReceiveMessage(sender.Name, message);
            }
        }

        public void SendPrivateMessage(User sender, User recipient, string message)
        {
            recipient.ReceivePrivateMessage(sender.Name, message);
        }

        public void NotifyUserJoined(User user)
        {
            foreach (var member in _users)
            {
                if (member != user)
                    member.ReceiveNotification($"{user.Name} entrou no grupo");
            }
        }

        public void LeaveGroup(User user)
        {
            _users.Remove(user);
            foreach (var member in _users)
                member.ReceiveNotification($"{user.Name} saiu do grupo");
        }

        public void MuteUser(User moderator, User target)
        {
            target.SetMuted(true);
            foreach (var member in _users)
            {
                if (member != moderator && member != target)
                    member.ReceiveNotification($"{target.Name} foi mutado por {moderator.Name}");
            }
        }
    }
}
