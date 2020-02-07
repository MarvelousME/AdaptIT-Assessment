using App.Data.Models;
using App.Service;
using System;
using System.Collections.Generic;

public class Program
{
    #region Variables
    static SearchKeywordService service = null;

    public static bool resetScreen = false;
    #endregion

    #region Main
    public static void Main(string[] args)
    {
        service = new SearchKeywordService();

        ShowIntialSearchKeywardScreen();

        var searchKeyword = Console.ReadLine();

        if (validateInputIsEmpty(searchKeyword))
        {
            RaiseErrorInConsole("Please enter a search keyword, cannot be blank", ConsoleColor.Red);

            if(resetScreen)
            {
                ReloadScreen();
            }
        }

        PrintOutToScreen(runQuery(searchKeyword));
    }
    #endregion

    #region Helper Methods
    /// <summary>
    /// Method that will run a query against the database based on the search keyward
    /// </summary>
    /// <param name="searchKeyword">search keyward</param>
    /// <returns>result set with the data from the database</returns>
    public static List<SearchKeywordMatch> runQuery(string searchKeyword)
    {
        return service.GetMatchedItems(searchKeyword);
    }
    /// <summary>
    /// Print out the results of the query ran against the database for the search keywards 
    /// the user has entered
    /// </summary>
    /// <param name="result">result set with the data from the databas</param>
    public static void PrintOutToScreen(List<SearchKeywordMatch> result)
    {
        if (result == null || result.Count == 0)
        {
            RaiseErrorInConsole("Sorry, no results for that search", ConsoleColor.Yellow);

            if (resetScreen)
            {
                ReloadScreen();
            }
        }
        else
        {
            DisplaySearchResult(result);

            if (resetScreen)
            {
                ReloadScreen();
            }
        }
    }
    /// <summary>
    /// Method to check user input is valid and not empty
    /// </summary>
    /// <param name="searchKeyword">user input</param>
    /// <returns>false is blank entry</returns>
    private static bool validateInputIsEmpty(string searchKeyword)
    {
        return string.IsNullOrEmpty(searchKeyword);
    }
    /// <summary>
    /// Method will accept a resultSet of type List<SearchKeywordMatch> and display to the screen
    /// </summary>
    /// <param name="result">List<SearchKeywordMatch> collection</param>
    private static void DisplaySearchResult(List<SearchKeywordMatch> result)
    {
        Console.WriteLine("=================================================================");
        Console.WriteLine("                 ==== Matched Item(s) ==== ");
        Console.WriteLine("=================================================================");
        Console.WriteLine(" ");

        foreach (var item in result)
        {
            Console.WriteLine(item.MatchedItem);
        }

        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine("Please press enter to do another search...");

        resetScreen = true;
        Console.ReadLine();
    }
    /// <summary>
    /// Method will reload the screen, clear the console so that the user can do anpther search
    /// </summary>
    private static void ReloadScreen()
    {
        ResetColorInConsole();
        ClearConsole();
        Main(null);
    }
    /// <summary>
    /// Method will display the initial screen the user will interact with to do a search
    /// </summary>
    private static void ShowIntialSearchKeywardScreen()
    {
        Console.WriteLine("=================================================================");
        Console.WriteLine("== Please enter a Search Keyword to return the Matched Item(s) == ");
        Console.WriteLine("=================================================================");
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine("Search Keywords: [u],[u l], [u gr], [r], [r l], [r d]");
        Console.WriteLine("Enter Keyword:");


    }
    /// <summary>
    /// Method will clear the screen 
    /// </summary>
    private static void ClearConsole()
    {
        Console.Clear();
    }
    /// <summary>
    /// Method will display a message in red in the console, a message can passed in as 
    /// a parameter to inform the user
    /// </summary>
    /// <param name="message">Message passed in to display on the screen</param>
    /// <param name="messageColor">Color of the message to display</param>
    private static void RaiseErrorInConsole(string message, ConsoleColor messageColor)
    {
        Console.ForegroundColor = messageColor;
        Console.WriteLine($"{message}");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Please press enter to search again");

        resetScreen = true;
        Console.ReadLine();
    }

    private static void ResetColorInConsole()
    {
        Console.ResetColor();
    }
    #endregion
}
