using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MAB;

namespace MABTests
{
    class FakeListrunRepository : IBanditRepo<FakeListrun>
    {
        private int _listrunId = -1;

        public FakeListrunRepository(int listrunId)
        {
            this._listrunId = listrunId;
        }

        public IAlternative[] Alternatives
        {
            get { 
                return new FakeListrun[3] { 
                    new FakeListrun() { Id = 1000, Subject = "First fake listrun" },
                    new FakeListrun() { Id = 1001, Subject = "Second fake listrun" },
                    new FakeListrun() { Id = 1002, Subject = "Third fake listrun" }
                };
            }
        }
    }

    class FakeListrun : AbstractAlternative
    {
        public int Id { get; set; }
        public string Subject { get; set; }
    }
}
