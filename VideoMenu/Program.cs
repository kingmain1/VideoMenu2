using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using VideoMenuBLL;
using VideoMenuBLL.BusinessObjects;



namespace VideoMenu
{
    class Program
    {
        
        static BLLFacade bllFacade = new BLLFacade();

        static void Main(string[] args)
        {           
            var vid1 = new VideosBO()
            {
                Titel = "DeathStork",
                Director = "Jens Nissen",
                Playtime = "2"
            };
            bllFacade.VideoService.Create(vid1);

            bllFacade.VideoService.Create(new VideosBO()
            {
                Titel = "King Kong",
                Director = "Huggo Borge",
                Playtime = "2.5"
            });

            string[] menuItems = {
                "List All Videos",
                "Add Video",
                "Delete Video",
                "Edit Video",
                "Exit"
            };



            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        ListVideos();
                        break;
                    case 2:
                        AddVideo();
                        break;
                    case 3:
                        DeleteVideo();
                        break;
                    case 4:
                        EditVideo();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye!");

            Console.ReadLine();
        }

        private static void EditVideo()
        {
            var vid = FindVideoById();
            if (vid != null)
            {
                Console.WriteLine("Titel: ");
                vid.Titel = Console.ReadLine();
                Console.WriteLine("Director: ");
                vid.Director = Console.ReadLine();
                Console.WriteLine("Playtime: ");
                vid.Playtime = Console.ReadLine();

                bllFacade.VideoService.Update(vid);
            }
            else
            {
                Console.WriteLine("Video not found");
            }
        }

        private static VideosBO FindVideoById()
        {
            Console.WriteLine("Insert Video Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return bllFacade.VideoService.Get(id);
        }

        private static void DeleteVideo()
        {

            var VideoFound = FindVideoById();
            if (VideoFound != null)
            {
                bllFacade.VideoService.Delete(VideoFound.Id);
                Console.WriteLine("Video Deletet");
            }
            else
            {
                Console.WriteLine("Video not found");
            }

        }

        private static void AddVideo()
        {
            Console.WriteLine("Titel: ");
            var titel = Console.ReadLine();

            Console.WriteLine("Director: ");
            var director = Console.ReadLine();

            Console.WriteLine("Playtime: ");
            var playtime = Console.ReadLine();
            bllFacade.VideoService.Create(new VideosBO()
            {
                Titel = titel,
                Director = director,
                Playtime = playtime
            });

        }



        private static void ListVideos()
        {
            Console.WriteLine("\nList of Videos");
            foreach (var video in bllFacade.VideoService.Getall())
            {
                Console.WriteLine($"Id: {video.Id} Titel: {video.Titel} " +
                                  $"Director: {video.Director} " +
                                  $"Playtime: {video.Playtime} hours");
            }
            Console.WriteLine("\n");

        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select What you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1
                   || selection > 5)
            {
                Console.WriteLine("Please select a number between 1-5");
            }

            return selection;
        }
    }
}