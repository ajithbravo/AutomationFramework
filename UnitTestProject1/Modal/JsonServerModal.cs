using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Modal
{
    public class Post
    {
        public string id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
    }

    public class Comment
    {
        public int id { get; set; }
        public string body { get; set; }
        public int postId { get; set; }
    }

    public class Profile
    {
        public string name { get; set; }
        public string postId { get; set; }
    }

    public class Primary
    {
        public string city { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int PinCode { get; set; }
    }

    public class Secondary
    {
        public string city { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int PinCode { get; set; }
    }

    public class Address
    {
        public List<Primary> primary { get; set; }
        public List<Secondary> secondary { get; set; }
    }

    public class JsonServerModal
    {
        public List<Post> posts { get; set; }
        public List<Comment> comments { get; set; }
        public Profile profile { get; set; }
        public Address address { get; set; }
    }
}
