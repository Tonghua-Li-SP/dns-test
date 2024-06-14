```
docker build -t dns-test-alpine -f alpine.Dockerfile .
docker build -t dns-test-debian -f debian.Dockerfile .

docker run --rm dns-test-alpine
docker run --rm dns-test-debian
```

Output from alpine
```
-----------
dns lookup: a.local
dns lookup completed, ip: 1.2.3.4
-----------
dns lookup: b.local
dns lookup completed, ip: 5.6.7.8
-----------
dns lookup: A.local
System.Net.Sockets.SocketException (00000005, 0xFFFDFFFF): Name does not resolve
   at System.Net.Dns.GetHostEntryOrAddressesCore(String hostName, Boolean justAddresses, AddressFamily addressFamily, Nullable`1 startingTimestamp)
   at System.Net.Dns.GetHostAddresses(String hostNameOrAddress, AddressFamily family)
   at Program.<<Main>$>g__Test|0_0(String sqlServerHostname) in /app/Program.cs:line 21
-----------
dns lookup: B.local
System.Net.Sockets.SocketException (00000005, 0xFFFDFFFF): Name does not resolve
   at System.Net.Dns.GetHostEntryOrAddressesCore(String hostName, Boolean justAddresses, AddressFamily addressFamily, Nullable`1 startingTimestamp)
   at System.Net.Dns.GetHostAddresses(String hostNameOrAddress, AddressFamily family)
   at Program.<<Main>$>g__Test|0_0(String sqlServerHostname) in /app/Program.cs:line 21
```

Output from debian
```
-----------
dns lookup: a.local
dns lookup completed, ip: 1.2.3.4
-----------
dns lookup: b.local
dns lookup completed, ip: 5.6.7.8
-----------
dns lookup: A.local
dns lookup completed, ip: 1.2.3.4
-----------
dns lookup: B.local
dns lookup completed, ip: 5.6.7.8
```
