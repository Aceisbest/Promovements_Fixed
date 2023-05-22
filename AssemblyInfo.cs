using MelonLoader;

[assembly: System.Reflection.AssemblyTitle(ClientsInfo.Description)]
[assembly: System.Reflection.AssemblyDescription(ClientsInfo.Description)]
[assembly: System.Reflection.AssemblyCompany(ClientsInfo.Company)]
[assembly: System.Reflection.AssemblyProduct(ClientsInfo.Name)]
[assembly: System.Reflection.AssemblyCopyright(ClientsInfo.Author)]
[assembly: System.Reflection.AssemblyTrademark(ClientsInfo.Company)]
[assembly: System.Reflection.AssemblyVersion(ClientsInfo.Version)]
[assembly: System.Reflection.AssemblyFileVersion(ClientsInfo.Version)]
[assembly: MelonLoader.MelonInfo(typeof(Promovements_Fixed.Main), ClientsInfo.Name, ClientsInfo.Version, ClientsInfo.Author, ClientsInfo.DownloadLink)]

[assembly: MelonColor(System.ConsoleColor.DarkRed)]
[assembly: MelonLoader.MelonGame("VRChat")]

public static class ClientsInfo
    {
    public const string Name = "Promovements";
    public const string Description = "light mod<e";
    public const string Author = "Fixed by Ace made by EdenFails";
    public const string Company = "KARMA.Inc";
    public const string Version = "1.0.0";
    public const string DownloadLink = " ";
    }