build:
	dotnet build
build_all:
	dotnet clean
	dotnet build
clean:
	dotnet clean
restore:
	dotnet restore
watch:
	dotnet watch --project src/UI/MediaSorter.UI.CLI/MediaSorter.UI.CLI.csproj run
run:
	dotnet run --project src/UI/MediaSorter.UI.CLI/MediaSorter.UI.CLI.csproj -- $(ARGS)