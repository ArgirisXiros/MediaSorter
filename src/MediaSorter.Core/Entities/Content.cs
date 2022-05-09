using MediaSorter.Core.Enumerations;
using MediaSorter.Core.Extensions;

namespace MediaSorter.Core.Entities;

public class Content
{
    public string Name { get; private set; }
    public ContentType Type {get; private set;}
    public Folder? Folder { get; private set; }

    public Content(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        Name = name;
        Type = name.ToContentType();
    }

    public void SetFolder(Folder folder)
    {
        ArgumentNullException.ThrowIfNull(folder);

        Folder = folder;
    }
}
