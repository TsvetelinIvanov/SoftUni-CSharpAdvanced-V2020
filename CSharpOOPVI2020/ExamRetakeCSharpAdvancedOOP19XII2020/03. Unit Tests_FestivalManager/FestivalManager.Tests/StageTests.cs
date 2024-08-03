// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;//For Judge this must be commented
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class StageTests
    {
        private const string CanNotBeNullExceptionMessage = "Can not be null!";
        private const string YoungPerformerExceptionMessage = "You can only add performers that are at least 18.";
        private const string LittleSongExceptionMessage = "You can only add songs that are longer than 1 minute.";
        private const string NoPerformerExceptionMessage = "There is no performer with this name.";
        private const string NoSongExceptionMessage = "There is no song with this name.";        
        private const string AddedSongSuccessMessage = "{0} will be performed by {1}";
        private const string PlaySongsSuccessMessage = "{0} performers played {1} songs";

        private readonly Song song1 = new Song("Áóðíè Íîùè1", new TimeSpan(0, 1, 30));
        private readonly Song song2 = new Song("Áóðíè Íîùè2", new TimeSpan(0, 2, 30));
        private readonly Song song3 = new Song("Áóðíè Íîùè3", new TimeSpan(0, 3, 30));
        private readonly Song song4 = new Song("Áóðíè Íîùè4", new TimeSpan(0, 0, 30));

        private Performer performer1;
        private Performer performer2; 
        private Performer performer3; 
        private Performer performer4; 

        private Stage stage;

        [SetUp]
        public void Initialization()
        {
            this.performer1 = new Performer("Ivan1", "Ivanov1", 19);
            this.performer2 = new Performer("Ivan2", "Ivanov2", 29);
            this.performer3 = new Performer("Ivan3", "Ivanov3", 39);
            this.performer4 = new Performer("Ivan4", "Ivanov4", 9);

            this.stage = new Stage();
        }

        [Test]
        public void SongInitializeCorrectly()
        {
            Assert.AreEqual("Áóðíè Íîùè1", this.song1.Name);
            Assert.AreEqual(new TimeSpan(0, 1, 30).ToString(), this.song1.Duration.ToString());    
            Assert.AreEqual("Áóðíè Íîùè1 (01:30)", this.song1.ToString());
        }

        [Test]
        public void PerformerInitializeCorrectly()
        {
            Assert.AreEqual("Ivan1 Ivanov1", this.performer1.FullName);
            Assert.AreEqual("Ivan1 Ivanov1", this.performer1.ToString());
            Assert.AreEqual(19, this.performer1.Age);            
        }

        [Test]
        public void InitializationSuccess()
        {
            Assert.IsInstanceOf(typeof(Stage), this.stage);
        }

        [Test]
        public void InitializationWithEmptyPerformers()
        {           
            Assert.AreEqual(0, this.stage.Performers.Count);
        }

        [Test]
        public void InitializationReturnsCorrectlyCollectionPerformers()
        {
            this.stage.AddPerformer(this.performer1);
            this.stage.AddPerformer(this.performer2);
            this.stage.AddPerformer(this.performer3);            

            Assert.AreEqual(3, this.stage.Performers.Count);            
        }

        [Test]
        public void AddPerformerWorksCorrectly()
        {
            this.stage.AddPerformer(this.performer1);
            this.stage.AddPerformer(this.performer2);
            this.stage.AddPerformer(this.performer3);

            Assert.AreEqual(3, this.stage.Performers.Count);
            Assert.IsTrue(this.stage.Performers.Contains(this.performer1));
            Assert.IsTrue(this.stage.Performers.Contains(this.performer2));
            Assert.IsTrue(this.stage.Performers.Contains(this.performer3));
        }

        [Test]
        public void AddPerformerThrowsIfNull()
        {
            Assert.That(() => this.stage.AddPerformer(null), Throws.ArgumentNullException);
        }

        [Test]
        public void AddPerformerThrowsIfYoungPerformer()
        {
            Assert.That(() => this.stage.AddPerformer(this.performer4), Throws.ArgumentException.With.Message.EqualTo(YoungPerformerExceptionMessage));
        }

        [Test]
        public void AddSongNotThrowsIfWorksCorrectly()
        {
            Assert.That(() => this.stage.AddSong(this.song1), Throws.Nothing);
        }

        [Test]
        public void AddSongThrowsIfNull()
        {
            Assert.That(() => this.stage.AddSong(null), Throws.ArgumentNullException);
        }

        [Test]
        public void AddSongThrowsIfLittleSong()
        {
            Assert.That(() => this.stage.AddSong(this.song4), Throws.ArgumentException.With.Message.EqualTo(LittleSongExceptionMessage));
        }

        [Test]
        public void AddSongToPerformerThrowsIfNullSong()
        {
            this.stage.AddPerformer(this.performer1);

            this.stage.AddSong(this.song1);

            Assert.That(() => this.stage.AddSongToPerformer(null, null), Throws.ArgumentNullException);
            Assert.That(() => this.stage.AddSongToPerformer(null, this.performer1.FullName), Throws.ArgumentNullException);
        }

        [Test]
        public void AddSongToPerformerThrowsIfNullPerformer()
        {
            this.stage.AddPerformer(this.performer1);

            this.stage.AddSong(this.song1);

            Assert.That(() => this.stage.AddSongToPerformer(null, null), Throws.ArgumentNullException);
            Assert.That(() => this.stage.AddSongToPerformer(this.song1.Name, null), Throws.ArgumentNullException);
        }

        [Test]
        public void AddSongToPerformerThrowsIfNoSong()
        {
            this.stage.AddPerformer(this.performer1);
            this.stage.AddPerformer(this.performer2);

            this.stage.AddSong(this.song1);
            this.stage.AddSong(this.song2);
            
            Assert.That(() => this.stage.AddSongToPerformer(this.song3.Name, this.performer1.FullName), Throws.ArgumentException.With.Message.EqualTo(NoSongExceptionMessage));
        }

        [Test]
        public void AddSongToPerformerThrowsIfNoPerformer()
        {
            this.stage.AddPerformer(this.performer1);
            this.stage.AddPerformer(this.performer2);

            this.stage.AddSong(this.song1);
            this.stage.AddSong(this.song2);

            Assert.That(() => this.stage.AddSongToPerformer(this.song1.Name, this.performer3.FullName), Throws.ArgumentException.With.Message.EqualTo(NoPerformerExceptionMessage));
        }        

        [Test]
        public void AddSongToPerformerWorksCorectly()
        {
            this.stage.AddPerformer(this.performer1);
            this.stage.AddPerformer(this.performer2);

            this.stage.AddSong(this.song1);
            this.stage.AddSong(this.song2);

            string expectedSuccessMessage =  string.Format(AddedSongSuccessMessage, this.song1.ToString(), this.performer1.ToString());
            string realSuccessMessage =  this.stage.AddSongToPerformer(this.song1.Name, this.performer1.FullName);

            Assert.AreEqual(1, this.performer1.SongList.Count);
            Assert.True(this.performer1.SongList.Contains(this.song1));
            Assert.AreEqual(expectedSuccessMessage, realSuccessMessage);
        }
       
        [Test]
        public void AddSongToPerformerWorksCorectlyForMoreSongs()
        {
            this.stage.AddPerformer(this.performer1);
            this.stage.AddPerformer(this.performer2);
            this.stage.AddPerformer(this.performer3);

            this.stage.AddSong(this.song1);
            this.stage.AddSong(this.song2);
            this.stage.AddSong(this.song3);

            string expectedSuccessMessage1_1 = string.Format(AddedSongSuccessMessage, this.song1.ToString(), this.performer1.ToString());
            string expectedSuccessMessage1_2 = string.Format(AddedSongSuccessMessage, this.song1.ToString(), this.performer2.ToString());
            string expectedSuccessMessage1_3 = string.Format(AddedSongSuccessMessage, this.song1.ToString(), this.performer3.ToString());
            string expectedSuccessMessage2_3 = string.Format(AddedSongSuccessMessage, this.song2.ToString(), this.performer3.ToString());
            string expectedSuccessMessage3_3 = string.Format(AddedSongSuccessMessage, this.song3.ToString(), this.performer3.ToString());
            string realSuccessMessage1_1 = this.stage.AddSongToPerformer(this.song1.Name, this.performer1.FullName);
            string realSuccessMessage1_2 = this.stage.AddSongToPerformer(this.song1.Name, this.performer2.FullName);
            string realSuccessMessage1_3 = this.stage.AddSongToPerformer(this.song1.Name, this.performer3.FullName);
            string realSuccessMessage2_3 = this.stage.AddSongToPerformer(this.song2.Name, this.performer3.FullName);
            string realSuccessMessage3_3 = this.stage.AddSongToPerformer(this.song3.Name, this.performer3.FullName);

            Assert.AreEqual(1, this.performer1.SongList.Count);
            Assert.AreEqual(1, this.performer2.SongList.Count);
            Assert.AreEqual(3, this.performer3.SongList.Count);

            Assert.True(this.performer1.SongList.Contains(this.song1));
            Assert.True(this.performer2.SongList.Contains(this.song1));
            Assert.True(this.performer3.SongList.Contains(this.song1));
            Assert.True(this.performer3.SongList.Contains(this.song2));
            Assert.True(this.performer3.SongList.Contains(this.song3));

            Assert.AreEqual(expectedSuccessMessage1_1, realSuccessMessage1_1);
            Assert.AreEqual(expectedSuccessMessage1_2, realSuccessMessage1_2);
            Assert.AreEqual(expectedSuccessMessage1_3, realSuccessMessage1_3);
            Assert.AreEqual(expectedSuccessMessage2_3, realSuccessMessage2_3);
            Assert.AreEqual(expectedSuccessMessage3_3, realSuccessMessage3_3);
        }
                
        [Test]
        public void PlayWorksCorectlyWith1Performer()
        {
            this.stage.AddPerformer(this.performer1);            

            this.stage.AddSong(this.song1);
            this.stage.AddSong(this.song2);

            string songSuccessMessage = this.stage.AddSongToPerformer(this.song1.Name, this.performer1.FullName);
           


            string expectedSuccessMessage = string.Format(PlaySongsSuccessMessage, 1, 1);
            //string expectedSuccessMessage = "1 performers played 1 songs";
            string realSuccessMessage = this.stage.Play();

            Assert.AreEqual(expectedSuccessMessage, realSuccessMessage);
        }
        
        [Test]
        public void PlayWorksCorectly()
        {
            this.stage.AddPerformer(this.performer1);
            this.stage.AddPerformer(this.performer2);
            this.stage.AddPerformer(this.performer3);

            this.stage.AddSong(this.song1);
            this.stage.AddSong(this.song2);

            string song1SuccessMessage = this.stage.AddSongToPerformer(this.song1.Name, this.performer1.FullName);
            string song2SuccessMessage = this.stage.AddSongToPerformer(this.song2.Name, this.performer2.FullName);


            string expectedSuccessMessage = string.Format(PlaySongsSuccessMessage, 3, 2);
            
            string realSuccessMessage = this.stage.Play();

            Assert.AreEqual(expectedSuccessMessage, realSuccessMessage);
        }
        
        [Test]
        public void PlayWorksCorectlyWithMoreSongs()
        {
            

            this.stage.AddPerformer(this.performer1);
            this.stage.AddPerformer(this.performer2);
            this.stage.AddPerformer(this.performer3);

            this.stage.AddSong(this.song1);
            this.stage.AddSong(this.song2);
            this.stage.AddSong(this.song3);

            string song1_1SuccessMessage = this.stage.AddSongToPerformer(this.song1.Name, this.performer1.FullName);
            string song1_2SuccessMessage = this.stage.AddSongToPerformer(this.song1.Name, this.performer2.FullName);
            string song1_3SuccessMessage = this.stage.AddSongToPerformer(this.song1.Name, this.performer3.FullName);
            string song2_1SuccessMessage = this.stage.AddSongToPerformer(this.song2.Name, this.performer1.FullName);
            string song3_1SuccessMessage = this.stage.AddSongToPerformer(this.song3.Name, this.performer1.FullName);
            string song2_2SuccessMessage = this.stage.AddSongToPerformer(this.song2.Name, this.performer2.FullName);
            string song3_3SuccessMessage = this.stage.AddSongToPerformer(this.song3.Name, this.performer3.FullName);


            string expectedSuccessMessage = string.Format(PlaySongsSuccessMessage, 3, 7);
            
            string realSuccessMessage = this.stage.Play();

            Assert.AreEqual(expectedSuccessMessage, realSuccessMessage);
        }
    }
}
