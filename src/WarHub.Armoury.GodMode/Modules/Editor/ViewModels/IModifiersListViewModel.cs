﻿// WarHub licenses this file to you under the MIT license.
// See LICENSE file in the project root for more information.

namespace WarHub.Armoury.GodMode.Modules.Editor.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Input;
    using Bindables;
    using Models;

    public interface IModifiersListViewModel : INotifyPropertyChanged
    {
        ICommand CreateModifierCommand { get; }

        IBindableGrouping<ModifierFacade> Modifiers { get; }

        ICommand OpenModifierCommand { get; }
    }
}
