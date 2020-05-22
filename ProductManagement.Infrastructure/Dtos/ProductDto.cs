namespace ProductManagement.Infrastructure.Dtos
{
    public class ProductDto
    {
        public string Number{ get;}
        public string Name{ get; }
        public int Quantity{ get;}

        public ProductDto(string number, string name, int quantity)
        {
            Number = number;
            Name = name;
            Quantity = quantity;
        }
    }
}
