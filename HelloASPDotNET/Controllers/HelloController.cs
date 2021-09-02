using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloASPDotNET.Controllers
{
    [Route("/helloworld")] //designate that every path for each action method needs to start with /helloworld.
    public class HelloController : Controller
    {
        // GET: /<controller>/
        //[Route("/helloworld")]
        [HttpGet] //attribute
        public IActionResult Index()
        {
            string html =
                "<form method='post' action='/helloworld/welcome'>" + //send data to hello/welcome path
                "<input type='text' name='name' />" + //given text input same name as argument of the Welcome() method, which happens to be name.
                "<select name='language'/>" + //provide menu option for user to select different language
                    "<option value='English'>" + "English" + "</option>" +
                    "<option value='French'>" + "French" + "</option>" +
                    "<option value='Portugese'>" + "Portugese" + "</option>" +
                    "<option value='Spanish'>" + "Spanish" + "</option>" +
                    "<option value='German'>" + "German" + "</option>" +  
                "<input type='submit' value='Greet Me!' />" +
                "</form>";

            return Content(html, "text/html");

        }
      

        // GET: /<controller>/welcome?name=value or GET: /<controller>/welcome/name
        // POST: /<controller>/welcome

        //[HttpGet("welcome/{name?}")] //Welcome() also respond to GET Request

        [HttpPost("welcome")] //attribute include end path. Welcome() will respond to POST requests at localhost:5001/helloworld/welcome
        public IActionResult Welcome(string name = "World", string language = "Hello") //method handles submission
        {
            return Content(CreateMessage(name,language), "text/html");
        }

        public static string CreateMessage(string name, string language)
        {
           
            string displayMessage;
            if (language == "French")
            {
               displayMessage =  "<h1 style='color:pink; font-size:300%; text-align: center;'> Bonjour " + name + "!</h1>";

            } else if (language == "Portugese")
            {
                displayMessage = "<h1 style='color:pink; font-size:300%; text-align: center;' > Ola " + name + "!</h1>";

            } else if (language == "German")
            {
                displayMessage = "<h1 style='color:pink; font-size:300%; text-align: center;' > Hallo " + name + "!</h1>";

            } else if (language == "Spanish")
            {
                displayMessage = "<h1 style='color:pink; font-size:300%; text-align: center;' > Hola " + name + "!</h1>";

            } else
            {
                displayMessage = "<h1 style='color:pink; font-size:300%; text-align: center;' >Hello " + name + "!</h1>";
            }
                return displayMessage;

        }
    }
}
