This repo is for testing batch calls under .net core odata 8

Current problem is: when call ../odata/$batch i am getting a 405 error ... and response headers look like such
```
HTTP/1.1 405 Method Not Allowed
Content-Length: 0
Date: Mon, 20 May 2024 22:51:49 GMT
Server: Kestrel
Access-Control-Allow-Origin: *
Allow: GET
```

sample postman curl:
```
curl --location 'http://localhost:5021/odata/$batch' \
--header 'Content-Type: application/json' \
--header 'Accept: application/json' \
--data '{
  "requests": [
    {
      "id": "json-batch-test-get-features-1",
      "method": "GET",
      "url": "http://localhost:5021/odata/Features",
      "headers": {
        "content-type": "application/json; odata.metadata=minimal; odata.streaming=true",
        "odata-version": "4.0"
      }
    }
  ]
}'
```
