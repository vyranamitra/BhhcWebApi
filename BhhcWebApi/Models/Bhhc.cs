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
                Text = "Be a part of the Berkshire Hathaway family"
            });
            _reasons.Add(new Reason
            {
                Text = "Create innovative solutions that help users be more efficient and productive."
            });
            _reasons.Add(new Reason
            {
                Text = "Work, learn, advance."
            });

        }

        public void Dispose()
        {
            //release resources here
        }
    }
}