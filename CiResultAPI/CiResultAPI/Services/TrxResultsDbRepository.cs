using CiResultAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Services
{
    public class TrxResultsDbRepository : ITrxResultsDbRepository
    {
        private readonly ITrxResultsDbRepository _context;

        public TrxResultsDbRepository(ITrxResultsDbRepository context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddCIExecution(CIExecution ciExecution)
        {
            throw new NotImplementedException();
        }

        public void AddErrorImage(ErrorImage errorImage)
        {
            throw new NotImplementedException();
        }

        public void AddFeature(Feature feature)
        {
            throw new NotImplementedException();
        }

        public void AddResult(Result result, int featureId, int errorImageId, int ciExecutionId)
        {
            throw new NotImplementedException();
        }

        public void DeleteCIExecution(CIExecution ciExecution)
        {
            throw new NotImplementedException();
        }

        public void DeleteErrorImage(ErrorImage errorImage)
        {
            throw new NotImplementedException();
        }

        public void DeleteFeature(Feature feature)
        {
            throw new NotImplementedException();
        }

        public void DeleteResult(Result result)
        {
            throw new NotImplementedException();
        }

        public CIExecution GetCIExecution(int ciExecutionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CIExecution> GetCIExecutions()
        {
            throw new NotImplementedException();
        }

        public ErrorImage GetErrorImage(int errorImageId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ErrorImage> GetErrorImages()
        {
            throw new NotImplementedException();
        }

        public Feature GetFeature(int featureId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feature> GetFeatures()
        {
            throw new NotImplementedException();
        }

        public Result GetResult(int resultId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Result> GetResults()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Result> GetResults(IEnumerable<int> resultsIds)
        {
            throw new NotImplementedException();
        }

        public void UpdateCIExecution(CIExecution ciExecution)
        {
            throw new NotImplementedException();
        }
        public void UpdateErrorImage(ErrorImage errorImage)
        {
            throw new NotImplementedException();
        }

        public void UpdateFeature(Feature feature)
        {
            throw new NotImplementedException();
        }

        public void UpdateResult(Result result)
        {
            throw new NotImplementedException();
        } 
        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
