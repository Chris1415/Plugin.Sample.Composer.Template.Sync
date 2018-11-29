using Plugin.Sample.Composer.Template.Sync.Pipelines.Arguments;
using System.Collections.Generic;

namespace Plugin.Sample.Composer.Template.Sync.Models
{
    /// <summary>
    /// Model to parse between pipeline blocks in importer pipeline
    /// </summary>
    public class ImportComposerTemplatePipelineModel
    {
        /// <summary>
        /// Input Argument
        /// </summary>
        public ImportComposerTemplatesArgument Arguments { get; set; }

        /// <summary>
        /// Composer Templates
        /// </summary>
        public IList<CustomComposerTemplate> InputComposerTemplates { get; set; }

        /// <summary>
        /// Succes flag to determine if the import was successful
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// c'tor
        /// </summary>
        public ImportComposerTemplatePipelineModel()
        {
            Arguments = null;
            InputComposerTemplates = new List<CustomComposerTemplate>();
            Success = false;
        }
    }
}
