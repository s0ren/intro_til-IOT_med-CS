using nanoFramework.Networking;
using System;
using System.Device.Wifi;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using nanoFramework.Networking;
using System.Net.NetworkInformation;

Debug.WriteLine("Hello Simple WiFi!");

const string MYSSID = "TEC-IOT";
const string MYPASSWORD = "42090793";

//WifiAdapter wifiadp = WifiAdapter.FindAllAdapters()[0];
WifiAdapter wifiadp = WifiNetworkHelper.WifiAdapter;

//WifiAvailableNetwork net = new WifiAvailableNetwork();

//WifiConnectionResult result = wifiadp.Connect(MYSSID, WifiReconnectionKind.Automatic, MYPASSWORD);
//if (result.ConnectionStatus == WifiConnectionStatus.Success)

bool result = WifiNetworkHelper.ConnectDhcp(MYSSID, MYPASSWORD, requiresDateTime: false, token: CancellationToken.None);
if (result)
{
    Debug.WriteLine("Connected to WiFi network.");

    NetworkInterface nic = NetworkInterface.GetAllNetworkInterfaces()[0];
    Debug.WriteLine($"IP Address: {nic.IPv4Address}");


    //Debug.WriteLine($"NetworkInterface: {wifiadp.NetworkInterface.ToString()}");
    //Debug.WriteLine($"IP Address: {NetworkInterface}");

    //WifiNetworkHelper.WifiAdapter.
    //Debug.WriteLine($"IP Address: {NetworkInterfaceHelper.GetAllNetworkInterfaces()[0].IpAddress}");

    Debug.WriteLine($"System time (before Sntp.Start()): {DateTime.UtcNow}");

    Sntp.Server1 = "1.europe.pool.ntp.org";
    Sntp.Start();
    Debug.WriteLine($"System time: {DateTime.UtcNow}");

    WifiNetworkHelper.Disconnect();
    Debug.WriteLine("Disconnected from WiFi!");
}
else
{
    //Debug.WriteLine($"Failed to connect to WiFi network. Status: {result.ConnectionStatus}");
    Debug.WriteLine($"Failed to connect to WiFi network. Status: {result}");
}


Thread.Sleep(Timeout.Infinite);