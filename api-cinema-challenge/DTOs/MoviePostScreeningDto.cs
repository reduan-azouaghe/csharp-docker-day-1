namespace api_cinema_challenge.DTOs;

public class MoviePostScreeningDto
{
    public int ScreenNumber { get; set; }
    
    public int Capacity { get; set; }
    
    public DateTime StartsAt { get; set; }
}