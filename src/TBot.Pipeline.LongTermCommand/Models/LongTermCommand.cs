using TBot.Core.TBot.EnvironmentManagement;
using TBot.Storage;

namespace TBot.Pipeline.LongTermCommand.Models;

public class LongTermCommand : BaseEntity
{
    public long UserId { get; set; }
    public long ChatId { get; set; }
    public string Identifier { get; set; } = null!;
    public string SegmentName { get; set; } = null!;
    public int SegmentNumber { get; set; }
    public string? IntermediateData { get; set; }

    public static LongTermCommand Create(CurrentRequest currentRequest, Pipeline.LongTermCommand.LongTermCommand longTermCommand, string intermediateData)
    {
        return new LongTermCommand
        {
            Identifier = longTermCommand.Identifier,
            IntermediateData = intermediateData,
            ChatId = currentRequest.FromChatId,
            UserId = currentRequest.FromUserId,
            SegmentName = longTermCommand.CurrentSegmentName,
            SegmentNumber = longTermCommand.CurrentSegmentNumber
        };
    }
}