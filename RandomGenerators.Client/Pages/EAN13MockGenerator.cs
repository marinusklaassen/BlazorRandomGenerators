using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RandomGenerators.EAN13MockGenerator;

namespace RandomGenerators.Client.Pages
{
    public partial class EAN13MockGenerator : ComponentBase
    {
        [Inject]
        IEAN13MockGenerator EAN13GeneratorService { get; set; }

        [Inject]
        IClipboardService ClipboardService { get; set; }

        [Inject]
        IToastService ToastNotifcationService { get; set; }

        List<string> EAN13Mocks = new List<string>();

        private int Count { get; set; } = 10;

        protected override void OnInitialized()
        {
            EAN13Mocks = EAN13GeneratorService.GenerateEAN13Bulk(Count);
        }

        private void On_Button_Generate(MouseEventArgs e)
        {
            EAN13Mocks = EAN13GeneratorService.GenerateEAN13Bulk(Count);
        }

        private async Task OnClick_CopyToClipboard(int position)
        {
            var eanCode = EAN13Mocks[position]; 
            
            await ClipboardService.WriteTextAsync(eanCode);

            ToastNotifcationService.ShowInfo($"Copied {eanCode} to your clipboard");
        }

        private async Task OnClick_CopyToClipboardAll()
        {
            var eanText = String.Join(Environment.NewLine, EAN13Mocks);

            ToastNotifcationService.ShowInfo($"Copied {EAN13Mocks.Count} eancodes to your clipboard");

            await ClipboardService.WriteTextAsync(eanText);
        }

        private void OnClick_ResetForm(MouseEventArgs e)
        {
            EAN13Mocks.Clear();
        }
    }
}
