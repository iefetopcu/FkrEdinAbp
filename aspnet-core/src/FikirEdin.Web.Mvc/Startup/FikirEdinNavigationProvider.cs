using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using FikirEdin.Authorization;

namespace FikirEdin.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class FikirEdinNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                    )
                ).AddItem( // Menu items below is just for demonstration!
                    new MenuItemDefinition(
                        "Product",
                        L("Product"),
                        icon: "fas fa-list"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.Product,
                        L("Product"),
                        url: "Product",
                        icon: "fas fa-list",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Product)
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.ProductCategory,
                        L("Category"),
                        url: "Product/Category",
                        icon: "fas fa-list",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Product)
                        )
                    )
                )

                .AddItem( // Menu items below is just for demonstration!
                    new MenuItemDefinition(
                        "Blog",
                        L("Blog"),
                        icon: "fas fa-blog"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.Blog,
                        L("Blog"),
                        url: "Blog",
                        icon: "fas fa-blog",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Blog)
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.BlogCategory,
                        L("BlogCategory"),
                        url: "Blog/Category",
                        icon: "fas fa-blog",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Blog)
                        )
                    )
                )
                .AddItem( // Menu items below is just for demonstration!
                    new MenuItemDefinition(
                        "Contact",
                        L("Contact"),
                        icon: "fa fa-envelope"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.Messages,
                        L("Messages"),
                        url: "Contact/Messages",
                        icon: "fa fa-envelope",
                        permissionDependency: new SimplePermissionDependency()
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.Subscriber,
                        L("Subscriber"),
                        url: "Contact/Subscriber",
                        icon: "fa fa-users",
                        permissionDependency: new SimplePermissionDependency()
                        )
                    )
                );
                
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, FikirEdinConsts.LocalizationSourceName);
        }
    }
}