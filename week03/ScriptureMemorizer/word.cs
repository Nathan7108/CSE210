namespace ScriptureMemorizer
{
    class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public bool IsHidden => _isHidden;

        public void Hide()
        {
            _isHidden = true;
        }

        public override string ToString()
        {
            if (_isHidden)
                return new string('_', _text.Length);
            return _text;
        }
    }
}
