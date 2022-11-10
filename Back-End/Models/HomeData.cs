namespace Back_End.Models
{
    public class HomeData
    {
        public Header header { get; set; }
        public Footer footer { get; set; }

        public HomeData() {
            this.header = new Header();
            this.footer = new Footer();
        }
    }
}
