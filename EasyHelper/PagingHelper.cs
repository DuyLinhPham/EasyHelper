using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHelper
{
    /// <summary>
    /// It supports for paging data
    /// </summary>
    public class PagingHelper<T> where T : class
    {
        public IList<T> Collections { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }

        /// <summary>
        /// Set to true to paging / false to stop paging
        /// </summary>
        public virtual bool IsPaging
        {
            set
            {
                if (value)
                {
                    InitPaging();
                }
                else
                {
                    Dispose();
                }
            }
        }

        public PagingHelper(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
            Collections = new List<T>();
        }

        public virtual void Dispose()
        {
            Page = PageSize = TotalPage = 0;
            Collections.Clear();
        }

        /// <summary>
        /// Initial paging data
        /// </summary>
        private void InitPaging()
        {
            if (Collections != null)
            {
                TotalPage = (int)Math.Ceiling(Collections.Count() / (float)PageSize);
                Total = Collections.Count;
                Collections = Collections.Skip(PageSize * (Page - 1)).Take(PageSize).ToList();
            }
        }
    }
}
