using DesignPatternChallengeMediator.Colleague;
using DesignPatternChallengeMediator.ConcreteClass;
using DesignPatternChallengeMediator.Interface;

namespace DesignPatternChallengeMediator
{
    internal class Program
    {
        private static void Main()
        {

            IChatMediator mediator = new ChatMediator();

            var alice = new User(mediator, "Alice");
            var bob = new User(mediator, "Bob");
            var carlos = new User(mediator, "Carlos");
            var diana = new User(mediator, "Diana");

            Console.WriteLine("=== Sistema de Chat em Grupo (Mediator) ===\n");
            Console.WriteLine("=== Usuários Entrando no Grupo ===");

            mediator.RegisterUser(alice);
            mediator.RegisterUser(bob);
            mediator.RegisterUser(carlos);
            mediator.RegisterUser(diana);
            alice.AnnounceJoin();
            bob.AnnounceJoin();
            carlos.AnnounceJoin();
            diana.AnnounceJoin();

            Console.WriteLine("\n=== Conversação ===");
            alice.SendMessage("Olá, pessoal!");
            bob.SendMessage("Oi, Alice!");
            carlos.SendMessage("E aí!");

            Console.WriteLine("\n=== Mensagem Privada ===");
            alice.SendPrivateMessage(bob, "Bob, você viu o relatório?");

            Console.WriteLine("\n=== Moderação ===");
            alice.MuteUser(carlos);
            carlos.SendMessage("Ainda posso falar?"); // Não será enviado

            Console.WriteLine("\n=== Saindo do Grupo ===");
            diana.LeaveGroup();
            alice.SendMessage("Diana saiu");

            Console.WriteLine("\n=== Benefícios do Mediator ===");
            Console.WriteLine("✓ Desacoplamento: usuários não conhecem outros usuários");
            Console.WriteLine("✓ Comunicação centralizada: uma única via (mediator)");
            Console.WriteLine("✓ Lógica em um lugar: notificações, mute, envio");
            Console.WriteLine("✓ Fácil estender: log, filtros, rate limit no mediator");

        }
    }
}