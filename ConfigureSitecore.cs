// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureSitecore.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Plugin.Sample.Composer.Template.Sync
{
    using System.Reflection;
    using global::Plugin.Sample.Composer.Template.Sync.Pipelines;
    using global::Plugin.Sample.GenericTaxes.Pipelines.Blocks;
    using Microsoft.Extensions.DependencyInjection;
    using Plugin.Sample.Composer.Template.Sync.Services;
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Configuration;
    using Sitecore.Framework.Pipelines.Definitions.Extensions;

    /// <summary>
    /// The configure sitecore class.
    /// </summary>
    public class ConfigureSitecore : IConfigureSitecore
    {
        /// <summary>
        /// The configure services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.RegisterAllPipelineBlocks(assembly);

            services.Sitecore().Pipelines(config => config
               .ConfigurePipeline<IConfigureServiceApiPipeline>(configure => configure.Add<ConfigureServiceApiBlock>())
               .AddPipeline<IExportComposerTemplatesPipeline, ExportComposerTemplatesPipeline>(
                configure =>
                {
                    configure
                    .Add<GetAllComposerTemplatesBlock>()
                    .Add<MapComposerTemplateToCustomComposerModel>()
                    .Add<WriteComposerTemplatesToDisc>();
                })
             .AddPipeline<IImportComposerTemplatesPipeline, ImportComposerTemplatesPipeline>(
                configure =>
                {
                    configure
                    .Add<ReadComposerTemplatesFromDisc>()
                    .Add<SkipComposerTemplatesBlock>()
                    .Add<OverrideComposerTemplatesBlock>()
                    .Add<MergeComposerTemplatesBlock>();
                }));

            services.RegisterAllCommands(assembly);
            services.AddTransient<IComposerTemplateService, ComposerTemplateService>();
        }
    }
}