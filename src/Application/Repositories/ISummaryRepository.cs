using Domain;

namespace Application.Repositories
{
    public interface ISummaryRepository
    {
        IEnumerable<Summary> GetAllSummaries();
    }
}
