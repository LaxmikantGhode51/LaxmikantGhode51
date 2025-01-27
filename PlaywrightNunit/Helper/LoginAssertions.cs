using NUnit.Framework;
using Microsoft.Playwright;
using System.Threading.Tasks;

public class LoginAssertions
{
    private readonly IPage _page;

    public LoginAssertions(IPage page)
    {
        _page = page;
    }

    // Assertion for username field visibility
    public async Task AssertUsernameFieldVisibleAsync()
    {
        var usernameField = _page.GetByLabel("UserName");
        Assert.IsTrue(await usernameField.IsVisibleAsync(), "Username field is not visible");
    }

    // Assertion for password field visibility
    public async Task AssertPasswordFieldVisibleAsync()
    {
        var passwordField = _page.GetByLabel("Password");
        Assert.IsTrue(await passwordField.IsVisibleAsync(), "Password field is not visible");
    }

    // Assertion for login button visibility and enablement
    public async Task AssertLoginButtonVisibleAndEnabledAsync()
    {
        var loginButton = _page.GetByRole(AriaRole.Button, new() { Name = "Log in" });
        Assert.IsTrue(await loginButton.IsVisibleAsync(), "Login button is not visible");
        Assert.IsTrue(await loginButton.IsEnabledAsync(), "Login button is not enabled");
    }

    // Assertion for login heading after clicking login
    public async Task AssertLoginHeadingVisibleAsync()
    {
        var loginHeading = _page.GetByRole(AriaRole.Heading, new() { Name = "Login." });
        Assert.IsTrue(await loginHeading.IsVisibleAsync(), "Login heading is not visible after login");
    }
}
