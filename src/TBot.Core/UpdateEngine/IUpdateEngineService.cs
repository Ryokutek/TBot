using TBot.Dto.Updates;

namespace TBot.Core.UpdateEngine;

public interface IUpdateEngineService
{
    Task ExecuteAsync(UpdateDto updateDto);
}