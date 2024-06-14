docker build -t dns-test-alpine -f alpine.Dockerfile .
docker build -t dns-test-debian -f debian.Dockerfile .

docker run --rm dns-test-alpine
docker run --rm dns-test-debian