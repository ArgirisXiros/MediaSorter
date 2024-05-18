using System.Collections.Immutable;

namespace MediaSorter.Core.Entities;

public class Folder
{
    public string Path { get; init; }
    public Folder? Parent { get; init; }

    public ImmutableArray<Content> Contents { get; private set; }
    public ImmutableArray<Folder> SubFolders { get; private set; }

    public Folder(string path, Folder? parent)
    {
        ArgumentNullException.ThrowIfNull(path);

        Path = path.EndsWith('/') ? path : path + "/";
        Parent = parent;

        Contents = new ImmutableArray<Content>();
        SubFolders = new ImmutableArray<Folder>();
    }

    public Folder(string path) : this(path, null)
    {
    }

    public void Add(Content content)
    {
        ArgumentNullException.ThrowIfNull(content);

        Contents = Contents.AddRange();
    }

    public void Add(Folder subFolder)
    {
        ArgumentNullException.ThrowIfNull(subFolder);

        SubFolders = SubFolders.Add(subFolder);
    }
}
