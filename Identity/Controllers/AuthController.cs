using Identity.Models;
using Identity.Models.ViewModels;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers;

public class AuthController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly IIdentityServerInteractionService _interactionService;

    public AuthController(
        SignInManager<AppUser> signInManager,
        UserManager<AppUser> userManager,
        IIdentityServerInteractionService interactionService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _interactionService = interactionService;
    }

    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        return View(new LoginViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var user = await _userManager.FindByNameAsync(viewModel.Username);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "User not found");
            return View(viewModel);
        }

        var result = await _signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);
        if (result.IsLockedOut)
        {
            return Redirect(viewModel.ReturnUrl);
        }

        ModelState.AddModelError(string.Empty, "Login error");
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Register(string returnUrl)
    {
        return View(new RegisterViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var user = new AppUser
        {
            UserName = viewModel.Username,
        };

        var result = await _userManager.CreateAsync(user, viewModel.Password);
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
            return Redirect(viewModel.ReturnUrl);
        }

        ModelState.AddModelError(string.Empty, "Register Error");
        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Logout(string logoutId)
    {
        await _signInManager.SignOutAsync();
        var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);

        return Redirect(logoutRequest.PostLogoutRedirectUri);
    }
}