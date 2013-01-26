using System;
using Csla;

namespace ParentLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DTO for E05_SubContinent_Child type
    /// </summary>
    public partial class E05_SubContinent_ChildDto
    {
        /// <summary>
        /// Gets or sets the parent Sub Continent ID.
        /// </summary>
        /// <value>The Sub Continent ID.</value>
        public int Parent_SubContinent_ID { get; set; }

        /// <summary>
        /// Gets or sets the 3_Countries Child Name.
        /// </summary>
        /// <value>The Sub Continent Child Name.</value>
        public string SubContinent_Child_Name { get; set; }

        /// <summary>
        /// Gets or sets the SubContinent ID1.
        /// </summary>
        /// <value>The Sub Continent ID1.</value>
        public int SubContinent_ID1 { get; set; }

        /// <summary>
        /// Gets or sets the Row Version.
        /// </summary>
        /// <value>The Row Version.</value>
        public byte[] RowVersion { get; set; }
    }
}
