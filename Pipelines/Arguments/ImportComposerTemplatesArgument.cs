using Sitecore.Commerce.Core;

namespace Plugin.Sample.Composer.Template.Sync.Pipelines.Arguments
{
    /// <summary>
    /// ImportComposerTemplatesArgument
    /// </summary>
    public class ImportComposerTemplatesArgument : PipelineArgument
    {
        /// <summary>
        /// Import Type
        /// </summary>
        public ImportType ImportType { get; set; }

        /// <summary>
        /// c'tor
        /// </summary>
        public ImportComposerTemplatesArgument()
        {
            ImportType = ImportType.Skip;
        }
    }
}