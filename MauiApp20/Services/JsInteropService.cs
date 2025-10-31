using Microsoft.JSInterop;
namespace MauiApp20.Services
{
    public class JsInteropService
    {
        private readonly IJSRuntime _jsRuntime;
        public JsInteropService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public async Task InitializeSlick(string selector, object options)
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("initSlick", selector, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Slick initialization error: {ex.Message}");
            }
        }
        public async Task DestroySlick(string selector)
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("destroySlick", selector);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Slick destroy error: {ex.Message}");
            }
        }
        public async Task InitializeTimer(string selector, DateTime targetDate)
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("initTimer", selector, targetDate.ToString("o"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Timer initialization error: {ex.Message}");
            }
        }
    }
}