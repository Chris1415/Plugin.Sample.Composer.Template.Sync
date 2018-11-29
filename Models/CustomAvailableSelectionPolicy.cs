using System.Collections.Generic;

namespace Plugin.Sample.Composer.Template.Sync.Models
{
    public class CustomAvailableSelectionPolicy
    {
        public string PolicyId { get; set; }

        public IList<CustomSelection> Selection { get; set; }

        public bool AllowMultiSelect { get; set; }
    }
}
