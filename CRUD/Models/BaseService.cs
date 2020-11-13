using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace CRUD.Models
{
    public class BaseService
    {
        protected string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["CRUD_DB"].ConnectionString;
            }
        }

        protected int StringToInt(string value)
        {
            try
            {
                return int.Parse(value);
            }
            catch(Exception exp)
            {
                return 0;
            }
        }
    }
}