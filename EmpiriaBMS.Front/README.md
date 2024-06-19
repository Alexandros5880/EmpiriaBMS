### Git CD/CI
1. When push tag ****-staging*** deploy to azure staging server
2. When push tag ****-prod*** deploy to azure production server

### You can open the app oustide of teams:
`https://localhost:44302/login`

### MicrosoftTeams User:
`using MicrosoftUser = Microsoft.Graph.Models.User;`


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


### Roles -> Permissions Ords:
***Role[ Designer ]*** -----------> ***[ 1, 2, 8 ]***
***Role[ Engineer ]*** -----------> ***[ 1, 2, 3, 8, 9, 10 ]***
***Role[ Project Manager ]*** --> ***[ 1, 2, 4, 8, 9, 10, 17, 22, 23 ]***
***Role[ COO ]*** ---------------> ***[ 1, 2, 3, 4, 5, 8, 9, 10, 11, 31, 32, 32, 34 ]***
***Role[ CTO ]*** ----------------> ***[ 1, 2, 3, 4, 5, 6, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34 ]***
***Role[ CEO ]*** ----------------> ***[ 1, 3, 4, 5, 9, 10, 11, 13, 12, 17, 18, 19, 20, 21, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 32, 34 ]***
***Role[ Guest ]*** --------------> ***[ 1 ]***
***Role[ Customer ]*** ----------> ***[ 1 ]***
***Role[ Admin ]*** -------------> ***[ 7, 9, 10, 11, 28 ]***
***Role[ Engineer SUB ]*** -------------> ***[  ]***