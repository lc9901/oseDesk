using System.Runtime.Serialization;
namespace Contract
{
    [DataContract]
    public class Pagination
    {
        /// <summary>
        /// Represents the total count of the list.
        /// </summary>
        [DataMember]
        private int totalCount;

        /// <summary>
        /// Represents the current page of the list.
        /// </summary>
        [DataMember]
        private int currentPage;

        /// <summary>
        /// Represents the colume name of the sort.
        /// </summary>
        [DataMember]
        private string sortColume;

        /// <summary>
        /// Represents the sort way of the list.
        /// </summary>
        [DataMember]
        private string sortWay;

        /// <summary>
        /// Repersents the exam status.
        /// </summary>
        [DataMember]
        public string ExamStatus { set; get; }

        /// <summary>
        /// Repersents the page size.
        /// </summary>
        [DataMember]
        public int PageSize { set; get; }

        /// <summary>
        /// Represents the current page of the list.
        /// </summary>
        [DataMember]
        public int CurrentPage
        {
            set
            {
                this.currentPage = value;
            }
            get
            {
                if (this.currentPage < 1)
                {
                    this.currentPage = 1;
                }

                if (this.currentPage > PageCount)
                {
                    this.currentPage = PageCount;
                }
                return this.currentPage;
            }
        }

        /// <summary>
        /// Represents the total count of list.
        /// </summary>
        [DataMember]
        public int TotalCount
        {
            set
            {
                this.totalCount = value;
            }
            get
            {
                if (this.totalCount < 1)
                {
                    this.totalCount = 1;
                    return 1;
                }
                else
                {
                    return this.totalCount;
                }
            }
        }

        /// <summary>
        /// Repersents the page count of hte list.
        /// </summary>
        [DataMember]
        public int PageCount
        {
            set
            {
                // Nothing to do.
            }
            get
            {
                return (TotalCount - 1) / PageSize + 1;
            }
        }

        /// <summary>
        /// Represents the colume name of the sort.
        /// </summary>
        [DataMember]
        public string SortColume
        {
            set
            {
                this.sortColume = value + Constants.Blank;
            }
            get
            {
                return this.sortColume;
            }
        }

        /// <summary>
        /// Represents the sort way of the list.
        /// </summary>
        [DataMember]
        public string SortWay
        {
            set
            {
                this.sortWay = value;
            }
            get
            {
                return this.sortWay;
            }
        }
    }
}