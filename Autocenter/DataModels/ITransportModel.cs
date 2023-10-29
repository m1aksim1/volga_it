using DataModels.Enums;
using DataModels.HelperInterfaces;

namespace DataModels
{
	public interface ITransportModel : IId
	{
        bool CanBeRented { get; }
        TypeTransport TypeTransport { get; }
		string Model { get; }
		string Color { get; }
		string identifier { get; }
		string description { get; }
		double latitude { get; }
		double longitude { get; }
        double minutePrice { get; }
		double dayPrice { get; }
	}
}