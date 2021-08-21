namespace ShopService.Api.ShoppingCart.Remote.Model
{
    public class ResponseRemote
    {
        
        public bool Result { get; set; }
        public BookRemote BookRemote { get; set; }
        public string ErrorMessage { get; set; }
    }
}
