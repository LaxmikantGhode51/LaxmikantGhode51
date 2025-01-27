//using Microsoft.Playwright;
//using NUnit.Framework;
//using System.Diagnostics;
//using System.IO;
//using System.Threading.Tasks;

//[TestFixture]
//public class PlaywrightTests
//{
//    private IPlaywright _playwright;
//    private IBrowser _browser;
//    private IBrowserContext _context;
//    private IPage _page;

//    // Define the trace file path
//    private readonly string _traceFilePath = @"C:\Users\91954\source\repos\PlaywrightNunit\PlaywrightNunit\bin\Debug\net8.0\trace.zip";

//    [OneTimeSetUp]
//    public async Task OneTimeSetUp()
//    {
//        _playwright = await Playwright.CreateAsync();
//        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
//        {
//            Headless = false // Set to true to run tests in headless mode
//        });
//    }

//    [SetUp]
//    public async Task SetUp()
//    {
//        _context = await _browser.NewContextAsync();
//        _page = await _context.NewPageAsync();

//        // Start tracing to capture actions and snapshots
//        await _context.Tracing.StartAsync(new TracingStartOptions
//        {
//            Screenshots = true,
//            Snapshots = true,
//            Sources = true


//        });
//    }

//    [Test]
//    public async Task SampleTest()
//    {
        
//        await _page.GotoAsync("https://testautomationpractice.blogspot.com/");
       
        
//        await _page.PauseAsync();
        
//    }

//    [TearDown]
//    public async Task TearDown()
//    {
//        // Ensure the directory exists before saving the trace file
//        var traceDirectory = Path.GetDirectoryName(_traceFilePath);
//        if (!Directory.Exists(traceDirectory))
//        {
//            Directory.CreateDirectory(traceDirectory);
//        }

//        // Stop tracing and save it to the specified file path
//        await _context.Tracing.StopAsync(new TracingStopOptions
//        {
//            Path = _traceFilePath
//        });

//        // Close the page and context
//        await _page.CloseAsync();
//        await _context.CloseAsync();

//        // Automatically open the trace report in the default browser
//        Process.Start(new ProcessStartInfo
//        {
//            FileName = "cmd",
//            Arguments = $"/c npx playwright show-trace \"{_traceFilePath}\"",
//            UseShellExecute = false,
//            CreateNoWindow = true
//        });
//    }

//    [OneTimeTearDown]
//    public async Task OneTimeTearDown()
//    {
//        await _browser.CloseAsync();
//        _playwright.Dispose();
//    }
//}
