using System;

namespace Core.Builder
{
    public class Director
    {
        private AbstractBuilder _builder;

        public AbstractBuilder Builder
        {
            set
            {
                if (value is AbstractBuilder)
                {
                    _builder = value;
                }
                else throw new Exception();
            }
        }

        public void Build()
        {
            _builder.Construct();
        }

        public Director(AbstractBuilder builder)
        {
            Builder = builder;
        }
    }
}
