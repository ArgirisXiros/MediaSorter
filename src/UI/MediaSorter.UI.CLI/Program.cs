using MediaSorter.APP.Enumerations;

namespace MediaSorter.UI;

public static class CLI {
    private const string LookupDirectory = "/Users/argiris/Downloads/GoogleTakeout";
    private const MediaCollectionType CollectionType = MediaCollectionType.GoogleTakeout;
    
    public static readonly string[] SupportedImageTypes = new string[] {"jpg", "jpeg", "png"};

    public static int Main(string[] args) {
        // if (CollectionType != MediaCollectionType.GoogleTakeout) {
        //     Console.WriteLine("Unsopported Collection Type. Exiting");
        //     Environment.Exit(0);
        // }

        Console.WriteLine($"Lookup directory: {LookupDirectory}");

        var filePaths = Directory.GetFiles(LookupDirectory, "*.*", SearchOption.AllDirectories)
            .Where(f => SupportedImageTypes.Contains(f.Split(".").Last().ToLower()))
            .ToList();
        Console.WriteLine($"Found: {filePaths.Count} files.");

        var extensions = filePaths.GroupBy(f => f.Split(".").Last()).ToList();
        foreach (var extension in extensions) {
            Console.WriteLine(extension.First().Split(".").Last());
        }

        return 0;
    }

    public static void ShowExecutionHelp() {
        
    }
}
