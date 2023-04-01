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

# 3. Thực hiện tạo image bằng docker-compose