using Stories.Data.Entities;
using Stories.Data.Queries.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Queries
{
    public class StoryQuery : IStoryQuery
    {
        /// <summary>
        /// Getting Story
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Task<IDictionary<Guid, Story>> Get(Guid guid)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                return null;
            }
        }
    }
}
