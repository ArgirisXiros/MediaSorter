namespace MediaSorter.Core.Entities;

public class Folder
{
    public string Path { get; private set; }

    public List<Content> Contents { get; private set; }

    public Folder? Parent { get; private set; }
    public List<Folder> SubFolders { get; private set; }

    public Folder(string path)
    {
        ArgumentNullException.ThrowIfNull(path);

        if (!IsPathValid(path))
            throw new ArgumentException($"Invalid folder path: '{path}'", nameof(path));

        Path = System.IO.Path.GetFullPath(path);

        Contents = new List<Content>();
        SubFolders = new List<Folder>();
    }

    private static bool IsPathValid(string path)
    {
        return Directory.Exists(path);
    }

    public void AddContent(Content content)
    {
        ArgumentNullException.ThrowIfNull(content);

        content.SetFolder(this);
        Contents.Add(content);
    }

    public void SetParent(Folder parent)
    {
        ArgumentNullException.ThrowIfNull(parent);
        
        Parent = parent;
    }

    public void AddSubFolder(Folder subFolder)
    {
        ArgumentNullException.ThrowIfNull(subFolder);

        subFolder.SetParent(this);
        SubFolders.Add(subFolder);
    }
}
