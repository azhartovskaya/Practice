namespace Task2.Classes
{
    public class Book : Item, ILendable
    {
        private bool _isAvailable;

        public Book(string title, Author author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            _isAvailable = true;
        }

        public Author Author { get; private set; }
        public int PublicationYear { get; private set; }

        public bool IsAvailable => _isAvailable;

        public void Lend()
        {
            if (_isAvailable)
                _isAvailable = false;
            else
                throw new InvalidOperationException(" нига уже вз€та напрокат.");
        }

        public void Return()
        {
            _isAvailable = true;
        }
    }
}
