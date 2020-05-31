using CiResultAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Services
{
    public interface ITrxResultsDbRepository
    {
        Result GetResult(int resultId);
        IEnumerable<Result> GetResults();
        IEnumerable<Result> GetResults(IEnumerable<int> resultsIds);
        void AddResult(Result result, int featureId, int errorImageId, int ciExecutionId);
        void UpdateResult(Result result);
        void DeleteResult(Result result);
        //
        IEnumerable<Feature> GetFeatures();
        Feature GetFeature(int featureId);
        void AddFeature(Feature feature);
        void UpdateFeature(Feature feature);
        void DeleteFeature(Feature feature);
        //
        IEnumerable<ErrorImage> GetErrorImages();
        ErrorImage GetErrorImage(int errorImageId);
        void AddErrorImage(ErrorImage errorImage);
        void UpdateErrorImage(ErrorImage errorImage);
        void DeleteErrorImage(ErrorImage errorImage);
        //
        IEnumerable<CIExecution> GetCIExecutions();
        CIExecution GetCIExecution(int ciExecutionId);
        void AddCIExecution(CIExecution ciExecution);
        void UpdateCIExecution(CIExecution ciExecution);
        void DeleteCIExecution(CIExecution ciExecution);
        //
        bool Save();
    }
}
