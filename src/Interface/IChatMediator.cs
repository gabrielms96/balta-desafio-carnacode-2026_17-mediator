using DesignPatternChallengeMediator.Colleague;

namespace DesignPatternChallengeMediator.Interface
{
    public interface IChatMediator
    {
        void RegisterUser(User user);
        void SendMessageToGroup(string message, User sender);
        void SendPrivateMessage(User sender, User recipient, string message);
        void NotifyUserJoined(User user);
        void LeaveGroup(User user);
        void MuteUser(User moderator, User target);
    }
}
