using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PagedResult.Link;

namespace ApiPagination.Controllers
{
    [Route("api/[controller]")]
    public class PagedResultController : Controller
    {
        private DataService _dataService ;

        public PagedResultController ( ) 
        {
            _dataService = new DataService ( ) ;
        }


        // GET api/PagingExample
        [HttpGet]
        public IEnumerable<AppEntity> Get( int? page, int? pgSize )
        {

            LinkHeaderBuilder linkBuilder = new LinkHeaderBuilder (  ) ;

            var entities    = _dataService.GetAllEntities ( page, pgSize ) ;
            var request     = Url.ActionContext.HttpContext.Request ;
            var uriBuilder  = new UriBuilder ( request.Scheme, 
                                               request.Host.ToUriComponent( ) ) {  Path = Url.Action ( ) } ;


            Response.Headers.Add ( "link", linkBuilder.GetLinkHeader ( entities, uriBuilder.ToString() ) ) ;
            
            return entities.Result ;
        }
    }
}
