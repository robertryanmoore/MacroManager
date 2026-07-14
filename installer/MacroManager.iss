#define MyAppName "MacroManager"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Robert Moore"
#define MyAppExeName "MacroManager.exe"
#define MyPublishDir "..\MacroManager\bin\Release\net8.0-windows\win-x64\publish"

[Setup]
; Keep this GUID stable across releases so Windows treats upgrades as upgrades, not side-by-side installs.
AppId={{7C2B9C2C-6B7B-4C8A-9A9C-6D1A6E9F5B31}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
UninstallDisplayIcon={app}\{#MyAppExeName}
OutputDir=Output
OutputBaseFilename=MacroManagerSetup
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
SetupIconFile=..\MacroManager\app.ico
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "Create a &desktop shortcut"; GroupDescription: "Additional shortcuts:"; Flags: unchecked
Name: "startupicon"; Description: "&Launch MacroManager when Windows starts"; GroupDescription: "Additional shortcuts:"; Flags: unchecked

[Files]
Source: "{#MyPublishDir}\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MyPublishDir}\songs.json"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist
Source: "{#MyPublishDir}\*.config"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\Uninstall {#MyAppName}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userstartup}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: startupicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "Launch {#MyAppName} now"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
; Remove the per-user JSON/settings state MacroManager writes at runtime so a reinstall starts clean.
Type: filesandordirs; Name: "{localappdata}\{#MyAppName}"
