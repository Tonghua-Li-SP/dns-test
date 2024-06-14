using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

var scriptResult = RunScript(
    "echo '1.2.3.4    a.local' >> /etc/hosts",
    "echo '5.6.7.8    b.local' >> /etc/hosts"
    );

Test("a.local");
Test("b.local");

Test("A.local");
Test("B.local");

void Test(string sqlServerHostname){
    Console.WriteLine("-----------");
    try{
        Console.WriteLine("dns lookup: " + sqlServerHostname);
        var ip = System.Net.Dns.GetHostAddresses(sqlServerHostname).First().ToString();
        Console.WriteLine("dns lookup completed, ip: " + ip);
    }
    catch(Exception e){
        Console.WriteLine(e);
    }
    
}


string RunScript(params string[] cmds)
{
    var processStartInfo = new ProcessStartInfo
    {
        FileName = "/bin/sh",
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        UseShellExecute = false,
        CreateNoWindow = true,
    };

    var process = new Process
    {
        StartInfo = processStartInfo,
    };

    process.Start();

    using (var sw = process.StandardInput)
    {
        if (sw.BaseStream.CanWrite)
        {
            foreach (var s in cmds)
            {
                sw.WriteLine(s);
            }
        }
    }


    process.WaitForExit();
    var result = process.StandardOutput.ReadToEnd();
    return result;
}