using CiResultAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.SupportClasses.Extensions
{
    public class CiExecutionComparerExtension : IEqualityComparer<CIExecution>
    {
        public bool Equals(CIExecution x, CIExecution y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the CIExecution's properties are equal.
            return x.Path == y.Path;
        }

        public int GetHashCode(CIExecution obj)
        {
            throw new NotImplementedException();
        }
    }
}
