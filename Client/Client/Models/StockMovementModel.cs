namespace Client.Models
{
    public class StockMovementModel
    {
        public int Id { get; set; }
        public DateTime dateOfMovement { get; set; }
        public int itemID { get; set; }
        public ItemModel item { get; set; }
        public string mailUser { get; set; }
        public int movementTypeID { get; set; }
        public MovementTypeModel movementType { get; set; }
        public int amount { get; set; }

       
    }
}
