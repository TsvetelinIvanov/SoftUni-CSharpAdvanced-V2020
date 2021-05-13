namespace FestivalManager
{	
	using Entities;
	using System;

	public static class StartUp
	{
		public static void Main(string[] args)
		{
			//example usage of the Stage class
			var song1 = new Song("Ветрове", new TimeSpan(0,3,30));
			var song2 = new Song("Бурни Нощи", new TimeSpan(0, 2, 30));
			var song3 = new Song("Ветрове и Бурни Нощи", new TimeSpan(0, 2, 30));

			var performer1 = new Performer("Ivan", "Ivanov", 19);
			var performer2 = new Performer("Ivanko", "Ivanov", 19);
			Stage stage = new Stage();

			stage.AddSong(song1);
			stage.AddSong(song2);
			stage.AddSong(song3);
			stage.AddPerformer(performer1);
			stage.AddPerformer(performer2);

			Console.WriteLine(stage.AddSongToPerformer("Ветрове", "Ivan Ivanov"));
			Console.WriteLine(stage.AddSongToPerformer("Ветрове", "Ivanko Ivanov"));
			Console.WriteLine(stage.AddSongToPerformer("Бурни Нощи", "Ivanko Ivanov"));

			Console.WriteLine(stage.Play());
		}
	}
}