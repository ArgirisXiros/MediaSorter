using CommandLine;

namespace MediaSorter.UI.Models;

public class CliArguments
{
    [Value(index: 0, Required = true, MetaName = "Root Folder", HelpText = "Root folder to start analyzing.")]
    public string? RootFolder { get; private set; }

    private CliArguments() {}

    public CliArguments(string rootFolder)
    {
        ArgumentNullException.ThrowIfNull(rootFolder);

        RootFolder = rootFolder;
    }    
}
