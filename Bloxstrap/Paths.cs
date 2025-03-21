﻿namespace Hellstrap
{
    static class Paths
    {
        public static string Temp => Path.Combine(Path.GetTempPath(), App.ProjectName);
        public static string UserProfile => Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public static string LocalAppData => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string Desktop => Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public static string WindowsStartMenu => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu), "Programs");
        public static string System => Environment.GetFolderPath(Environment.SpecialFolder.System);
        public static string Process => Environment.ProcessPath!;

        public static string TempUpdates => Path.Combine(Temp, "Updates");
        public static string TempLogs => Path.Combine(Temp, "Logs");
        public static string Base { get; private set; } = string.Empty;
        public static string Downloads { get; private set; } = string.Empty;
        public static string SavedBackups { get; private set; } = string.Empty;
        public static string Logs { get; private set; } = string.Empty;
        public static string Integrations { get; private set; } = string.Empty;
        public static string Versions { get; private set; } = string.Empty;
        public static string Mods { get; private set; } = string.Empty;
        public static string Roblox { get; private set; } = string.Empty;
        public static string CustomThemes { get; private set; } = string.Empty;
        public static string Application { get; private set; } = string.Empty;

        public static string CustomFont => Path.Combine(Mods, "content", "fonts", "CustomFont.ttf");
        public static bool Initialized => !string.IsNullOrWhiteSpace(Base);

        public static void Initialize(string baseDirectory)
        {
            if (string.IsNullOrWhiteSpace(baseDirectory))
                throw new ArgumentException("Base directory cannot be null or empty.", nameof(baseDirectory));

            Base = baseDirectory;
            Downloads = Path.Combine(Base, "Downloads");
            SavedBackups = Path.Combine(Base, "SavedBackups");
            Logs = Path.Combine(Base, "Logs");
            Integrations = Path.Combine(Base, "Integrations");
            Versions = Path.Combine(Base, "RblxVersions");
            Mods = Path.Combine(Base, "Mods");
            CustomThemes = Path.Combine(Base, "CustomThemes");

            Application = Path.Combine(Base, $"{App.ProjectName}.exe");

            EnsureDirectoryExists(Downloads);
            EnsureDirectoryExists(SavedBackups);
            EnsureDirectoryExists(Logs);
            EnsureDirectoryExists(Integrations);
            EnsureDirectoryExists(Versions);
            EnsureDirectoryExists(Mods);
            EnsureDirectoryExists(CustomThemes);
        }

        private static void EnsureDirectoryExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                try
                {
                    Directory.CreateDirectory(directoryPath);
                    Console.WriteLine($"Created missing directory: {directoryPath}");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Failed to create directory {directoryPath}: {ex.Message}");
                }
            }
        }
    }
}
