# 1. certificate
# Cần phải thực hiện tạo chứng chỉ bảo mật cho ứng dụng
- Ở môi trường phát triển là windown
dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p <CREDENTIAL_PLACEHOLDER>
# CREDENTIAL_PLACEHOLDER: Thiết lập public key (password) cho chứng chỉ
# [aspnetapp.pfx] Tên file chứng chỉ bảo mật
# Thiết lập trust cho chứng chỉ vừa tạo
dotnet dev-certs https --trust
# 2. Command line thiết lập Certificate cho ứng dụng
dotnet user-secrets -p aspnetapp\aspnetapp.csproj set "Kestrel:Certificates:Development:Password" "<CREDENTIAL_PLACEHOLDER>"

# ===========================================================
Các bước build image docker và push to hub
# 1. Build image
    docker build -t image [ImageName]:[tag] [Dockerfile]
    - ImageName: tên của image docker cần build
    - Tag: Đánh dấu version của image
    - Đường dẫn của Dockerfile
# 2. Tạo repository
    docker tag api-ecommerce:v1 thongnm/api-ecommerce:v1
# 3. Thực hiện push Image đã tạo ở local lên Docker Hub
    docker push thongnm/api-ecommerce:v1
# ===========================================================
# Build docketr Image và Container
    docker-compose up -d
