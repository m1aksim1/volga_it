using DataModels.Enums;
using DataModels.HelperInterfaces;

namespace DataModels
{
	public interface ITransportModel : IId
	{
		long OwnerId { get; }
        bool CanBeRented { get; }
        TypeTransport TypeTransport { get; }
		string Model { get; }
		string Color { get; }
		string Identifier { get; }
		string Description { get; }
		double Latitude { get; }
		double Longitude { get; }
        double MinutePrice { get; }
		double DayPrice { get; }
	}
}