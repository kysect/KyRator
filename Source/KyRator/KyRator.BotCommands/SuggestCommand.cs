using System.Threading.Tasks;
using FluentResults;
using KyRator.Core.Managers;
using Kysect.BotFramework.Core.BotMessages;
using Kysect.BotFramework.Core.Commands;

namespace KyRator.BotCommands
{
    public class SuggestCommand : IBotAsyncCommand
    {
        public static readonly BotCommandDescriptor<SuggestCommand> Descriptor = 
            new BotCommandDescriptor<SuggestCommand>("sug","Create give points suggestion", 
                                                     new string[]{"user","amount","description"});

        private SuggestionManager _suggestionManager;
        private SectantsManager _sectantsManager;

        public SuggestCommand(SuggestionManager suggestionManager, SectantsManager sectantsManager)
        {
            _suggestionManager = suggestionManager;
            _sectantsManager = sectantsManager;
        }
        
        public Result CanExecute(CommandContainer args) => Result.Ok();

        public Task<Result<IBotMessage>> Execute(CommandContainer args)
        {
            string mentionId = UserUtils.ParseUserIdFromMention(args.Arguments[0]);
                
            if (long.Parse(mentionId)==args.Sender.UserSenderId)
                return Task.FromResult(Result.Fail<IBotMessage>("Sectant can't suggest himself"));
            
            int pointsAmount = int.Parse(args.Arguments[1]);

            var sectant = _sectantsManager.GetOrCreateSectant(mentionId);

            _suggestionManager.CreateSuggestion(sectant,pointsAmount,args.Arguments[2]);

            IBotMessage resultMessage = new BotTextMessage($"Suggestion successfully created");
            return Task.FromResult(Result.Ok(resultMessage));
        }
    }
}