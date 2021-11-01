#JustEmuTarkov MP

server.json - modify your \Server JET 1.1.0\user\configs\server.json as shown in server.json. Replace backend address with machine hosting JET server IP address.


This is lazy fix but helps for faster client loading right now.
\Server JET 1.1.0\src\response\mode.offline.js - change serverConfig.offline line to serverConfig.online

exports.execute = (url, info, sessionID) => {
	return response_f.noBody(
		serverConfig.online
	);
}

Modify \Server JET 1.1.0\src\classes\match.js - getMatch function, replace loopback IP 127.0.0.1 with EFT_Server IP - defined in ServerInstance.cs public const string UDPServerAddress = "192.168.100.18";

getMatch(location) {
	return {"id": "TEST", "ip": "127.0.0.1", "port": 5000};
}