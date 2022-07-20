namespace SimpleConsole.AsyncTest
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Flurl.Http;

    public class Tests
    {
        private readonly List<string> _images = new List<string>() {
                "https://uploads.cs2.adultlite.net/imgproxy/jXCijR2s6gZQ21kCHBlIZi8LOjz5d2-VpM-GnUDe_lk/czM6Ly91cGxvYWRzLzJlZjE2OWM0YmJjNzQ3MzViNjZmODQzYjMyZDNkZGM3.jpg",
                "https://uploads.cs2.adultlite.net/imgproxy/rTkSDDKMp_hTBkd-RaD_Gly8UN9iKMgdx92slsXok3U/czM6Ly91cGxvYWRzLzA4ZjFjZDA3ZGUyNjY0YTFkNDg5ZjMwNjJhNmM0NDk2.jpg",
                "https://uploads.cs2.adultlite.net/imgproxy/XDfXnV4Io1HUZJYdUMs092aZ-pI1ltSduS-BZBAYFCM/czM6Ly91cGxvYWRzL2IzOTYzZjUyZWJlYzk4YThmZjMyZGVlNDY1ZGYyMmQ2.jpg",
                "https://uploads.cs2.adultlite.net/imgproxy/2xohOmb3OeVVDOGHMfu-r-6IJ0mQvPQIHhMsiqLbjw4/czM6Ly91cGxvYWRzL2EwYzMwZmI1N2Y4MTE2MGFhNjY5NWMyOWQ4NDlmMzUz.jpg",
                "https://uploads.cs2.adultlite.net/imgproxy/DwR1OwCsXRqu_L64inABQr0cXDlE1f-aPFqJZCze9ms/czM6Ly91cGxvYWRzL2UwNDBjNTY3NmFjMjkxMmJlNzZjNTdhMjdiMWJhNWRj.jpg",
                "https://uploads.cs2.adultlite.net/imgproxy/trOgKpfux57EltusujlDzbCsbdCczjvQX0FkbeZZmX4/czM6Ly91cGxvYWRzL2M3NDkwYTAzODllN2ExNGRmZWNjMjEzOWRmMzdhYTRl.jpg",
                "https://uploads.cs2.adultlite.net/imgproxy/_i2bweMCQwn88vZg3sJAcIqgWJQujwOXT3Cam6uDuTQ/czM6Ly91cGxvYWRzL2Y5NjViMDM0ODI5Mjk1NmE1YjQyNWJjYmY1ZGJmNjE4.jpg",
                "https://uploads.cs2.adultlite.net/imgproxy/_i2bweMCQwn88vZg3sJAcIqgWJQujwOXT3Cam6uDuTQ/czM6Ly91cGxvYWRzL2Y5NjViMDM0ODI5Mjk1NmE1YjQyNWJjYmY1ZGJmNjE4.jpg",
                "https://uploads.cs2.adultlite.net/imgproxy/rTkSDDKMp_hTBkd-RaD_Gly8UN9iKMgdx92slsXok3U/czM6Ly91cGxvYWRzLzA4ZjFjZDA3ZGUyNjY0YTFkNDg5ZjMwNjJhNmM0NDk2.jpg",
                "https://uploads.cs2.adultlite.net/imgproxy/DwR1OwCsXRqu_L64inABQr0cXDlE1f-aPFqJZCze9ms/czM6Ly91cGxvYWRzL2UwNDBjNTY3NmFjMjkxMmJlNzZjNTdhMjdiMWJhNWRj.jpg",
                "https://uploads.cs2.adultlite.net/imgproxy/jXCijR2s6gZQ21kCHBlIZi8LOjz5d2-VpM-GnUDe_lk/czM6Ly91cGxvYWRzLzJlZjE2OWM0YmJjNzQ3MzViNjZmODQzYjMyZDNkZGM3.jpg",
                "https://uploads.cs2.adultlite.net/imgproxy/2xohOmb3OeVVDOGHMfu-r-6IJ0mQvPQIHhMsiqLbjw4/czM6Ly91cGxvYWRzL2EwYzMwZmI1N2Y4MTE2MGFhNjY5NWMyOWQ4NDlmMzUz.jpg",
                "https://uploads.cs2.adultlite.net/imgproxy/trOgKpfux57EltusujlDzbCsbdCczjvQX0FkbeZZmX4/czM6Ly91cGxvYWRzL2M3NDkwYTAzODllN2ExNGRmZWNjMjEzOWRmMzdhYTRl.jpg",
                "https://uploads.cs2.adultlite.net/imgproxy/XDfXnV4Io1HUZJYdUMs092aZ-pI1ltSduS-BZBAYFCM/czM6Ly91cGxvYWRzL2IzOTYzZjUyZWJlYzk4YThmZjMyZGVlNDY1ZGYyMmQ2.jpg"
            };
        
        public void Run1()
        {
            //Thread.Sleep(1000);
            Task.Run(() => LoadImages());           
        }

        public void Run2()
        {
            //Thread.Sleep(1000);
            Task.Run(() => LoadImages2());            
        }

        public async Task LoadImages()
        {
            var timer = new Stopwatch();
            timer.Start();
            
            var tasks = new List<Task>();
            
            _images.ForEach(x =>
            {
                tasks.Add(x.GetBytesAsync());
            });

            await Task.WhenAll(tasks);

            timer.Stop();
            
            Console.WriteLine($"LoadImages done in {timer.Elapsed}");
        }

        public async Task LoadImages2()
        {
            var timer = new Stopwatch();
            timer.Start();
            
            foreach (var i in _images)
            {
                var image = await i.GetBytesAsync();
            }

            timer.Stop();

            Console.WriteLine($"LoadImages2 done in {timer.Elapsed}");
        }
    }
}
