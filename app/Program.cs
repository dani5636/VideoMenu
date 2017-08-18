using System;
using System.Collections.Generic;
using System.Dynamic;
using static System.Console;

namespace app
{
    class Program
    {
        private static int _id = 0;
        private static List<Video> Videos = new List<Video>();
        static void Main(string[] args)
        {
            #region Filling Video List

            Videos.Add(new Video()
            {
                Id = ++_id,
                Genre = "Horror",
                Name = "The Ring"
            });
            Videos.Add(new Video()
            {
                Id = ++_id,
                Genre = "Comedy",
                Name = "Dr. Doolittle"
            });
            Videos.Add(new Video()
            {
                Id = ++_id,
                Genre = "Action",
                Name = "Spider Man: Homecoming"
            });
            
            #endregion

            #region Menu Items
            string[] menuItems =
            {
                "Create video",
                "List videos",
                "Update video",
                "Delete video",
                "Search video",
                "Exit"
            };
            #endregion

            #region Menu Switch
            var selection = ShowMenu(menuItems);
            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        CreateVideo();
                        break;
                    case 2:
                        ListAllVideos();
                        break;
                    case 3:
                        UpdateVideo();
                        break;
                    case 4:
                        DeleteVideo();
                        break;
                    case 5:
                        WriteLine("\nSearch video");
                        WriteLine("What would you like to find?");
                        break;
                }
                WriteLine("Press Enter to go back to the menu");
                ReadLine();
                selection = ShowMenu(menuItems);


            }
            #endregion
            WriteLine("\nBye!");
            ReadLine();

        }

        private static void DeleteVideo()
        {
            WriteLine("Which Video would you like to delete? (ID)");
            var video = FindVideoById();
            Videos.Remove(video);
        }

        private static void UpdateVideo()
        {
            WriteLine("Which Video would you like to update? (ID)");
            var video = FindVideoById();

            if (video != null) { 
            WriteLine("You are updating the following video:");
            WriteLine($"Genre: {video.Genre} |Name: {video.Name}");
            WriteLine("Genre: ");
            var genre = ReadLine();

            WriteLine("Name: ");
            var name = ReadLine();

            WriteLine("You have inputted the following info:");
            WriteLine($"Genre: {genre} |Name: {name}");
                if (ConfirmInfo())
                {
                    video.Genre = genre;
                    video.Name = name;
                    WriteLine("Video has been updated");
                }
                else
                {
                    WriteLine("The video was not updated");
                }
            }
        }

        private static bool ConfirmInfo()
        {
            WriteLine("is this info correct? (Y/N)");
            string accept = ReadLine().ToLower();
            while (!accept.Equals("y") && !accept.Equals("n"))
            {
                WriteLine("Input Y for yes or N for no if the information is right or wrong");

            }
            if (accept.Equals("y"))
            {
                return true;
            }
            
                return false;
        }

        private static Video FindVideoById()
        {
            WriteLine("Enter Q to go back to the menu");
            Video video = null;
            while (video == null)
            {
                int idSearch;
                string input = ReadLine();

                if (int.TryParse(input, out idSearch))
                {
                    foreach (var vid in Videos)
                    {
                        if (vid.Id == idSearch)
                        {
                            return vid;
                           
                        }
                    }
                }
                else if (input.ToLower().Equals("q"))
                {
                    break;
                }
                else
                {
                    Write("You have to input the id");
                }


            }
            return null;
        }

        private static void CreateVideo()
        {
            WriteLine("Genre: ");
            var genre = ReadLine();

            WriteLine("Name: ");
            var name = ReadLine();

            WriteLine("You have inputted the following info:");
            WriteLine($"Genre: {genre} |Name: {name}");

            if (ConfirmInfo())
            {
                Videos.Add(new Video()
                {
                    Id = ++_id,
                    Genre = genre,
                    Name = name
                });
                WriteLine("Video is now in information");
            }
            else
            {
                WriteLine("The video was not added");
            }
        }

        private static void ListAllVideos()
        {
            foreach (var video in Videos)
            {
                WriteLine($"ID: {video.Id} |Genre: {video.Genre} |Name: {video.Name}"); 
            }
        }

        private static int ShowMenu(string[] menuItems)
        {
            Clear();
            WriteLine("Select what you want to do: \n");

            for (int i = 0; i < menuItems.Length; i++)
            {
               WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1
                   || selection > 6
            )
            {
               WriteLine("You need to select a number between 1 and 6");
            }

            return selection;
        }
    }

}
