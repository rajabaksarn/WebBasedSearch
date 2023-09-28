# WebBased-SearchApp-CodingAssignment
Web based search application .


-I have done Basic Features as well as some advanced feature such as Faceting and Stemming.

Basic Features: 🌱

1.For test data, use the included movies.csv file.

2.The website should load and index the test data. 

3.The app should allow the user to enter keywords and find your indexed content.

4.Your app should also feature a responsive design to ensure it renders well for a variety of screen sizes and resolutions.

Advanced Features:

1.Faceting - Provide faceting options for the user to filter by (for example, the ability to search by the date when the film was released).
2.Stemming - when searching for “engineer”, the search should also return results for “engineering”, “engineers”, and “engineered”.
 

***Run the Application***

1.Go the repository and download the source code and run the code into vs2022.

2.after run the code, type in textbox your keyword you want to search.

3.movies.csv file is In solution only so dont worry about file.




***About Coding***

1.Movies.csv file is kept in FIles folder of wwwroot directory.

2.In Services , the GetData.cs class is wrote for read the csv file and store into Datatable.

3.In HomeController.cs, GetCSVData Action method wrote for once got data in datatable , 
  from Datatable, we get the records one by one and store into propery and Convert this to 
  Json and send to front or render to viewer.
  Also in this, wrote the code for searching and server side pagination with datatable using Linq.

4.1.FilmDetails model class is contain the all movies.csv related propery.
  2.JqueryDatatableParam model class contain the Search realted propery.
  
5.On Index.cshtml page the data is bind to datatable with responsive.
  -In this page wrote some server side pagination using Jqery.
  
  
