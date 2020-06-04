using CiResultAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Services
{
    public interface ITrxResultsDbRepository
    {
        //Result section
        IEnumerable<Result> GetResults();
        IEnumerable<Result> GetResults(IEnumerable<int> resultsIds);
        Result GetResult(int resultId);
        void AddResult(Result result);
        void UpdateResult(Result result);
        void DeleteResult(Result result);
        bool ResultExist(int resultId);
        //Feature section
        IEnumerable<Feature> GetFeatures();
        IEnumerable<Feature> GetFeatures(IEnumerable<int> featuresIds);
        Feature GetFeature(int featureId);
        void AddFeature(Feature feature);
        void UpdateFeature(Feature feature);
        void DeleteFeature(Feature feature);
        //ErrorImage section
        IEnumerable<ErrorImage> GetErrorImages();
        IEnumerable<ErrorImage> GetErrorImages(IEnumerable<int> errorImagesIds);
        IEnumerable<ErrorImage> GetErrorImages(int resultId);
        ErrorImage GetErrorImage(int errorImageId);
        void AddErrorImage(int resultId, ErrorImage errorImage);
        void UpdateErrorImage(ErrorImage errorImage);
        void DeleteErrorImage(ErrorImage errorImage);
        //CIExecution section
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
