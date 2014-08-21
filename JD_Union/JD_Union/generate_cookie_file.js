var cookies = [
  {
    "domain": ".jd.com",
    "expirationDate": 1424180399,
    "hostOnly": false,
    "httpOnly": false,
    "name": "__jda",
    "path": "/",
    "secure": false,
    "session": false,
    "storeId": "0",
    "value": "95931165.1901070492.1408628399.1408628399.1408628399.1",
    "id": 36
  },
  {
    "domain": ".jd.com",
    "expirationDate": 1408630199,
    "hostOnly": false,
    "httpOnly": false,
    "name": "__jdb",
    "path": "/",
    "secure": false,
    "session": false,
    "storeId": "0",
    "value": "95931165.1.1901070492|1.1408628399",
    "id": 37
  },
  {
    "domain": ".jd.com",
    "hostOnly": false,
    "httpOnly": false,
    "name": "__jdc",
    "path": "/",
    "secure": false,
    "session": true,
    "storeId": "0",
    "value": "95931165",
    "id": 38
  },
  {
    "domain": ".jd.com",
    "expirationDate": 1409924399,
    "hostOnly": false,
    "httpOnly": false,
    "name": "__jdv",
    "path": "/",
    "secure": false,
    "session": false,
    "storeId": "0",
    "value": "95931165|direct|-|none|-",
    "id": 39
  },
  {
    "domain": ".jd.com",
    "expirationDate": 1424180694.287593,
    "hostOnly": false,
    "httpOnly": false,
    "name": "__jdu",
    "path": "/",
    "secure": false,
    "session": false,
    "storeId": "0",
    "value": "1901070492",
    "id": 40
  },
  {
    "domain": ".jd.com",
    "expirationDate": 1411220694.396593,
    "hostOnly": false,
    "httpOnly": true,
    "name": "_pst",
    "path": "/",
    "secure": false,
    "session": false,
    "storeId": "0",
    "value": "jd_753d05bde9aca",
    "id": 41
  },
  {
    "domain": ".jd.com",
    "expirationDate": 1411220694.396595,
    "hostOnly": false,
    "httpOnly": false,
    "name": "pin",
    "path": "/",
    "secure": false,
    "session": false,
    "storeId": "0",
    "value": "jd_753d05bde9aca",
    "id": 42
  },
  {
    "domain": ".jd.com",
    "hostOnly": false,
    "httpOnly": false,
    "name": "logining",
    "path": "/",
    "secure": false,
    "session": true,
    "storeId": "0",
    "value": "1",
    "id": 43
  },
  {
    "domain": ".jd.com",
    "expirationDate": 1411220694.396597,
    "hostOnly": false,
    "httpOnly": true,
    "name": "unick",
    "path": "/",
    "secure": false,
    "session": false,
    "storeId": "0",
    "value": "jd_lzkwin",
    "id": 44
  },
  {
    "domain": ".jd.com",
    "hostOnly": false,
    "httpOnly": true,
    "name": "ceshi3.com",
    "path": "/",
    "secure": false,
    "session": true,
    "storeId": "0",
    "value": "1085A217B1BF56E003E85D875056F2D57540EF803D61BE8B9F1A9A0CB1E784A5580A79E130A80223BC3C68DE60A2F45842BC1455454A4D02D13B6A3286DF1ABD85B619E9DD7FA1D0D2DD76CC3D88256B160028C9B2ABCD4DD15CD43806B32C8722111764559359547F2593A9006437FF3986A9B540846ABC037EA22C240E1006F03B5ACEFD8D305DC32591C671AA2B41B65F92C6C8DF3E5301EA481525622937",
    "id": 45
  },
  {
    "domain": ".jd.com",
    "expirationDate": 1411220694.397594,
    "hostOnly": false,
    "httpOnly": false,
    "name": "_tp",
    "path": "/",
    "secure": false,
    "session": false,
    "storeId": "0",
    "value": "GKwlRsuScjjrvd%2Bt9uWewM8cj1JudigZUz2p9GHuQzk%3D",
    "id": 46
  },
  {
    "domain": ".media.jd.com",
    "hostOnly": false,
    "httpOnly": false,
    "name": "master",
    "path": "/",
    "secure": false,
    "session": true,
    "storeId": "0",
    "value": "v",
    "id": 47
  }
];

var str = '';
for (var i = 0; i < cookies.length; i++) {
	var ck = cookies[i];
	for(var key in ck){
		str += key + ':'+ ck[key] + ',';
	}
	str += '\n';
};