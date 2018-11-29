using Plugin.Sample.Composer.Template.Sync.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Framework.Pipelines;


namespace Plugin.Sample.Composer.Template.Sync.Pipelines
{
    /// <summary>
    /// Import Composer Templates Pipeline
    /// </summary>
    [PipelineDisplayName("ImportComposerTemplatesPipeline")]
    public interface IImportComposerTemplatesPipeline : IPipeline<ImportComposerTemplatesArgument, bool, CommercePipelineExecutionContext>
    {
    }
}
