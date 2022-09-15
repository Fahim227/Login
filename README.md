# Documentation

Steps:
1. Download and Install Node.js "LTS" version from [Click Herek](https://nodejs.org/en/) 
2. Install Angular by writing this command "npm install -g @angular/cli" in terminal or see the documentation [Here](https://angular.io/cli)
3. Now go to "Login/RA.SPCore.Web.UI/ngTable/" location of project file and open terminal, then run ng build, this will build the angular.js project
4. Install Visual Studio IDE
5. Open "SampleProjectCore.sln" file via Visual Studio
6. Then go to "appsettings.json" of "RA.SPCore.Web.API" project inside Visual Studio. And if needed then change the database connectivity by changing the value of ConnectionStrings.DefaultConnection.give server,database,uid,pwd(password) to configure the database
7. To change the Header token go to  "appsettings.json" of "RA.SPCore.Web.UI" project inside Visual Studio. you can see Json formated "header_token" key inside that key another key is "tokenOne" so change "key" and "value" attributes value to change header token.
8."base_url": "https://localhost:7066/" from the same path of step #7 base_url can be changed.
