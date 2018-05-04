using System.Collections.Generic;
using DtsApi.Exhibitors.Model;

namespace DtsApi.Exhibitors.Database
{
    public interface IExhibitorsRepository
    {
        List<Exhibitor> GetExhibitors();
        void AddExhibitor(Exhibitor exhibitor);
        bool UpdateExhibitor(Exhibitor newExhibitor);
        bool DeleteExhibitor(int id);
    }
}