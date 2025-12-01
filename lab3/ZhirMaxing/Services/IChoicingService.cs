namespace ZhirMaxing.Services;

using ZhirMaxing.Interfaces;

public interface IChoicingService
{
    bool IsCorrect(int id);
    IDish GetDishWithId(int id);
}