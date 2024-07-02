### Git CD/CI
1. When push tag ****-staging*** deploy to azure staging server
2. When push tag ****-prod*** deploy to azure production server

### You can open the app oustide of teams:
`https://localhost:44302/login`

### MicrosoftTeams User:
`using MicrosoftUser = Microsoft.Graph.Models.User;`

### Run Seed Data Ceator:
``dotnet run --project  EmpiriaBMS.EF.CLI/EmpiriaBMS.EF.CLI.csproj -- seed``

### Run CI GitHub WorkFlow:
``make ci -i``

### Microsoft 365 Admin User:
1. Create an admin user.
2. Add licences and apps -> Microsoft 365 Business Basc -> Apps Select All.
3. Add licences and apps -> Microsoft Power Automate Free.

### MicrosoftTeams Admin Center:
1. Teams apps -> Permission policies -> Add **Allow-All-Apps**


### Create SSL Certificate:
1. Open PowerShell With Admin Permissions.
2. Press New-SelfSignedCertificate -Subject "CN=EmbiriaBMS-Staging" -CertStoreLocation "cert:\LocalMachine\My".
3. Add to appsettings.json:
```
"Key": {
    "Type": "Store",
    "StoreName": "My",
    "StoreLocation": "CurrentUser",
    "Name": "CN=EmbiriaBMS-Staging"
  }
```
4. Press Windows Key On Keyboard.
5. Type Manage Computer Certificates and press Enter.
6. Go to Personal (on the left), then Certificates.
7. Double-click on the certificate you created.
8. Go to Details.
9. Press the button “Copy to File …”.
10. Click Next.
11. Click on “Yes, export the private key”, then Next.
12. Click Next.
13. Click on Password, and enter a password (write down the password, we will need it).
14. In Encryption, select TripleDESH-SHA1, click Next.
15. Select where you want to export your certificate, next and Finish.

### Uploading the Certificate to Azure:
1. Go to your Azure App Service.
2. Go to TLS / SSL settings.
3. Click on Private Key Certificates (.pfx).
4. Click on Upload Certificate.
5. Select the pfx file you created.
6. Insert the password that we used in the previous section.
7. Click on Upload.

### Create an app int MicrosoftTeams Dev Portal:
1. Ceate an app example EmbiriaBMS-Production.
2. Downlowd manifest.json.
3. Rename to manifest.prod.json.
4. Update Imfo like azure portal Application (Client Id) et cetera.

### Ord -> Permisions:
***1*** -> ***See Dashboard Layout***
***2*** -> ***Dashboard Edit My Hours***
***3*** -> ***Dashboard Assign Designer***
***4*** -> ***Dashboard Assign Engineer***
***5*** -> ***Dashboard Assign Project Manager***
***6*** -> ***Dashboard Add Project***
***7*** -> ***See Admin Layout***
***8*** -> ***Dashboard See My Hours***
***9*** -> ***See All Disciplines***
***10*** -> ***See All Drawings***
***11*** -> ***See All Projects***
***12*** -> ***Dashboard Edit Project***
***13*** -> ***Display Projects Code***
***14*** -> ***Dashboard Edit Discipline***
***15*** -> ***Dashboard Edit Deliverable***
***16*** -> ***Dashboard Edit Other***
***17*** -> ***Dashboard See KPIS***
***18*** -> ***See Hours Per Role KPI***
***19*** -> ***See Active Delayed Projects KPI***
***20*** -> ***See All Projects Missed DeadLine KPI***
***21*** -> ***See Employee Turnover KPI***
***22*** -> ***See My Projects Missed DeadLine KPI***
***23*** -> ***See Active Delayed Project Types Counter KPI***
***24*** -> ***See Offers***
***25*** -> ***See Tender Table KPI***
***26*** -> ***See Delayed Payments KPI***
***27*** -> ***See Pendings Payments KPI***
***28*** -> ***See Teams Requested Users***
***29*** -> ***See Invoices***
***30*** -> ***See Excpences***
***31*** -> ***Work on Project***
***32*** -> ***Work on Offers***
***33*** -> ***Work on Leds***
***34*** -> ***See Next Year Income***
***35*** -> ***Backup Database***
***36*** -> ***Restore Database***
***37*** -> ***Can Change Everybody Hours***


### Roles -> Permissions Ords:
***Role[ Designer ]*** -----------> ***[ 1, 2, 8 ]***
***Role[ Engineer ]*** -----------> ***[ 1, 2, 3, 8, 9, 10 ]***
***Role[ Project Manager ]*** --> ***[ 1, 2, 4, 8, 9, 10, 17, 22, 23 ]***
***Role[ COO ]*** ---------------> ***[ 1, 2, 3, 4, 5, 8, 9, 10, 11, 31, 32, 32, 34 ]***
***Role[ CTO ]*** ----------------> ***[ 1, 2, 3, 4, 5, 6, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36,37 ]***
***Role[ CEO ]*** ----------------> ***[ 1, 3, 4, 5, 9, 10, 11, 13, 12, 17, 18, 19, 20, 21, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 32, 34, 35, 36, 37 ]***
***Role[ Guest ]*** --------------> ***[ 1 ]***
***Role[ Customer ]*** ----------> ***[ 1 ]***
***Role[ Admin ]*** -------------> ***[ 7, 9, 10, 11, 28, 35, 36, 37 ]***
***Role[ Engineer SUB ]*** -------------> ***[  ]***