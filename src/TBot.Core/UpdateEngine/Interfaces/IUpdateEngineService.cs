using TBot.Dto.Updates;

namespace TBot.Core.UpdateEngine.Interfaces;

public interface IUpdateEngineService
{
    Task ExecuteAsync(UpdateDto updateDto);
}