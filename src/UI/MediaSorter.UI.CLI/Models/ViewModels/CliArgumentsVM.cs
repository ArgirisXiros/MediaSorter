using CommandLine;

namespace MediaSorter.UI.Models.ViewModels;

public class CliArgumentsVM
{
    [Value(index: 0, Required = true, HelpText = "Root folder to start analyzing.")]
    public string? RootFolder { get; private set; }
}
