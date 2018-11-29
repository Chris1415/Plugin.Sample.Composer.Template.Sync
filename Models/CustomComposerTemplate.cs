using System.Collections.Generic;

namespace Plugin.Sample.Composer.Template.Sync.Models
{
    public class CustomComposerTemplate
    {
        public string Id { get; set; }

        public int Version { get; set; }

        public int EntityVersion { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public IList<string> LinkedEntities { get; set; }

        public CustomEntityView ChildView { get; set; }
    }
}
