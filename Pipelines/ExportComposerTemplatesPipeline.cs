using Microsoft.Extensions.Logging;
using Plugin.Sample.Composer.Template.Sync.Commands;
using Plugin.Sample.Composer.Template.Sync.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Framework.Pipelines;

namespace Plugin.Sample.Composer.Template.Sync.Pipelines
{
    /// <summary>
    /// Import Composer Templates Pipeline
    /// </summary>
    public class ExportComposerTemplatesPipeline : CommercePipeline<ExportComposerTemplatesArgument, bool>, IExportComposerTemplatesPipeline
    {
        /// <summary>
        /// c'tor
        /// </summary>
        /// <param name="configuration">configuration</param>
        /// <param name="loggerFactory">loggerFactory</param>
        public ExportComposerTemplatesPipeline(IPipelineConfiguration<IExportComposerTemplatesPipeline> configuration, ILoggerFactory loggerFactory)
            : base(configuration, loggerFactory)
        {
        }
    }
}