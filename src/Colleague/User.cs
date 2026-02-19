using DesignPatternChallengeMediator.Interface;

namespace DesignPatternChallengeMediator.Colleague
{
    public class User
    {
        private readonly IChatMediator _mediator;
        private bool _isMuted;

        public User(IChatMediator mediator, string name)
        {
            _mediator = mediator;
            Name = name;
        }

        public string Name { get; }
        public bool IsMuted => _isMuted;

        public void SetMuted(bool muted) => _isMuted = muted;

        public void JoinGroup()
        {
            _mediator.RegisterUser(this);
            _mediator.NotifyUserJoined(this);
            Console.WriteLine($"[{Name}] Entrou no grupo");
        }

        public void AnnounceJoin()
        {
            _mediator.NotifyUserJoined(this);
            Console.WriteLine($"[{Name}] Entrou no grupo");
        }

        public void SendMessage(string message)
        {
            if (_isMuted)
            {
                Console.WriteLine($"[{Name}] ❌ Você está mutado");
                return;
            }
            Console.WriteLine($"[{Name}] Enviou: {message}");
            _mediator.SendMessageToGroup(message, this);
        }

        public void SendPrivateMessage(User recipient, string message)
        {
            if (_isMuted)
            {
                Console.WriteLine($"[{Name}] ❌ Você está mutado");
                return;
            }
            Console.WriteLine($"[{Name}] Enviou mensagem privada para {recipient.Name}");
            _mediator.SendPrivateMessage(this, recipient, message);
        }

        public void LeaveGroup()
        {
            _mediator.LeaveGroup(this);
            Console.WriteLine($"[{Name}] Saiu do grupo");
        }

        public void MuteUser(User target)
        {
            _mediator.MuteUser(this, target);
            Console.WriteLine($"[{Name}] Mutou {target.Name}");
        }

        public void ReceiveMessage(string senderName, string message)
        {
            Console.WriteLine($"  → [{Name}] Recebeu de {senderName}: {message}");
        }

        public void ReceivePrivateMessage(string senderName, string message)
        {
            Console.WriteLine($"  → [{Name}] 🔒 Mensagem privada de {senderName}: {message}");
        }

        public void ReceiveNotification(string notification)
        {
            Console.WriteLine($"  → [{Name}] ℹ️ {notification}");
        }
    }
}
