﻿// WarHub licenses this file to you under the MIT license.
// See LICENSE file in the project root for more information.

namespace WarHub.Armoury.GodMode.Modules.Editor.Views
{
    using ViewModels;

    /// <summary>
    /// Returns null, used only for BindingContext typing in XAML views.
    /// </summary>
    public static class ViewModelLocator
    {
        public static BookIndexViewModel BookIndexViewModel => Resolve<BookIndexViewModel>();

        public static CatalogueConditionGroupViewModel CatalogueConditionGroupViewModel
            => Resolve<CatalogueConditionGroupViewModel>();

        public static CatalogueConditionViewModel CatalogueConditionViewModel => Resolve<CatalogueConditionViewModel>();

        public static CatalogueViewModel CatalogueViewModel => Resolve<CatalogueViewModel>();

        public static CharacteristicViewModel CharacteristicViewModel => Resolve<CharacteristicViewModel>();

        public static EntryLimitsViewModel EntryLimitsViewModel => Resolve<EntryLimitsViewModel>();

        public static EntryLinkViewModel EntryLinkViewModel => Resolve<EntryLinkViewModel>();

        public static EntryModifierViewModel EntryModifierViewModel => Resolve<EntryModifierViewModel>();

        public static EntryViewModel EntryViewModel => Resolve<EntryViewModel>();

        public static GroupLinkViewModel GroupLinkViewModel => Resolve<GroupLinkViewModel>();

        public static GroupModifierViewModel GroupModifierViewModel => Resolve<GroupModifierViewModel>();

        public static GroupViewModel GroupViewModel => Resolve<GroupViewModel>();

        public static IdentifierViewModel IdentifierViewModel => Resolve<IdentifierViewModel>();

        public static ProfileLinkViewModel ProfileLinkViewModel => Resolve<ProfileLinkViewModel>();

        public static ProfileModifierViewModel ProfileModifierViewModel => Resolve<ProfileModifierViewModel>();

        public static ProfileViewModel ProfileViewModel => Resolve<ProfileViewModel>();

        public static RuleLinkViewModel RuleLinkViewModel => Resolve<RuleLinkViewModel>();

        public static RuleModifierViewModel RuleModifierViewModel => Resolve<RuleModifierViewModel>();

        public static RuleViewModel RuleViewModel => Resolve<RuleViewModel>();

        private static TService Resolve<TService>() where TService : class => null;
    }
}
