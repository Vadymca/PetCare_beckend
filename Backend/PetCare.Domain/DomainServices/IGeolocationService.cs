using NetTopologySuite.Geometries;

namespace PetCare.Domain.DomainServices
{
    // Інтерфейс для перетворення між адресою та геолокацією.
    public interface IGeolocationService
    {
        // Отримати координати (точку) за адресою.
        Task<Point?> GetCoordinatesFromAddressAsync(string address);

        // Отримати текстову адресу за географічною точкою.
        Task<string?> GetAddressFromCoordinatesAsync(Point location);
    }
}
