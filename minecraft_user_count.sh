#set -x
while true
do

     players=`netstat -anp | grep :25565 | grep ESTABLISHED | wc -l`

     # Update the customer ID to your Operations Management Suite workspace ID
     ws="7f1606c3-5241-4d1b-bcdf-a2a9c47492d9"

     # For the shared key, use either the primary or the secondary Connected Sources client authentication key
     key='rXhGXa5xdoaK/IRTo/2YdspdykshIKg4dHdDeo2X1YM2vcYfD8WX0uI31KaiUM4oVTFrO4eXTHCT99z4l0+ppQ=='
     # Name of the log generated
     LogType='MindCraft_Active_Users'

     hostname=`hostname`
     data='{"Hostname":"#hostname#","ActiveUsers":"#count#"}'
     data=${data/#count#/$players}
     data=${data/#hostname#/$hostname}
     echo $data
     timestamp=$(date -u +"%a, %d %b %Y %H:%M:%S GMT")
     # data='{"LinuxCurlId":"001","LinuxCurlValue1":"value1"}'
     stringToSign=$(echo -e "POST\n${#data}\napplication/json\nx-ms-date:${timestamp}\n/api/logs")
     decodedkey=`printf %s "$key" | base64 -d`
     encodedHash=`printf %s "$stringToSign" | openssl dgst -sha256 -binary -hmac "$decodedkey" | sed 's/^.* //' | base64`
     Signature="SharedKey $ws:$encodedHash"
     curl -H "Content-Type:application/json" -d "${data}" "https://${ws}.ods.opinsights.azure.com/api/logs?api-version=2016-04-01" -H "x-ms-date:${timestamp}" -H "Log-Type:${LogType}" -H "Authorization:${Signature}" -v

     sleep 60

done