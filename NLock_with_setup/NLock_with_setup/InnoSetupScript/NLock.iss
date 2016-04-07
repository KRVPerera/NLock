; Author : KRV
; Date : 2016/03/29

#define MyAppName "NLock"
#define MyAppVersion "1.1"
#define MyAppPublisher "Neurotechnology Lab (Private) Limited"
#define MyAppURL "http://www.neurotechnology.com/"
#define MyAppExeName "NLock.exe"
; Dont change the extention becaue it is a hardcoded value inside NLock application default is ".nlk" and this does not change any configuration
#define MyAppFileAssoc ".nlk"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{E8506827-8C04-4988-B92C-EABA04BF52A6}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
ChangesAssociations = yes
DefaultDirName={pf}\Neurotechnology\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
LicenseFile=..\\NLockFile\Resources\license.txt
OutputDir=.\InnoSetupOut
OutputBaseFilename=NLock-Installer
SetupIconFile=..\NLockFile\Resources\LockControls_322.ico
Compression=lzma
SolidCompression=yes            
ExtraDiskSpaceRequired=2
VersionInfoVersion=1.0
VersionInfoCompany=Neurotechnology
VersionInfoProductName=NLock
VersionInfoProductVersion=1.1
MinVersion=0,5.01

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
; NLock Files
Source: "..\NLockFile\bin\Win32_x86\NLock.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\NLock.exe.config"; DestDir: "{app}"; Flags: ignoreversion
; log4net libraries
Source: "..\NLockFile\bin\Win32_x86\log4net.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\log4net.xml"; DestDir: "{app}"; Flags: ignoreversion
; Neurotec Neorotec. Libraries
Source: "..\NLockFile\bin\Win32_x86\Neurotec.Biometrics.Client.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\Neurotec.Biometrics.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\Neurotec.Biometrics.Gui.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\Neurotec.Devices.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\Neurotec.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\Neurotec.Gui.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\Neurotec.Media.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\Neurotec.Media.Processing.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\LiveMedia.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\NCore.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\NMedia.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\NMediaProc.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\NBiometricClient.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\NBiometrics.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\NDevices.dll"; DestDir: "{app}"; Flags: ignoreversion
; Ndm files
Source: "..\NLockFile\bin\Win32_x86\NdmMedia.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\NdmMedia.ini"; DestDir: "{app}"; Flags: ignoreversion
; Nlicense Files
Source: "..\NLockFile\bin\Win32_x86\Neurotec.Licensing.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\NLicensing.cfg"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\NLicensing.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\Activation\*"; DestDir: "{app}\Activation"; Flags: ignoreversion recursesubdirs createallsubdirs
; Registry icon
Source: "..\NLockFile\Resources\Login_6031.ico*"; DestDir: "{app}\Resources"; Flags: ignoreversion
;Face
Source: "..\NLockFile\bin\Data\Faces.ndf"; DestDir: "{app}\Data"; Flags: ignoreversion
; Installation extra folders
Source: "..\NLockFile\bin\Win32_x86\Cameras\*"; DestDir: "{app}\Cameras"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "..\NLockFile\bin\Win32_x86\libopenblas.dll"; DestDir: "{app}"; Flags: ignoreversion
;msvcp/r files
Source: "..\NLockFile\bin\Win32_x86\msvcp100.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\msvcp110.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\msvcp80.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\msvcp90.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\msvcr100.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\msvcr110.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\msvcr80.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NLockFile\bin\Win32_x86\msvcr90.dll"; DestDir: "{app}"; Flags: ignoreversion


; NOTE: Don't use "Flags: ignoreversion" on any shared system files
Source: "..\NLockFile\Resources\license.txt"; DestDir: "{app}\Docs"; DestName: "license-EN.txt"

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\Resources\Login_6031.ico"
Name: "{group}\{cm:ProgramOnTheWeb,{#MyAppName}}"; Filename: "{#MyAppURL}"; IconFilename: "{app}\Resources\Login_6031.ico"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"; IconFilename: "{app}\Resources\Login_6031.ico"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\Resources\Login_6031.ico"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\Resources\Login_6031.ico"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Registry]
; NOTE: First element on each key try to delete the key and replace so don't change the oreder. If you change order subsequent entries won't show up
;       you can indentify it by key is being created by only one sub value or subkey
; Extention registration
Root: "HKCR"; Subkey: "{#MyAppFileAssoc}"; ValueType: string; ValueData: "{#MyAppName}"; Flags: deletekey uninsdeletekey
Root: "HKCR"; Subkey: "{#MyAppName}"; ValueType: string; ValueData: "Program {#MyAppName}"; Flags: uninsdeletekey deletekey
Root: "HKCR"; Subkey: "{#MyAppName}\DefaultIcon"; ValueType: string; ValueData: "{app}\Resources\Login_6031.ico"
Root: "HKCR"; Subkey: "{#MyAppName}\Shell\open"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\Resources\Login_6031.ico"; Flags: uninsdeletekey preservestringtype deletevalue
Root: "HKCR"; Subkey: "{#MyAppName}\Shell\open\command"; ValueType: string; ValueData: """{app}\{#MyAppExeName}"" -o ""%1"""
; NLock Shell Menu
; NLock menu for .nlk files
Root: "HKCR"; Subkey: "{#MyAppName}\Shell\{#MyAppName}"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\Resources\Login_6031.ico"; Flags: uninsdeletekey preservestringtype deletevalue
Root: "HKCR"; Subkey: "{#MyAppName}\Shell\{#MyAppName}"; ValueType: string; ValueName: "MUIVerb"; ValueData: "{#MyAppName}"; Flags: uninsdeletekey preservestringtype deletevalue
Root: "HKCR"; Subkey: "{#MyAppName}\Shell\{#MyAppName}"; ValueType: string; ValueName: "subcommands"; Flags: uninsdeletekey preservestringtype deletevalue
; NLock menu Lock command
Root: "HKCR"; Subkey: "{#MyAppName}\Shell\{#MyAppName}\Shell\cmd1"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Add to {#MyAppName} list"; Flags: uninsdeletekey preservestringtype deletevalue
Root: "HKCR"; Subkey: "{#MyAppName}\Shell\{#MyAppName}\Shell\cmd1"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\Resources\Login_6031.ico"; Flags: uninsdeletekey preservestringtype deletevalue
Root: "HKCR"; Subkey: "{#MyAppName}\Shell\{#MyAppName}\Shell\cmd1\command"; ValueType: string; ValueData: "{app}\{#MyAppExeName} -a ""%1"""; Flags: uninsdeletekey preservestringtype deletevalue
; NLock menu Unlock to command
Root: "HKCR"; Subkey: "{#MyAppName}\Shell\{#MyAppName}\Shell\cmd2"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Unlock to"; Flags: uninsdeletekey preservestringtype deletevalue
Root: "HKCR"; Subkey: "{#MyAppName}\Shell\{#MyAppName}\Shell\cmd2"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\Resources\Login_6031.ico"; Flags: uninsdeletekey preservestringtype deletevalue
Root: "HKCR"; Subkey: "{#MyAppName}\Shell\{#MyAppName}\Shell\cmd2\command"; ValueType: string; ValueData: "{app}\{#MyAppExeName} -ut ""%1"""; Flags: uninsdeletekey preservestringtype deletevalue
; NLock menu Unlock here command
Root: "HKCR"; Subkey: "{#MyAppName}\Shell\{#MyAppName}\Shell\cmd3"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Unlock here"; Flags: uninsdeletekey preservestringtype deletevalue
Root: "HKCR"; Subkey: "{#MyAppName}\Shell\{#MyAppName}\Shell\cmd3"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\Resources\Login_6031.ico"; Flags: uninsdeletekey preservestringtype deletevalue
Root: "HKCR"; Subkey: "{#MyAppName}\Shell\{#MyAppName}\Shell\cmd3\command"; ValueType: string; ValueData: "{app}\{#MyAppExeName} -uh ""%1"""; Flags: uninsdeletekey preservestringtype deletevalue
; Shell menu NLock - Applies to all files
Root: "HKCR"; Subkey: "*\Shell\{#MyAppName}"; ValueType: string; ValueName: "MUIVerb"; ValueData: "{#MyAppName}"; Flags: preservestringtype deletekey deletevalue uninsdeletekey
Root: "HKCR"; Subkey: "*\Shell\{#MyAppName}"; ValueType: string; ValueName: "AppliesTo"; ValueData: "System.FileExtension:<>{#MyAppFileAssoc}"; Flags: uninsdeletekey preservestringtype deletevalue
Root: "HKCR"; Subkey: "*\Shell\{#MyAppName}"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\Resources\Login_6031.ico"; Flags: uninsdeletekey preservestringtype deletevalue
Root: "HKCR"; Subkey: "*\Shell\{#MyAppName}"; ValueType: string; ValueName: "subcommands"; Flags: uninsdeletekey preservestringtype deletevalue
; Shell menu NLock - Applies to all files - Add to NLock list command
Root: "HKCR"; Subkey: "*\Shell\{#MyAppName}\Shell\cmd1"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Add to {#MyAppName} list"; Flags: preservestringtype deletevalue uninsdeletekey
Root: "HKCR"; Subkey: "*\Shell\{#MyAppName}\Shell\cmd1"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\Resources\Login_6031.ico"; Flags: uninsdeletekey preservestringtype deletevalue
Root: "HKCR"; Subkey: "*\Shell\{#MyAppName}\Shell\cmd1\command"; ValueType: string; ValueData: "{app}\{#MyAppExeName} -a ""%1"""; Flags: uninsdeletekey preservestringtype deletevalue
; Folder Shell Commands
Root: "HKCR"; Subkey: "Directory\Background\Shell\{#MyAppName}"; ValueType: string; ValueName: "subcommands"; Flags: uninsdeletekey preservestringtype deletevalue deletekey
Root: "HKCR"; Subkey: "Directory\Background\Shell\{#MyAppName}"; ValueType: string; ValueName: "MUIVerb"; ValueData: "{#MyAppName}"; Flags: preservestringtype deletevalue uninsdeletekey
Root: "HKCR"; Subkey: "Directory\Background\Shell\{#MyAppName}"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\Resources\Login_6031.ico"; Flags: uninsdeletekey preservestringtype deletevalue
; Lock this folder command
Root: "HKCR"; Subkey: "Directory\Background\Shell\{#MyAppName}\Shell\cmd1"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Lock this folder"; Flags: preservestringtype deletevalue uninsdeletekey
Root: "HKCR"; Subkey: "Directory\Background\Shell\{#MyAppName}\Shell\cmd1"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\Resources\Login_6031.ico"; Flags: uninsdeletekey preservestringtype deletevalue
Root: "HKCR"; Subkey: "Directory\Background\Shell\{#MyAppName}\Shell\cmd1\command"; ValueType: string; ValueData: "{app}\{#MyAppExeName} -D ""%V"""; Flags: uninsdeletekey preservestringtype deletevalue
; Below is a hack to prevent conflict from windows 10 default behavour
Root: "HKCR"; Subkey: "AllFilesystemObjects\Shell\{#MyAppName}"; ValueType: string; ValueName: "MUIVerb"; ValueData: "{#MyAppName}"; Flags: preservestringtype deletekey deletevalue uninsdeletekey
Root: "HKCR"; Subkey: "AllFilesystemObjects\Shell\{#MyAppName}"; ValueType: string; ValueName: "subcommands"; Flags: uninsdeletekey preservestringtype deletevalue
Root: "HKCR"; Subkey: "AllFilesystemObjects\Shell\{#MyAppName}"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\Resources\Login_6031.ico"; Flags: uninsdeletekey preservestringtype deletevalue
Root: "HKCR"; Subkey: "AllFilesystemObjects\Shell\{#MyAppName}"; ValueType: string; ValueName: "AppliesTo"; ValueData: "kind:folder System.FileExtension:<>"".zip"""; Flags: uninsdeletekey preservestringtype deletevalue
; Lock this folder command
Root: "HKCR"; Subkey: "AllFilesystemObjects\Shell\{#MyAppName}\Shell\cmd1"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Lock this folder"; Flags: preservestringtype deletevalue uninsdeletekey
Root: "HKCR"; Subkey: "AllFilesystemObjects\Shell\{#MyAppName}\Shell\cmd1"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\Resources\Login_6031.ico"; Flags: uninsdeletekey preservestringtype deletevalue
Root: "HKCR"; Subkey: "AllFilesystemObjects\Shell\{#MyAppName}\Shell\cmd1\command"; ValueType: string; ValueData: "{app}\{#MyAppExeName} -D ""%V"""; Flags: uninsdeletekey preservestringtype deletevalue

[UninstallDelete]
; delete log files
Type: filesandordirs; Name: "{localappdata}\Neurotechnology\{#MyAppName}"
; delete app folder
Type: filesandordirs; Name: "{app}"

[InstallDelete]
; delete log files
Type: filesandordirs; Name: "{localappdata}\Neurotechnology\{#MyAppName}"

[Messages]
ButtonInstall=&Install NLock


;Install https://code.google.com/archive/p/inno-download-plugin/
#include <idp.iss>
[Code]

// ref http://www.kynosarges.de/DotNetVersion.html
function IsDotNetDetected(version: string; service: cardinal): boolean;
// Indicates whether the specified version and service pack of the .NET Framework is installed.
// version -- Specify one of these strings for the required .NET Framework version:
//    'v1.1'          .NET Framework 1.1
//    'v2.0'          .NET Framework 2.0
//    'v3.0'          .NET Framework 3.0
//    'v3.5'          .NET Framework 3.5
//    'v4\Client'     .NET Framework 4.0 Client Profile
//    'v4\Full'       .NET Framework 4.0 Full Installation
//    'v4.5'          .NET Framework 4.5
//    'v4.5.1'        .NET Framework 4.5.1
//    'v4.5.2'        .NET Framework 4.5.2
//    'v4.6'          .NET Framework 4.6
//    'v4.6.1'        .NET Framework 4.6.1
//
// service -- Specify any non-negative integer for the required service pack level:
//    0               No service packs required
//    1, 2, etc.      Service pack 1, 2, etc. required
var
    key, versionKey: string;
    install, release, serviceCount, versionRelease: cardinal;
    success: boolean;
begin
    versionKey := version;
    versionRelease := 0;

    // .NET 1.1 and 2.0 embed release number in version key
    if version = 'v1.1' then begin
        versionKey := 'v1.1.4322';
    end else if version = 'v2.0' then begin
        versionKey := 'v2.0.50727';
    end

    // .NET 4.5 and newer install as update to .NET 4.0 Full
    else if Pos('v4.', version) = 1 then begin
        versionKey := 'v4\Full';
        case version of
          'v4.5':   versionRelease := 378389;
          'v4.5.1': versionRelease := 378675; // or 378758 on Windows 8 and older
          'v4.5.2': versionRelease := 379893;
          'v4.6':   versionRelease := 393295; // or 393297 on Windows 8.1 and older
          'v4.6.1': versionRelease := 394254; // or 394271 on Windows 8.1 and older
        end;
    end;

    // installation key group for all .NET versions
    key := 'SOFTWARE\Microsoft\NET Framework Setup\NDP\' + versionKey;

    // .NET 3.0 uses value InstallSuccess in subkey Setup
    if Pos('v3.0', version) = 1 then begin
        success := RegQueryDWordValue(HKLM, key + '\Setup', 'InstallSuccess', install);
    end else begin
        success := RegQueryDWordValue(HKLM, key, 'Install', install);
    end;

    // .NET 4.0 and newer use value Servicing instead of SP
    if Pos('v4', version) = 1 then begin
        success := success and RegQueryDWordValue(HKLM, key, 'Servicing', serviceCount);
    end else begin
        success := success and RegQueryDWordValue(HKLM, key, 'SP', serviceCount);
    end;

    // .NET 4.5 and newer use additional value Release
    if versionRelease > 0 then begin
        success := success and RegQueryDWordValue(HKLM, key, 'Release', release);
        success := success and (release >= versionRelease);
    end;

    result := success and (install = 1) and (serviceCount >= service);
end;

// Without IDP Framework download simple message to the user asking to download
//function InitializeSetup(): Boolean;
//begin
//    if not IsDotNetDetected('v4.5.2', 0) then begin
//        MsgBox('NLock requires Microsoft .NET Framework 4.5.'#13#13
//            'Please use Windows Update to install this version,'#13
//            'and then re-run the MyApp setup program.', mbInformation, MB_OK);
//        result := false;
//    end else
//        result := true;
//end;

//             ref https://blogs.msdn.microsoft.com/davidrickard/2015/07/17/installing-net-framework-4-5-automatically-with-inno-setup/
// .NET Framework links : https://msdn.microsoft.com/en-US/library/ee942965%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396#redist
// .NET Framework 4.5  : http://go.microsoft.com/fwlink/?LinkId=225704
// .NET Framework 4.5.1: http://go.microsoft.com/fwlink/?LinkId=322115
// .NET Framework 4.5.2: http://go.microsoft.com/fwlink/?LinkId=397707
procedure InitializeWizard;
begin
    if not IsDotNetDetected('v4.5.2', 0) then 
    begin
        idpAddFile('http://go.microsoft.com/fwlink/?LinkId=397707', ExpandConstant('{tmp}\NetFrameworkInstaller.exe'));
        idpDownloadAfter(wpReady);
    end      
end;

procedure InstallFramework;
var
  StatusText: string;
  ResultCode: Integer;
begin
  StatusText := WizardForm.StatusLabel.Caption;
  WizardForm.StatusLabel.Caption := 'Installing .NET Framework 4.5.2. This might take a few minutes…';
  WizardForm.ProgressGauge.Style := npbstMarquee;
  try
    if not Exec(ExpandConstant('{tmp}\NetFrameworkInstaller.exe'), '/passive /norestart','', SW_SHOW, ewWaitUntilTerminated, ResultCode) then
    begin
      MsgBox('.NET installation failed with code: ' + IntToStr(ResultCode) + '.', mbError, MB_OK);
    end;
  finally
    WizardForm.StatusLabel.Caption := StatusText;
    WizardForm.ProgressGauge.Style := npbstNormal;

    DeleteFile(ExpandConstant('{tmp}\NetFrameworkInstaller.exe'));
  end;
end;
     
procedure CurStepChanged(CurStep: TSetupStep);
begin
  case CurStep of
    ssPostInstall:
      begin
        if not IsDotNetDetected('v4.5.2', 0) then
        begin
          InstallFramework();
        end;
      end;
  end;
end;