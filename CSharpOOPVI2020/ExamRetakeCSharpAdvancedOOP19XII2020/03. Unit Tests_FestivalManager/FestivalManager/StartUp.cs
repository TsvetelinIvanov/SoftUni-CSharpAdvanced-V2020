namespace FestivalManager
{	
	using Entities;
	using System;

	public static class StartUp
	{
		public static void Main(string[] args)
		{
			//example usage of the Stage class
			Song song1 = new Song("Ветрове", new TimeSpan(0,3,30));
			Song song2 = new Song("Бурни Нощи", new TimeSpan(0, 2, 30));
			Song song3 = new Song("Ветрове и Бурни Нощи", new TimeSpan(0, 2, 30));

			Performer performer1 = new Performer("Ivan", "Ivanov", 19);
			Performer performer2 = new Performer("Ivanko", "Ivanov", 19);
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
