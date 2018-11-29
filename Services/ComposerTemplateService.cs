using Sitecore.Commerce.Core;
using Sitecore.Commerce.Core.Commands;
using Sitecore.Commerce.Plugin.Composer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plugin.Sample.Composer.Template.Sync.Services
{
    /// <summary>
    /// Composer Template Service
    /// </summary>
    public class ComposerTemplateService : IComposerTemplateService
    {
        /// <summary>
        /// Find Entities In List Command
        /// </summary>
        private readonly FindEntitiesInListCommand _findEntitiesInListCommand;

        /// <summary>
        /// c'tor
        /// </summary>
        /// <param name="findEntitiesInListCommand">findEntitiesInListCommand</param>
        public ComposerTemplateService(
            FindEntitiesInListCommand findEntitiesInListCommand)
        {
            _findEntitiesInListCommand = findEntitiesInListCommand;
        }

        /// <summary>
        /// Gets all Composer Templates
        /// </summary>
        /// <param name="context">context</param>
        /// <returns>List of all composer templates</returns>
        public List<ComposerTemplate> GetAllComposerTemplates(CommerceContext context)
        {
            CommerceList<ComposerTemplate> commerceList = _findEntitiesInListCommand.Process<ComposerTemplate>(context, CommerceEntity.ListName<ComposerTemplate>(), 0, int.MaxValue).Result;
            List<ComposerTemplate> composerTemplateList;
            if (commerceList == null)
            {
                composerTemplateList = null;
            }
            else
            {
                List<ComposerTemplate> items = commerceList.Items;
                composerTemplateList = items != null ? items.ToList() : null;
            }
            if (composerTemplateList == null)
            {
                composerTemplateList = new List<ComposerTemplate>();
            }

            return composerTemplateList;
        }
    }
}
