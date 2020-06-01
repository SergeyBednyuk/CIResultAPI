using CiResultAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Services
{
    public interface ITrxResultsDbRepository
    {
        IEnumerable<Result> GetResults();
        IEnumerable<Result> GetResults(IEnumerable<int> resultsIds);
        Result GetResult(int resultId);
        void AddResult(Result result);
        void UpdateResult(Result result);
        void DeleteResult(Result result);
        //
        IEnumerable<Feature> GetFeatures();
        IEnumerable<Feature> GetFeatures(IEnumerable<int> featuresIds);
        Feature GetFeature(int featureId);
        void AddFeature(Feature feature);
        void UpdateFeature(Feature feature);
        void DeleteFeature(Feature feature);
        //
        IEnumerable<ErrorImage> GetErrorImages();
        IEnumerable<ErrorImage> GetErrorImages(IEnumerable<int> errorImagesIds);
        ErrorImage GetErrorImage(int errorImageId);
        void AddErrorImage(ErrorImage errorImage);
        void UpdateErrorImage(ErrorImage errorImage);
        void DeleteErrorImage(ErrorImage errorImage);
        //
        IEnumerable<CIExecution> GetCIExecutions();
        IEnumerable<CIExecution> GetCIExecutions(IEnumerable<int> ciExecutionsIds);
        CIExecution GetCIExecution(int ciExecutionId);
        void AddCIExecution(CIExecution ciExecution);
        void UpdateCIExecution(CIExecution ciExecution);
        void DeleteCIExecution(CIExecution ciExecution);
        //
        bool Save();
    }
}
