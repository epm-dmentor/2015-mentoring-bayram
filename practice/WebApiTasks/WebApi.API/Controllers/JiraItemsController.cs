using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.API.Controllers
{
    public class JiraItemsController : ApiController
    {

        private static List<JiraItem> _jiraItems = new List<JiraItem>
        {
            new JiraItem {JiraItemId = 1, JiraNumber = 100, JiraSourceId = 1, RequestIdType = 3},
            new JiraItem {JiraItemId = 2, JiraNumber = 100, JiraSourceId = 1, RequestIdType = 3},
            new JiraItem {JiraItemId = 3, JiraNumber = 100, JiraSourceId = 1, RequestIdType = 3},
            new JiraItem {JiraItemId = 4, JiraNumber = 100, JiraSourceId = 1, RequestIdType = 3},
            new JiraItem {JiraItemId = 5, JiraNumber = 100, JiraSourceId = 1, RequestIdType = 3},
            new JiraItem {JiraItemId = 6, JiraNumber = 100, JiraSourceId = 1, RequestIdType = 3},

        };
        // GET api/jiraitems
        public IEnumerable<JiraItem> GetAll()
        {
            return _jiraItems;
        }

        // GET api/jiraitems/5
        public JiraItem Get(int id)
        {
            return _jiraItems.FirstOrDefault(x => x.JiraItemId == id);
        }

        // POST api/jiraitems
        public void Post([FromBody]JiraItem value)
        {
            _jiraItems.Add(value);
        }


        // PUT api/jiraitems/5
        public void Put(int id, [FromBody]JiraItem value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value");
            }
            int index = _jiraItems.FindIndex(p => p.JiraItemId == id);
            if (index == -1)
            {
                return;
            }
            _jiraItems.RemoveAt(index);
            _jiraItems.Add(value);
        }

        // DELETE api/jiraitems/5
        public void Delete(int id)
        {
            var item = _jiraItems.FirstOrDefault(x => x.JiraItemId == id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _jiraItems.Remove(item);
        }
    }
}
