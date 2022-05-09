using MediaSorter.Core.Entities;

namespace MediaSorter.Core.Services;

public interface IDirectoryService
{
    Folder AnalyzeDirectory(string path);
}
