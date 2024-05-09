using System.Text.Json;
using app.Services.UserPermissionsServices;
using Microsoft.AspNetCore.Authorization;

namespace app.WebApp.Handlers;

public class AuthorizationRequirement : IAuthorizationRequirement
{
    public string PermissionName { get; }
    public AuthorizationRequirement(string permissionName)
    {
        PermissionName = permissionName;
    }
   
}

public class PermissionHandler : AuthorizationHandler<AuthorizationRequirement>
{
    private readonly IHttpContextAccessor _iHttpContextAccessor;
    private readonly IAssignMenus _iAssignMenus;

    public PermissionHandler(IHttpContextAccessor iHttpContextAccessor, IAssignMenus iAssignMenus)
    {
        _iHttpContextAccessor = iHttpContextAccessor;
        _iAssignMenus = iAssignMenus;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationRequirement requirement)
    {
        if (context.Resource is HttpContext httpContext && httpContext.GetEndpoint() is RouteEndpoint endpoint)
        {
            endpoint.RoutePattern.RequiredValues.TryGetValue("controller", out var _controller);
            endpoint.RoutePattern.RequiredValues.TryGetValue("action", out var _action);
            endpoint.RoutePattern.RequiredValues.TryGetValue("page", out var _page);
            endpoint.RoutePattern.RequiredValues.TryGetValue("area", out var _area);
            var serializedArrayFromSession = _iHttpContextAccessor.HttpContext?.Session.GetString("ArrayData");

            MenuPermissionViewModel retrievedArray = new MenuPermissionViewModel();
            if (serializedArrayFromSession != null)
            {
                retrievedArray = JsonSerializer.Deserialize<MenuPermissionViewModel>(serializedArrayFromSession);
                // Now 'retrievedArray' contains the array of strings
            }

            List<MenuItemVm> menuItemVMs = new List<MenuItemVm>();
            foreach (var item in retrievedArray.MainMenuVm)
            {
                foreach (var item1 in item.MenuItemVMs)
                {
                    MenuItemVm menu = new MenuItemVm();
                    menu.Name = item1.Name;
                    menu.Controller = item1.Controller;
                    menu.Action = item1.Action;
                    menuItemVMs.Add(menu);
                }
            }

            var checkPermission = menuItemVMs.FirstOrDefault(s => s.Action == (string)_action && s.Controller == (string)_controller);
            //Check if a parent action is permitted then it'll allow child without checking for child permissions
            if (!string.IsNullOrWhiteSpace(requirement?.PermissionName) && !requirement.PermissionName.Equals("kgecomAuthorizatio"))
            {
                _action = requirement.PermissionName;
            }
            if (checkPermission != null)
            {
                if (requirement != null && context.User.Identity?.IsAuthenticated == true && _controller != null && _action != null && checkPermission.Action != null && checkPermission.Controller != null)
                {
                    context.Succeed(requirement);
                }
            }
        }

        await Task.CompletedTask;
    }
}
