using System;
using System.Collections.Generic;
using System.Linq;

namespace PagedResult.Link
{
    /// <summary>
    /// A class that holds the current page results and the metadata about the page
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResult<T>
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="entity">The complete result set</param>
        /// <param name="pageNumber">The current page number for the <see cref="Result"/></param>
        /// <param name="pageSize">The size of the page</param>
        public PagedResult ( IEnumerable<T> entity, int pageNumber, int pageSize )
        {
            TotalCount = entity.Count ( ) ;
            PageNumber = pageNumber ;
            PageSize   = pageSize ;
            Result     = entity.Skip ( (pageNumber - 1) * PageSize ).Take ( PageSize ) ;

            NumberOfPages = (int) Math.Ceiling (((decimal) TotalCount/ PageSize)) ;
        }

        /// <summary>
        /// Gets the current page result
        /// </summary>
        public virtual IEnumerable<T> Result
        {
            get; private set;
        }

        /// <summary>
        /// Gets the total count of the result
        /// </summary>
        public virtual int TotalCount
        {
            get; private set;
        }

        /// <summary>
        /// Gets the page size
        /// </summary>
        public virtual int PageSize
        {
            get; private set;
        }

        /// <summary>
        /// Gets the current page number returned in the <see cref="Result"/>
        /// </summary>
        public virtual int PageNumber
        {
            get; private set;
        }

        /// <summary>
        /// Gets the complete number of pages availabile.
        /// </summary>
        public virtual int NumberOfPages
        {
            get; private set;
        }
    }


    public static class PagedResultExtension
    {
        /// <summary>
        /// Returns a new instance of <see cref="PagedResult{T}"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The complete result set</param>
        /// <param name="pageNumber">The current page number for the <see cref="Result"/></param>
        /// <param name="pageSize">The size of the page</param>
        /// <returns></returns>
        public static PagedResult<T> ToPagedResult<T> ( this IEnumerable<T> result, int pageNumber, int pageSize )
        {
            return new PagedResult<T> ( result, pageNumber, pageSize ) ;
        }
    }

}
