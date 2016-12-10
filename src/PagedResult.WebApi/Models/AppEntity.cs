namespace ApiPagination
{
    public class AppEntity
    {
        private static int _Counter = 0 ;
        private int _idNumber ;
        public AppEntity ( )
        {
            _Counter ++ ;

            _idNumber = _Counter ;
        }

        public string Id
        {
            get 
            {
                return "Value #" + _idNumber ;
            }
        }
    }
}