using DataModels.Enums;
using DataModels.HelperInterfaces;

namespace DataModels
{
	public interface ITransportModel : IId
	{
		string Name { get; }
		double RentCost { get; }
		TypeTransport TypeTransport { get; }
	}
}