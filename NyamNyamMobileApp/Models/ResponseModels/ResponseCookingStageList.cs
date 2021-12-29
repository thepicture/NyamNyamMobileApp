namespace NyamNyamMobileApp.Models.ResponseModels
{
    public class ResponseCookingStageList
    {
        public ResponseCookingStageList()
        {
        }

        public string RecipeName { get; set; }
        public int ServingsCount { get; set; }
        public bool IsInProgress { get; set; }
        public ResponseCookingStage[] CookingStages { get; set; }
    }
}
