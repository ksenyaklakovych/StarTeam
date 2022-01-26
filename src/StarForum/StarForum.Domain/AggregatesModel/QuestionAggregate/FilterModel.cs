namespace StarForum.Application.Models
{
    public class FilterModel
    {
        public string OrderOption { get; set; }
        public string Tags { get; set; }

        public FilterModel(string orderOption, string tags)
        {
            OrderOption = orderOption;
            Tags = tags;
        }
    }
}
