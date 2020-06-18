dotnet ef -s ../../Apps/ApiHost migrations add Initialize -c BloggingContext -o Migrations

dotnet ef -s ../../Apps/ApiHost database update --context BloggingContext

dotnet ef -s ../../Temp/WebEntityFramework migrations add Initialize -c BloggingContext -o Migrations

dotnet ef -s ../../Temp/WebEntityFramework database update --context BloggingContext
