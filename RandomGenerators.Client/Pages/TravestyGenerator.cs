using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RandomGenerators.Travesty;

namespace RandomGenerators.Client.Pages
{
    public partial class TravestyGenerator : ComponentBase
    {
        [Inject]
        ITravestyGenerator TravestyGeneratorService { get; set; }

        public class SelectorItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        int SelectedLevelOfGarbling = 5;

        string Text;

        int MaxLength;

        string Error;

        List<SelectorItem> LevelOfGarblingItems = new List<SelectorItem>
        {
            new SelectorItem { Id = 1, Name = "Most Garbled" },
            new SelectorItem { Id = 2, Name = "" },
            new SelectorItem { Id = 3, Name = "" },
            new SelectorItem { Id = 4, Name = "" },
            new SelectorItem { Id = 5, Name = "Middle Garbling" },
            new SelectorItem { Id = 6, Name = "" },
            new SelectorItem { Id = 7, Name = "" },
            new SelectorItem { Id = 8, Name = "" },
            new SelectorItem { Id = 9, Name = "Least Garbeld" }
        };

        private void ProcessText(MouseEventArgs e)
        {
            try
            {
                Error = null;
                if (Text != null && Text.Length > SelectedLevelOfGarbling)
                {
                    Text = TravestyGeneratorService.ProcessText(Text, SelectedLevelOfGarbling, MaxLength);
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
    }
}
