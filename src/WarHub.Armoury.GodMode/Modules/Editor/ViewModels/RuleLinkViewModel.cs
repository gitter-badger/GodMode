﻿// WarHub licenses this file to you under the MIT license.
// See LICENSE file in the project root for more information.

namespace WarHub.Armoury.GodMode.Modules.Editor.ViewModels
{
    using System.Collections.Generic;
    using System.Windows.Input;
    using AppServices;
    using Bindables;
    using Demo;
    using Model;
    using Models;

    public class RuleLinkViewModel : GenericViewModel<RuleLinkViewModel, IRuleLink>, IModifiersListViewModel
    {
        public RuleLinkViewModel(ICommandsAggregateService commands, IRuleLink model = null)
            : base(model ?? ModelLocator.RuleLink)
        {
            Commands = commands;
            Id = ViewModelLocator.IdentifierViewModel.WithModel(Link.Id);
            Modifiers = Link.Modifiers.ToBindableMap(removeCommand: Commands.RemoveModifierCommand.For(() => Modifiers));
        }

        public IdentifierViewModel Id { get; }

        public BindableMap<ModifierFacade, IRuleModifier> Modifiers { get; }

        public ICommand OpenLinkTargetAsChildCommand
            => Commands.OpenLinkTargetAsChildCommand.SetParameter(Link.ToFacade());

        public ICommand OpenLinkTargetAsSharedCommand
            => Commands.OpenLinkTargetAsSharedCommand.SetParameter(Link.ToFacade());

        public IRule Target
        {
            get { return Link.Target; }
            set { Set(() => Link.Target == value, () => Link.Target = value); }
        }

        public IEnumerable<IRule> Targets => Link.Context.Catalogue.SharedRules;

        private ICommandsAggregateService Commands { get; }

        private IRuleLink Link => Model;

        public ICommand CreateModifierCommand => Commands.CreateModifierCommand.EnableFor(Link.Modifiers);

        IBindableGrouping<ModifierFacade> IModifiersListViewModel.Modifiers => Modifiers;

        public ICommand OpenModifierCommand => Commands.OpenModifierCommand;

        protected override RuleLinkViewModel WithModelCore(IRuleLink model)
        {
            return new RuleLinkViewModel(Commands, model);
        }
    }
}
