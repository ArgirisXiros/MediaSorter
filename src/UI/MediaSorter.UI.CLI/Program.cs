using CommandLine;
using MediaSorter.APP.Services;
using MediaSorter.UI.Models;

namespace MediaSorter.UI;

public static class CLI {

    public static int Main(string[] args) {
#if DEBUG
        var arguments = new CliArguments(
            "/run/user/1000/gvfs/smb-share:server=192.168.0.100,share=mediastoragetemp/family/Photos/2011"
        );
        Run(arguments);
#else
        Parser.Default.ParseArguments<CliArguments>(args)
            .WithParsed(Run)
            .WithNotParsed(HandleParseError);
#endif

        return 0;
    }

    private static void Run(CliArguments arguments)
    {
        if (File.Exists(arguments.RootFolder))
        {
            Console.WriteLine("This is a file");
        }

        if (!Directory.Exists(arguments.RootFolder))
        {
            Console.WriteLine($"Directory: '{arguments.RootFolder}' doesn't exist");
            return;
        }

        // var fullRootFolderPath = Path.GetFullPath(arguments.RootFolder);
        // Console.WriteLine($"Using: {fullRootFolderPath}");

        var directoryService = new YDDirectoryService();
        var rootFolder = directoryService.AnalyzeDirectory(arguments.RootFolder);

        // var fullPathFiles = Directory.GetFiles(fullRootFolderPath, "*.*", SearchOption.TopDirectoryOnly);
        // foreach(var fullPathFile in fullPathFiles)
        // {
        //     var filename = Path.GetFileName(fullPathFile);

        //     Console.WriteLine($"fff {fullPathFile} ~ {filename}");
        // }

        // var fullPathFolders = Directory.GetDirectories(fullRootFolderPath, "*", SearchOption.TopDirectoryOnly);
        // foreach(var fullPathFolder in fullPathFolders)
        // {
        //     var folderName = Path.GetFileName(fullPathFolder);

        //     Console.WriteLine($"ddd {fullPathFolder} ~ {folderName}");
        // }
    }

    private static void HandleParseError(IEnumerable<Error> errs)
    {
        if (errs.IsVersion())
        {
            Console.WriteLine("Version Request");
            return;
        }

        if (errs.IsHelp())
        {
            Console.WriteLine("Help Request");
            return;
        }
        Console.WriteLine("Parser Fail");
    }
}
