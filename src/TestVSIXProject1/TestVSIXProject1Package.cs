global using Community.VisualStudio.Toolkit;
global using Microsoft.VisualStudio.Shell;
global using System;
global using Task = System.Threading.Tasks.Task;
using Community.VisualStudio.Toolkit.DependencyInjection.Microsoft;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;
using System.Threading;

namespace TestVSIXProject1
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
    [ProvideToolWindow(typeof(MyToolWindow.Pane), Style = VsDockStyle.Tabbed, Window = WindowGuids.SolutionExplorer)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.TestVSIXProject1String)]
    public sealed class TestVSIXProject1Package : MicrosoftDIToolkitPackage<TestVSIXProject1Package>
    {
        protected override void InitializeServices(IServiceCollection services)
        {
            // Register any commands. They can be registered as a 'Singleton' or 'Scoped'. 
            // 'Transient' will work but in practice it will behave the same as 'Scoped'.
            services.AddSingleton<MyToolWindowCommand>();

            // Alternatively, you can use the 'RegisterCommands' extension method to automatically register all commands in an assembly.
            services.RegisterCommands(ServiceLifetime.Singleton);
        }

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            // Ensure that you first call the base.InitializeAsync method.
            await base.InitializeAsync(cancellationToken, progress);

        }
    }
}