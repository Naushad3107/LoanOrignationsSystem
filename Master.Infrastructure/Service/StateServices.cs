using AutoMapper;
using LOSApplicationApi.Data;
using LOSApplicationApi.Repository;

namespace LOSApplicationApi.Service
{
    public class StateServices: IStates
    {
        ApplicationDbContext db;
        IMapper mapper;

        public StateServices(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddState(DTO.AddStateDTO state)
        {
            var details = mapper.Map<Model.States>(state);
            db.State.Add(details);
            db.SaveChanges();
        }

        public List<DTO.FetchStateDTO> FetchStates()
        {
            var details = db.State.Where(x => x.IsActive == 1 && x.IsDeleted == 0).ToList();
            var mappedDetails = mapper.Map<List<DTO.FetchStateDTO>>(details);
            return mappedDetails;
        }

        public DTO.FetchStateDTO FetchStateById(int id)
        {
            var data = db.State.FirstOrDefault(s => s.StateId == id && s.IsActive == 1 && s.IsDeleted == 0);
            if (data != null)
            {
                var mappedData = mapper.Map<DTO.FetchStateDTO>(data);
                return mappedData;
            }
            return null; // Return null if no state found
        }

        public void UpdateState(DTO.UpdateStatesDTO state)
        {
            var data = db.State.FirstOrDefault(s => s.StateId == state.StateId && s.IsActive == 1 && s.IsDeleted == 0);
            if (data != null)
            {
                var updatedData = mapper.Map(state, data);
                db.State.Update(updatedData);
                db.SaveChanges();
            }
        }

        public void DeleteState(int id)
        {
            var data = db.State.FirstOrDefault(s => s.StateId == id && s.IsActive == 1 && s.IsDeleted == 0);
            if (data != null)
            {
                data.IsDeleted = 1; // Assuming IsDeleted is a flag to mark deletion
                db.SaveChanges();
            }
        }

    }
}
