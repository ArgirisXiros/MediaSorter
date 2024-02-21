using CommandLine;
using MediaSorter.APP.Enumerations;
using MediaSorter.APP.Services;
using MediaSorter.Core.Entities;
using MediaSorter.Core.Services;
using MediaSorter.UI.Models.ViewModels;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using MetadataExtractor.Formats.GeoTiff;

namespace MediaSorter.UI;

public static class CLI {
    // private const string LookupDirectory = "/Users/argiris/Downloads/GoogleTakeout";
    private const string LookupDirectory = "/Users/argiris/Downloads/Google Takeout/Merged";
    private const MediaCollectionType CollectionType = MediaCollectionType.GoogleTakeout;
    
    public static readonly string[] SupportedImageTypes = new string[] {"jpg", "jpeg", "png"};

    public static int Main(string[] args) {
        // if (CollectionType != MediaCollectionType.GoogleTakeout) {
        //     Console.WriteLine("Unsopported Collection Type. Exiting");
        //     Environment.Exit(0);
        // }

        Console.WriteLine($"Raw arguments: {args.Length}");
        foreach (var arg in args)
        {
            Console.WriteLine($"{arg}");
        }

        var parsedArguments = Parser.Default.ParseArguments<CliArgumentsVM>(args);


        Console.WriteLine($"parsing errors: {parsedArguments.Errors.Count()}");
        foreach (var error in parsedArguments.Errors)
        {
            Console.WriteLine($"{error}");
        }
        Console.WriteLine($"parsedArguments: {parsedArguments.Value.RootFolder}");

        // IDirectoryService directoryService = new GoogleTakeoutDirectoryService();

        // var folder = directoryService.AnalyzeDirectory(LookupDirectory);
        // Console.WriteLine($"Found: {folder.Contents.Count()} files");

        // Merge Folders
        // var outputDirectory = "/Users/argiris/Downloads/GoogleTakeout_merged";
        // if (!Directory.Exists(outputDirectory))
        //     Directory.CreateDirectory(outputDirectory);

        // var counter = 0;
        // foreach (var content in folder.Contents)
        // {
        //     Console.WriteLine($"file {++counter}/{folder.Contents.Count()}: {content.FilePath()}");
        //     if (content.Name.Equals(".DS_Store"))
        //     {
        //         File.Delete(content.FilePath());
        //     }
        //     else
        //     {
        //         var newDirectory = $"{outputDirectory}/{content.Folder.PatentFolderName()}";
                
        //         if (!Directory.Exists(newDirectory))
        //             Directory.CreateDirectory(newDirectory);

        //         File.Move(content.FilePath(), $"{newDirectory}/{content.Name}");
        //     }
        // }

        // Create structure
        // var excludedFolders = new List<string>() {
        //     // "2015-06-13", "2015-06-06", "2015-06-12", "2015-08-15", "2015-09-13"
        // };
        // var existingDirectory = "/Volumes/MediaStorage/Media_Storage/family/Photos";
        // var existingFolders = System.IO.Directory.GetDirectories(existingDirectory)
        //     .Select(f => f.Split("/").Last().Split(" ").First())
        //     .Where(f => !excludedFolders.Contains(f));

        // ===================================================================

        // var destinationDirectory = "/Users/argiris/Downloads/Google Takeout/ToCopy";
        // var processedDirectory = "/Users/argiris/Downloads/Google Takeout/Processed";

        // var counter = 0;
        // foreach (var content in folder.Contents.Take(2000))
        // {
        //     try
        //     {
        //         Console.WriteLine($"file {++counter}/{folder.Contents.Count()}: {content.FilePath()}");
        //         if (content.Name.Equals(".DS_Store"))
        //             continue;

        //         var googleDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        //         using (StreamReader r = new StreamReader(content.MetadataFilePath()))
        //         {
        //             var metadata = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(r.ReadToEnd());
        //             if (metadata == null)
        //                 throw new Exception();

                    
        //             googleDateTime = googleDateTime.AddSeconds(Double.Parse(metadata.photoTakenTime.timestamp.ToString())).ToLocalTime();
        //         }

        //         var fileDateTime = new DateTime();
        //         using(FileStream fs = new FileStream(content.FilePath(), FileMode.Open, FileAccess.Read, FileShare.Read))
        //         {
        //             var metadataDirectories = ImageMetadataReader.ReadMetadata(fs);
        //             var subIfdDirectory = metadataDirectories.OfType<ExifSubIfdDirectory>().FirstOrDefault();

        //             var dateTimeStr = subIfdDirectory?.GetDescription(ExifDirectoryBase.TagDateTimeDigitized);
        //             if (dateTimeStr != null)
        //             {
        //                 try
        //                 {
        //                     fileDateTime = DateTime.ParseExact(dateTimeStr, "yyyy:MM:dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        //                 }
        //                 catch
        //                 {
                            
        //                     fileDateTime = DateTime.ParseExact(dateTimeStr.Trim(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        //                 }
        //             }
        //         }

        //         var googleFolderName = googleDateTime.ToString("yyyy-MM-dd");
        //         var fileFolderName = fileDateTime.ToString("yyyy-MM-dd");

        //         if (
        //             (googleFolderName != fileFolderName)
        //             && !content.Name.EndsWith(".mp4")
        //             && !content.Name.EndsWith(".gif")
        //             && (fileDateTime.Year > 1)
        //             && ((googleDateTime - fileDateTime) > TimeSpan.FromDays(1))
        //         )
        //         {
        //             Console.WriteLine($"Diferrent names: {googleFolderName} - {fileFolderName}");
        //             continue;
        //         }

        //         // if (existingFolders.Contains(googleFolderName))
        //         // {
        //         //     Console.WriteLine($"Folder exists: {googleFolderName}");
        //         //     continue;
        //         // }

        //         var newDirectory = $"{destinationDirectory}/{googleFolderName}";
                    
        //         if (!System.IO.Directory.Exists(newDirectory))
        //             System.IO.Directory.CreateDirectory(newDirectory);

        //         Console.WriteLine($"Moving to: {newDirectory}/{content.Name}");
        //         File.Move(content.FilePath(), $"{newDirectory}/{content.Name}");
        //         File.Move(content.MetadataFilePath(), $"{processedDirectory}/{content.Name}.json");
        //     }
        //     catch (System.Exception ex)
        //     {
        //         Console.WriteLine(ex.ToString());
        //     }
        // }

        return 0;
    }

    public static void ShowExecutionHelp() {
        
    }
}
