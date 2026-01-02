using TBot.Core.RequestManagement;
using TBot.Core.RequestOptions;
using TBot.Dto.Responses;
using TBot.Dto.Types;
using TBot.Dto.Updates;

namespace TBot.Core.TBot.Interfaces;

public interface ITBotClient
{
    Task<ResponseDto<bool>> DeleteMessageAsync(DeleteMessageOptions options);
    Task<ResponseDto<bool>> DeleteMessagesAsync(DeleteMessagesOptions options);
    Task<ResponseDto<List<MessageDto>>> SendMediaGroupAsync(SendMediaGroupOptions options);
    Task<ResponseDto<MessageDto>> SendPhotoAsync(SendVideoOptions options);
    Task<ResponseDto<MessageDto>> SendVideoAsync(SendVideoOptions options);
    Task<ResponseDto<MessageDto>> SendMessageAsync(SendMessageOptions options);
    Task<ResponseDto<List<UpdateDto>>> GetUpdateAsync(GetUpdateOptions options);

    Task<ResponseDto<TResponseDto>> SendAsync<TResponseDto>(RequestDescriptor request);
    Task<HttpResponseMessage> SendAsync(RequestDescriptor request);
}