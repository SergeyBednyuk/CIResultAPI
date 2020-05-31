using CiResultAPI.Models;
using CiResultAPI.Models.DbContexts;
using CiResultAPI.Models.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.SupportClasses
{
    public class TfsManager
    {
        public List<Feature> Features { get; set; }

        private IConfiguration _appConfiguration { get; set; }
        private Uri _uriTo05Tfs;
        private TrxResultsContext _db;

        public TfsManager()
        {
        //    var builder = new ConfigurationBuilder()
        //      .AddXmlFile("config.xml");
        //    _appConfiguration = builder.Build();

        //    _uriTo05Tfs = new Uri(_appConfiguration["TfsUrl"]);
        //    Features = GetFeaturesInfo();

        //    _db
        }

        private List<Feature> GetFeaturesInfo()
        {
            List<Feature> featuresList = new List<Feature>();
        //    IEnumerable<Feature> features;

        //    features = _db.Features.ToList();


        //    var tfsProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(_uriTo05Tfs);
        //    WorkItemStore workItemStore = new WorkItemStore(tfsProjectCollection);

        //    WorkItemCollection itemsCollection = workItemStore.Query(@" SELECT * 
        //                                                                FROM WorkItems 
        //                                                                WHERE [System.TeamProject] = 'Development'
        //                                                                AND [System.WorkItemType] = 'TestSuite'
        //                                                                AND [Continuous Integration] = 'Integrated'");

        //    if (features.Count() > 0)
        //    {
        //        foreach (WorkItem item in itemsCollection)
        //        {
        //            string nameOfFeature = item.Fields["Feature Number"].Value + "-" + item.Fields["Feature Name"].Value;
        //            if (features.Where(f => f.Name == nameOfFeature).Count() == 0)
        //            {
        //                featuresList.Add(new Feature() { Name = nameOfFeature });
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (WorkItem item in itemsCollection)
        //        {
        //            featuresList.Add(new Feature() { Name = item.Fields["Feature Number"].Value + "-" + item.Fields["Feature Name"].Value });
        //        }
        //    }


            return featuresList;
        }
    }
}
