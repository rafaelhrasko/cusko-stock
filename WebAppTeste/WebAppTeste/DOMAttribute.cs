namespace DOMSharp
{
    public class DOMAttribute
    {
        private string _name;

        public string Name
        {
            get { return _name; }
        }

        private string _value;

        public string Value
        {
            get { return _value; }
        }

        public DOMAttribute(string name_,string value_)
        {
            this._name = name_;
            this._value = value_;
        }
    }
}