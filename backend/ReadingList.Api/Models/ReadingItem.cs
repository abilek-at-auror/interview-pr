namespace ReadingListApi.Models
{
    public class ReadingItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool IsRead { get; set; }
    }
}
