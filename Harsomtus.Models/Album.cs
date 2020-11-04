
namespace Harsomtus.Models
{
    public class Album : BaseModel
    {
        public Artist Artist { get; set; }
        public string Title { get; set; }
        public AlbumYear Year { get; set; }
        public int CoverId { get; set; }
        public string CoverImage { get; set; }
    }
}
