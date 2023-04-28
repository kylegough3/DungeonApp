namespace DungeonLibrary
{
    //abstract marks a Class as "incomplete". It must be inherited somewhere to be used.
    //abstract classes cannot be created as an object using the new() keyword. 
    public abstract class Character
    {
        /*
         * Create Fields and Properties for each of the following attributes
         *  life – int

            name – string

            hitChance – int

            block – int

            maxLife – int

        INCLUDE a business rule that Life cannot be more than MaxLife. If it is, set it equal to MaxLife.
         */

        //frugal people collect money
        //FIELDS
        private string _name;
        private int _hitChance;
        private int _block;
        private int _maxLife;
        private int _life;
        

        //PROPERTIES
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }
        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        public int Life
        {
            get { return _life; }
            set
            {
                if (value > MaxLife)
                {
                    _life = MaxLife;
                }
                else
                {
                    _life = value;
                }
            }
        }


        //CONSTRUCTORS - Life = life; -> Life = maxLife
        //No matter what, assign MaxLife BEFORE Life.

            public Character(string name,  int hitChance, int block, int maxLife)
        {//Fully Qualified
            Name = name;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = maxLife;

        }//end Fully Qualified
        public Character()
        { //Unqualified
        }//end Unqualified


        //METHODS
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Life: {Life} / {MaxLife}\n" +
                $"Hit Chance: {HitChance}%\n" +
                $"Block: {Block}%";
                
        }
        public virtual int CalcBlock() { return Block; }

        public virtual int CalcHitChance() { return HitChance; }

        public abstract int CalcDamage();

        //an abstract method will have no functionality, no scopes. It makes override MANDATORY.

    }//end class
}//end namespace