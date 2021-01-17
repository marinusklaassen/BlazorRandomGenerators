using System.Threading.Tasks;

public interface IClipboardService
{
    ValueTask WriteTextAsync(string text);
}