Follow these steps:
1.  => Control Panel 
	=> Programs
	=> Turn Windows features on or off
 	=> Internet Information Service
 	=> World Wide Web Services
 	=> Check all options under "Application Development Features" and "Common HTTP Features"

2. Open IIS, right click the root of left tree menu, click "Add Web Site". Set physical 	path to project root folder.

3. Right click above web site, click "Add Application". Give it a name. Set physical path to the proxy folder. 

4. Set MIME Types. Select the web site, open "MIME Types", click "Add..." button on the right region. Add extension ".json" as MIME type "application/json".

5. In config.js file, set serverUrl = 'http://yourpc:(port)/(proxyname)/';
	for example: 
	var serverUrl = 'http://szpc1488.morningstar.com:8999/aaproxy/';

6. You can specify user acount and remote serve in Web.config file located in proxy folder. Just edit appSettings node.
  <appSettings>
    <add key="email" value="your-email"/>
    <add key="password" value="your-password"/>
    <add key="remoteUrl" value="https://assetallocationstg.morningstar.com/assetallocation/"/>
  </appSettings>

Done. Enjoy it.