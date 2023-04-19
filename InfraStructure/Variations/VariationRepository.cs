using Application.Contracts.Variations;
using DbContextL;
using Domian;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Variations
{
    public class VariationRepository : Repository<Variation, int>, IVariationRepository
    {
        public VariationRepository(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Variation>> FilterByAsync(string? filter = null)
        {
            return _context.Variations
                .Where(a => filter == null ? true : a.Name.ToLower().Contains(filter.ToLower())).ToList();

        }
        public override async Task<Variation?> GetDetailsAsync(int id)
        {
            return _context.Variations.Where(a => a.Id == id).Include(a => a.VariationOptions).FirstOrDefault();
        }
    }
}
