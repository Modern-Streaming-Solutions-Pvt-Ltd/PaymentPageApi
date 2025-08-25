#C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe -Command {Import-Module WebAdministration; Set-ItemProperty 'IIS:\sites\Default Web Site' -Name physicalPath -Value C:\inetpub\wwwroot}
#C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe -Command {Import-Module IISAdministration; Stop-WebSite 'devconsole'} 
#Import-Module IISAdministration
#Stop-WebSite 'devconsole'
echo y | C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe Stop-IISSite -Name "planofferapi.watcho.com"
C:\Windows\System32\inetsrv\appcmd.exe recycle apppool planofferapi.watcho.com