using System.Threading.Tasks;
using FluentResults;
using KyRator.Core.Managers;
using KyRator.Data.Entities;
using Kysect.BotFramework.Core.BotMessages;
using Kysect.BotFramework.Core.Commands;

namespace KyRator.BotCommands
{
    public class GiveCommand : IBotAsyncCommand
    {
        public static readonly BotCommandDescriptor<GiveCommand> Descriptor = 
            new BotCommandDescriptor<GiveCommand>("give","Admin can give points to other user.", 
                                                  new string[]{"user","amount"});

        private PointsManager _pointsManager;
        private SectantsManager _sectantsManager;

        public GiveCommand(PointsManager pointsManager, SectantsManager sectantsManager)
        {
            _pointsManager = pointsManager;
            _sectantsManager = sectantsManager;
        }
        
        public Result CanExecute(CommandContainer args)
        {
            if (args.Sender.IsAdmin) return Result.Ok();
            return Result.Fail("Command can be used only by admin");
        }

        public Task<Result<IBotMessage>> Execute(CommandContainer args)
        {
            string mentionId = UserUtils.ParseUserIdFromMention(args.Arguments[0]);

            int pointsAmount = int.Parse(args.Arguments[1]);

            var sectant = _sectantsManager.GetOrCreateSectant(mentionId);

            _pointsManager.GivePoints(sectant,pointsAmount);

            IBotMessage resultMessage = new BotTextMessage($"Sectant {args.Arguments[0]} now have {sectant.Points} points");
            return Task.FromResult(Result.Ok(resultMessage));
        }
    }
}