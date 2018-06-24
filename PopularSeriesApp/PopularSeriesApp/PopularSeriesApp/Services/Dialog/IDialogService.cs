using System.Threading.Tasks;

namespace PopularSeriesApp.Services.Dialog
{
    //Autor: Profº Willian S Rodriguez
    public interface IDialogService
    {
        Task<string> ActionSheetAsync(string title, string cancel, string destruction, params string[] buttons);
        Task AlertAsync(string title, string message, string cancel);
        Task<bool> AlertAsync(string title, string message, string accept, string cancel);
    }
}
