using Chinese_Zodiac.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chinese_Zodiac.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    
    public int Year {get; set;}
    public void OnGet()
    {
        ViewData["Zodiac"] = "";
        ViewData["Image"] = "";
    }

    public void OnPost(Util zodiacYear)
    {
        if (Year < 1900 || Year > DateTime.Now.Year + 1){
            ViewData["Zodiac"] = "Invalid Year";
        } else {
            ViewData["Zodiac"] = zodiacYear.GetZodiac();
        ViewData["Image"] = "../images/" + zodiacYear.GetZodiac().ToLower() + ".png";
        }
        
    }
}
