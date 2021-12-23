namespace NyamNyamMobileApp.Models.ResponseModels
{
    public class ResponseOrder
    {
        public ResponseOrder()
        {
        }

        public int Id { get; set; }
        public string CustomerFullName { get; set; }
        public string Dishes { get; set; }
        public string AppointmentDate { get; set; }
        public string TotalCost { get; set; }
        public string Status { get; set; }
        public bool IsEnoughIngredients { get; set; }
        public ResponseDish[] DishesList { get; set; }
    }
}
