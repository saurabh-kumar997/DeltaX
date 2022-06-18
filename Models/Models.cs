namespace Deltax.Models;

public class ResponseStatus<T>
{
    public BussinessStatus Status { get; set; }
    public string? ResponseMessage { get; set; }
    public T? Data { get; set; }
}
public partial class MasterDTO
{
    public int mId { get; set; }
    public string mName { get; set; } = null!;
    public string mType { get; set; } = null!;
}

public partial class ActorDTO
{
    public ActorDTO()
    {
        MovieDetails = new HashSet<MovieDetailDTO>();
    }

    public string ActorName { get; set; } = null!;
    public string Bio { get; set; } = null!;
    public DateTime? DateOfBirth { get; set; }
    public int? Gender { get; set; }

    public virtual ICollection<MovieDetailDTO> MovieDetails { get; set; }
}

public partial class MovieDTO
{
    public MovieDTO()
    {
        MovieDetails = new HashSet<MovieDetailDTO>();
    }

    public int MovieId { get; set; }
    public string MovieName { get; set; } = null!;
    public string? Plot { get; set; }
    public string Poster { get; set; } = null!;
    public DateTime? ReleaseDate { get; set; }
    public int ProducerId { get; set; }

    public virtual ProducerDTO Producer { get; set; } = null!;
    public virtual ICollection<MovieDetailDTO> MovieDetails { get; set; }
}

public partial class MovieDetailDTO
{
    public int MovieId { get; set; }
    public int ActorId { get; set; }

    public virtual ActorDTO Actor { get; set; } = null!;
    public virtual MovieDTO Movie { get; set; } = null!;
}

public partial class ProducerDTO
{
    public ProducerDTO()
    {
        Movies = new HashSet<MovieDTO>();
    }
    public string ProducerName { get; set; } = null!;
    public string Bio { get; set; } = null!;
    public DateTime? DateOfBirth { get; set; }
    public int? Gender { get; set; }
    public string Comapny { get; set; } = null!;

    public virtual ICollection<MovieDTO> Movies { get; set; }
}

public class ActorData
{
    public int MovieId { get; set; }
    public int Id { get; set; }
    public string ActorName { get; set; }
}

public class MovieData
{
    public ActorData ActorsData { get; set; }
    public MovieDTO Movie { get; set; }
}