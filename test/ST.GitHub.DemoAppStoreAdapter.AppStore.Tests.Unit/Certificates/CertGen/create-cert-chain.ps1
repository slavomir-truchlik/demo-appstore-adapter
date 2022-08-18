#list curves
#openssl ecparam -list_curves

#create root CA
openssl ecparam -name prime256v1 -genkey -noout -out root.key
openssl req -new -sha256 -key root.key -out root_cert_request.csr -subj "/C=CZ/OU=personal/O=slavomir-truchlik/CN=SLAVOMIR TRUCHLIK CA ROOT"
openssl x509 -signkey root.key -in root_cert_request.csr -extfile .\v3_ca.ext -req -days 3650 -out root_certificate.pem
openssl x509 -outform der -in .\root_certificate.pem -out root_certificate.cer

#create intermediate
openssl ecparam -name prime256v1 -genkey -noout -out intermediate.key
openssl req -new -sha256 -key intermediate.key -out intermediate_request.csr -subj "/C=CZ/OU=personal-intermediary/O=slavomir-truchlik/CN=SLAVOMIR TRUCHLIK GITHUB CA"
openssl x509 -req -in intermediate_request.csr -extfile .\v3_non_ca.ext -CA root_certificate.pem -CAkey root.key -CAcreateserial -out ca_intermediate.pem -days 3650 -sha256
openssl x509 -outform der -in ca_intermediate.pem -out ca_intermediate.cer 

#create signing 
openssl ecparam -name prime256v1 -genkey -noout -out signing.key
openssl req -new -sha256 -key signing.key -out signing_request.csr -subj "/C=CZ/OU=personal-signing/O=slavomir-truchlik/CN=SLAVOMIR TRUCHLIK SIGNING APPSTORE DEMO"
openssl x509 -req -in signing_request.csr -extfile .\v3_non_ca.ext -CA ca_intermediate.pem -CAkey intermediate.key -CAcreateserial -out signing.pem -days 3650 -sha256
openssl x509 -outform der -in signing.pem -out signing.cer 

#read certificates
openssl x509 -text -noout -in .\root_certificate.pem
openssl x509 -text -noout -in .\ca_intermediate.pem
openssl x509 -text -noout -in .\signing.pem

#verify chain
openssl verify -CAfile .\root_certificate.pem -untrusted .\ca_intermediate.pem .\signing.pem