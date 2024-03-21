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
***12*** -> ***Dashboard Add Project***
***13*** -> ***Display Projects Code***


### Roles -> Permissions Ords:
***Role[ Designer ]*** -----------> ***[ 1, 2, 8 ]***
***Role[ Engineer ]*** -----------> ***[ 1, 2, 3, 8, 9, 10 ]***
***Role[ Project Manager ]*** --> ***[ 1, 2, 4, 8, 9, 10 ]***
***Role[ COO ]*** ---------------> ***[ 1, 2, 3, 4, 5, 8, 9, 10, 11 ]***
***Role[ CTO ]*** ----------------> ***[ 1, 2, 3, 4, 5, 6, 8, 9, 10, 11, 12 ]***
***Role[ CEO ]*** ----------------> ***[ 1, 3, 4, 5, 9, 10, 11, 3 ]***
***Role[ Guest ]*** --------------> ***[ 1 ]***
***Role[ Customer ]*** ----------> ***[ 1 ]***
***Role[ Admin ]*** -------------> ***[ 7, 9, 10, 11 ]***