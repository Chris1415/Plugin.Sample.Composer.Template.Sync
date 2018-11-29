using System;
using System.Threading.Tasks;
using Plugin.Sample.Composer.Template.Sync.Pipelines;
using Plugin.Sample.Composer.Template.Sync.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Core.Commands;

namespace Plugin.Sample.Composer.Template.Sync.Commands
{
    /// <summary>
    /// ImportComposerTemplatesCommand
    /// </summary>
    public class ExportComposerTemplatesCommand : CommerceCommand
    {
        /// <summary>
        /// Import Composer Template Pipeline
        /// </summary>
        private readonly IExportComposerTemplatesPipeline _pipeline;

        /// <summary>
        /// c'tor
        /// </summary>
        /// <param name="pipeline">Import Composer Template Pipeline</param>
        /// <param name="serviceProvider">Service Provider</param>
        public ExportComposerTemplatesCommand(IExportComposerTemplatesPipeline pipeline, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this._pipeline = pipeline;
        }

        /// <summary>
        /// Process
        /// </summary>
        /// <param name="commerceContext">commerceContext</param>
        /// <returns>true if the process was successful</returns>
        public async Task<bool> Process(CommerceContext commerceContext)
        {
            using (var activity = CommandActivity.Start(commerceContext, this))
            {
                var arg = new ExportComposerTemplatesArgument();
                var result = await this._pipeline.Run(arg, new CommercePipelineExecutionContextOptions(commerceContext));
                return result;
            }
        }
    }
}
