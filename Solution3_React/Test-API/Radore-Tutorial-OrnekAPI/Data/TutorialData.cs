namespace Radore_Tutorial_OrnekAPI.Data
{
    public class TutorialData
    {
        private List<TutorialModel> _tutorials = new List<TutorialModel>
        {
            new TutorialModel { id = 1, title = "Test 1", description = "Test Entry" },
            new TutorialModel { id = 12, title = "functional baslik deneme", description = "functional aciklama deneme" },
            new TutorialModel { id = 15, title = "asdf", description = "asdf" },
            new TutorialModel { id = 17, title = "Deneme", description = "Deneme Desc" },
            new TutorialModel { id = 19, title = "Deneme2", description = "Deneme2 description" },
            new TutorialModel { id = 13, title = "yeni tutorial", description = "yeni tutorial desc" },
            new TutorialModel { id = 2, title = "asdf", description = "sadfsadf" }
        };

        public List<TutorialModel> GetAllTutorials()
        {
            return _tutorials;
        }

        public TutorialModel GetTutorialById(int id)
        {
            return _tutorials.FirstOrDefault(t => t.id == id);
        }
    }
}