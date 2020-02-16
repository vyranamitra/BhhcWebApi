using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BhhcWebApi.Models
{
    public class Reason
    {
        public string Text { get; set; }
    }

    public class BhhcDBContext : IDisposable
    {
        private List<Reason> _reasons;
        public List<Reason> Reasons
        {
            get
            {
                return _reasons;
            }
            set
            {
                _reasons.Clear();
                _reasons.AddRange(value);
            }
        }

        public BhhcDBContext()
        {
            _reasons = new List<Reason>();
            _reasons.Add(new Reason
            {
                Text = "Reason 1"
            });
            _reasons.Add(new Reason
            {
                Text = "Reason 2"
            });
            _reasons.Add(new Reason
            {
                Text = "Reason 3"
            });

        }

        public void Dispose()
        {
            //release resources here
        }
    }
}