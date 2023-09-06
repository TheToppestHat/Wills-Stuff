/* Made by Joey Whitmire, 9/6/2023
 * For Mr. Rochelle's 2910 Class
 * Assignment 1
 */

using Assignment1_CSCI_2910;
using System.Xml.Schema;

char directorySep = Path.DirectorySeparatorChar;

//Locates the file used in the assignment
string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
string filePath = projectFolder + Path.DirectorySeparatorChar + "videogames.csv";
List<VideoGames> myVideoGames = new List<VideoGames>();

//Opens the reader for the file and makes the data viable
using (StreamReader reader = new StreamReader(filePath))
{
    reader.ReadLine();

    while (!reader.EndOfStream)
    {
        string currentgame = reader.ReadLine();
        string[] internaldata = currentgame.Split(','); 
        VideoGames nextgame = new VideoGames(internaldata[0], internaldata[1], Convert.ToInt32(internaldata[2]), internaldata[3], internaldata[4], Convert.ToDouble(internaldata[5]), Convert.ToDouble(internaldata[6]), Convert.ToDouble(internaldata[7]), Convert.ToDouble(internaldata[8]), Convert.ToDouble(internaldata[9]));
        myVideoGames.Add(nextgame);
    }

    reader.Close();
}

//Sorts the list of games
myVideoGames.Sort();


//Creates the publisher list without user input
var publish = myVideoGames.Where(p => p.Publisher == "Nintendo");
foreach (var p in publish) Console.WriteLine(p);

double totalGameCount = myVideoGames.Count();
double totalpublishCount = publish.Count();

Console.Write($"\n\nOut of {totalGameCount} games, {totalpublishCount} are developed by Nintendo, which is {Math.Round((totalpublishCount/totalGameCount)*100, 2)}%");



//Creates the genre list without user input
var genre = myVideoGames.Where(g => g.Genre == "Shooter");
foreach (var g in genre) Console.WriteLine(g);

double totalGenreCount =  genre.Count();
Console.Write($"\n\nOut of {totalGameCount} games, {totalGenreCount} are developed as a Shooter, which is {Math.Round((totalGenreCount / totalGameCount) * 100, 2)}%");


PublisherData(myVideoGames);

//Method to use user input to find games
static void PublisherData(List<VideoGames> myVideoGames)
{
    Console.Write("\n\n\nWhat is the publisher you want to use?  ");
    var input = Console.ReadLine();

    List<VideoGames> Publishlist = new List<VideoGames>();

    foreach(var video in myVideoGames)
    {
        if (video.Publisher.ToUpper() == input.ToUpper())
        {
            Publishlist.Add(video);
        }
    }

    double totalPublishCount = Publishlist.Count();
    double totalCount = myVideoGames.Count();

    foreach(var video in  Publishlist)
    {
        Console.WriteLine(video);
    }

    Console.Write($"\n\nOut of {totalCount} games, {totalPublishCount} are developed by {input}, which is {Math.Round(totalPublishCount/totalCount * 100, 2)}%");

}

GenreData(myVideoGames);


//Method used to find user inputted genre and display results
static void GenreData(List<VideoGames> myVideoGames)
{
    Console.Write("\n\n\nWhat is the genre of games you want to see?  ");
    var input = Console.ReadLine();

    List<VideoGames> Genrelist = new List<VideoGames>();

    foreach (var video in myVideoGames)
    {
        if (video.Genre.ToUpper() == input.ToUpper())
        {
            Genrelist.Add(video);
        }
    }

    double totalGenreCount = Genrelist.Count();
    double totalCount = myVideoGames.Count();

    foreach (var video in Genrelist)
    {
        Console.WriteLine(video);
    }

    Console.Write($"\n\nOut of {totalCount} games, {totalGenreCount} are developed by {input}, which is {Math.Round(totalGenreCount / totalCount * 100, 2)}%");

}