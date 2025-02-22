// /*
//     Copyright (C) 2021 0x90d
//     This file is part of VideoDuplicateFinder
//     VideoDuplicateFinder is free software: you can redistribute it and/or modify
//     it under the terms of the GPLv3 as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
//     VideoDuplicateFinder is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
//     You should have received a copy of the GNU General Public License
//     along with VideoDuplicateFinder.  If not, see <http://www.gnu.org/licenses/>.
// */
//

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using VDF.GUI.Data;
using VDF.GUI.ViewModels;
using VDF.GUI.Views;

namespace VDF.GUI
{
    public class App : Application
    {
        public override void Initialize() => AvaloniaXamlLoader.Load(this);

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowVM(),
                };
            }

            base.OnFrameworkInitializationCompleted();
			/*
			 * Because of an Avalonia bug, the selected item of a Combobox gets changed
			 * when XAML is parsed back to the initial value of the list. This will
			 * override the saved value, so we must restore it here
			 */
			SettingsFile.Instance.HardwareAccelerationMode = ApplicationHelpers.MainWindow.InitialHwMode;
        }
    }
}
