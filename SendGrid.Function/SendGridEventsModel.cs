using Newtonsoft.Json;
using System.Collections.Generic;

namespace SendGrid.Function
{
    public class SendGridEventsModel
    {
        public string email { get; set; }
        public int timestamp { get; set; }
        public int uid { get; set; }
        public int id { get; set; }
        public string sendgrid_event_id { get; set; }
        [JsonProperty("smtp-id")] // switched to underscore for consistancy
        public string smtp_id { get; set; }
        public string sg_message_id { get; set; }
        [JsonProperty("event")] // event is protected keyword
        public string sendgrid_event { get; set; }
        public string type { get; set; }
        public IList<string> category { get; set; }
        public string reason { get; set; }
        public string status { get; set; }
        public string url { get; set; }
        public string useragent { get; set; }
        public string ip { get; set; }
    }
}
