using MediaSorter.Core.Enumerations;
using MediaSorter.Core.Extensions;

namespace MediaSorter.Core.Entities;

public class Content
{
    public string Name { get; private set; }
    public ContentType Type {get; private set;}
    public Folder Folder { get; private set; }

    public Content(string name, Folder folder)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(folder);

        Name = name;
        Type = name.ToContentType();
        Folder = folder;
    }

    public string FilePath()
    {
        return $"{Folder.Path}{Name}";
    }

    public string MetadataFilePath()
    {
        var metaDataFileName = $"{Name}.json";

        if (metaDataFileName.Length > 51)
            metaDataFileName = $"{Name.Substring(0, 46)}.json";
            
        return $"{Folder.Path}{metaDataFileName}";
    }
}
