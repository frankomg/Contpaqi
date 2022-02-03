using System.Collections.Generic;

namespace Models
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Dato
    {
        public string fecha { get; set; }
        public string dato { get; set; }
    }

    public class Series
    {
        public List<Dato> datos { get; set; }
    }

    public class Bmx
    {
        public List<Series> series { get; set; }
    }

    public class Banxico
    {
        public Bmx bmx { get; set; }
    }

}
