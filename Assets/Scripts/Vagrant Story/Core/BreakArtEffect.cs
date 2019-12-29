namespace VagrantStory.Core
{
    public class BreakArtEffect
    {
        public enum Target { SELF, TARGET, VOID };
        public enum Type { MODIFIER, PERMA_MOD, ADD_STATUS, REMOVE_STATUS };
        public enum Mod { NULL, HP, MP, RISK, STR, INT, AGI };
        public enum Status { NULL, Poison, Paralysis, Numbness, Curse, Speed, Argon, Tarnish, ALL_DEBUFF };
        public static short Roll(uint v)
        {
            return (short)UnityEngine.Random.Range(1, v);
        }


        public Target target = Target.VOID;
        public Type type = Type.MODIFIER;
        public Mod mod = Mod.NULL;
        public Status status = Status.NULL;
        public short value;



        public BreakArtEffect(Target _target, Type _type, Mod _mod)
        {
            target = _target;
            type = _type;
            mod = _mod;
        }

        public BreakArtEffect(Target _target, Type _type, Mod _mod, short _value)
        {
            target = _target;
            type = _type;
            mod = _mod;
            value = _value;
        }

        public BreakArtEffect(Target _target, Type _type, Status _status)
        {
            target = _target;
            type = _type;
            status = _status;
        }
        public BreakArtEffect(Target _target, Type _type, Status _status, short _duration)
        {
            target = _target;
            type = _type;
            status = _status;
            value = _duration;
        }
    }
}