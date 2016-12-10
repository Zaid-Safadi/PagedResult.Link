using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedResult.Link;

namespace ApiPagination
{
    /// <summary>
    /// An implemntation example for creating a paged data back to your controller. You can replace this with your own service implemntation.
    /// </summary>
    public class DataService
    {
        static DataService ( ) 
        {
            _DummyData = new List<AppEntity> ( ) ;

            for ( int i = 0; i < 100; i++ ) 
            {
                _DummyData.Add ( new AppEntity ( ) ) ;
            }
        }

        public DataService  ( ) 
        {
        }
        
        public PagedResult<AppEntity> GetAllEntities ( int? page, int? pgSize )
        {
            int pageNumber = Math.Max ( 1, GetInt ( page, 1 ) ) ;
            int pageSize   = Math.Max ( 1, GetInt ( pgSize, 10 ) ) ;

            return _DummyData.ToPagedResult ( pageNumber, pageSize ) ;
        }

        private int GetInt ( int? value, int defaultValue )
        {
            if ( null != value && value.HasValue ) { return value.Value ; }

            return defaultValue ;
        }

        private static List<AppEntity> _DummyData ;
    }
}
