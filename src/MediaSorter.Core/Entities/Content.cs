using MediaSorter.Core.Enumerations;
using MediaSorter.Core.Extensions;

namespace MediaSorter.Core.Entities;

public class Content
{
    public string Name { get; private set; }
    public ContentType Type {get; private set;}
    public Folder Folder { get; private set; }

    public string FullPath => $"{Folder.Path}{Name}";

    public Content(string name, Folder folder)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(folder);

        Name = name;
        Type = name.ToContentType();
        Folder = folder;
    }
}
