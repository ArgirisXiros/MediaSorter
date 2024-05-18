using MediaSorter.Core.Entities;
using MediaSorter.Core.Services;

namespace MediaSorter.APP.Services;

public abstract class BaseDirectoryService : IDirectoryService
{
    public virtual Folder AnalyzeDirectory(string rootPath)
    {
        ArgumentNullException.ThrowIfNull(rootPath);

        if (!Directory.Exists(rootPath))
        {
            throw new ArgumentException($"Invalid root path: {rootPath}", nameof(rootPath));
        }
        
        var fullPathDirectory = Path.GetFullPath(rootPath);
        var rootFolder = new Folder(fullPathDirectory);

        var filesInDirectory = Directory.GetFiles(fullPathDirectory, "*.*", SearchOption.TopDirectoryOnly)
            .Select(f => new Content(Path.GetFileName(f), rootFolder));

        var subDirectories = Directory.GetDirectories(fullPathDirectory, "*", SearchOption.TopDirectoryOnly)
            .Select(d => new Folder(Path.GetFileName(d), rootFolder));
        // foreach(var fullPathFolder in fullPathFolders)
        // {
        //     var folderName = Path.GetFileName(fullPathFolder);

        //     Console.WriteLine($"ddd {fullPathFolder} ~ {folderName}");
        // }



        // var fullPath = Path.GetFullPath(path);
        // var folder = new Folder(fullPath);

        return rootFolder;
    }
}
