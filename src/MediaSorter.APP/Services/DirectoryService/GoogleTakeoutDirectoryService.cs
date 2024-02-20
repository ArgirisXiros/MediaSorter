using MediaSorter.Core.Entities;
using MediaSorter.Core.Services;

namespace MediaSorter.APP.Services;

public class GoogleTakeoutDirectoryService : IDirectoryService
{
    public GoogleTakeoutDirectoryService()
    {
    }
    
    public Folder AnalyzeDirectory(string path)
    {
        ArgumentNullException.ThrowIfNull(path);

        if (!Directory.Exists(path))
            throw new ArgumentException($"Invalid path: {path}", nameof(path));

        var fullPath = Path.GetFullPath(path);
        var folder = new Folder(fullPath);

        var subFolders = new Dictionary<string, Folder>();

        var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
        foreach(var file in files)
        {
            if (file.EndsWith(".json"))
                continue;

            fullPath = Path.GetFullPath(file).Replace(Path.GetFileName(file), "");
            if (!subFolders.ContainsKey(fullPath))
                subFolders.Add(fullPath, new Folder(fullPath));

            var filename = Path.GetFileName(file);
            var content = new Content(filename, subFolders[fullPath]);

            folder.Add(content);
        }

        return folder;
    }
}
