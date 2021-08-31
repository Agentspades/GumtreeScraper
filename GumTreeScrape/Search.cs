using System.Collections.Generic;

namespace GumTreeScrape
{
    public class Search
    {
        private string _term;
        public string Term
        {
            get => _term;
            set => _term = value;
        }
        private int _refresh;
        public int Refresh
        {
            get => _refresh;
            set => _refresh = value;
        }
        private string _radius;
        public string Radius
        {
            get => _radius;
            set => _radius = value;
        }

        public override string ToString()
        {
            return $"{_term},{_refresh},{_radius}";
        }
    }

    public class SearchComparer : IComparer<Search>
    {
        public int Compare(Search s1, Search s2)
        {
            return s1.Term.CompareTo(s2.Term);
        }
    }
}
