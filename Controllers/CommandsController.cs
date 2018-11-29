using System;
using System.Threading.Tasks;
using System.Web.Http.OData;
using Microsoft.AspNetCore.Mvc;
using Plugin.Sample.Composer.Template.Sync.Commands;
using Plugin.Sample.Composer.Template.Sync.Pipelines.Arguments;
using Sitecore.Commerce.Core;

namespace Plugin.Sample.Composer.Template.Sync.Controllers
{
    /// <summary>
    /// Commands Controller
    /// </summary>
    public class CommandsController : CommerceController
    {
        /// <summary>
        /// c'tor
        /// </summary>
        /// <param name="serviceProvider">serviceProvider</param>
        /// <param name="globalEnvironment">globalEnvironment</param>
        public CommandsController(IServiceProvider serviceProvider, CommerceEnvironment globalEnvironment)
            : base(serviceProvider, globalEnvironment)
        {
        }

        /// <summary>
        /// Interface function ImportComposerTemplate
        /// </summary>
        /// <param name="value">parameter</param>
        /// <returns>Action Result</returns>
        [HttpPut]
        [Route("ImportComposerTemplates()")]
        public async Task<IActionResult> ImportComposerTemplates([FromBody] ODataActionParameters value)
        {
            string importType = value["ImportType"].ToString();
            var command = this.Command<ImportComposerTemplatesCommand>();
            var result = await command.Process(this.CurrentContext, new ImportComposerTemplatesArgument()
            {
                ImportType = (ImportType)Enum.Parse(typeof(ImportType), importType)
            });

            return new ObjectResult(command);
        }

        /// <summary>
        /// Interface function ImportComposerTemplate
        /// </summary>
        /// <param name="value">parameter</param>
        /// <returns>Action Result</returns>
        [HttpPut]
        [Route("ExportComposerTemplates()")]
        public async Task<IActionResult> ExportComposerTemplates([FromBody] ODataActionParameters value)
        {
            var command = this.Command<ExportComposerTemplatesCommand>();
            var result = await command.Process(this.CurrentContext);

            return new ObjectResult(command);
        }
    }
}