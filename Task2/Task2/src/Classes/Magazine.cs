namespace Task2.Classes
{
    public class Magazine : Item, ILendable
    {
        private bool _isAvailable;

        public Magazine(string title, int publicationYear)
        {
            Title = title;
            PublicationYear = publicationYear;
            _isAvailable = true;
        }

        public bool IsAvailable => _isAvailable;

        public void Lend()
        {
            if (_isAvailable)
                _isAvailable = false;
            else
                throw new InvalidOperationException("Журнал уже сдан в аренду.");
        }

        public void Return()
        {
            _isAvailable = true;
        }
    }
}
