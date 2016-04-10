using System.Threading.Tasks;
using dx.misv.donations.data;

namespace dx.misv.donations.web.Services
{
    public interface IDonationPredictionService
    {
        Task<DonationPredictionResponse> InvokeRequestResponseService(Donater donater);
    }
}