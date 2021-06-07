namespace Biblioteka
{
    public partial class Prolongata
    {
        /// <summary>
        /// Informacja, czy prolongata została zaakceptowana.
        /// </summary>
        public bool Accepted => Status.HasValue && Status.Value == 1;
    }
}