using System.Text.Json.Serialization;

namespace TheTableBackend.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MealType
    {
        Appetizer = 1,
        MainCourse = 2,
        Dessert = 3
    }
}
