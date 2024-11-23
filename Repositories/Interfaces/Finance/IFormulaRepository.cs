using Data.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Finance
{
    public interface IFormulaRepository
    {
        Task AddFormulaAsync(Formula input);
        void UpdateFormula(Formula input);
        void DeleteFormula(Formula input);
        Task<IEnumerable<Formula>> GetAllFormulasAsync(int quotationId);
    }
}
