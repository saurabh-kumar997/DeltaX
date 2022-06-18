using Deltax.Entities;
using Deltax.Models;

namespace Deltax.Services;


public interface IMasterServices
{
    IEnumerable<IGrouping<string, MasterDTO>> GetMasterAsync();
}
public class MasterServices : IMasterServices
{
    private readonly DeltaDBContext _context;
    public MasterServices(DeltaDBContext context)
    {
        _context = context;
    }

    public IEnumerable<IGrouping<string, MasterDTO>> GetMasterAsync()
    {
        var masterData = _context.Masters.Select(x => new MasterDTO()
        {
            mId = x.MasterId,
            mName = x.MasterName,
            mType = x.MasterType
        }).ToList();

        return masterData.GroupBy(group => group.mType);
    }

}