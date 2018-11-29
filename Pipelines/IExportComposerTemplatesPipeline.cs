using Plugin.Sample.Composer.Template.Sync.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Framework.Pipelines;


namespace Plugin.Sample.Composer.Template.Sync.Pipelines
{
    [PipelineDisplayName("ExportComposerTemplatesPipeline")]
    public interface IExportComposerTemplatesPipeline : IPipeline<ExportComposerTemplatesArgument, bool, CommercePipelineExecutionContext>
    {
    }
}
