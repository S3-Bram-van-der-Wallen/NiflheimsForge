using System.ComponentModel.DataAnnotations;

namespace NiflheimsForge.DTOs
{
    public class MonsterFilterDTO
    {
        public string? MonsterName { get; set; }
        public int? CR { get; set; }
        private string _sortOrder = "asc";
        public string SortOrder
        {
            get { return _sortOrder; }
            set { _sortOrder = string.IsNullOrEmpty(value) ? "asc" : value; }
        }
    }
}
