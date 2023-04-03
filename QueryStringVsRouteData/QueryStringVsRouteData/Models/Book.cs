using Microsoft.AspNetCore.Mvc;

namespace QueryStringVsRouteData.Models
{
    public class Book
    {
        //[FromQuery]//To feth the value from only Query String for "BookId" not for "Author". Normal priority applys for "Author"
        public int? BookId { get; set; }//"BookId" is not case sensitive during model binding
        public string? Author { get; set; }
        public override string ToString()
        {
            return $"Book object - Book id: {BookId}, Author: {Author}";
        }
    }
}
