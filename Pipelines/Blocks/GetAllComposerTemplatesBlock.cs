using System;
using System.Threading.Tasks;
using Sitecore.Commerce.Core;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;
using System.Collections.Generic;
using Plugin.Sample.Composer.Template.Sync.Pipelines.Arguments;
using Sitecore.Commerce.Plugin.Composer;
using Sitecore.Commerce.Core.Commands;
using System.Linq;
using Plugin.Sample.Composer.Template.Sync.Services;

namespace Plugin.Sample.GenericTaxes.Pipelines.Blocks
{
    /// <summary>
    /// Import Composer Templates Block
    /// </summary>
    [PipelineDisplayName("GetAllComposerTemplatesBlock")]
    public class GetAllComposerTemplatesBlock : PipelineBlock<ExportComposerTemplatesArgument, IList<ComposerTemplate>, CommercePipelineExecutionContext>
    {
        /// <summary>
        /// Commerce Commander
        /// </summary>
        private readonly CommerceCommander _commerceCommander;

        /// <summary>
        /// Composer Template Service
        /// </summary>
        private readonly IComposerTemplateService _composerTemplateService;

        /// <summary>
        /// c'tor
        /// </summary>
        /// <param name="commerceCommander">commerceCommander</param>
        /// <param name="findEntitiesInListCommand">findEntitiesInListCommand</param>
        public GetAllComposerTemplatesBlock(
            CommerceCommander commerceCommander,
            IComposerTemplateService composerTemplateService)
        {
            _commerceCommander = commerceCommander;
            _composerTemplateService = composerTemplateService;
        }

        /// <summary>
        /// Run
        /// </summary>
        /// <param name="arg">arg</param>
        /// <param name="context">context</param>
        /// <returns>flag if the process was sucessfull</returns>
        public override async Task<IList<ComposerTemplate>> Run(ExportComposerTemplatesArgument arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull($"{this.Name}: The argument can not be null");

            List<ComposerTemplate> composerTemplates = _composerTemplateService.GetAllComposerTemplates(context.CommerceContext);

            return await Task.FromResult(composerTemplates);
        }
    }
}