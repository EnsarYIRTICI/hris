dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=hrisdb;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;"
dotnet user-secrets set "JWT_SECRET" "YOUR_SECRET_KEY"
dotnet user-secrets set "TokenLifetimeInDays" "1"