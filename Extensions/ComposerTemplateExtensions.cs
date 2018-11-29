using Plugin.Sample.Composer.Template.Sync.Models;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using Sitecore.Commerce.Plugin.Composer;
using Sitecore.Commerce.Plugin.ManagedLists;
using Sitecore.Commerce.Plugin.Views;
using System.Collections.Generic;
using System.Linq;

namespace Plugin.Sample.Composer.Template.Sync.Extensions
{
    /// <summary>
    /// Composer Template Extensions
    /// </summary>
    public static class ComposerTemplateExtensions
    {
        /// <summary>
        /// To Custom Composer Template
        /// </summary>
        /// <param name="input">Composer Template input</param>
        /// <returns>Custom Composer Template output</returns>
        public static CustomComposerTemplate ToCustomComposerTemplate(this ComposerTemplate input)
        {
            EntityView entityView = input.GetComponent<EntityViewComponent>().View.ChildViews.FirstOrDefault() as EntityView;
            entityView.EntityId = string.IsNullOrEmpty(entityView.EntityId) ? entityView.EntityId : input.Id;

            return new CustomComposerTemplate()
            {
                EntityVersion = input.EntityVersion,
                Id = input.Id,
                Name = input.Name,
                DisplayName = input.DisplayName,
                Version = input.Version,
                LinkedEntities = input.LinkedEntities,
                ChildView = entityView.ToCustomEntityView()
            };
        }

        /// <summary>
        /// To Composer Template
        /// </summary>
        /// <param name="input">Custom Composer Template</param>
        /// <returns>Composer Tewmplate</returns>
        public static ComposerTemplate ToComposerTemplate(this CustomComposerTemplate input)
        {
            var composerTemplate = new ComposerTemplate(input.Id);
            composerTemplate.GetComponent<ListMembershipsComponent>().Memberships.Add(CommerceEntity.ListName<ComposerTemplate>());

            composerTemplate.LinkedEntities = input.LinkedEntities;

            composerTemplate.Name = input.Name;
            composerTemplate.DisplayName = input.DisplayName;
            composerTemplate.Version = input.Version;
            composerTemplate.EntityVersion = input.EntityVersion;   

            var composerTemplateViewComponent = composerTemplate.GetComponent<EntityViewComponent>();
            composerTemplateViewComponent.View.ChildViews.Add(input.ChildView.ToEntityView());

            return composerTemplate;
        }
    }
}
