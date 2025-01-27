using Microsoft.Playwright;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

public class TraceViewerHelper
{
    private readonly IBrowser _browser;
    private readonly IPage _page;
    private readonly IBrowserContext _context;
    private readonly string _traceFilePath;

    public TraceViewerHelper(IBrowser browser, IBrowserContext context, IPage page)
    {
        _browser = browser;
        _context = context;
        _page = page;
        _traceFilePath = Path.Combine(@"C:\Users\91954\source\repos\PlaywrightNunit\PlaywrightNunit\bin\Debug\net8.0\Traces", "trace.zip");
    }

    public async Task StopTracingAsync()
    {
        var traceDirectory = Path.GetDirectoryName(_traceFilePath);
        if (!Directory.Exists(traceDirectory))
        {
            Directory.CreateDirectory(traceDirectory);
        }

        await _context.Tracing.StopAsync(new TracingStopOptions
        {
            Path = _traceFilePath
        });

        await _page.CloseAsync();
        await _context.CloseAsync();

        Process.Start(new ProcessStartInfo
        {
            FileName = "cmd",
            Arguments = $"/c npx playwright show-trace \"{_traceFilePath}\"",
            UseShellExecute = false,
            CreateNoWindow = true
        });
    }

    public async Task CleanupAsync(IPlaywright playwright)
    {
        await _browser.CloseAsync();
        playwright.Dispose();
    }
}
