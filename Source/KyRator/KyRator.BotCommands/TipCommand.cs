using System.Threading.Tasks;
using FluentResults;
using KyRator.Core.Managers;
using Kysect.BotFramework.Core.BotMessages;
using Kysect.BotFramework.Core.Commands;
namespace KyRator.BotCommands
{
    public class TipCommand : IBotAsyncCommand
    {
        public static BotCommandDescriptor<TipCommand> Descriptor =
            new BotCommandDescriptor<TipCommand>("tip", "Transfer your points to other user",
                                                 new[] {"Recipient", "Amount"});

        private PointsManager _pointsManager;
        private SectantsManager _sectantsManager;

        public TipCommand(SectantsManager sectantsManaget, PointsManager pointsManager)
        {
            _sectantsManager = sectantsManaget;
            _pointsManager = pointsManager;
        }

        public Result CanExecute(CommandContainer args) => Result.Ok();

        public Task<Result<IBotMessage>> Execute(CommandContainer args)
        {
            string mentionId = UserUtils.ParseUserIdFromMention(args.Arguments[0]);

            int pointsAmount = int.Parse(args.Arguments[1]);

            var fromSectant = _sectantsManager.GetOrCreateSectant(args.Sender.UserSenderId.ToString());

            var toSectant = _sectantsManager.GetOrCreateSectant(mentionId);

            _pointsManager.SendPoints(fromSectant, toSectant, pointsAmount);

            IBotMessage resultMessage = new BotTextMessage($"Successfully tipped {args.Arguments[0]}");
            return Task.FromResult(Result.Ok(resultMessage));
        }
    }
}