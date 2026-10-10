// WSL Container Desktop - a WinUI 3 manager for WSL containers.
// Copyright (C) 2026 Michael Hacker
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using BlazorWinUI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace WslContainerDesktop.Views;

/// <summary>Hosts the BlazorWinUI endpoint inventory component.</summary>
public sealed partial class EndpointsPage : Page
{
    public EndpointsPage()
    {
        InitializeComponent();

        RootHost.Parameters = new Dictionary<string, object?>
        {
            ["SecondaryTextStyle"] = Resources["EndpointSecondaryTextStyle"],
            ["TertiaryIconStyle"] = Resources["EndpointTertiaryIconStyle"],
            ["AccentIconStyle"] = Resources["EndpointAccentIconStyle"],
            ["HeaderBorderStyle"] = Resources["EndpointHeaderBorderStyle"],
            ["BodyBorderStyle"] = Resources["EndpointBodyBorderStyle"]
        };
    }

    public WinUIRenderer Renderer => ((App)Application.Current).Renderer;

    public Type RootComponentType => typeof(EndpointsPanel);

    private void RootHost_OnHostError(object? sender, System.UnhandledExceptionEventArgs e)
    {
        var exception = e.ExceptionObject as Exception
            ?? new Exception($"BlazorWinUI reported an endpoint host error: {e.ExceptionObject}");
        App.Current.Services.GetRequiredService<ILogger<EndpointsPage>>()
            .LogError(exception, "The Endpoints Blazor host failed.");
    }
}
