namespace Client.Models
{
    public class SummaryModel
    {
        public int? year { get; set; }
        public int? amount { get; set; }
        public List<TypeAndAmountModel>? movements { get; set; }
    }

    public class TypeAndAmountModel
    {
        public string typeName { get; set; }
        public int amount { get; set; }
    }

}

