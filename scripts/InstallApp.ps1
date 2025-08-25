#sl C:\Domains\EmptyProject\
# Restore the nuget references
#& "C:\Program Files\dotnet\dotnet.exe" restore
# Publish application with all of its dependencies and runtime for IIS to use
#& "C:\Program Files\dotnet\dotnet.exe" publish --configuration release -o C:\Domains\EmptyProject\publish
# Point IIS wwwroot of the published folder. CodeDeploy uses 32 bit version of PowerShell.
# To make use the IIS PowerShell CmdLets we need call the 64 bit version of PowerShell.
#C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe -Command {Import-Module WebAdministration; Set-ItemProperty 'IIS:\sites\Default Web Site' -Name physicalPath -Value C:\Domains\EmptyProject\publish}
#Import-Module IISAdministration
#Stop-WebSite 'devconsole'
C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe Start-IISSite -Name "planofferapi.watcho.com"