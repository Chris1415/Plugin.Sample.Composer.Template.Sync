using System.Threading.Tasks;
using Sitecore.Commerce.Core;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;
using System.Collections.Generic;
using Plugin.Sample.Composer.Template.Sync.Pipelines.Arguments;
using Newtonsoft.Json;
using System.IO;
using Plugin.Sample.Composer.Template.Sync.Policies;
using Plugin.Sample.Composer.Template.Sync.Models;

namespace Plugin.Sample.GenericTaxes.Pipelines.Blocks
{
    /// <summary>
    /// Import Composer Templates Block
    /// </summary>
    [PipelineDisplayName("ReadComposerTemplatesFromDisc")]
    public class ReadComposerTemplatesFromDisc : PipelineBlock<ImportComposerTemplatesArgument, ImportComposerTemplatePipelineModel, CommercePipelineExecutionContext>
    {
        /// <summary>
        /// Run
        /// </summary>
        /// <param name="arg">arg</param>
        /// <param name="context">context</param>
        /// <returns>flag if the process was sucessfull</returns>
        public override async Task<ImportComposerTemplatePipelineModel> Run(ImportComposerTemplatesArgument arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull($"{this.Name}: The argument can not be null");
            ComposerTemplatesSyncPolicy policy = context.GetPolicy<ComposerTemplatesSyncPolicy>();

            string inputJson = File.ReadAllText(policy.PathToJson);

            List<CustomComposerTemplate> allComposerTemplates = JsonConvert.DeserializeObject<List<CustomComposerTemplate>>(inputJson);

            return await Task.FromResult(new ImportComposerTemplatePipelineModel()
            {
                Arguments = arg,
                InputComposerTemplates = allComposerTemplates
            });
        }
    }
}