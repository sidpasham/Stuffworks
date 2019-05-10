using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace StuffWorks.Models
{
    public class Stuffer
    {
        public List<string> liststufferservices;
        public string ordersplaced;
        
    }
    public class User
    {
        public List<string> listuserorders;
        public int userordernumber;
    }
    public class Admin
    {
        public DataTable dtstuffers;
        public DataTable dtusers;
        public DataTable dtservices;
        
    }
}