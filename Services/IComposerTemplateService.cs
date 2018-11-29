using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Composer;
using System.Collections.Generic;

namespace Plugin.Sample.Composer.Template.Sync.Services
{
    /// <summary>
    /// Composer Template Service
    /// </summary>
    public interface IComposerTemplateService
    {
        /// <summary>
        /// Gets all Composer Templates
        /// </summary>
        /// <param name="context">context</param>
        /// <returns>List of all composer templates</returns>
        List<ComposerTemplate> GetAllComposerTemplates(CommerceContext context);
    }
}
