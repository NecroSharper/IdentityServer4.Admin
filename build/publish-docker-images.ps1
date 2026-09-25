param([string] $version)

Set-Location "../"

# build docker images according to docker-compose
docker-compose -f docker-compose.yml build

# rename images with following tag
docker tag necrosharper-identityserver10-admin necrosharper/identityserver10-admin:$version
docker tag necrosharper-identityserver10-sts-identity necrosharper/identityserver10-sts-identity:$version
docker tag necrosharper-identityserver10-admin-api necrosharper/identityserver10-admin-api:$version

# push to docker hub
docker push necrosharper/identityserver10-admin:$version
docker push necrosharper/identityserver10-admin-api:$version
docker push necrosharper/identityserver10-sts-identity:$version