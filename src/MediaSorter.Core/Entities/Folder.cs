namespace MediaSorter.Core.Entities;

public class Folder
{
    public string Path { get; private set; }
    public Folder? Parent { get; private set; }

    public List<Content> Contents { get; private set; }
    public List<Folder> SubFolders { get; private set; }

    public Folder(string path, Folder? parent)
    {
        ArgumentNullException.ThrowIfNull(path);

        Path = path;
        Parent = parent;

        Contents = new List<Content>();
        SubFolders = new List<Folder>();
    }

    public Folder(string path) : this(path, null)
    {
    }

    public void Add(Content content)
    {
        ArgumentNullException.ThrowIfNull(content);

        Contents.Add(content);
    }

    public void Add(Folder subFolder)
    {
        ArgumentNullException.ThrowIfNull(subFolder);

        SubFolders.Add(subFolder);
    }
}
