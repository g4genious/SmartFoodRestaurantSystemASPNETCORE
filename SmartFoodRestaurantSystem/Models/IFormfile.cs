namespace SmartFoodRestaurantSystem.Models
{
    public interface IFormfile
    {
        string FileName { get; }

        object CopyTo(System.IO.FileStream fileStream);
    }
}